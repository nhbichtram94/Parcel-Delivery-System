using BLL;
using DTO;
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
    public partial class Shipper_About : Form
    {
        private readonly NguoiDung_DTO _shipper;

        public Shipper_About(NguoiDung_DTO shipper)
        {
            InitializeComponent();
            _shipper = shipper; // nhận dữ liệu từ Shipper_MainForm
        }

        private void Shipper_About_Load(object sender, EventArgs e)
        {
            try
            {
                if (_shipper == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin shipper!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // Load dữ liệu vào UI
                txtTenDangNhap.Text = _shipper.TenDangNhap ?? "";
                txtHoTen.Text = _shipper.HoTen ?? "";
                txtSDT.Text = _shipper.SoDienThoai ?? "";
                txtEmail.Text = _shipper.Email ?? "";
                txtDiaChi.Text = _shipper.DiaChiChiTiet ?? "";
                txtChucVu.Text = _shipper.ChucVu ?? "";
                txtKhuVuc.Text = _shipper.KhuVucPhuTrach ?? "";

                // bool -> string
                txtTrangThai.Text = _shipper.TrangThai ? "Đang hoạt động" : "Bận";

                txtNgayTao.Text = _shipper.NgayTao.ToString("dd/MM/yyyy HH:mm");
                txtNgayCapNhat.Text = _shipper.NgayCapNhatCuoi.ToString("dd/MM/yyyy HH:mm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin shipper!\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================
        // Nút quay lại
        // ================================
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // quay về form trước (Shipper_MainForm)
        }
    }
}