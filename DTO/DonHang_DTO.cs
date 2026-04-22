using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DTO
{
    [BsonIgnoreExtraElements]
    public class DonHang_DTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("maDonHang")]
        public string MaDonHang { get; set; }

        // ======== LIÊN KẾT NGƯỜI DÙNG ========

        [BsonElement("idNguoiGui")]
        public ObjectId IdNguoiGui { get; set; }

        [BsonElement("idNguoiNhan")]
        public ObjectId IdNguoiNhan { get; set; }

        [BsonElement("idNguoiPhuTrach")]
        public ObjectId IdNguoiPhuTrach { get; set; }

        // ======== SNAPSHOT THÔNG TIN NGƯỜI GỬI / NHẬN ========
        // Lưu lại để đơn hàng không bị sai khi người dùng đổi địa chỉ sau này

        [BsonElement("nguoiGuiThongTin")]
        public NguoiDungThongTinSnapshot NguoiGuiThongTin { get; set; }

        [BsonElement("nguoiNhanThongTin")]
        public NguoiDungThongTinSnapshot NguoiNhanThongTin { get; set; }

        [BsonElement("nguoiPhuTrachTen")]
        public string NguoiPhuTrachTen { get; set; }

        // ======== SẢN PHẨM ========

        [BsonElement("danhSachSanPham")]
        public List<SanPham_DTO> DanhSachSanPham { get; set; }

        [BsonElement("tongSoLuongSanPham")]
        public int TongSoLuongSanPham { get; set; }

        [BsonElement("tongTrongLuong")]
        public double TongTrongLuong { get; set; }

        [BsonElement("tongGiaTriSanPham")]
        public decimal TongGiaTriSanPham { get; set; }

        // ======== TÀI CHÍNH ========

        [BsonElement("phiVanChuyen")]
        public decimal PhiVanChuyen { get; set; }

        [BsonElement("tongTien")]
        public decimal TongTien { get; set; }

        [BsonElement("hinhThucThanhToan")]
        public string HinhThucThanhToan { get; set; }

        [BsonElement("daThanhToan")]
        public bool DaThanhToan { get; set; }

        // ======== TRẠNG THÁI / NGÀY THÁNG ========

        [BsonElement("trangThai")]
        public string TrangThai { get; set; }

        [BsonElement("ngayTaoDon")]
        public DateTime NgayTaoDon { get; set; }

        [BsonElement("ngayCapNhatCuoi")]
        public DateTime NgayCapNhatCuoi { get; set; }

        // ======== GHI CHÚ / ĐÁNH GIÁ ========

        [BsonElement("ghiChuDonHang")]
        public string GhiChuDonHang { get; set; }

        [BsonElement("yeuCauDacBiet")]
        public string YeuCauDacBiet { get; set; }

        [BsonElement("diemDichVu")]
        public int DiemDichVu { get; set; }

        [BsonElement("binhLuanDichVu")]
        public string BinhLuanDichVu { get; set; }

        [BsonElement("ngayDanhGiaDichVu")]
        public DateTime NgayDanhGiaDichVu { get; set; }

        // ======== CONSTRUCTOR ========

        public DonHang_DTO()
        {
            DanhSachSanPham = new List<SanPham_DTO>();
            NguoiGuiThongTin = new NguoiDungThongTinSnapshot();
            NguoiNhanThongTin = new NguoiDungThongTinSnapshot();
            NgayTaoDon = DateTime.Now;
            NgayCapNhatCuoi = DateTime.Now;
            TrangThai = "Mới tạo";
        }
    }

    // === LỚP SNAPSHOT GIỮ LẠI THÔNG TIN NGƯỜI DÙNG TẠI THỜI ĐIỂM TẠO ĐƠN ===
    public class NguoiDungThongTinSnapshot
    {
        [BsonElement("hoTen")]
        public string HoTen { get; set; }

        [BsonElement("soDienThoai")]
        public string SoDienThoai { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("diaChiChiTiet")]
        public string DiaChiChiTiet { get; set; }

        [BsonElement("phuongXa")]
        public string PhuongXa { get; set; }

        [BsonElement("quanHuyen")]
        public string QuanHuyen { get; set; }

        [BsonElement("tinhThanh")]
        public string TinhThanh { get; set; }
    }
}
