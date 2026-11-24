using QLCP.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCP.GUI
{
    public partial class frmMain : Form
    {
        public bool DangXuat { get; private set; }

        public frmMain() { InitializeComponent(); }

        private void frmMain_Load(object? sender, EventArgs e)
        {
            lblNguoiDung.Text = $"Người dùng: {PhienLamViec.HoTen}  |  Vai trò: {PhienLamViec.TenVaiTro}";
            PhanQuyenMenu(msMain.Items);
            tmrGio_Tick(null, EventArgs.Empty);
        }

        // Mục menu có Tag = mã chức năng thì ẩn nếu không có quyền Xem.
        // Dùng Available (không dùng Visible vì Visible của mục con luôn false khi menu chưa mở).
        private void PhanQuyenMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem it in items)
            {
                if (it is not ToolStripMenuItem mi) continue;

                if (mi.HasDropDownItems)
                {
                    PhanQuyenMenu(mi.DropDownItems);
                    mi.Available = mi.DropDownItems.OfType<ToolStripMenuItem>().Any(x => x.Available);
                }
                else if (mi.Tag is string maCN && maCN != "")
                {
                    mi.Available = PhienLamViec.CoQuyen(maCN, "Xem");
                }
            }
        }

        // Mở form con, đã mở rồi thì kích hoạt lại
        private void MoForm<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
                if (f is T) { f.Activate(); return; }

            new T { MdiParent = this, WindowState = FormWindowState.Maximized }.Show();
        }

        private void mnuDoUong_Click(object? sender, EventArgs e) => MoForm<frmDoUong>();
        private void mnuDatMon_Click(object? sender, EventArgs e) => MessageBox.Show("Chức năng đang phát triển.");
        private void mnuNVL_Click(object? sender, EventArgs e) => MessageBox.Show("Chức năng đang phát triển.");
        private void mnuDoanhThu_Click(object? sender, EventArgs e) => MessageBox.Show("Chức năng đang phát triển.");

        private void mnuDangXuat_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            DangXuat = true;
            PhienLamViec.Xoa();
            Close();
        }

        private void mnuThoat_Click(object? sender, EventArgs e) => Close();

        private void tmrGio_Tick(object? sender, EventArgs e)
            => lblGio.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
    }
}
