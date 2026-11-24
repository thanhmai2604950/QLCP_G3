namespace QLCP.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private MenuStrip msMain;
        private StatusStrip ssMain;
        private System.Windows.Forms.Timer tmrGio;
        private ToolStripMenuItem mnuHeThong, mnuDangXuat, mnuThoat, mnuDanhMuc, mnuDoUong,
                                  mnuBanHang, mnuDatMon, mnuKho, mnuNVL, mnuBaoCao, mnuDoanhThu;
        private ToolStripStatusLabel lblNguoiDung, lblGio;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var nau = ColorTranslator.FromHtml("#3E2723");

            msMain = new MenuStrip(); ssMain = new StatusStrip();
            tmrGio = new System.Windows.Forms.Timer(components);
            mnuHeThong = new ToolStripMenuItem(); mnuDangXuat = new ToolStripMenuItem(); mnuThoat = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem(); mnuDoUong = new ToolStripMenuItem();
            mnuBanHang = new ToolStripMenuItem(); mnuDatMon = new ToolStripMenuItem();
            mnuKho = new ToolStripMenuItem(); mnuNVL = new ToolStripMenuItem();
            mnuBaoCao = new ToolStripMenuItem(); mnuDoanhThu = new ToolStripMenuItem();
            lblNguoiDung = new ToolStripStatusLabel(); lblGio = new ToolStripStatusLabel();
            msMain.SuspendLayout(); ssMain.SuspendLayout(); SuspendLayout();

            // Menu (Tag = mã chức năng để phân quyền)
            msMain.BackColor = nau;
            msMain.Font = new Font("Segoe UI", 10.5F);
            msMain.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuDanhMuc, mnuBanHang, mnuKho, mnuBaoCao });

            mnuHeThong.Text = "Hệ thống"; mnuHeThong.ForeColor = Color.White;
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuThoat });
            mnuDangXuat.Text = "Đăng xuất"; mnuDangXuat.Click += mnuDangXuat_Click;
            mnuThoat.Text = "Thoát"; mnuThoat.Click += mnuThoat_Click;

            mnuDanhMuc.Text = "Danh mục"; mnuDanhMuc.ForeColor = Color.White;
            mnuDanhMuc.DropDownItems.Add(mnuDoUong);
            mnuDoUong.Text = "Đồ uống"; mnuDoUong.Tag = "QL_DOUONG"; mnuDoUong.Click += mnuDoUong_Click;

            mnuBanHang.Text = "Bán hàng"; mnuBanHang.ForeColor = Color.White;
            mnuBanHang.DropDownItems.Add(mnuDatMon);
            mnuDatMon.Text = "Đặt món"; mnuDatMon.Tag = "QL_DATMON"; mnuDatMon.Click += mnuDatMon_Click;

            mnuKho.Text = "Kho"; mnuKho.ForeColor = Color.White;
            mnuKho.DropDownItems.Add(mnuNVL);
            mnuNVL.Text = "Nguyên vật liệu"; mnuNVL.Tag = "QL_NVL"; mnuNVL.Click += mnuNVL_Click;

            mnuBaoCao.Text = "Báo cáo"; mnuBaoCao.ForeColor = Color.White;
            mnuBaoCao.DropDownItems.Add(mnuDoanhThu);
            mnuDoanhThu.Text = "Doanh thu"; mnuDoanhThu.Tag = "QL_BAOCAO"; mnuDoanhThu.Click += mnuDoanhThu_Click;

            // Status bar
            ssMain.BackColor = ColorTranslator.FromHtml("#F5EBDD");
            ssMain.Items.AddRange(new ToolStripItem[] { lblNguoiDung, lblGio });
            lblGio.Spring = true; lblGio.TextAlign = ContentAlignment.MiddleRight;

            tmrGio.Interval = 1000; tmrGio.Enabled = true; tmrGio.Tick += tmrGio_Tick;

            // Form
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1200, 720);
            Font = new Font("Segoe UI", 10F);
            IsMdiContainer = true; MainMenuStrip = msMain;
            WindowState = FormWindowState.Maximized;
            Text = "The Coffee House - Quản lý cửa hàng"; Name = "frmMain";
            Controls.Add(ssMain); Controls.Add(msMain);
            Load += frmMain_Load;
            msMain.ResumeLayout(false); msMain.PerformLayout();
            ssMain.ResumeLayout(false); ssMain.PerformLayout();
            ResumeLayout(false); PerformLayout();
        }
    }
}