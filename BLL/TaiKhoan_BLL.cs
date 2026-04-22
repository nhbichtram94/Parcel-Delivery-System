using DAL;
using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoan_BLL
    {
        private readonly TaiKhoan_DAL _dal = new TaiKhoan_DAL();

        // 🔒 Hàm mã hóa mật khẩu (nếu muốn bật lại sau)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // 🧾 Lấy toàn bộ tài khoản (người dùng)
        public async Task<List<NguoiDung_DTO>> LayTatCaTaiKhoanAsync() =>
            await _dal.GetAllAsync();

        // ➕ Thêm tài khoản (thực chất là thêm người dùng)
        public async Task<bool> ThemTaiKhoanAsync(NguoiDung_DTO tk)
        {
            // tk.MatKhauHash = HashPassword(tk.MatKhauHash); // bật nếu cần mã hóa
            tk.NgayTao = tk.NgayCapNhatCuoi = DateTime.UtcNow;
            await _dal.CreateAsync(tk);
            return true;
        }

        // ✏️ Cập nhật thông tin tài khoản (người dùng)
        public async Task<bool> CapNhatTaiKhoanAsync(NguoiDung_DTO tk)
        {
            tk.NgayCapNhatCuoi = DateTime.UtcNow;
            return await _dal.UpdateAsync(tk.Id, tk);
        }

        // ❌ Xóa tài khoản
        public async Task<bool> XoaTaiKhoanAsync(ObjectId id) =>
            await _dal.DeleteAsync(id);

        // 🔒 Khóa / mở khóa tài khoản
        public async Task<bool> DatTrangThaiTaiKhoanAsync(ObjectId id, bool trangThai) =>
            await _dal.SetTrangThaiAsync(id, trangThai);

        // 🔍 Kiểm tra tên đăng nhập đã tồn tại chưa
        public async Task<bool> KiemTraTonTaiTaiKhoanAsync(string tenDangNhap)
        {
            var tk = await _dal.GetByTenDangNhapAsync(tenDangNhap);
            return tk != null;
        }

        // 🔍 Lấy tài khoản theo ID người dùng
    
    }
}
