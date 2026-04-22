using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Admin_FormDangNhap : Form
    {
        public Admin_FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text;
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.Hide(); // Ẩn form đăng nhập
                Admin_MainForm mainForm = new Admin_MainForm();
                mainForm.ShowDialog(); // Mở form chính
                this.Close(); // Đóng hẳn form đăng nhập sau khi form chính tắt

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtTaiKhoan.Focus();
            }
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            // Nếu đang ẩn mật khẩu thì hiện
            if (txtMatKhau.PasswordChar == '*')
            {
                txtMatKhau.PasswordChar = '\0'; // không có ký tự che -> hiện password
                btn_hienthi.Text = "Ẩn";        // đổi text nút
            }
            else
            {
                txtMatKhau.PasswordChar = '*'; // che lại
                btn_hienthi.Text = "Hiện thị";     // đổi text nút
            }
        }

        private void lblTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }
    }
}
