namespace QLCP.DTO
{
    public class TaiKhoanDTO
    {
        public string MaTK { get; set; } = "";
        public string TenDangNhap { get; set; } = "";
        public string MaVaiTro { get; set; } = "";
        public string TenVaiTro { get; set; } = "";
        public string? MaNV { get; set; }
        public string HoTen { get; set; } = "";
        public bool TrangThai { get; set; }
        public string? LyDoKhoa { get; set; }
    }
}
