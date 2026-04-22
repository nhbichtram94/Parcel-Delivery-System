using DTO;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Shipper_FormDangNhap : Form
    {
        private readonly IMongoCollection<NguoiDung_DTO> _nguoiDungCollection;

        public Shipper_FormDangNhap()
        {
            InitializeComponent();

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GiaoNhanBuuPham");
            _nguoiDungCollection = database.GetCollection<NguoiDung_DTO>("NguoiDung");
        }

      
        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("⚠️ Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 🔹 Tìm người dùng Shipper hợp lệ
                var filter = Builders<NguoiDung_DTO>.Filter.And(
                    Builders<NguoiDung_DTO>.Filter.Eq(u => u.TenDangNhap, tenDangNhap),
                    Builders<NguoiDung_DTO>.Filter.Eq(u => u.MatKhauHash, matKhau),
                    Builders<NguoiDung_DTO>.Filter.Eq(u => u.PhanQuyen, "Shipper"),
                    Builders<NguoiDung_DTO>.Filter.Eq(u => u.TrangThai, true)
                );

                var shipper = (await _nguoiDungCollection.FindAsync(filter)).FirstOrDefault();

                if (shipper == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc không phải Shipper!",
                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Đăng nhập thành công
                MessageBox.Show($"✅ Đăng nhập thành công! Chào {shipper.HoTen}.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Mở form chính của Shipper
                this.Hide();
                using (var mainForm = new Shipper_MainForm(shipper))
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi hệ thống: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnHienThiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                txtMatKhau.PasswordChar = '\0';
                btnHienThiMatKhau.Text = "Ẩn";
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                btnHienThiMatKhau.Text = "Hiển thị";
            }
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
