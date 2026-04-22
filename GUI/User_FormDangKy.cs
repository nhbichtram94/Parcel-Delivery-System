using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MongoDB.Bson;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace GUI
{
    public partial class User_FormDangKy : Form
    {
        private readonly KhachHang_BLL khachHangService = new KhachHang_BLL();
        private readonly TaiKhoan_BLL tkService = new TaiKhoan_BLL();
        private List<TinhThanh> _provinces;

        public User_FormDangKy()
        {
            InitializeComponent();
            LoadJsonsData();
        }

        private void LoadJsonsData()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "provinces.open-api.vn.json");
                string json = File.ReadAllText(path);
                _provinces = JsonConvert.DeserializeObject<List<TinhThanh>>(json);

                cbo_tinh.DataSource = _provinces;
                cbo_tinh.DisplayMember = "name";
                cbo_tinh.ValueMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tỉnh/thành: " + ex.Message);
            }
        }

        private bool KiemTraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool KiemTraSoDienThoai(string sdt)
        {
            // SĐT phải 10 chữ số, bắt đầu bằng 0
            return Regex.IsMatch(sdt ?? "", @"^0\d{9}$");
        }

        private bool KiemTraMatKhau(string matKhau)
        {
            // ≥8 ký tự, ít nhất 1 hoa, 1 thường, 1 số, 1 ký tự đặc biệt, không dấu cách
            return Regex.IsMatch(matKhau ?? "", @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_])(?!.*\s).{8,}$");
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string nhapLaiMK = txt_NhapLaiMK.Text;
            string ten = txtTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            // 1️⃣ Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(matKhau) ||
                string.IsNullOrWhiteSpace(nhapLaiMK) ||
                string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(sdt) ||
                string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Kiểm tra mật khẩu
            // 2️⃣ KIỂM TRA MẬT KHẨU
            if (!KiemTraMatKhau(matKhau))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, gồm chữ hoa, chữ thường, số, ký tự đặc biệt và không chứa khoảng trắng!",
                    "Mật khẩu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (matKhau != nhapLaiMK)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi xác nhận mật khẩu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3️⃣ Kiểm tra số điện thoại
            if (!KiemTraSoDienThoai(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải gồm 10 chữ số và bắt đầu bằng 0.",
                    "Lỗi số điện thoại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4️⃣ Kiểm tra email (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(email) && !KiemTraEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5️⃣ Kiểm tra trùng tài khoản hoặc SDT
            bool tonTaiTaiKhoan = await tkService.KiemTraTonTaiTaiKhoanAsync(tenDangNhap);
            if (tonTaiTaiKhoan)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác.",
                    "Trùng tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool tonTaiSDT = await khachHangService.KiemTraTonTaiSDTAsync(sdt);
            if (tonTaiSDT)
            {
                MessageBox.Show("Số điện thoại này đã được sử dụng cho tài khoản khác!",
                    "Trùng số điện thoại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ 6️⃣ Tạo đối tượng người dùng mới
            var nguoiDung = new NguoiDung_DTO
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId(),
                TenDangNhap = tenDangNhap,
                MatKhauHash = matKhau, // Có thể hash SHA256 nếu cần
                PhanQuyen = "KhachHang",
                LoaiNguoiDung = "KhachHang",
                TrangThai = true,

                HoTen = ten,
                SoDienThoai = sdt,
                Email = email,
                DiaChiChiTiet = diaChi,
                TinhThanh = cbo_tinh.SelectedValue?.ToString(),
                QuanHuyen = cbo_quanhuyen.SelectedValue?.ToString(),
                PhuongXa = cbo_xaphuong.SelectedValue?.ToString(),

                NgayTao = DateTime.UtcNow,
                NgayCapNhatCuoi = DateTime.UtcNow
            };

            // 7️⃣ Gọi service đăng ký
            bool success = await khachHangService.DangKyAsync(nguoiDung, tenDangNhap, matKhau);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại sau.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_FormDangNhap formDangNhap = new User_FormDangNhap();
            formDangNhap.Show();
            this.Hide();
        }


        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                txtMatKhau.PasswordChar = '\0';
                btn_hienthi.Text = "Ẩn";
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                btn_hienthi.Text = "Hiển thị";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_NhapLaiMK.PasswordChar == '*')
            {
                txt_NhapLaiMK.PasswordChar = '\0';
                btn_hienthi.Text = "Ẩn";
            }
            else
            {
                txt_NhapLaiMK.PasswordChar = '*';
                btn_hienthi.Text = "Hiển thị";
            }
        }



        private void cbo_tinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tinh.SelectedItem is TinhThanh tinh)
            {
                cbo_quanhuyen.DataSource = tinh.Districts;
                cbo_quanhuyen.DisplayMember = "name";
                cbo_quanhuyen.ValueMember = "name";
            }
        }

        private void cbo_quanhuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_quanhuyen.SelectedItem is QuanHuyen quan)
            {
                cbo_xaphuong.DataSource = quan.Wards;
                cbo_xaphuong.DisplayMember = "name";
                cbo_xaphuong.ValueMember = "name";
            }
        }

        private void lblHaveAccount_Click(object sender, EventArgs e)
        {

        }

        private void User_FormDangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
