using DTO;
using BLL;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
// Cập nhật khách hàng
using System.Text.RegularExpressions;
namespace GUI
{
    public partial class User_TaiKhoan : Form
    {
        private readonly NguoiDung_DTO _currentUser;
        private readonly TaiKhoan_BLL _tkBll = new TaiKhoan_BLL();


        public User_TaiKhoan(NguoiDung_DTO user)
        {
            InitializeComponent();
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            _ = LoadUserDataAsync();
        }

        private async Task LoadUserDataAsync()
        {
            try
            {
                txtTenDangNhap.Text = _currentUser.TenDangNhap ?? "";
                txtEmail.Text = _currentUser.Email ?? "";
                txtSoDienThoai.Text = _currentUser.SoDienThoai ?? "";
                txtHoTen.Text = _currentUser.HoTen ?? "";
                chkTrangThai.Checked = _currentUser.TrangThai;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin tài khoản: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 🧾 Kiểm tra đầu vào
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
                {
                    MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDienThoai.Focus();
                    return;
                }

                string email = txtEmail.Text.Trim();
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sdt = txtSoDienThoai.Text.Trim();
                if (!Regex.IsMatch(sdt, @"^(0[1-9][0-9]{8,9})$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 📋 Cập nhật dữ liệu người dùng
                _currentUser.HoTen = txtHoTen.Text.Trim();
                _currentUser.Email = email;
                _currentUser.SoDienThoai = sdt;
                _currentUser.TrangThai = chkTrangThai.Checked;
                _currentUser.NgayCapNhatCuoi = DateTime.UtcNow;

                //// 🔑 Kiểm tra mật khẩu mới (nếu nhập)
                //string matKhauMoi = txtMatKhauMoi.Text.Trim();
                //string matKhauXacNhan = txtXacNhanMatKhau.Text.Trim();

                //if (!string.IsNullOrEmpty(matKhauMoi))
                //{
                //    if (matKhauMoi != matKhauXacNhan)
                //    {
                //        MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    _currentUser.MatKhauHash = matKhauMoi; // có thể thêm mã hoá sau
                //}

                // 📡 Gửi lên BLL để cập nhật
                await _tkBll.CapNhatTaiKhoanAsync(_currentUser);

                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_hienthiMKM_Click(object sender, EventArgs e)
        {
            //if (txtMatKhauMoi.PasswordChar == '*')
            //{
            //    txtMatKhauMoi.PasswordChar = '\0';
            //    btn_hienthiMKM.Text = "Ẩn";
            //}
            //else
            //{
            //    txtMatKhauMoi.PasswordChar = '*';
            //    btn_hienthiMKM.Text = "Hiển thị";
            //}

        }


        private void btn_hienthiXNMK_Click(object sender, EventArgs e)
        {
            //if  (txtXacNhanMatKhau.PasswordChar == '*')
            //{
            //    txtXacNhanMatKhau.PasswordChar = '\0';
            //    btn_hienthiXNMK.Text = "Ẩn";
            //}
            //else
            //{
            //    txtXacNhanMatKhau.PasswordChar = '*';
            //    btn_hienthiXNMK.Text = "Hiển thị";
            //}

        }
    }
}
