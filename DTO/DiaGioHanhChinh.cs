using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTO
{
    // Tỉnh/Thành (provinces.open-api.vn.json)
    public class TinhThanh
    {
        [JsonProperty("code")] public int Code { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("districts")] public List<QuanHuyen> Districts { get; set; } = new List<QuanHuyen>();

        public override string ToString() => Name;
    }

    // Quận/Huyện
    public class QuanHuyen
    {
        [JsonProperty("code")] public int Code { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("wards")] public List<PhuongXa> Wards { get; set; } = new List<PhuongXa>();

        public override string ToString() => Name;
    }

    public class PhuongXa
    {
        [JsonProperty("code")] public int Code { get; set; }
        [JsonProperty("name")] public string Name { get; set; }

        public override string ToString() => Name;
    }
}
