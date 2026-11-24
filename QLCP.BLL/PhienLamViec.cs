using QLCP.DTO;

namespace QLCP.BLL
{
        public static class PhienLamViec
        {
            public static TaiKhoanDTO? TaiKhoan { get; private set; }
            static Dictionary<string, QuyenDTO> quyen = new();

            public static string HoTen => TaiKhoan?.HoTen ?? "";
            public static string TenVaiTro => TaiKhoan?.TenVaiTro ?? "";
            public static string MaNV => TaiKhoan?.MaNV ?? "";

            public static void Dat(TaiKhoanDTO tk, List<QuyenDTO> ds)
            {
                TaiKhoan = tk;
                quyen = ds.ToDictionary(q => q.MaCN);
            }

            public static void Xoa() { TaiKhoan = null; quyen.Clear(); }

            // loai: "Xem" | "Them" | "Sua" | "Xoa"
            public static bool CoQuyen(string maCN, string loai)
            {
                if (!quyen.TryGetValue(maCN, out var q)) return false;
                return loai switch { "Xem" => q.CoXem, "Them" => q.CoThem, "Sua" => q.CoSua, "Xoa" => q.CoXoa, _ => false };
            }
        }
    
}
