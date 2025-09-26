using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Bai3
{
    public partial class frmCombobox : Form
    {
        public frmCombobox()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNhapSo.Text, out var value))
            {
                errorProvider1.SetError(txtNhapSo, "Please enter a valid number.");
                MessageBox.Show("Please enter a valid number.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapSo.Focus();
                txtNhapSo.SelectAll();
                return;
            }

            errorProvider1.Clear();

            if (cbbSo.Items.Contains(txtNhapSo.Text))
            {
                MessageBox.Show("This number already exists.");
                txtNhapSo.Focus();
                txtNhapSo.SelectAll();
                return;
            }

            cbbSo.Items.Add(txtNhapSo.Text);
            MessageBox.Show("Number added successfully!");
            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }

        private void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnCapNhat_Click(sender, e);
            }
        }

        private void cbbSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstTinh.Items.Clear();
            int so = int.Parse(cbbSo.SelectedItem.ToString());
            for (int i = 1; i <= so; i++)
            {
                if ((so % i) == 0)
                {
                    lstTinh.Items.Add(i);
                }
            }
        }

        private bool CheckList()
        {
            if (lstTinh.Items.Count == 0)
            {
                MessageBox.Show("The list is empty. Please select a valid number first.");
                return false;
            }
            return true;
        }
        private void btnTong_Click(object sender, EventArgs e)
        {
            if (!CheckList()) return;
            int tong = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                tong += int.Parse(lstTinh.Items[i].ToString());
            }
            MessageBox.Show("The sum of the numbers is: " + tong);
        }

        private void btnUocChan_Click(object sender, EventArgs e)
        {
            if (!CheckList()) return;
            int count = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                if (int.Parse(lstTinh.Items[i].ToString()) % 2 == 0)
                {
                    count++;
                }
            }
            MessageBox.Show("The count of even numbers is: " + count);
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            int sqrtN = (int)Math.Sqrt(n);
            for (int i = 3; i <= sqrtN; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private void btnSoNguyenTo_Click(object sender, EventArgs e)
        {
            if(!CheckList()) return;
            int count = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                if (IsPrime(int.Parse(lstTinh.Items[i].ToString())))
                {
                    count++;
                }
            }
            MessageBox.Show("The count of prime numbers is: " + count);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}