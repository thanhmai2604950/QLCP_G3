using Microsoft.Data.SqlClient;
using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.DAL
{
    public class DALTaiKhoan : DBConnection
    {
        public TaiKhoanDTO? DangNhap(string tenDN, string matKhauHash)
        {
            const string sql = @"
                SELECT tk.MaTK, tk.TenDangNhap, tk.MaVaiTro, vt.TenVaiTro, tk.MaNV,
                       tk.TrangThai, tk.LyDoKhoa, ISNULL(nv.HoTen, tk.TenDangNhap) AS HoTen
                FROM TaiKhoan tk
                JOIN VaiTro vt ON vt.MaVaiTro = tk.MaVaiTro
                LEFT JOIN NhanVien nv ON nv.MaNV = tk.MaNV
                WHERE tk.TenDangNhap = @u AND tk.MatKhauHash = @p";

            DataTable dt = LayDuLieu(sql, new SqlParameter("@u", tenDN), new SqlParameter("@p", matKhauHash));
            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new TaiKhoanDTO
            {
                MaTK = r["MaTK"].ToString()!,
                TenDangNhap = r["TenDangNhap"].ToString()!,
                MaVaiTro = r["MaVaiTro"].ToString()!,
                TenVaiTro = r["TenVaiTro"].ToString()!,
                MaNV = r["MaNV"] == DBNull.Value ? null : r["MaNV"].ToString(),
                HoTen = r["HoTen"].ToString()!,
                TrangThai = Convert.ToBoolean(r["TrangThai"]),
                LyDoKhoa = r["LyDoKhoa"] == DBNull.Value ? null : r["LyDoKhoa"].ToString()
            };
        }

        public List<QuyenDTO> LayQuyen(string maVaiTro)
            => LayDuLieu("SELECT MaCN, CoXem, CoThem, CoSua, CoXoa FROM VaiTro_ChucNang WHERE MaVaiTro = @vt",
                         new SqlParameter("@vt", maVaiTro))
               .AsEnumerable()
               .Select(r => new QuyenDTO
               {
                   MaCN = r["MaCN"].ToString()!,
                   CoXem = Convert.ToBoolean(r["CoXem"]),
                   CoThem = Convert.ToBoolean(r["CoThem"]),
                   CoSua = Convert.ToBoolean(r["CoSua"]),
                   CoXoa = Convert.ToBoolean(r["CoXoa"])
               }).ToList();

        public void CapNhatLanDangNhap(string maTK)
            => ThucThi("UPDATE TaiKhoan SET LanDangNhapCuoi = SYSDATETIME() WHERE MaTK = @ma",
                       new SqlParameter("@ma", maTK));
    }
}
