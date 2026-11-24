namespace QLCP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            while (true)
            {
                // Mở form đăng nhập
                using var login = new QLCP.GUI.frmDangNhap();

                if (login.ShowDialog() != DialogResult.OK)
                    break;

                // Đăng nhập thành công thì mở form chính
                using var main = new QLCP.GUI.frmMain();

                Application.Run(main);

                // Nếu đăng xuất thì quay lại màn hình đăng nhập
                // Nếu đóng bằng nút X thì thoát chương trình
                if (!main.DangXuat)
                    break;
            }
        }
    }
}