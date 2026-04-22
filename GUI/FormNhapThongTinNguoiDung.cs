using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormNhapThongTinNguoiDung : Form
    {
        public string HoTen => txtHoTen.Text.Trim();
        public string SDT => txtSDT.Text.Trim();
        public string Email => txtEmail.Text.Trim();
        public string DiaChi => txtDiaChi.Text.Trim();
        public string ChucVu => txtChucVu.Text.Trim();
        public string KhuVuc => txtKhuVuc.Text.Trim();

        public FormNhapThongTinNguoiDung(string loaiNguoiDung)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            if (loaiNguoiDung == "Khách hàng")
            {
                lblChucVu.Visible = false;
                txtChucVu.Visible = false;
                lblKhuVuc.Visible = false;
                txtKhuVuc.Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HoTen) || string.IsNullOrEmpty(SDT))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên và số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
