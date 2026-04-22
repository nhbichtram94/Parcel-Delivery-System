using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHang_DAL
    {
        private readonly IMongoCollection<DonHang_DTO> _donHangCollection;

        private static readonly string[] TrangThaiHopLe =
      {
    "Mới tạo",
    "Đang xử lý",
    "Đang giao",
    "Hoàn thành",
    "Đã hủy",
    "Đã hoàn tiền"
};

        public DonHang_DAL()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GiaoNhanBuuPham");
            _donHangCollection = database.GetCollection<DonHang_DTO>("DonHang");
        }
        public IMongoCollection<DonHang_DTO> GetDonHangCollection()
        {
            return _donHangCollection;
        }

        // Lấy toàn bộ đơn hàng
        public async Task<List<DonHang_DTO>> LayTatCaDonHangAsync()
        {
            return await _donHangCollection.Find(_ => true).ToListAsync();
        }


        // Cập nhật trạng thái
        public async Task<bool> CapNhatTrangThaiDonHangAsync(ObjectId donHangId, string trangThaiMoi)
        {
            if (!TrangThaiHopLe.Contains(trangThaiMoi))
                throw new ArgumentException("Trạng thái đơn hàng không hợp lệ.");

            var update = Builders<DonHang_DTO>.Update
                .Set(d => d.TrangThai, trangThaiMoi)
                .Set(d => d.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _donHangCollection.UpdateOneAsync(d => d.Id == donHangId, update);
            return result.ModifiedCount > 0;
        }

        // Lấy danh sách đơn hàng theo trạng thái + id khách hàng
        // Lấy danh sách đơn hàng theo trạng thái + id người gửi (khách hàng)
        public async Task<List<DonHang_DTO>> GetDonHangsByTrangThaiAsync(string trangThai, ObjectId nguoiGuiId)
        {
            var filter = Builders<DonHang_DTO>.Filter.And(
                Builders<DonHang_DTO>.Filter.Eq(dh => dh.TrangThai, trangThai),
                Builders<DonHang_DTO>.Filter.Eq(dh => dh.IdNguoiGui, nguoiGuiId)
            );

            return await _donHangCollection.Find(filter).ToListAsync();
        }

        // Lấy chi tiết sản phẩm trong đơn hàng
        public async Task<List<SanPham_DTO>> GetChiTietDonHangAsync(ObjectId donHangId)
        {
            var donHang = await _donHangCollection
                .Find(dh => dh.Id == donHangId)
                .FirstOrDefaultAsync();

            return donHang?.DanhSachSanPham ?? new List<SanPham_DTO>();
        }

        // Hủy đơn hàng
        public async Task<bool> HuyDonHangAsync(ObjectId donHangId)
        {
            var update = Builders<DonHang_DTO>.Update
                .Set(dh => dh.TrangThai, "Đã hủy")
                .Set(dh => dh.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _donHangCollection.UpdateOneAsync(
                dh => dh.Id == donHangId,  // so sánh trực tiếp vì giờ cùng kiểu ObjectId
                update
            );

            return result.ModifiedCount > 0;
        }

        // Thêm đơn hàng mới
        public async Task<bool> TaoDonHangAsync(DonHang_DTO donHang)
        {
            try
            {
                await _donHangCollection.InsertOneAsync(donHang);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // tìm kiếm,lọc theo trạng thái hoặc từ khóa
        public async Task<List<DonHang_DTO>> TimKiemDonHangAsync(string keyword, string trangThai)
        {
            var filter = Builders<DonHang_DTO>.Filter.Empty;

            if (!string.IsNullOrEmpty(keyword))
            {
                filter = Builders<DonHang_DTO>.Filter.Regex(d => d.MaDonHang, new BsonRegularExpression(keyword, "i"));
            }

            if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
            {
                var statusFilter = Builders<DonHang_DTO>.Filter.Eq(d => d.TrangThai, trangThai);
                filter = Builders<DonHang_DTO>.Filter.And(filter, statusFilter);
            }

            return await _donHangCollection.Find(filter).ToListAsync();
        }

        // Tìm đơn hàng theo số điện thoại người gửi và ngày tạo đơn
        public async Task<List<DonHang_DTO>> LayDonHangTheoSDTvaNgayAsync(string soDienThoai, DateTime ngay)
        {
            var builder = Builders<DonHang_DTO>.Filter;

            var filter = builder.And(
                builder.Eq("thongTinNguoiGui.soDienThoai", soDienThoai),
                builder.Gte(dh => dh.NgayTaoDon, ngay.Date),          // từ 00:00 của ngày
                builder.Lt(dh => dh.NgayTaoDon, ngay.Date.AddDays(1)) // đến 23:59:59
            );

            var result = await _donHangCollection.Find(filter).ToListAsync();
            return result;
        }
        public async Task<List<DonHang_DTO>> TimDonHangDonLeAsync(
    string soDienThoai,
    string maDonHang,
    DateTime? ngay,
     bool? daThanhToan)
        {
            var builder = Builders<DonHang_DTO>.Filter;
            var filters = new List<FilterDefinition<DonHang_DTO>>();

            // 1️ Nếu có số điện thoại
            if (!string.IsNullOrEmpty(soDienThoai))
            {
                filters.Add(builder.Or(
                    builder.Eq("nguoiGuiThongTin.soDienThoai", soDienThoai)
                ));
            }

            // 2️ Nếu có mã đơn hàng
            if (!string.IsNullOrEmpty(maDonHang))
                filters.Add(builder.Regex(d => d.MaDonHang, new BsonRegularExpression(maDonHang, "i")));

            // 3️ Nếu có ngày
            if (ngay.HasValue)
            {
                filters.Add(builder.Gte(d => d.NgayTaoDon, ngay.Value.Date));
                filters.Add(builder.Lt(d => d.NgayTaoDon, ngay.Value.Date.AddDays(1)));
            }


            // 5 Lọc theo tình trạng thanh toán
            if (daThanhToan.HasValue)
            {
                if (daThanhToan.Value)
                {
                    // ✅ Lấy những đơn có DaThanhToan = true
                    filters.Add(builder.Eq(d => d.DaThanhToan, true));
                }
                else
                {
                    // ✅ Lấy những đơn chưa thanh toán (false hoặc chưa có field)
                    var filterFalse = builder.Eq(d => d.DaThanhToan, false);
                    var filterNull = builder.Exists("daThanhToan", false);
                    filters.Add(builder.Or(filterFalse, filterNull));
                }
            }


            if (filters.Count == 0)
                throw new ArgumentException("Cần ít nhất 1 tiêu chí tìm kiếm (SĐT hoặc Mã đơn hàng).");

            var combinedFilter = builder.And(filters);
            return await _donHangCollection.Find(combinedFilter).ToListAsync();
        }

        public async Task<List<DonHang_DTO>> TimDonHangTheoKhoangThoiGianAsync(
    DateTime ngayBatDau,
    DateTime ngayKetThuc,
    string soDienThoai,
    string maDonHang,
     bool? daThanhToan)
        {
            var builder = Builders<DonHang_DTO>.Filter;
            var filters = new List<FilterDefinition<DonHang_DTO>>();

            // 1️ Lọc theo khoảng thời gian
            filters.Add(builder.Gte(d => d.NgayTaoDon, ngayBatDau.Date));
            filters.Add(builder.Lt(d => d.NgayTaoDon, ngayKetThuc.Date.AddDays(1)));

            // 2️ Nếu có SĐT
            if (!string.IsNullOrEmpty(soDienThoai))
            {
                filters.Add(builder.Or(
                    builder.Eq("nguoiGuiThongTin.soDienThoai", soDienThoai)
                ));
            }

            // 3️⃣ Nếu có mã đơn hàng
            if (!string.IsNullOrEmpty(maDonHang))
                filters.Add(builder.Regex(d => d.MaDonHang, new BsonRegularExpression(maDonHang, "i")));

            //// 4️⃣ Nếu có trạng thái
            //if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
            //    filters.Add(builder.Eq(d => d.TrangThai, trangThai));

            // 50 Lọc theo tình trạng thanh toán
            if (daThanhToan.HasValue)
            {
                if (daThanhToan.Value)
                {
                    // ✅ Lấy những đơn có DaThanhToan = true
                    filters.Add(builder.Eq(d => d.DaThanhToan, true));
                }
                else
                {
                    // ✅ Lấy những đơn chưa thanh toán (false hoặc chưa có field)
                    var filterFalse = builder.Eq(d => d.DaThanhToan, false);
                    var filterNull = builder.Exists("daThanhToan", false);
                    filters.Add(builder.Or(filterFalse, filterNull));
                }
            }


            var combinedFilter = builder.And(filters);
            return await _donHangCollection.Find(combinedFilter).ToListAsync();
        }

        // Tìm kiếm nâng cao theo tất cả textbox
        public async Task<List<DonHang_DTO>> TimKiemNangCaoAsync(
                   string maDonHang,

                   string sdtNguoiGui,

                   string sdtNguoiNhan,
                   string trangThai,
                   DateTime? tuNgay,
                   DateTime? denNgay,
                   bool? daThanhToan)
        {
            var builder = Builders<DonHang_DTO>.Filter;
            var filters = new List<FilterDefinition<DonHang_DTO>>();

            // 1️⃣ Mã đơn hàng
            if (!string.IsNullOrEmpty(maDonHang))
                filters.Add(builder.Regex(d => d.MaDonHang, new BsonRegularExpression(maDonHang, "i")));

            // 3️⃣ SĐT người gửi
            if (!string.IsNullOrEmpty(sdtNguoiGui))
                filters.Add(builder.Eq("nguoiGuiThongTin.soDienThoai", sdtNguoiGui));

            // 5️⃣ SĐT người nhận
            if (!string.IsNullOrEmpty(sdtNguoiNhan))
                filters.Add(builder.Eq("nguoiNhanThongTin.soDienThoai", sdtNguoiNhan));

            // 6️⃣ Trạng thái
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
                filters.Add(builder.Eq(d => d.TrangThai, trangThai));

            // 7️⃣ Khoảng ngày
            if (tuNgay.HasValue)
                filters.Add(builder.Gte(d => d.NgayTaoDon, tuNgay.Value.Date));
            if (denNgay.HasValue)
                filters.Add(builder.Lt(d => d.NgayTaoDon, denNgay.Value.Date.AddDays(1)));

            // 8️⃣ DaThanhToan
            if (daThanhToan.HasValue)
            {
                if (daThanhToan.Value)
                    filters.Add(builder.Eq(d => d.DaThanhToan, true));
                else
                    filters.Add(builder.Or(
                        builder.Eq(d => d.DaThanhToan, false),
                        builder.Exists("daThanhToan", false)
                    ));
            }

            var combinedFilter = filters.Count > 0 ? builder.And(filters) : builder.Empty;
            return await _donHangCollection.Find(combinedFilter).ToListAsync();
        }

        // Lấy danh sách đơn hàng theo mã người gửi (chuỗi)
        public async Task<List<DonHang_DTO>> LayDonHangTheoNguoiGuiAsync(string maNguoiGui)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maNguoiGui))
                    return new List<DonHang_DTO>();

                // Chuyển string sang ObjectId
                var objectId = new ObjectId(maNguoiGui);

                var filter = Builders<DonHang_DTO>.Filter.Eq(d => d.IdNguoiGui, objectId);
                var donHangs = await _donHangCollection.Find(filter).ToListAsync();

                return donHangs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Lỗi khi truy vấn đơn hàng: {ex.Message}");
                return new List<DonHang_DTO>();
            }
        }
        public async Task<bool> CapNhatDonHangAsync(DonHang_DTO donHang)
        {
            try
            {
                var filter = Builders<DonHang_DTO>.Filter.Eq(x => x.Id, donHang.Id);
                var result = await _donHangCollection.ReplaceOneAsync(filter, donHang);
                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL: " + ex.Message);
                return false;
            }
        }
        // ===============================
        // Lấy đơn theo shipper
        // ===============================
        public async Task<List<DonHang_DTO>> GetDonHangByShipper(string shipperId)
        {
            // Tạm thời: shipper xem các đơn đang giao
            var filter = Builders<DonHang_DTO>.Filter.Eq(d => d.TrangThai, "Đang giao");

            return await _donHangCollection.Find(filter).ToListAsync();
        }

        // ===============================
        // Đánh dấu hoàn thành đơn hàng
        // ===============================
        public async Task<bool> MarkAsCompleted(ObjectId id)
        {
            var update = Builders<DonHang_DTO>.Update
                .Set(d => d.TrangThai, "Hoàn thành")
                .Set(d => d.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _donHangCollection.UpdateOneAsync(d => d.Id == id, update);

            return result.ModifiedCount > 0;
        }
        /// <summary>
        /// Hủy đơn hàng và lưu ghi chú (lý do hủy)
        /// </summary>
        public async Task<bool> HuyDonHangLDAsync(ObjectId donHangId, string ghiChu)
        {
            var update = Builders<DonHang_DTO>.Update
                .Set(dh => dh.TrangThai, "Đã hủy")           // cập nhật trạng thái
                .Set(dh => dh.GhiChuDonHang, ghiChu)         // lưu lý do vào ghi chú
                .Set(dh => dh.NgayCapNhatCuoi, DateTime.UtcNow); // cập nhật thời gian

            var result = await _donHangCollection.UpdateOneAsync(
                dh => dh.Id == donHangId,
                update
            );

            return result.ModifiedCount > 0;
        }




    }

}


