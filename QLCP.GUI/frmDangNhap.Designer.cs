namespace QLCP.GUI
{
    partial class frmDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Panel pnlTrai;
        private Label lblThuongHieu, lblSlogan, lblTieuDe, lblTen, lblMK, lblThongBao;
        private TextBox txtTenDN, txtMatKhau;
        private CheckBox chkHienMK;
        private Button btnDangNhap, btnThoat;

        private void InitializeComponent()
        {
            var nau = ColorTranslator.FromHtml("#3E2723");
            var cam = ColorTranslator.FromHtml("#C8793B");
            var kem = ColorTranslator.FromHtml("#FFF8F0");

            pnlTrai = new Panel(); lblThuongHieu = new Label(); lblSlogan = new Label();
            lblTieuDe = new Label(); lblTen = new Label(); lblMK = new Label(); lblThongBao = new Label();
            txtTenDN = new TextBox(); txtMatKhau = new TextBox(); chkHienMK = new CheckBox();
            btnDangNhap = new Button(); btnThoat = new Button();
            pnlTrai.SuspendLayout(); SuspendLayout();

            // pnlTrai
            pnlTrai.BackColor = nau; pnlTrai.Dock = DockStyle.Left; pnlTrai.Width = 260;
            pnlTrai.Controls.Add(lblThuongHieu); pnlTrai.Controls.Add(lblSlogan);

            lblThuongHieu.AutoSize = false; lblThuongHieu.SetBounds(25, 120, 220, 90);
            lblThuongHieu.Text = "THE COFFEE HOUSE";
            lblThuongHieu.Font = new Font("Segoe UI", 20F, FontStyle.Bold); lblThuongHieu.ForeColor = kem;

            lblSlogan.AutoSize = false; lblSlogan.SetBounds(28, 215, 210, 50);
            lblSlogan.Text = "Hệ thống quản lý chuỗi cửa hàng";
            lblSlogan.Font = new Font("Segoe UI", 10F); lblSlogan.ForeColor = ColorTranslator.FromHtml("#D7B899");

            // phần phải
            lblTieuDe.AutoSize = true; lblTieuDe.Location = new Point(300, 40); lblTieuDe.Text = "ĐĂNG NHẬP";
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold); lblTieuDe.ForeColor = nau;

            lblTen.AutoSize = true; lblTen.Location = new Point(300, 115); lblTen.Text = "Tên đăng nhập";
            txtTenDN.Location = new Point(300, 140); txtTenDN.Width = 340; txtTenDN.Font = new Font("Segoe UI", 12F);

            lblMK.AutoSize = true; lblMK.Location = new Point(300, 185); lblMK.Text = "Mật khẩu";
            txtMatKhau.Location = new Point(300, 210); txtMatKhau.Width = 340;
            txtMatKhau.Font = new Font("Segoe UI", 12F); txtMatKhau.UseSystemPasswordChar = true;

            chkHienMK.AutoSize = true; chkHienMK.Location = new Point(300, 250); chkHienMK.Text = "Hiện mật khẩu";
            chkHienMK.CheckedChanged += chkHienMK_CheckedChanged;

            lblThongBao.AutoSize = false; lblThongBao.SetBounds(300, 280, 340, 36);
            lblThongBao.ForeColor = Color.Firebrick;

            btnDangNhap.SetBounds(300, 325, 160, 40); btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.FlatStyle = FlatStyle.Flat; btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.BackColor = cam; btnDangNhap.ForeColor = Color.White; btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangNhap.Click += btnDangNhap_Click;

            btnThoat.SetBounds(480, 325, 160, 40); btnThoat.Text = "Thoát";
            btnThoat.FlatStyle = FlatStyle.Flat; btnThoat.FlatAppearance.BorderColor = nau;
            btnThoat.ForeColor = nau; btnThoat.Cursor = Cursors.Hand;
            btnThoat.DialogResult = DialogResult.Cancel;

            // Form
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(700, 420);
            BackColor = kem; Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle; MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - The Coffee House"; Name = "frmDangNhap";
            AcceptButton = btnDangNhap; CancelButton = btnThoat;
            Controls.Add(lblTieuDe); Controls.Add(lblTen); Controls.Add(txtTenDN);
            Controls.Add(lblMK); Controls.Add(txtMatKhau); Controls.Add(chkHienMK);
            Controls.Add(lblThongBao); Controls.Add(btnDangNhap); Controls.Add(btnThoat);
            Controls.Add(pnlTrai);
            pnlTrai.ResumeLayout(false); ResumeLayout(false); PerformLayout();
        }
    }
}