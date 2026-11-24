using QLCP.DAL;
using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.BLL
{
    public class BLLLoaiDoUong
    {
        readonly DALLoaiDoUong dal = new();
        public List<LoaiDoUongDTO> LayDanhSach() => dal.LayDanhSach();
    }
}
