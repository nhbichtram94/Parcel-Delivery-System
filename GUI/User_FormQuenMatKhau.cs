using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class User_FormQuenMatKhau : Form
    {
        private readonly KhachHang_BLL khachHangService = new KhachHang_BLL();

        public User_FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private bool KiemTraEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private async void btnLayLaiMatKhau_Click(object sender, EventArgs e)
        {
            var taiKhoan = txtTaiKhoan.Text.Trim();
            var email = txtEmail.Text.Trim();

            try
            {
                var khachHang = await khachHangService.LayTheoTaiKhoanVaEmailAsync(taiKhoan, email);

                if (khachHang != null)
                {
                    MessageBox.Show("Tài khoản hợp lệ.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (var formXacNhanMK = new User_XacNhanMatKhau(taiKhoan))
                    {
                        formXacNhanMK.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản hoặc email không khớp.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Không tìm thấy tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
