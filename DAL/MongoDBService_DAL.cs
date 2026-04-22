using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DTO;

namespace DAL
{
    public class MongoDBService
    {
        private readonly IMongoCollection<DonHang_DTO> _donHangCollection;

        // Khai báo trạng thái theo thứ tự
        private static readonly List<string> TrangThaiOrder = new List<string>
        { "Mới tạo", "Chờ xử lý", "Đang xử lý", "Đang giao", "Đã giao", "Đã hủy" };
      
        public MongoDBService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GiaoNhanBuuPham");
            _donHangCollection = database.GetCollection<DonHang_DTO>("DonHang");
        }

        // Lấy tất cả đơn hàng
        public async Task<List<DonHang_DTO>> LayTatCaDonHang()
        {
            return await _donHangCollection.Find(Builders<DonHang_DTO>.Filter.Empty).ToListAsync();
        }

        // Tạo mới đơn hàng
        public async Task TaoDonHang(DonHang_DTO donHang)
        {
            if (donHang == null)
                throw new ArgumentNullException(nameof(donHang));

            await _donHangCollection.InsertOneAsync(donHang);
        }

        // Lấy đơn hàng của khách hàng theo Id
        public async Task<List<DonHang_DTO>> LayDonHangTheoKhach(ObjectId idNguoiGui)
        {
            var filter = Builders<DonHang_DTO>.Filter.Eq(dh => dh.IdNguoiGui, idNguoiGui);
            return await _donHangCollection.Find(filter).ToListAsync();

        }

        // Cập nhật trạng thái đơn hàng
        public async Task<bool> CapNhatTrangThaiDonHangAsync(ObjectId idDonHang, string trangThaiMoi)
        {
            if (string.IsNullOrEmpty(trangThaiMoi))
                throw new ArgumentException("Trạng thái mới không được để trống.", nameof(trangThaiMoi));

            var donHang = await _donHangCollection.Find(dh => dh.Id == idDonHang).FirstOrDefaultAsync();
            if (donHang == null)
                throw new Exception("Đơn hàng không tồn tại.");

            int currentIndex = TrangThaiOrder.IndexOf(donHang.TrangThai);
            int newIndex = TrangThaiOrder.IndexOf(trangThaiMoi);

            if (newIndex == -1)
                throw new Exception("Trạng thái mới không hợp lệ.");

            // Không cho phép cập nhật trạng thái lùi lại
            if (newIndex < currentIndex)
                return false;

            var filter = Builders<DonHang_DTO>.Filter.Eq(dh => dh.Id, idDonHang);
            var update = Builders<DonHang_DTO>.Update.Set(dh => dh.TrangThai, trangThaiMoi);

            var result = await _donHangCollection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }

        // Lấy chi tiết một đơn hàng
        public async Task<DonHang_DTO> LayChiTietDonHang(ObjectId idDonHang)
        {
            var filter = Builders<DonHang_DTO>.Filter.Eq(dh => dh.Id, idDonHang);
            return await _donHangCollection.Find(filter).FirstOrDefaultAsync();
        }

        // Lấy danh sách đơn hàng theo trạng thái và khách hàng
        public async Task<List<DonHang_DTO>> GetDonHangsByTrangThaiAsync(string trangThai, ObjectId khachHangId)
        {
            var filter = Builders<DonHang_DTO>.Filter.Eq(dh => dh.TrangThai, trangThai) &
                         Builders<DonHang_DTO>.Filter.Eq(dh => dh.IdNguoiGui, khachHangId);

            return await _donHangCollection.Find(filter).ToListAsync();
        }

        // Lấy danh sách sản phẩm trong đơn hàng theo Id đơn hàng
        public async Task<List<SanPham_DTO>> GetChiTietDonHangAsync(ObjectId donHangId)
        {
            var donHang = await _donHangCollection.Find(dh => dh.Id == donHangId).FirstOrDefaultAsync();
            return donHang?.DanhSachSanPham ?? new List<SanPham_DTO>();
        }

        // Hủy đơn hàng (cập nhật trạng thái "Đã hủy")
        public async Task<bool> HuyDonHangAsync(ObjectId idDonHang)
        {
            var donHang = await _donHangCollection.Find(dh => dh.Id == idDonHang).FirstOrDefaultAsync();
            if (donHang == null)
                throw new Exception("Đơn hàng không tồn tại.");

            if (donHang.TrangThai == "Đã hủy" || donHang.TrangThai == "Đã giao")
                return false; // Không thể hủy nếu đã giao hoặc đã hủy rồi

            var filter = Builders<DonHang_DTO>.Filter.Eq(dh => dh.Id, idDonHang);
            var update = Builders<DonHang_DTO>.Update.Set(dh => dh.TrangThai, "Đã hủy");

            var result = await _donHangCollection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }
        /// Form phân công
        // Hàm phân công nhân viên phụ trách đơn hàng
        public async Task<bool> PhanCongNguoiPhuTrachAsync(ObjectId idDonHang, ObjectId idNguoiPhuTrach, string tenNguoiPhuTrach)
        {
            if (idNguoiPhuTrach == ObjectId.Empty)
                throw new ArgumentException("Id người phụ trách không hợp lệ.", nameof(idNguoiPhuTrach));

            var donHang = await _donHangCollection
                .Find(dh => dh.Id == idDonHang)
                .FirstOrDefaultAsync();

            if (donHang == null)
                throw new Exception("Đơn hàng không tồn tại.");

            var filter = Builders<DonHang_DTO>.Filter.Eq(dh => dh.Id, idDonHang);

            var update = Builders<DonHang_DTO>.Update
                .Set(dh => dh.IdNguoiPhuTrach, idNguoiPhuTrach)
                .Set(dh => dh.NguoiPhuTrachTen, tenNguoiPhuTrach)
                .Set(dh => dh.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _donHangCollection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }

    }
}
