using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class frmTinhToan : Form
    {
        public frmTinhToan()
        {
            InitializeComponent();
        }
        private void txtnum1_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtnum1.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho Số 1", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnum1.Focus();
            }
        }

        private void txtnum2_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtnum2.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho Số 2", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnum2.Focus();
                return;
            }
            if (radCong.Checked == true) { radCong_CheckedChanged(sender, e);}
            else if (radTru.Checked == true) { radTru_CheckedChanged(sender, e);}
            else if (radNhan.Checked == true) { radNhan_CheckedChanged(sender, e);}
            else if (radChia.Checked == true) { radChia_CheckedChanged(sender, e); }
        }

        private void radCong_CheckedChanged(object sender, EventArgs e)
        {
            txtKetQua.Text = (double.Parse(txtnum1.Text) + double.Parse(txtnum2.Text)).ToString();
        }

        private void radTru_CheckedChanged(object sender, EventArgs e)
        {
            txtKetQua.Text = (double.Parse(txtnum1.Text) - double.Parse(txtnum2.Text)).ToString();
        }

        private void radNhan_CheckedChanged(object sender, EventArgs e)
        {
            txtKetQua.Text = (double.Parse(txtnum1.Text) * double.Parse(txtnum2.Text)).ToString();
        }
        private void radChia_CheckedChanged(object sender, EventArgs e)
        {
            if (txtnum2.Text == "0")
                MessageBox.Show("Mẫu số phải khác 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                txtKetQua.Text = (double.Parse(txtnum1.Text) / double.Parse(txtnum2.Text)).ToString();
        }

    }
}
