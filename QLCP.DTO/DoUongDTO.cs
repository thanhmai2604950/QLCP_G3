using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.DTO
{
    public class DoUongDTO
    {
        public string MaDU { get; set; } = "";
        public string TenDU { get; set; } = "";
        public string MaLoai { get; set; } = "";
        public string TenLoai { get; set; } = "";   // chỉ để hiển thị
        public decimal GiaNiemYet { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; } = true;
    }
}
