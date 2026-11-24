using QLCP.DAL;
using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.BLL
{
    public class BLLDoUong
    {
        readonly DALDoUong dal = new();

        public List<DoUongDTO> LayDanhSach(string tuKhoa = "", string maLoai = "")
            => dal.LayDanhSach(tuKhoa.Trim(), maLoai);

        public void Them(DoUongDTO d)
        {
            KiemTra(d);
            d.MaDU = dal.TaoMaMoi();
            dal.Them(d);
        }

        public void Sua(DoUongDTO d)
        {
            if (string.IsNullOrEmpty(d.MaDU)) throw new Exception("Vui lòng chọn đồ uống cần sửa.");
            KiemTra(d);
            dal.Sua(d);
        }

        public void Xoa(string ma)
        {
            if (string.IsNullOrEmpty(ma)) throw new Exception("Vui lòng chọn đồ uống cần xóa.");
            dal.Xoa(ma);
        }

        static void KiemTra(DoUongDTO d)
        {
            if (string.IsNullOrWhiteSpace(d.TenDU)) throw new Exception("Tên đồ uống không được để trống.");
            if (string.IsNullOrEmpty(d.MaLoai)) throw new Exception("Vui lòng chọn loại đồ uống.");
            if (d.GiaNiemYet < 0) throw new Exception("Giá niêm yết phải là số không âm.");
            d.TenDU = d.TenDU.Trim();
        }
    }
}
