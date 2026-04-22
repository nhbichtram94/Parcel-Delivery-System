using BLL;
using DTO;
using MongoDB.Bson;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace GUI
{
    public partial class User_TaoDonHang : Form
    {
        private List<TinhThanh> _provinces;
        private readonly DonHang_BLL _donHangBLL = new DonHang_BLL();
        private List<SanPham_DTO> _danhSachSanPham = new List<SanPham_DTO>();
        private readonly NguoiDung_DTO _currentUser;  // 🔹 đổi kiểu gộp
        private readonly DonHang_DTO _donHang;

        public User_TaoDonHang(NguoiDung_DTO user)
        {
            InitializeComponent();
            _currentUser = user;

            // Gán thông tin người gửi (từ người dùng hiện tại)
            txtTenNguoiGui.Text = _currentUser.HoTen ?? "";
            txtSDTNguoiGui.Text = _currentUser.SoDienThoai ?? "";
            txtDiaChiNguoiGui.Text = _currentUser.DiaChiChiTiet ?? "";
            txt_emailNgGui.Text = _currentUser.Email ?? "";

            LoadJsonsData();
        }

        private void LoadJsonsData()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "provinces.open-api.vn.json");
                string json = File.ReadAllText(path);
                _provinces = JsonConvert.DeserializeObject<List<TinhThanh>>(json);

                // ===== Người gửi =====
                cbo_tinh_ngGui.DataSource = _provinces;
                cbo_tinh_ngGui.DisplayMember = "name";
                cbo_tinh_ngGui.ValueMember = "name";

                // ===== Người nhận =====
                cbo_tinh_ngNhan.DataSource = new List<TinhThanh>(_provinces);
                cbo_tinh_ngNhan.DisplayMember = "name";
                cbo_tinh_ngNhan.ValueMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tỉnh/thành: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            _danhSachSanPham.Clear();
            lstSanPham.Items.Clear();
            txtTenNguoiNhan.Clear();
            txtSDTNguoiNhan.Clear();
            txtDiaChiNguoiNhan.Clear();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTenSanPham.Text.Trim();
                if (string.IsNullOrEmpty(tenSP)) { MessageBox.Show("Tên sản phẩm không được để trống."); return; }

                if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
                { MessageBox.Show("Số lượng không hợp lệ."); return; }

                if (!double.TryParse(txtTrongLuong.Text.Trim(), out double trongLuong) || trongLuong <= 0)
                { MessageBox.Show("Trọng lượng không hợp lệ."); return; }

                if (!decimal.TryParse(txtGiaTri.Text.Trim(), out decimal giaTri) || giaTri < 0)
                { MessageBox.Show("Giá trị không hợp lệ."); return; }

                var sp = new SanPham_DTO
                {
                    MaSanPham = "SP" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    TenSanPham = tenSP,
                    SoLuong = soLuong,
                    TrongLuong = trongLuong,
                    GiaTri = giaTri
                };

                _danhSachSanPham.Add(sp);
                lstSanPham.Items.Add($"{tenSP} - SL: {soLuong}, TL: {trongLuong}kg, Giá trị: {giaTri:N0} VND");

                CapNhatTongHopSanPham();
                txtTenSanPham.Clear(); txtSoLuong.Clear(); txtTrongLuong.Clear(); txtGiaTri.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm sản phẩm: {ex.Message}");
            }
        }

        private void CapNhatTongHopSanPham()
        {
            int tongSoLuong = _danhSachSanPham.Sum(sp => sp.SoLuong);
            double tongTrongLuong = _danhSachSanPham.Sum(sp => sp.TrongLuong * sp.SoLuong);
            decimal tongGiaTri = _danhSachSanPham.Sum(sp => sp.GiaTri * sp.SoLuong);

            txtTongSoLuongSanPham.Text = tongSoLuong.ToString();
            txtTongTrongLuong.Text = tongTrongLuong.ToString("N2");
            txtTongGiaTriSanPham.Text = tongGiaTri.ToString("N0");
        }

        private bool ValidateFormInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenNguoiGui.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNguoiGui.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNguoiGui.Text) ||
                string.IsNullOrWhiteSpace(txtTenNguoiNhan.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNguoiNhan.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNguoiNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin người gửi và người nhận.");
                return false;
            }

            return true;
        }

        private async void btnXacNhanDH_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin người gửi
            if (!ValidateFormInputs())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin người gửi.");
                return;
            }

            // Kiểm tra thông tin người nhận
            if (!ValidateFormInputs1())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin người nhận.");
                return;
            }

            // Kiểm tra danh sách sản phẩm
            if (_danhSachSanPham.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất 1 sản phẩm.");
                return;
            }


            try
            {
                decimal phiVanChuyen = await TinhPhiVanChuyenAsync();
                decimal tongGiaTriSP = _danhSachSanPham.Sum(sp => sp.GiaTri * sp.SoLuong);
                decimal tongTien = tongGiaTriSP + phiVanChuyen;

                // 🧩 Tạo đối tượng đơn hàng
                var donHang = new DonHang_DTO
                {
                    Id = ObjectId.GenerateNewId(),
                    MaDonHang = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss"),

                    IdNguoiGui = _currentUser.Id,
                    NguoiGuiThongTin = new NguoiDungThongTinSnapshot
                    {
                        HoTen = txtTenNguoiGui.Text.Trim(),
                        SoDienThoai = txtSDTNguoiGui.Text.Trim(),
                        Email = txt_emailNgGui.Text.Trim(),
                        DiaChiChiTiet = txtDiaChiNguoiGui.Text.Trim(),
                        PhuongXa = cbo_phuongXa_ngGui.Text,
                        QuanHuyen = cbo_quanHuyen_ngGui.Text,
                        TinhThanh = cbo_tinh_ngGui.Text
                    },
                    NguoiNhanThongTin = new NguoiDungThongTinSnapshot
                    {
                        HoTen = txtTenNguoiNhan.Text.Trim(),
                        SoDienThoai = txtSDTNguoiNhan.Text.Trim(),
                        Email = txt_emailNgNhan.Text.Trim(),
                        DiaChiChiTiet = txtDiaChiNguoiNhan.Text.Trim(),
                        PhuongXa = cbo_phuongXa_ngNhan.Text,
                        QuanHuyen = cbo_quanHuyen_ngNhan.Text,
                        TinhThanh = cbo_tinh_ngNhan.Text
                    },

                    DanhSachSanPham = new List<SanPham_DTO>(_danhSachSanPham),
                    TongSoLuongSanPham = _danhSachSanPham.Sum(sp => sp.SoLuong),
                    TongTrongLuong = _danhSachSanPham.Sum(sp => sp.TrongLuong * sp.SoLuong),
                    TongGiaTriSanPham = tongGiaTriSP,
                    PhiVanChuyen = phiVanChuyen,
                    TongTien = tongTien,
                    TrangThai = "Mới tạo",
                    NgayTaoDon = DateTime.Now,
                    NgayCapNhatCuoi = DateTime.Now
                };

                // 🔹 Mở form thanh toán
                var formThanhToan = new User_ThanhToan(donHang, _currentUser);
                this.Hide();
                formThanhToan.ShowDialog();
                this.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận đơn hàng: " + ex.Message);
            }
        }

        // -------------------------
        // Hàm kiểm tra dữ liệu form
        private bool ValidateFormInputs1()
        {
            // Người gửi
            if (string.IsNullOrWhiteSpace(txtTenNguoiGui.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNguoiGui.Text) ||
                string.IsNullOrWhiteSpace(txt_emailNgGui.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNguoiGui.Text) ||
                string.IsNullOrWhiteSpace(cbo_phuongXa_ngGui.Text) ||
                string.IsNullOrWhiteSpace(cbo_quanHuyen_ngGui.Text) ||
                string.IsNullOrWhiteSpace(cbo_tinh_ngGui.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin người gửi.");
                return false;
            }

            // Người nhận
            if (string.IsNullOrWhiteSpace(txtTenNguoiNhan.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNguoiNhan.Text) ||
                string.IsNullOrWhiteSpace(txt_emailNgNhan.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNguoiNhan.Text) ||
                string.IsNullOrWhiteSpace(cbo_phuongXa_ngNhan.Text) ||
                string.IsNullOrWhiteSpace(cbo_quanHuyen_ngNhan.Text) ||
                string.IsNullOrWhiteSpace(cbo_tinh_ngNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin người nhận.");
                return false;
            }

            // Kiểm tra số điện thoại hợp lệ (9-12 chữ số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDTNguoiGui.Text, @"^0\d{9}$") ||
       !System.Text.RegularExpressions.Regex.IsMatch(txtSDTNguoiNhan.Text, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Phải có 10 chữ số và bắt đầu bằng 0.");
                return false;
            }


            // Kiểm tra email hợp lệ
            try
            {
                var mailGui = new System.Net.Mail.MailAddress(txt_emailNgGui.Text);
                var mailNhan = new System.Net.Mail.MailAddress(txt_emailNgNhan.Text);
            }
            catch
            {
                MessageBox.Show("Email không hợp lệ.");
                return false;
            }

            // Kiểm tra danh sách sản phẩm
            if (_danhSachSanPham.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất 1 sản phẩm.");
                return false;
            }

            return true;
        }


        private async Task<decimal> TinhPhiVanChuyenAsync()
        {
            try
            {
                string pickProvince = cbo_tinh_ngGui.Text;
                string pickDistrict = cbo_quanHuyen_ngGui.Text;
                string province = cbo_tinh_ngNhan.Text;
                string district = cbo_quanHuyen_ngNhan.Text;
                string address = txtDiaChiNguoiNhan.Text.Trim();
                double weight = _danhSachSanPham.Sum(sp => sp.TrongLuong * sp.SoLuong) * 1000;
                decimal value = _danhSachSanPham.Sum(sp => sp.GiaTri * sp.SoLuong);

                var client = new RestClient("https://services.giaohangtietkiem.vn/services/shipment/fee");
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Token", "2WBzGLH0QNM7GOLgBYgI5cfxf2saOwmkQfr2qnM");

                var body = new
                {
                    pick_province = pickProvince,
                    pick_district = pickDistrict,
                    province = province,
                    district = district,
                    address = address,
                    weight = weight,
                    value = value,
                    transport = "road"
                };

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);
                var response = await client.ExecuteAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<GHTKFeeResponse_DTO>(response.Content);
                    if (data.success)
                        return data.fee.fee;
                }

                MessageBox.Show("Không thể tính được phí vận chuyển từ GHTK!");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gọi API GHTK: " + ex.Message);
                return 0;
            }
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có chọn sản phẩm trong list box không
                if (lstSanPham.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trong danh sách.", "Chưa chọn sản phẩm",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int index = lstSanPham.SelectedIndex;

                // Xác nhận xóa
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm:\n\n{lstSanPham.SelectedItem}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Xóa khỏi danh sách hiển thị
                    lstSanPham.Items.RemoveAt(index);

                    // Xóa khỏi danh sách dữ liệu thật
                    _danhSachSanPham.RemoveAt(index);

                    // Cập nhật lại tổng số lượng, trọng lượng, giá trị
                    CapNhatTongHopSanPham();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbo_tinh_ngGui_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tinh_ngGui.SelectedItem is TinhThanh tinh)
            {
                cbo_quanHuyen_ngGui.DataSource = tinh.Districts;
                cbo_quanHuyen_ngGui.DisplayMember = "name";
                cbo_quanHuyen_ngGui.ValueMember = "name";
            }
        }

        private void cbo_tinh_ngNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tinh_ngNhan.SelectedItem is TinhThanh tinh)
            {
                cbo_quanHuyen_ngNhan.DataSource = tinh.Districts;
                cbo_quanHuyen_ngNhan.DisplayMember = "name";
                cbo_quanHuyen_ngNhan.ValueMember = "name";
            }
        }

        private void cbo_quanHuyen_ngGui_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_quanHuyen_ngGui.SelectedItem is QuanHuyen quan)
            {
                cbo_phuongXa_ngGui.DataSource = quan.Wards;
                cbo_phuongXa_ngGui.DisplayMember = "name";
                cbo_phuongXa_ngGui.ValueMember = "name";
            }

        }

        private void cbo_quanHuyen_ngNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_quanHuyen_ngNhan.SelectedItem is QuanHuyen quan)
            {
                cbo_phuongXa_ngNhan.DataSource = quan.Wards;
                cbo_phuongXa_ngNhan.DisplayMember = "name";
                cbo_phuongXa_ngNhan.ValueMember = "name";
            }

        }

        private void lblTenNguoiNhan_Click(object sender, EventArgs e)
        {

        }
    }
}
