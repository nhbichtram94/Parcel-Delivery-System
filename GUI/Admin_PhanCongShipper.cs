using BLL;
using DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Form quản lý phân công Shipper
    /// 🔑 Tối ưu hóa hiệu suất vận chuyển, tránh quá tải cho shipper
    /// </summary>
    public partial class Admin_PhanCongShipper : Form
    {
        private readonly PhanCongShipper_BLL _bll = new PhanCongShipper_BLL();
        private List<DonHang_DTO> _donHangs = new List<DonHang_DTO>();
        private List<NguoiDung_DTO> _shippers = new List<NguoiDung_DTO>();

        public Admin_PhanCongShipper()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeListView();

            dataGridViewPhanCong.CellMouseDown += dataGridViewPhanCong_CellMouseDown;
        }

        #region Initialization
        private void InitializeGrid()
        {
            dataGridViewDonHang.Columns.Clear();
            dataGridViewDonHang.AutoGenerateColumns = false;

            dataGridViewDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDonHang", HeaderText = "Mã Đơn Hàng", Width = 120 });
            dataGridViewDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongSoLuongSanPham", HeaderText = "Số SP", Width = 80 });
            dataGridViewDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongTien", HeaderText = "Tổng Tiền", Width = 120 });
            dataGridViewDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", Width = 100 });
        }

        private void InitializeListView()
        {
            listViewShippers.Columns.Clear();
            listViewShippers.Columns.Add("Mã Shipper", 100);
            listViewShippers.Columns.Add("Tên Shipper", 150);
            listViewShippers.Columns.Add("Trạng Thái", 100);
            listViewShippers.Columns.Add("Số Đơn", 80, HorizontalAlignment.Center);
        }

        private async void Admin_PhanCongShipper_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            InitializePhanCongGrid();
        }
        private void InitializePhanCongGrid()
        {
            dataGridViewPhanCong.Columns.Clear();
            dataGridViewPhanCong.AutoGenerateColumns = false;

            dataGridViewPhanCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Đơn Hàng", Width = 120 });
            dataGridViewPhanCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số SP", Width = 80 });
            dataGridViewPhanCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tổng Tiền", Width = 120 });
            dataGridViewPhanCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Shipper", Width = 150 });
            dataGridViewPhanCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Shipper", Width = 100 });
        }

        private async Task LoadDataAsync()
        {
            _donHangs = await _bll.LayDonHangDangXuLyAsync();
            _shippers = await _bll.LayTatCaShipperAsync();

            dataGridViewDonHang.DataSource = null;
            dataGridViewDonHang.DataSource = _donHangs;

            listViewShippers.Items.Clear();
            foreach (var s in _shippers)
            {
                // Cột đầu ListView: ưu tiên TenDangNhap, rồi HoTen, rồi Id
                var firstText = s.TenDangNhap ?? s.HoTen ?? s.Id.ToString();

                var item = new ListViewItem(firstText) { Tag = s };  // ⬅️ Tag cả object NguoiDung_DTO
                item.SubItems.Add(s.HoTen ?? "");                     // ⬅️ thay ThongTinNguoi?.Ten
                item.SubItems.Add(s.TrangThaiShipper);
                item.SubItems.Add(s.SoLuongDonHangDangGiao.ToString());
                listViewShippers.Items.Add(item);
            }
        }
        #endregion

        #region Button Events
        private void btnTaoPhanCong_Click(object sender, EventArgs e)
        {
            if (dataGridViewDonHang.SelectedRows.Count == 0 || listViewShippers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 đơn hàng và 1 shipper!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dataGridViewDonHang.SelectedRows)
            {
                var dh = (DonHang_DTO)row.DataBoundItem;
                // ⬇️ Tag đang là NguoiDung_DTO theo phần LoadDataAsync ở trên
                var shipper = (NguoiDung_DTO)listViewShippers.SelectedItems[0].Tag;

                // Thêm vào DataGridViewPhanCong
                dataGridViewPhanCong.Rows.Add(
                    dh.MaDonHang,
                    dh.TongSoLuongSanPham,
                    dh.TongTien,
                    shipper.HoTen ?? shipper.TenDangNhap ?? shipper.Id.ToString(),
                    shipper.Id // <-- lưu ObjectId
                );
            }
        }
        private async void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (dataGridViewPhanCong.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách phân công trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn phân công các đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int success = 0;
            foreach (DataGridViewRow row in dataGridViewPhanCong.Rows)
            {
                string maDonHang = row.Cells[0].Value.ToString();
                var dh = _donHangs.FirstOrDefault(d => d.MaDonHang == maDonHang);

                if (dh != null && row.Cells[4].Value is ObjectId shipperId)
                {
                    if (await _bll.PhanCongDonHangTheoShipperAsync(dh.Id, shipperId))
                        success++;
                }
            }

            MessageBox.Show($"Đã phân công thành công {success} đơn hàng.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
            dataGridViewPhanCong.Rows.Clear();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridViewPhanCong.Rows.Clear();
           
        }

       

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dataGridViewPhanCong.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "PhanCong.csv" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var lines = new List<string>();
                var headers = dataGridViewPhanCong.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText);
                lines.Add(string.Join(",", headers));

                foreach (DataGridViewRow row in dataGridViewPhanCong.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>().Select(c => c.Value?.ToString().Replace(",", " ") ?? "");
                    lines.Add(string.Join(",", cells));
                }

                System.IO.File.WriteAllLines(sfd.FileName, lines);
                MessageBox.Show("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region DataGridView ContextMenu
        private void dataGridViewPhanCong_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;

            dataGridViewPhanCong.ClearSelection();
            dataGridViewPhanCong.Rows[e.RowIndex].Selected = true;

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Xóa").Click += (s, ev) => dataGridViewPhanCong.Rows.RemoveAt(e.RowIndex);


            menu.Show(Cursor.Position);
        }

       
        #endregion
    }
}
