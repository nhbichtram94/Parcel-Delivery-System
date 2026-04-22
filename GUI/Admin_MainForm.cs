using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Admin_MainForm : Form
    {
        public Admin_MainForm()
        {
            InitializeComponent();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            using (Admin_QLTaiKhoan Admin_TaiKhoanForm1 = new Admin_QLTaiKhoan())
            {
                Admin_TaiKhoanForm1.ShowDialog();  // Mở modal, khi đóng thì form tự dispose
            }
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            using (Admin_DonHangForm donHangForm = new Admin_DonHangForm())
            {
                donHangForm.ShowDialog();  // Mở modal, khi đóng thì form tự dispose
            }
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            using (Admin_PhanCongShipper PhanCongShipperForm1 = new Admin_PhanCongShipper())
            {
                PhanCongShipperForm1.ShowDialog();  // Mở modal, khi đóng thì form tự dispose
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            //using (BaoCao BaoCaoForm1 = new BaoCao())
            //{
            //    BaoCaoForm1.ShowDialog();  // Mở modal, khi đóng thì form tự dispose
            //}
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Đóng form hiện tại và trở về màn hình đăng nhập (giả sử LoginForm)
                this.Close();
                // Nếu cần mở lại form đăng nhập, làm trong chương trình chính hoặc nơi gọi User_MainForm
            }
        }

        private void btnQLPhi_Click(object sender, EventArgs e)
        {

        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {

        }

        private void btnQLPhuongTien_Click(object sender, EventArgs e)
        {

        }

        private void btnSuCo_Click(object sender, EventArgs e)
        {

        }

        private void btn_QLThanhToan_Click(object sender, EventArgs e)
        {
            using (Admin_ThanhToan thanhtoan = new Admin_ThanhToan())
            {
                thanhtoan.ShowDialog();  // Mở modal, khi đóng thì form tự dispose
            }
        }

        private void btn_backup_restore_Click(object sender, EventArgs e)
        {
            using (Admin_Backup_Restore bs = new Admin_Backup_Restore())
            {
                bs.ShowDialog();  // Mở modal, khi đóng thì form tự dispose
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
