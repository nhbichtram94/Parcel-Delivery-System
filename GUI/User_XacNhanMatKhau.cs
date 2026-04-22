using BLL;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class User_XacNhanMatKhau : Form
    {
        private readonly KhachHang_BLL _khachHangService = new KhachHang_BLL();
        private readonly string _tenDangNhap; // lấy từ form trước

        public User_XacNhanMatKhau(string tenDangNhap)
        {
            InitializeComponent();
            _tenDangNhap = tenDangNhap;
            // Ẩn mặc định
            txt_MKMoi.UseSystemPasswordChar = true;
            txt_XacNhanMKMoi.UseSystemPasswordChar = true;
        }

        private async void btn_XacNhan_Click(object sender, EventArgs e)
        {
            string matKhauMoi = txt_MKMoi.Text.Trim();
            string nhapLaiMK = txt_XacNhanMKMoi.Text.Trim();

            // 1️⃣ Kiểm tra rỗng
            if (string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(nhapLaiMK))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Kiểm tra khớp
            if (matKhauMoi != nhapLaiMK)
            {
                MessageBox.Show("Hai mật khẩu nhập không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3️⃣ Kiểm tra độ mạnh cơ bản
            if (!Regex.IsMatch(matKhauMoi, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, bao gồm chữ hoa, chữ thường và số!",
                    "Mật khẩu yếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = await _khachHangService.CapNhatMatKhauAsync(_tenDangNhap, matKhauMoi);
                if (success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản để cập nhật.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật mật khẩu: " + ex.Message,
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool show = checkBox1.Checked;
            txt_MKMoi.UseSystemPasswordChar = !show;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool show = checkBox2.Checked;
            txt_XacNhanMKMoi.UseSystemPasswordChar = !show;

        }
    }
}
