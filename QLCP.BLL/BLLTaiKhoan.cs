using QLCP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QLCP.BLL
{
    public class BLLTaiKhoan
    {
        readonly DALTaiKhoan dal = new();

        // SHA-256 hex chữ thường, khớp với HASHBYTES trong script SQL
        public static string BamMatKhau(string matKhau)
            => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(matKhau))).ToLower();

        public void DangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrEmpty(matKhau))
                throw new Exception("Vui lòng nhập tên đăng nhập và mật khẩu.");

            var tk = dal.DangNhap(tenDN.Trim(), BamMatKhau(matKhau));
            if (tk == null) throw new Exception("Sai tên đăng nhập hoặc mật khẩu.");
            if (!tk.TrangThai) throw new Exception("Tài khoản đã bị khóa. Lý do: " + tk.LyDoKhoa);
            if (tk.MaNV == null) throw new Exception("Tài khoản khách hàng không được dùng ứng dụng quản lý.");

            PhienLamViec.Dat(tk, dal.LayQuyen(tk.MaVaiTro));
            dal.CapNhatLanDangNhap(tk.MaTK);
        }
    }
}
