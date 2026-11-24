using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.DAL
{
    public class DALLoaiDoUong : DBConnection
    {
        public List<LoaiDoUongDTO> LayDanhSach()
            => LayDuLieu("SELECT MaLoai, TenLoai FROM LoaiDoUong ORDER BY TenLoai")
                .AsEnumerable()
                .Select(r => new LoaiDoUongDTO
                {
                    MaLoai = r["MaLoai"].ToString()!,
                    TenLoai = r["TenLoai"].ToString()!
                }).ToList();
    }
}
