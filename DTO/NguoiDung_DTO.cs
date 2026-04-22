using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DTO
{
    [BsonIgnoreExtraElements]
    public class NguoiDung_DTO
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        // 🧍 Thông tin cá nhân
        [BsonElement("hoTen")] public string HoTen { get; set; }
        [BsonElement("soDienThoai")] public string SoDienThoai { get; set; }
        [BsonElement("email")] public string Email { get; set; }
        [BsonElement("diaChiChiTiet")] public string DiaChiChiTiet { get; set; }
        [BsonElement("phuongXa")] public string PhuongXa { get; set; }
        [BsonElement("quanHuyen")] public string QuanHuyen { get; set; }
        [BsonElement("tinhThanh")] public string TinhThanh { get; set; }

        // 🧩 Phân loại vai trò: "KhachHang" | "NhanVien" | "Admin"
        [BsonElement("loaiNguoiDung")] public string LoaiNguoiDung { get; set; }

        // 👷 Nếu là nhân viên
        [BsonElement("chucVu")] public string ChucVu { get; set; }                  // VD: "Shipper", "Nhân viên", ...
        [BsonElement("khuVucPhuTrach")] public string KhuVucPhuTrach { get; set; } // Khu vực giao hàng chính
        [BsonElement("trangThaiShipper")] public string TrangThaiShipper { get; set; } // "available", "busy", ...
        [BsonElement("soLuongDonHangDangGiao")] public int? SoLuongDonHangDangGiao { get; set; } = 0;

        // 🕒 Thời gian làm việc (phục vụ cho lọc shipper phù hợp)
        [BsonElement("gioBatDauLamViec")] public TimeSpan GioBatDauLamViec { get; set; } = new TimeSpan(8, 0, 0);  // 8:00 sáng
        [BsonElement("gioKetThucLamViec")] public TimeSpan GioKetThucLamViec { get; set; } = new TimeSpan(17, 0, 0); // 5:00 chiều

        // 🔐 Thông tin tài khoản đăng nhập
        [BsonElement("tenDangNhap")] public string TenDangNhap { get; set; }
        [BsonElement("matKhauHash")] public string MatKhauHash { get; set; }
        [BsonElement("phanQuyen")] public string PhanQuyen { get; set; }  // "admin", "staff", "customer"
        [BsonElement("trangThai")] public bool TrangThai { get; set; } = true;

        // 🕓 Dấu thời gian
        [BsonElement("ngayTao")] public DateTime NgayTao { get; set; } = DateTime.UtcNow;
        [BsonElement("ngayCapNhatCuoi")] public DateTime NgayCapNhatCuoi { get; set; } = DateTime.UtcNow;
    }
}
