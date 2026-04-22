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
    public partial class User_ThanhToan : Form
    {
        private readonly DonHang_BLL _donHangBLL = new DonHang_BLL();
        private readonly DonHang_DTO _donHang;
        private readonly NguoiDung_DTO _currentUser;
        public User_ThanhToan(DonHang_DTO donHang, NguoiDung_DTO currentUser)
        {
            InitializeComponent();
            _donHang = donHang;
            _currentUser = currentUser;
        }

        private void User_ThanhToan_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin đơn hàng
            lb_Madon.Text = _donHang.MaDonHang;
            lb_nguogui.Text = $"{_donHang.NguoiGuiThongTin?.HoTen} ({_donHang.NguoiGuiThongTin?.SoDienThoai})";
            lb_nguoiNhan.Text = $"{_donHang.NguoiNhanThongTin?.HoTen} ({_donHang.NguoiNhanThongTin?.SoDienThoai})";
            lb_Tongtien.Text = $"{_donHang.TongTien:N0} VND";
            lb_phiVanChuyen.Text = _donHang.PhiVanChuyen.ToString("N0") + " VND";

            // Ghép đầy đủ địa chỉ người gửi
            string noiGui = $"{_donHang.NguoiGuiThongTin?.DiaChiChiTiet}, " +
                            $"{_donHang.NguoiGuiThongTin?.PhuongXa}, " +
                            $"{_donHang.NguoiGuiThongTin?.QuanHuyen}, " +
                            $"{_donHang.NguoiGuiThongTin?.TinhThanh}";

            // Ghép đầy đủ địa chỉ người nhận
            string noiNhan = $"{_donHang.NguoiNhanThongTin?.DiaChiChiTiet}, " +
                             $"{_donHang.NguoiNhanThongTin?.PhuongXa}, " +
                             $"{_donHang.NguoiNhanThongTin?.QuanHuyen}, " +
                             $"{_donHang.NguoiNhanThongTin?.TinhThanh}";

            // Gán vào label
            lb_noigui.Text = noiGui;
            lb_noinhan.Text = noiNhan;

            // Cấu hình combobox hình thức thanh toán
            cbb_hinhthucTT.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Ví điện tử" });
            cbb_hinhthucTT.SelectedIndex = 0;
        }

        private async void btn_XacnhanTT_Click(object sender, EventArgs e)
        {
            // --- Kiểm tra chọn hình thức thanh toán ---
            if (cbb_hinhthucTT.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn hình thức thanh toán!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Kiểm tra chọn người trả tiền ---
            if (!rdoNguoiGui.Checked && !rdoNguoiNhan.Checked)
            {
                MessageBox.Show("Vui lòng chọn người trả tiền (người gửi hoặc người nhận)!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // --- Kiểm tra chọn người trả tiền ---
            if (!rdoNguoiGui.Checked && !rdoNguoiNhan.Checked)
            {
                MessageBox.Show("Vui lòng chọn người trả tiền (người gửi hoặc người nhận)!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Gán thông tin vào đơn hàng ---
            _donHang.HinhThucThanhToan = cbb_hinhthucTT.SelectedItem.ToString();
            _donHang.DaThanhToan = false;
            _donHang.TrangThai = "Mới tạo";
            _donHang.GhiChuDonHang = rdoNguoiGui.Checked ? "Người gửi trả tiền" : "Người nhận trả tiền";
            // Gán thông tin người tạo đơn (người gửi)
            _donHang.IdNguoiGui = _currentUser.Id;
            // (Tùy trường hợp, nếu người nhận là chính người dùng hiện tại thì có thể gán thêm)
            _donHang.IdNguoiNhan = _currentUser.Id;

            try
            {
                bool result = await _donHangBLL.TaoDonHangAsync(_donHang);

                if (result)
                {
                    MessageBox.Show("Đơn hàng đã được tạo và đang chờ xác nhận!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo đơn hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống khi tạo đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lb_phiVanChuyen_Click(object sender, EventArgs e)
        {

        }
    }
}
