using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHang_DAL
    {
        private readonly IMongoCollection<NguoiDung_DTO> _nguoiDungCollection;

        public KhachHang_DAL()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GiaoNhanBuuPham");
            _nguoiDungCollection = database.GetCollection<NguoiDung_DTO>("NguoiDung");
        }

        // ✅ Đăng nhập khách hàng
        public async Task<NguoiDung_DTO> DangNhapAsync(string tenDangNhap, string matKhau)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.TenDangNhap, tenDangNhap)
                        & Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.MatKhauHash, matKhau)
                        & Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "KhachHang")
                        & Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.TrangThai, true);

            return await _nguoiDungCollection.Find(filter).FirstOrDefaultAsync();
        }

        // ✅ Đăng ký khách hàng
        // ✅ Đăng ký khách hàng
        public async Task<bool> DangKyAsync(NguoiDung_DTO nguoiDung, string tenDangNhap, string matKhau)
        {
            // Kiểm tra trùng tài khoản hoặc email
            var tonTai = await _nguoiDungCollection.Find(nd =>
                nd.TenDangNhap == tenDangNhap || nd.Email == nguoiDung.Email
            ).FirstOrDefaultAsync();

            if (tonTai != null)
                return false;

            // Thiết lập thông tin mặc định
            nguoiDung.Id = MongoDB.Bson.ObjectId.GenerateNewId();
            nguoiDung.TenDangNhap = tenDangNhap;
            nguoiDung.MatKhauHash = matKhau; // Có thể mã hoá SHA256 nếu muốn
            nguoiDung.TrangThai = true;
            nguoiDung.PhanQuyen = "KhachHang";
            nguoiDung.LoaiNguoiDung = "KhachHang";
            nguoiDung.NgayTao = DateTime.UtcNow;
            nguoiDung.NgayCapNhatCuoi = DateTime.UtcNow;

            // Gán mặc định (tương thích C# 7.3)
            if (nguoiDung.ChucVu == null) nguoiDung.ChucVu = "";
            if (nguoiDung.KhuVucPhuTrach == null) nguoiDung.KhuVucPhuTrach = "";
            if (nguoiDung.TrangThaiShipper == null) nguoiDung.TrangThaiShipper = "";
            if (nguoiDung.SoLuongDonHangDangGiao == null) nguoiDung.SoLuongDonHangDangGiao = 0;
            if (nguoiDung.GioBatDauLamViec == default(TimeSpan)) nguoiDung.GioBatDauLamViec = new TimeSpan(8, 0, 0);
            if (nguoiDung.GioKetThucLamViec == default(TimeSpan)) nguoiDung.GioKetThucLamViec = new TimeSpan(17, 0, 0);

            // Lưu MongoDB
            await _nguoiDungCollection.InsertOneAsync(nguoiDung);
            return true;
        }



        // ✅ Lấy thông tin khách hàng theo tài khoản + email
        public async Task<NguoiDung_DTO> LayTheoTaiKhoanVaEmailAsync(string tenDangNhap, string email)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.TenDangNhap, tenDangNhap)
                        & Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.Email, email)
                        & Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "KhachHang");

            return await _nguoiDungCollection.Find(filter).FirstOrDefaultAsync();
        }

        // ✅ Kiểm tra tồn tại số điện thoại
        public async Task<NguoiDung_DTO> GetBySoDienThoaiAsync(string soDienThoai)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.SoDienThoai, soDienThoai)
                        & Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "KhachHang");

            return await _nguoiDungCollection.Find(filter).FirstOrDefaultAsync();
        }

        // ✅ Lấy danh sách tất cả khách hàng
        public async Task<List<NguoiDung_DTO>> LayTatCaKhachHangAsync()
        {
            var filter = Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "KhachHang");
            return await _nguoiDungCollection.Find(filter).ToListAsync();
        }

        // ✅ Cập nhật mật khẩu mới cho khách hàng
        public async Task<bool> CapNhatMatKhauAsync(string tenDangNhap, string matKhauMoi)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.TenDangNhap, tenDangNhap)
                         & Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "KhachHang");

            var update = Builders<NguoiDung_DTO>.Update
                .Set(nd => nd.MatKhauHash, matKhauMoi) // Nếu bạn có hash thì hash trước khi set
                .Set(nd => nd.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _nguoiDungCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

    }
}
