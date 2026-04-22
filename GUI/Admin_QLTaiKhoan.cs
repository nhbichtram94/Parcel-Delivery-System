using BLL;
using DTO;
using Microsoft.VisualBasic; // Để dùng Interaction.InputBox
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class Admin_QLTaiKhoan : Form
    {
        private readonly TaiKhoan_BLL _bll = new TaiKhoan_BLL();
        private List<NguoiDung_DTO> _taiKhoanList = new List<NguoiDung_DTO>();
        private NguoiDung_DTO _selectedTaiKhoan;


        public Admin_QLTaiKhoan()
        {
            InitializeComponent();
            cmbLoaiNguoiDung.Items.AddRange(new[] { "Nhân viên", "Khách hàng" });
            cmbPhanQuyen.Items.AddRange(new[] { "Admin", "Quản lý", "Nhân viên văn phòng", "Kế toán", "Shipper", "Khách Hàng" });

            cmbLoaiNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhanQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhanQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadTaiKhoanAsync();
            cmbLoaiNguoiDung.SelectedIndexChanged += cmbLoaiNguoiDung_SelectedIndexChanged;

        }

        private async void Admin_QLTaiKhoan_Load(object sender, EventArgs e)
        {
            await LoadTaiKhoanAsync();
        }

        private void cmbLoaiNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiNguoiDung.SelectedItem == null)
            {
                cmbPhanQuyen.Items.Clear();
                cmbPhanQuyen.Enabled = false;
                return;
            }

            string loaiNguoiDung = cmbLoaiNguoiDung.SelectedItem.ToString();
            cmbPhanQuyen.Items.Clear();

            if (loaiNguoiDung == "Khách hàng")
            {
                cmbPhanQuyen.Items.Add("Khách Hàng");
                cmbPhanQuyen.SelectedIndex = 0;
                cmbPhanQuyen.Enabled = false;
            }
            else
            {
                cmbPhanQuyen.Items.AddRange(new[]
                {
            "Admin",
            "Quản lý",
            "Nhân viên văn phòng",
            "Kế toán",
            "Shipper",
        });
                cmbPhanQuyen.Enabled = true;
            }
        }

        private async Task LoadTaiKhoanAsync()
        {
            _taiKhoanList = await _bll.LayTatCaTaiKhoanAsync();

            dgvTaiKhoan.AutoGenerateColumns = false; // tắt tự động tạo cột
            dgvTaiKhoan.DataSource = null;
            dgvTaiKhoan.Columns.Clear();

            // Chỉ hiển thị các trường đặc trưng
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên đăng nhập",
                Width = 120
            });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ tên",
                Width = 150
            });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LoaiNguoiDung",
                HeaderText = "Loại người dùng",
                Width = 100
            });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PhanQuyen",
                HeaderText = "Phân quyền",
                Width = 120
            });
            dgvTaiKhoan.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Đang hoạt động",
                Width = 80
            });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NgayTao",
                HeaderText = "Ngày tạo",
                Width = 120,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            // Gán datasource
            dgvTaiKhoan.DataSource = _taiKhoanList;
        }



        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedTaiKhoan = dgvTaiKhoan.Rows[e.RowIndex].DataBoundItem as NguoiDung_DTO;
            if (_selectedTaiKhoan == null) return;

            txtTenDangNhap.Text = _selectedTaiKhoan.TenDangNhap;
            cmbLoaiNguoiDung.SelectedItem = _selectedTaiKhoan.LoaiNguoiDung == "NhanVien" ? "Nhân viên" : "Khách hàng";
            cmbPhanQuyen.SelectedItem = _selectedTaiKhoan.PhanQuyen;
            txtMatKhau.Text = _selectedTaiKhoan.MatKhauHash;
        }

        // ===============================================
        // 🔹 THÊM TÀI KHOẢN + THÔNG TIN NGƯỜI DÙNG
        // ===============================================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string loaiNguoiDung = cmbLoaiNguoiDung.Text;
                string phanQuyen = cmbPhanQuyen.Text;

                if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("⚠️ Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isExist = await _bll.KiemTraTonTaiTaiKhoanAsync(tenDangNhap);
                if (isExist)
                {
                    MessageBox.Show("❌ Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nhập thông tin người dùng
                using (var f = new FormNhapThongTinNguoiDung(loaiNguoiDung))
                {
                    if (f.ShowDialog() != DialogResult.OK) return;

                    // ✅ Gộp tất cả vào NguoiDung_DTO
                    var nguoiDung = new NguoiDung_DTO
                    {
                        Id = ObjectId.GenerateNewId(),
                        HoTen = f.HoTen,
                        SoDienThoai = f.SDT,
                        Email = f.Email,
                        DiaChiChiTiet = f.DiaChi,
                        LoaiNguoiDung = loaiNguoiDung == "Nhân viên" ? "NhanVien" : "KhachHang",
                        ChucVu = f.ChucVu,
                        KhuVucPhuTrach = f.KhuVuc,
                        TenDangNhap = tenDangNhap,
                        MatKhauHash = matKhau, // có thể mã hoá sau
                        PhanQuyen = phanQuyen,
                        TrangThai = true,
                        NgayTao = DateTime.UtcNow,
                        NgayCapNhatCuoi = DateTime.UtcNow
                    };

                    await _bll.ThemTaiKhoanAsync(nguoiDung);

                    MessageBox.Show("✅ Thêm tài khoản người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTaiKhoanAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // ===============================================
        // ✏️ SỬA THÔNG TIN
        // ===============================================
        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTaiKhoan == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn tài khoản cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác định loại người dùng để mở form đúng chế độ
                string loaiNguoiDung = _selectedTaiKhoan.LoaiNguoiDung == "NhanVien"
                    ? "Nhân viên"
                    : "Khách hàng";

                // ✨ Mở form cập nhật
                using (var f = new FormNhapThongTinNguoiDung(loaiNguoiDung))
                {
                    // --- ĐỔ DỮ LIỆU CŨ TRỰC TIẾP ---
                    f.Controls["txtHoTen"].Text = _selectedTaiKhoan.HoTen;
                    f.Controls["txtSDT"].Text = _selectedTaiKhoan.SoDienThoai;
                    f.Controls["txtEmail"].Text = _selectedTaiKhoan.Email;
                    f.Controls["txtDiaChi"].Text = _selectedTaiKhoan.DiaChiChiTiet;

                    // Nếu là nhân viên thì có chức vụ + khu vực
                    if (loaiNguoiDung == "Nhân viên")
                    {
                        f.Controls["txtChucVu"].Text = _selectedTaiKhoan.ChucVu;
                        f.Controls["txtKhuVuc"].Text = _selectedTaiKhoan.KhuVucPhuTrach;
                    }

                    // ================================

                    if (f.ShowDialog() != DialogResult.OK)
                        return;

                    // ✨ Cập nhật lại DTO
                    _selectedTaiKhoan.TenDangNhap = txtTenDangNhap.Text.Trim();

                    _selectedTaiKhoan.MatKhauHash = txtMatKhau.Text.Trim();
                    _selectedTaiKhoan.PhanQuyen = cmbPhanQuyen.Text;

                    _selectedTaiKhoan.HoTen = f.HoTen;
                    _selectedTaiKhoan.SoDienThoai = f.SDT;
                    _selectedTaiKhoan.Email = f.Email;
                    _selectedTaiKhoan.DiaChiChiTiet = f.DiaChi;
                    _selectedTaiKhoan.ChucVu = f.ChucVu;
                    _selectedTaiKhoan.KhuVucPhuTrach = f.KhuVuc;

                    _selectedTaiKhoan.NgayCapNhatCuoi = DateTime.UtcNow;

                    // Lưu xuống DB
                    await _bll.CapNhatTaiKhoanAsync(_selectedTaiKhoan);

                    MessageBox.Show("✅ Cập nhật tài khoản thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadTaiKhoanAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ===============================================
        // 🗑️ XÓA
        // ===============================================
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedTaiKhoan == null)
            {
                MessageBox.Show("⚠️ Vui lòng chọn tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _bll.XoaTaiKhoanAsync(_selectedTaiKhoan.Id);
                MessageBox.Show("🗑️ Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadTaiKhoanAsync();
            }
        }

        // ===============================================
        // 🔒 KHÓA / MỞ KHÓA
        // ===============================================
        private async void btnKhoa_Click(object sender, EventArgs e)
        {
            if (_selectedTaiKhoan == null) return;
            await _bll.DatTrangThaiTaiKhoanAsync(_selectedTaiKhoan.Id, false);
            MessageBox.Show("🔒 Đã khóa tài khoản!");
            await LoadTaiKhoanAsync();
        }

        private async void btnMoKhoa_Click(object sender, EventArgs e)
        {
            if (_selectedTaiKhoan == null) return;
            await _bll.DatTrangThaiTaiKhoanAsync(_selectedTaiKhoan.Id, true);
            MessageBox.Show("🔓 Đã mở khóa tài khoản!");
            await LoadTaiKhoanAsync();
        }

        // ===============================================
        // 🔍 TÌM KIẾM + RESET
        // ===============================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTenDangNhap.Text.Trim().ToLower();
            string loaiNguoiDungUI = cmbLoaiNguoiDung.SelectedItem?.ToString() ?? "";
            string phanQuyenUI = cmbPhanQuyen.SelectedItem?.ToString() ?? "";

            var filtered = _taiKhoanList;

            // ===========================
            // 1. Lọc theo từ khóa
            // ===========================
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.FindAll(t =>
                    !string.IsNullOrEmpty(t.TenDangNhap) &&
                    t.TenDangNhap.ToLower().Contains(keyword)
                );
            }

            // ===========================
            // 2. Lọc theo loại người dùng
            // ===========================
            string loaiNDFilter = "";
            if (loaiNguoiDungUI == "Nhân viên")
                loaiNDFilter = "NhanVien";
            else if (loaiNguoiDungUI == "Khách hàng")
                loaiNDFilter = "KhachHang";

            if (!string.IsNullOrEmpty(loaiNDFilter))
            {
                filtered = filtered.FindAll(t =>
                    t.LoaiNguoiDung != null &&
                    t.LoaiNguoiDung.Equals(loaiNDFilter, StringComparison.OrdinalIgnoreCase)
                );
            }

            // ===========================
            // 3. Lọc theo phân quyền (C# 7.3 compatible)
            // ===========================
            string phanQuyenFilter = "";

            if (phanQuyenUI == "Admin")
                phanQuyenFilter = "admin";
            else if (phanQuyenUI == "Quản lý")
                phanQuyenFilter = "manager";
            else if (phanQuyenUI == "Nhân viên văn phòng")
                phanQuyenFilter = "staff";
            else if (phanQuyenUI == "Kế toán")
                phanQuyenFilter = "accountant";
            else if (phanQuyenUI == "Shipper")
                phanQuyenFilter = "shipper";
            else if (phanQuyenUI == "Khách Hàng")
                phanQuyenFilter = "KhachHang";

            if (!string.IsNullOrEmpty(phanQuyenFilter))
            {
                filtered = filtered.FindAll(t =>
                    t.PhanQuyen != null &&
                    t.PhanQuyen.Equals(phanQuyenFilter, StringComparison.OrdinalIgnoreCase)
                );
            }

            // ===========================
            // 4. Hiển thị kết quả
            // ===========================
            dgvTaiKhoan.DataSource = null;
            dgvTaiKhoan.DataSource = filtered;

            if (filtered.Count == 0)
                MessageBox.Show("Không tìm thấy tài khoản phù hợp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            _selectedTaiKhoan = null;
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cmbLoaiNguoiDung.SelectedIndex = -1;
            cmbPhanQuyen.SelectedIndex = -1;
            if (_taiKhoanList != null)
            {
                dgvTaiKhoan.DataSource = null;
                dgvTaiKhoan.DataSource = _taiKhoanList;
            }

        }

        private async void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Lấy danh sách tài khoản
                var danhSachTaiKhoan = await _bll.LayTatCaTaiKhoanAsync();

                if (danhSachTaiKhoan == null || danhSachTaiKhoan.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2️⃣ Chọn nơi lưu file
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.Title = "Chọn nơi lưu file xuất";
                    sfd.FileName = $"DanhSachTaiKhoan_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // 3️⃣ Ghi dữ liệu ra file CSV
                        using (var writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            // Ghi header
                            writer.WriteLine("TenDangNhap,LoaiNguoiDung,PhanQuyen,TrangThai,NgayTao,NgayCapNhatCuoi");

                            // Ghi từng dòng
                            foreach (var tk in danhSachTaiKhoan)
                            {
                                writer.WriteLine($"{tk.TenDangNhap},{tk.LoaiNguoiDung},{tk.PhanQuyen},{tk.TrangThai},{tk.NgayTao},{tk.NgayCapNhatCuoi}");
                            }
                        }

                        MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_DatLaiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTaiKhoan == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn tài khoản cần đặt lại mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn đặt lại mật khẩu cho tài khoản '{_selectedTaiKhoan.TenDangNhap}' không?\nMật khẩu mới sẽ là: aA@123456",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes) return;

                // Đặt mật khẩu mới
                string matKhauMoi = "aA@123456"; 
                _selectedTaiKhoan.MatKhauHash = matKhauMoi;

                // Cập nhật database
                await _bll.CapNhatTaiKhoanAsync(_selectedTaiKhoan);

                MessageBox.Show($"✅ Đặt lại mật khẩu thành công!\nMật khẩu mới: {matKhauMoi}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally: Clear form hoặc load lại DataGridView
                await LoadTaiKhoanAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lại mật khẩu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
