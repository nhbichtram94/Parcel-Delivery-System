using BLL;
using DTO;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class User_FormDangNhap : Form
    {
        private readonly TaiKhoan_BLL _taiKhoanBll = new TaiKhoan_BLL();
        private readonly KhachHang_BLL _khachHangBll = new KhachHang_BLL();

        public User_FormDangNhap()
        {
            InitializeComponent();
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 🔹 1. Gọi BLL để xác thực đăng nhập
                var nguoiDung = await _khachHangBll.DangNhapAsync(tenDangNhap, matKhau);

                if (nguoiDung == null || nguoiDung.PhanQuyen != "KhachHang")
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Focus();
                    return;
                }

                // 🔹 2. Kiểm tra trạng thái khóa
                if (!nguoiDung.TrangThai)
                {
                    MessageBox.Show("Tài khoản này đang bị khóa. Vui lòng liên hệ quản trị viên.", "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 3. Lấy tên hiển thị (từ họ tên)
                string tenHienThi = !string.IsNullOrEmpty(nguoiDung.HoTen) ? nguoiDung.HoTen : nguoiDung.TenDangNhap;

                // 🔹 4. Thông báo và mở form chính
                MessageBox.Show($"Đăng nhập thành công! Chào mừng {tenHienThi}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                using (var mainForm = new User_MainForm(nguoiDung))
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using (var formDangKy = new User_FormDangKy())
            {
                this.Hide();
                formDangKy.ShowDialog();
                this.Show();
            }
        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            using (var formQuenMatKhau = new User_FormQuenMatKhau())
            {
                this.Hide();
                formQuenMatKhau.ShowDialog();
                this.Show();
            }
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
    }
}
