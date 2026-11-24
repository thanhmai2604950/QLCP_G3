namespace QLCP.GUI
{
    partial class frmDoUong
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Panel pnlTieuDe, pnlTim, pnlChiTiet;
        private Label lblTieuDe, lblTim, lblLoc, lblNhanMa, lblNhanTen, lblNhanLoai, lblNhanGia, lblNhanMoTa;
        private TextBox txtTimKiem, txtMaDU, txtTenDU, txtGia, txtMoTa;
        private ComboBox cboLocLoai, cboLoai;
        private CheckBox chkTrangThai;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;
        private DataGridView dgvDoUong;

        private void InitializeComponent()
        {
            var nau = ColorTranslator.FromHtml("#3E2723");
            var cam = ColorTranslator.FromHtml("#C8793B");
            var kem = ColorTranslator.FromHtml("#FFF8F0");
            var be = ColorTranslator.FromHtml("#F5EBDD");

            pnlTieuDe = new Panel(); pnlTim = new Panel(); pnlChiTiet = new Panel();
            lblTieuDe = new Label(); lblTim = new Label(); lblLoc = new Label();
            lblNhanMa = new Label(); lblNhanTen = new Label(); lblNhanLoai = new Label();
            lblNhanGia = new Label(); lblNhanMoTa = new Label();
            txtTimKiem = new TextBox(); txtMaDU = new TextBox(); txtTenDU = new TextBox();
            txtGia = new TextBox(); txtMoTa = new TextBox();
            cboLocLoai = new ComboBox(); cboLoai = new ComboBox(); chkTrangThai = new CheckBox();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button(); btnLamMoi = new Button();
            dgvDoUong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDoUong).BeginInit();
            pnlTieuDe.SuspendLayout(); pnlTim.SuspendLayout(); pnlChiTiet.SuspendLayout(); SuspendLayout();

            // Tiêu đề
            pnlTieuDe.BackColor = nau; pnlTieuDe.Dock = DockStyle.Top; pnlTieuDe.Height = 60;
            pnlTieuDe.Controls.Add(lblTieuDe);
            lblTieuDe.AutoSize = true; lblTieuDe.Location = new Point(20, 16); lblTieuDe.Text = "QUẢN LÝ ĐỒ UỐNG";
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold); lblTieuDe.ForeColor = kem;

            // Thanh tìm kiếm
            pnlTim.BackColor = be; pnlTim.Dock = DockStyle.Top; pnlTim.Height = 55;
            pnlTim.Controls.Add(lblTim); pnlTim.Controls.Add(txtTimKiem);
            pnlTim.Controls.Add(lblLoc); pnlTim.Controls.Add(cboLocLoai);
            lblTim.AutoSize = true; lblTim.Location = new Point(20, 18); lblTim.Text = "Tìm:";
            txtTimKiem.SetBounds(65, 15, 260, 27); txtTimKiem.PlaceholderText = "Nhập tên đồ uống...";
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            lblLoc.AutoSize = true; lblLoc.Location = new Point(350, 18); lblLoc.Text = "Loại:";
            cboLocLoai.SetBounds(395, 15, 200, 28); cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoai.SelectionChangeCommitted += cboLocLoai_SelectionChangeCommitted;

            // Panel chi tiết bên phải
            pnlChiTiet.BackColor = kem; pnlChiTiet.Dock = DockStyle.Right; pnlChiTiet.Width = 340;
            pnlChiTiet.Controls.AddRange(new Control[] {
                lblNhanMa, txtMaDU, lblNhanTen, txtTenDU, lblNhanLoai, cboLoai, lblNhanGia, txtGia,
                lblNhanMoTa, txtMoTa, chkTrangThai, btnThem, btnSua, btnXoa, btnLamMoi });

            lblNhanMa.AutoSize = true; lblNhanMa.Location = new Point(15, 15); lblNhanMa.Text = "Mã đồ uống";
            txtMaDU.SetBounds(15, 38, 300, 27); txtMaDU.ReadOnly = true; txtMaDU.BackColor = be;

            lblNhanTen.AutoSize = true; lblNhanTen.Location = new Point(15, 75); lblNhanTen.Text = "Tên đồ uống *";
            txtTenDU.SetBounds(15, 98, 300, 27);

            lblNhanLoai.AutoSize = true; lblNhanLoai.Location = new Point(15, 135); lblNhanLoai.Text = "Loại *";
            cboLoai.SetBounds(15, 158, 300, 28); cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;

            lblNhanGia.AutoSize = true; lblNhanGia.Location = new Point(15, 195); lblNhanGia.Text = "Giá niêm yết (đ) *";
            txtGia.SetBounds(15, 218, 300, 27);

            lblNhanMoTa.AutoSize = true; lblNhanMoTa.Location = new Point(15, 255); lblNhanMoTa.Text = "Mô tả";
            txtMoTa.SetBounds(15, 278, 300, 70); txtMoTa.Multiline = true;

            chkTrangThai.AutoSize = true; chkTrangThai.Location = new Point(15, 360);
            chkTrangThai.Text = "Đang kinh doanh"; chkTrangThai.Checked = true;

            btnThem.SetBounds(15, 400, 140, 36); btnThem.Text = "Thêm"; btnThem.BackColor = cam;
            btnSua.SetBounds(165, 400, 140, 36); btnSua.Text = "Sửa"; btnSua.BackColor = nau;
            btnXoa.SetBounds(15, 448, 140, 36); btnXoa.Text = "Xóa"; btnXoa.BackColor = Color.Firebrick;
            btnLamMoi.SetBounds(165, 448, 140, 36); btnLamMoi.Text = "Làm mới"; btnLamMoi.BackColor = ColorTranslator.FromHtml("#8D6E63");
            foreach (var b in new[] { btnThem, btnSua, btnXoa, btnLamMoi })
            {
                b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0;
                b.ForeColor = Color.White; b.Cursor = Cursors.Hand;
            }
            btnThem.Click += btnThem_Click; btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click; btnLamMoi.Click += btnLamMoi_Click;

            // Lưới dữ liệu
            dgvDoUong.Dock = DockStyle.Fill; dgvDoUong.ReadOnly = true;
            dgvDoUong.AllowUserToAddRows = false; dgvDoUong.AllowUserToDeleteRows = false;
            dgvDoUong.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvDoUong.MultiSelect = false;
            dgvDoUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoUong.RowHeadersVisible = false; dgvDoUong.BackgroundColor = Color.White;
            dgvDoUong.EnableHeadersVisualStyles = false;
            dgvDoUong.ColumnHeadersDefaultCellStyle.BackColor = nau;
            dgvDoUong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDoUong.ColumnHeadersHeight = 36;
            dgvDoUong.DefaultCellStyle.SelectionBackColor = cam;
            dgvDoUong.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDoUong.AlternatingRowsDefaultCellStyle.BackColor = kem;
            dgvDoUong.CellClick += dgvDoUong_CellClick;

            // Form (thứ tự Add: Fill trước, Top sau cùng để dock đúng)
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1100, 650);
            Font = new Font("Segoe UI", 10F);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đồ uống"; Name = "frmDoUong";
            Controls.Add(dgvDoUong); Controls.Add(pnlChiTiet); Controls.Add(pnlTim); Controls.Add(pnlTieuDe);
            Load += frmDoUong_Load;

            ((System.ComponentModel.ISupportInitialize)dgvDoUong).EndInit();
            pnlTieuDe.ResumeLayout(false); pnlTieuDe.PerformLayout();
            pnlTim.ResumeLayout(false); pnlTim.PerformLayout();
            pnlChiTiet.ResumeLayout(false); pnlChiTiet.PerformLayout();
            ResumeLayout(false);
        }
    }
}