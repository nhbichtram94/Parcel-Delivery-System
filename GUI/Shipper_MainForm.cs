using DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using BLL;

namespace GUI
{
    public partial class Shipper_MainForm : Form
    {
        private readonly NguoiDung_DTO _shipper;
        private readonly IMongoCollection<DonHang_DTO> _donHangCollection;

        private List<DonHang_DTO> _allOrders;   // toàn bộ đơn hàng theo shipper
        private List<DonHang_DTO> _filteredOrders; // sau khi lọc
        private int pageIndex = 0;
        private const int PAGE_SIZE = 12;
        private void SetupGridView()
        {
            dgvDonHang.Columns.Clear();
            dgvDonHang.AutoGenerateColumns = false;
            dgvDonHang.AllowUserToAddRows = false;

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaDonHang",
                HeaderText = "Mã Đơn",
                DataPropertyName = "MaDonHang",
                Width = 120
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenNguoiNhan",
                HeaderText = "Người Nhận",
                DataPropertyName = "TenNguoiNhan",
                Width = 150
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoDienThoai",
                HeaderText = "SĐT",
                DataPropertyName = "SoDienThoai",
                Width = 100
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiaChi",
                HeaderText = "Địa Chỉ",
                DataPropertyName = "DiaChi",
                Width = 200
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongSp",
                HeaderText = "Số SP",
                DataPropertyName = "TongSoLuongSanPham",
                Width = 70
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongTien",
                HeaderText = "Tổng Tiền",
                DataPropertyName = "TongTien",
                Width = 90
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                HeaderText = "Trạng Thái",
                DataPropertyName = "TrangThai",
                Width = 100
            });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DaThanhToan",
                HeaderText = "Đã thanh toán",
                DataPropertyName = "DaThanhToan",
                Width = 100
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayCapNhat",
                HeaderText = "Ngày Cập Nhật",
                DataPropertyName = "NgayCapNhat",
                Width = 150
            });
        }

        public Shipper_MainForm(NguoiDung_DTO shipper)
        {
            InitializeComponent();
            _shipper = shipper;

            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("GiaoNhanBuuPham");
            _donHangCollection = db.GetCollection<DonHang_DTO>("DonHang");
        }

        private async void Shipper_MainForm_Load(object sender, EventArgs e)
        {
        

            SetupGridView();   // 📌 QUAN TRỌNG – cấu hình trước khi load dữ liệu

            try
            {
                var filter = Builders<DonHang_DTO>.Filter.Eq(x => x.IdNguoiPhuTrach, _shipper.Id);
                _allOrders = await _donHangCollection.Find(filter).ToListAsync();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                _allOrders = new List<DonHang_DTO>();
                _filteredOrders = new List<DonHang_DTO>();
            }
        }


        // ------------------ FILTER FUNCTION ------------------
        private void ApplyFilters()
        {
            if (_allOrders == null) return;

            _filteredOrders = _allOrders;

            // 1. Lọc khu vực
            if (!string.IsNullOrWhiteSpace(txtSearchKhuVuc.Text))
            {
                string khuVuc = txtSearchKhuVuc.Text.ToLower();
                _filteredOrders = _filteredOrders
                    .Where(x => (x.NguoiNhanThongTin?.DiaChiChiTiet ?? "").ToLower().Contains(khuVuc))
                    .ToList();
            }

            // 2. Lọc trạng thái
            if (cboTrangThai.SelectedItem != null && cboTrangThai.SelectedItem.ToString() != "Tất cả")
            {
                string trangThai = cboTrangThai.SelectedItem.ToString();
                _filteredOrders = _filteredOrders
                    .Where(x => x.TrangThai == trangThai)
                    .ToList();
            }

            // Reset trang
            pageIndex = 0;
            LoadPage();
        }

        // ------------------ EVENT NÚT ÁP DỤNG FILTER ------------------
        private void ApplyFiltersButton_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }


        private void LoadPage()
        {
            var data = _filteredOrders
                .Skip(pageIndex * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .Select(d => new
                {
                    d.MaDonHang,
                    TenNguoiNhan = d.NguoiNhanThongTin?.HoTen ?? "Không rõ",
                    SoDienThoai = d.NguoiNhanThongTin?.SoDienThoai ?? "N/A",
                    DiaChi = d.NguoiNhanThongTin?.DiaChiChiTiet ?? "Không có",
                    d.TongSoLuongSanPham,
                    d.TongTien,
                    d.TrangThai,
                    DaThanhToan = d.DaThanhToan ? "✔ Có" : "✖ Chưa",
                    NgayCapNhat = d.NgayCapNhatCuoi.ToLocalTime().ToString("dd/MM/yyyy HH:mm")
                })
                .ToList();

            dgvDonHang.DataSource = null;  // reset để tránh lỗi binding
            dgvDonHang.DataSource = data;
        }


        // ----------- EVENT FILTER ----------
        private void TxtSearchKhuVuc_TextChanged(object sender, EventArgs e)
        {
            if (_allOrders != null) // đảm bảo dữ liệu đã load
                ApplyFilters();
        }


        private void CboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ApplyFilters();
        }

        private void FilterByDateTime(object sender, EventArgs e)
        {
            // ApplyFilters();
        }

        // ----------------- PHÂN TRANG -----------------
        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            int maxPage = (_filteredOrders.Count - 1) / PAGE_SIZE;
            if (pageIndex < maxPage)
            {
                pageIndex++;
                LoadPage();
            }
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (pageIndex > 0)
            {
                pageIndex--;
                LoadPage();
            }
        }

        // ------------------ HOÀN THÀNH ĐƠN ------------------
        private async void BtnHoanThanh_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 đơn để hoàn thành!");
                return;
            }

            string maDon = dgvDonHang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
            var don = _allOrders.FirstOrDefault(x => x.MaDonHang == maDon);

            if (don == null) return;

            if (MessageBox.Show($"Xác nhận hoàn thành đơn {maDon}?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            var update = Builders<DonHang_DTO>.Update
                .Set(x => x.TrangThai, "Hoàn thành")
                .Set(x => x.NgayCapNhatCuoi, DateTime.UtcNow);

            await _donHangCollection.UpdateOneAsync(x => x.Id == don.Id, update);

            don.TrangThai = "Hoàn thành";
            don.NgayCapNhatCuoi = DateTime.UtcNow;

            ApplyFilters();

            MessageBox.Show("Cập nhật thành công!");
        }

        // ------------------ XUẤT CSV ------------------
        private void BtnXuatCSV_Click(object sender, EventArgs e)
        {
            if (_filteredOrders.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "CSV|*.csv",
                FileName = "DonHang_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            List<string> lines = new List<string>();
            lines.Add("MaDonHang,SoLuong,TongTien,TrangThai,NgayCapNhat");

            foreach (var d in _filteredOrders)
            {
                lines.Add($"{d.MaDonHang},{d.TongSoLuongSanPham},{d.TongTien},{d.TrangThai},{d.NgayCapNhatCuoi.ToLocalTime():dd/MM/yyyy HH:mm}");
            }

            File.WriteAllLines(sfd.FileName, lines, new System.Text.UTF8Encoding(true));

            MessageBox.Show("Xuất CSV thành công!");
        }

        // ------------------ THANH TOÁN ------------------
        private async void Btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 đơn để thanh toán!");
                return;
            }

            string maDon = dgvDonHang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
            var don = _allOrders.FirstOrDefault(x => x.MaDonHang == maDon);

            if (don == null) return;

            if (MessageBox.Show($"Xác nhận thanh toán và hoàn thành đơn {maDon}?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                var update = Builders<DonHang_DTO>.Update
                    .Set(x => x.TrangThai, "Đã thanh toán")
                    .Set(x => x.DaThanhToan, true)
                    .Set(x => x.NgayCapNhatCuoi, DateTime.UtcNow);

                await _donHangCollection.UpdateOneAsync(x => x.Id == don.Id, update);

                // Cập nhật trong danh sách cục bộ
                don.TrangThai = "Đã thanh toán";
                don.DaThanhToan = true;
                don.NgayCapNhatCuoi = DateTime.UtcNow;

                ApplyFilters();

                MessageBox.Show("Thanh toán và cập nhật trạng thái thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đơn: " + ex.Message);
            }
        }


        // ------------------ XEM THÔNG TIN SHIPPER ------------------
        private void btnThongTinShipper_Click(object sender, EventArgs e)
        {

            var aboutForm = new Shipper_About(_shipper); // nếu form có constructor nhận NguoiDung_DTO
            aboutForm.ShowDialog();
        }

        // ------------------ ĐĂNG XUẤT ------------------
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new Shipper_FormDangNhap().Show();
            }
        }

        private async void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 đơn để hủy!");
                return;
            }

            string maDon = dgvDonHang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
            var don = _allOrders.FirstOrDefault(x => x.MaDonHang == maDon);

            if (don == null) return;

            // Nhập lý do hủy
            string ghiChu = NhapLyDoHuy();
            if (string.IsNullOrEmpty(ghiChu))
            {
                MessageBox.Show("Bạn phải nhập lý do hủy đơn!");
                return;
            }

            if (MessageBox.Show($"Xác nhận hủy đơn {maDon}?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                // Cập nhật MongoDB
                var update = Builders<DonHang_DTO>.Update
                    .Set(x => x.TrangThai, "Đã hủy")
                    .Set(x => x.GhiChuDonHang, ghiChu)
                    .Set(x => x.NgayCapNhatCuoi, DateTime.UtcNow);

                await _donHangCollection.UpdateOneAsync(x => x.Id == don.Id, update);

                // Cập nhật danh sách cục bộ
                don.TrangThai = "Đã hủy";
                don.GhiChuDonHang = ghiChu;
                don.NgayCapNhatCuoi = DateTime.UtcNow;

                ApplyFilters(); // refresh Grid

                MessageBox.Show("Hủy đơn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy đơn: " + ex.Message);
            }
        }

        private string NhapLyDoHuy()
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 220,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Nhập lý do hủy đơn",
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = System.Drawing.Color.White
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = "Vui lòng nhập lý do hủy đơn:",
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            };

            TextBox inputBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 340,
                Height = 70,
                Multiline = true,
                Font = new System.Drawing.Font("Segoe UI", 9),
                ScrollBars = ScrollBars.Vertical
            };

            Button confirmation = new Button()
            {
                Text = "Xác nhận",
                Width = 100,
                Height = 35,
                Left = (prompt.ClientSize.Width - 100) / 2,
                Top = 140,
                BackColor = System.Drawing.Color.LightSeaGreen,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK,
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)
            };
            confirmation.FlatAppearance.BorderSize = 0;

            prompt.AcceptButton = confirmation;
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text.Trim() : null;
        }




    }
}
