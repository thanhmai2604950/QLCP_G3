using QLCP.BLL;
using QLCP.DTO;
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
    public partial class frmDoUong : Form
    {
        readonly BLLDoUong bll = new();
        readonly BLLLoaiDoUong bllLoai = new();
        string maDangChon = "";

        public frmDoUong() { InitializeComponent(); }

        private void frmDoUong_Load(object? sender, EventArgs e)
        {
            try
            {
                NapLoai();
                PhanQuyen();
                TaiDanhSach();
                LamMoi();
            }
            catch (Exception ex) { Loi(ex); }
        }

        private void NapLoai()
        {
            List<LoaiDoUongDTO> ds = bllLoai.LayDanhSach();

            cboLoai.DisplayMember = "TenLoai"; cboLoai.ValueMember = "MaLoai";
            cboLoai.DataSource = new List<LoaiDoUongDTO>(ds);

            var dsLoc = new List<LoaiDoUongDTO>(ds);
            dsLoc.Insert(0, new LoaiDoUongDTO { MaLoai = "", TenLoai = "-- Tất cả --" });
            cboLocLoai.DisplayMember = "TenLoai"; cboLocLoai.ValueMember = "MaLoai";
            cboLocLoai.DataSource = dsLoc;
        }

        private void PhanQuyen()
        {
            btnThem.Enabled = PhienLamViec.CoQuyen("QL_DOUONG", "Them");
            btnSua.Enabled = PhienLamViec.CoQuyen("QL_DOUONG", "Sua");
            btnXoa.Enabled = PhienLamViec.CoQuyen("QL_DOUONG", "Xoa");
        }

        private void TaiDanhSach()
        {
            string loai = cboLocLoai.SelectedValue?.ToString() ?? "";
            dgvDoUong.DataSource = bll.LayDanhSach(txtTimKiem.Text, loai);     // List<DoUongDTO>

            dgvDoUong.Columns["MaDU"].HeaderText = "Mã";
            dgvDoUong.Columns["TenDU"].HeaderText = "Tên đồ uống";
            dgvDoUong.Columns["TenLoai"].HeaderText = "Loại";
            dgvDoUong.Columns["GiaNiemYet"].HeaderText = "Giá niêm yết";
            dgvDoUong.Columns["GiaNiemYet"].DefaultCellStyle.Format = "N0";
            dgvDoUong.Columns["TrangThai"].HeaderText = "Đang bán";
            dgvDoUong.Columns["MaLoai"].Visible = false;
            dgvDoUong.Columns["MoTa"].Visible = false;
        }

        private void LamMoi()
        {
            maDangChon = "";
            txtMaDU.Text = "(tự động)";
            txtTenDU.Clear(); txtGia.Clear(); txtMoTa.Clear();
            chkTrangThai.Checked = true;
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
            txtTenDU.Focus();
        }

        // Gom dữ liệu trên form thành 1 DTO
        private DoUongDTO LayTuForm()
        {
            if (!decimal.TryParse(txtGia.Text, out decimal gia))
                throw new Exception("Giá niêm yết phải là số.");

            return new DoUongDTO
            {
                MaDU = maDangChon,
                TenDU = txtTenDU.Text,
                MaLoai = cboLoai.SelectedValue?.ToString() ?? "",
                GiaNiemYet = gia,
                MoTa = txtMoTa.Text,
                TrangThai = chkTrangThai.Checked
            };
        }

        private static void Loi(Exception ex)
            => MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // ---------- Sự kiện ----------
        private void txtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            try { TaiDanhSach(); } catch (Exception ex) { Loi(ex); }
        }

        private void cboLocLoai_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            try { TaiDanhSach(); } catch (Exception ex) { Loi(ex); }
        }

        private void dgvDoUong_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;                                   // bấm vào tiêu đề cột
            var d = (DoUongDTO)dgvDoUong.Rows[e.RowIndex].DataBoundItem;  // lấy thẳng DTO

            maDangChon = d.MaDU;
            txtMaDU.Text = d.MaDU;
            txtTenDU.Text = d.TenDU;
            cboLoai.SelectedValue = d.MaLoai;
            txtGia.Text = d.GiaNiemYet.ToString("0");
            txtMoTa.Text = d.MoTa;
            chkTrangThai.Checked = d.TrangThai;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                bll.Them(LayTuForm());
                MessageBox.Show("Thêm đồ uống thành công.", "Thông báo");
                TaiDanhSach(); LamMoi();
            }
            catch (Exception ex) { Loi(ex); }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                bll.Sua(LayTuForm());
                MessageBox.Show("Cập nhật thành công.", "Thông báo");
                TaiDanhSach(); LamMoi();
            }
            catch (Exception ex) { Loi(ex); }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (maDangChon == "") { MessageBox.Show("Vui lòng chọn đồ uống cần xóa."); return; }
            if (MessageBox.Show($"Xóa đồ uống {maDangChon}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                bll.Xoa(maDangChon);
                TaiDanhSach(); LamMoi();
            }
            catch (Exception ex) { Loi(ex); }
        }

        private void btnLamMoi_Click(object? sender, EventArgs e) => LamMoi();
    }
}
