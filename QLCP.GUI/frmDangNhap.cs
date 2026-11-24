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
    public partial class frmDangNhap : Form
    {
        readonly BLLTaiKhoan bll = new();

        public frmDangNhap() { InitializeComponent(); }

        private void btnDangNhap_Click(object? sender, EventArgs e)
        {
            try
            {
                bll.DangNhap(txtTenDN.Text, txtMatKhau.Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void chkHienMK_CheckedChanged(object? sender, EventArgs e)
            => txtMatKhau.UseSystemPasswordChar = !chkHienMK.Checked;
    }
}
