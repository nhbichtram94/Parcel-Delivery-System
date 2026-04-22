using MongoDB.Bson.Serialization.Attributes;

namespace DTO
{
    public class SanPham_DTO
    {
        [BsonElement("MaSanPham")]
        public string MaSanPham { get; set; }

        [BsonElement("tenSanPham")]
        public string TenSanPham { get; set; }

        [BsonElement("soLuong")]
        public int SoLuong { get; set; }

        [BsonElement("trongLuong")]
        public double TrongLuong { get; set; }

        [BsonElement("giaTri")]
        public decimal GiaTri { get; set; }

        [BsonElement("ghiChu")]
        public string GhiChu { get; set; }
    }
}
