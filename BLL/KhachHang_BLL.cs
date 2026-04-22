using DAL;
using DTO;
using MongoDB.Driver;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHang_BLL
    {
        private readonly KhachHang_DAL _dal = new KhachHang_DAL();

        // ✅ Đăng nhập
        public async Task<NguoiDung_DTO> DangNhapAsync(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new ArgumentException("Tên đăng nhập không được để trống.");

            if (string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Mật khẩu không được để trống.");

            var khachHang = await _dal.DangNhapAsync(tenDangNhap, matKhau);

            if (khachHang == null)
                throw new UnauthorizedAccessException("Sai tài khoản hoặc mật khẩu.");

            return khachHang;
        }

        // ✅ Đăng ký
        public async Task<bool> DangKyAsync(NguoiDung_DTO khachHang, string tenDangNhap, string matKhau)
        {
            if (khachHang == null)
                throw new ArgumentException("Thông tin khách hàng không được để trống.");

            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new ArgumentException("Tên đăng nhập không được để trống.");

            if (string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Mật khẩu không được để trống.");

            if (matKhau.Length < 6)
                throw new ArgumentException("Mật khẩu phải có ít nhất 6 ký tự.");

            if (string.IsNullOrWhiteSpace(khachHang.Email))
                throw new ArgumentException("Email không được để trống.");

            if (!IsValidEmail(khachHang.Email))
                throw new ArgumentException("Email không hợp lệ.");

            bool isRegistered = await _dal.DangKyAsync(khachHang, tenDangNhap, matKhau);

            if (!isRegistered)
                throw new InvalidOperationException("Tên đăng nhập hoặc email đã tồn tại.");

            return true;
        }

        // ✅ Tìm theo tài khoản + email
        public async Task<NguoiDung_DTO> LayTheoTaiKhoanVaEmailAsync(string tenDangNhap, string email)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new ArgumentException("Tên đăng nhập không được để trống.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email không được để trống.");

            if (!IsValidEmail(email))
                throw new ArgumentException("Định dạng email không hợp lệ.");

            var kh = await _dal.LayTheoTaiKhoanVaEmailAsync(tenDangNhap, email);

            if (kh == null)
                throw new InvalidOperationException("Không tìm thấy tài khoản hoặc email không khớp.");

            return kh;
        }

        // Tìm người dùng theo Email hoặc TenDangNhap
     
        // ✅ Kiểm tra số điện thoại tồn tại
        public async Task<bool> KiemTraTonTaiSDTAsync(string soDienThoai)
        {
            var kh = await _dal.GetBySoDienThoaiAsync(soDienThoai);
            return kh != null;
        }

        // ✅ Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CapNhatMatKhauAsync(string tenDangNhap, string matKhauMoi)
        {
            return await _dal.CapNhatMatKhauAsync(tenDangNhap, matKhauMoi);
        }




    }
}
