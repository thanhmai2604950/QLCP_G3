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
    public class DALDoUong : DBConnection
    {
        static object Val(string? s) => string.IsNullOrWhiteSpace(s) ? DBNull.Value : s.Trim();

        public List<DoUongDTO> LayDanhSach(string tuKhoa, string maLoai)
        {
            const string sql = @"
                SELECT du.MaDU, du.TenDU, du.MaLoai, l.TenLoai, du.GiaNiemYet, du.MoTa, du.TrangThai
                FROM DoUong du JOIN LoaiDoUong l ON l.MaLoai = du.MaLoai
                WHERE du.TenDU LIKE N'%' + @kw + N'%'
                  AND (@loai = '' OR du.MaLoai = @loai)
                ORDER BY du.MaDU";

            return LayDuLieu(sql, new SqlParameter("@kw", tuKhoa), new SqlParameter("@loai", maLoai))
                .Rows
                .Cast<DataRow>()
                .Select(r => new DoUongDTO
                {
                    MaDU = r["MaDU"].ToString()!,
                    TenDU = r["TenDU"].ToString()!,
                    MaLoai = r["MaLoai"].ToString()!,
                    TenLoai = r["TenLoai"].ToString()!,
                    GiaNiemYet = Convert.ToDecimal(r["GiaNiemYet"]),
                    MoTa = r["MoTa"] == DBNull.Value ? null : r["MoTa"].ToString(),
                    TrangThai = Convert.ToBoolean(r["TrangThai"])
                }).ToList();
        }

        public string TaoMaMoi()
        {
            var dt = LayDuLieu("SELECT ISNULL(MAX(CAST(SUBSTRING(MaDU,3,10) AS INT)),0)+1 FROM DoUong");
            return "DU" + Convert.ToInt32(dt.Rows[0][0]).ToString("00");
        }

        public int Them(DoUongDTO d)
            => ThucThi(@"INSERT INTO DoUong (MaDU, TenDU, MaLoai, MoTa, GiaNiemYet, TrangThai)
                         VALUES (@ma, @ten, @loai, @mota, @gia, @tt)",
                new SqlParameter("@ma", d.MaDU), new SqlParameter("@ten", d.TenDU),
                new SqlParameter("@loai", d.MaLoai), new SqlParameter("@mota", Val(d.MoTa)),
                new SqlParameter("@gia", d.GiaNiemYet), new SqlParameter("@tt", d.TrangThai));

        public int Sua(DoUongDTO d)
            => ThucThi(@"UPDATE DoUong SET TenDU=@ten, MaLoai=@loai, MoTa=@mota,
                                           GiaNiemYet=@gia, TrangThai=@tt
                         WHERE MaDU=@ma",
                new SqlParameter("@ma", d.MaDU), new SqlParameter("@ten", d.TenDU),
                new SqlParameter("@loai", d.MaLoai), new SqlParameter("@mota", Val(d.MoTa)),
                new SqlParameter("@gia", d.GiaNiemYet), new SqlParameter("@tt", d.TrangThai));

        public int Xoa(string ma)
        {
            try { return ThucThi("DELETE FROM DoUong WHERE MaDU=@ma", new SqlParameter("@ma", ma)); }
            catch (SqlException ex) when (ex.Number == 547)   // vi phạm khóa ngoại
            {
                throw new Exception("Đồ uống đã được dùng ở giá bán, công thức hoặc đơn hàng nên không thể xóa.\n" +
                                    "Hãy bỏ chọn 'Đang kinh doanh' rồi bấm Sửa để ngừng bán.");
            }
        }
    }
}
