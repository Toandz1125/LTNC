using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class FrmBai1_1 : Form
    {
        public FrmBai1_1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.txtUser.ResetText(); 
            this.txtPass.Clear(); 
            this.txtUser.Focus();
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string thongbao;
            thongbao = "Tên đăng nhập là: ";
            thongbao += this.txtUser.Text;
            thongbao += "\n\rMật khẩu là: ";
            thongbao += this.txtPass.Text;
            if (this.chkNho.Checked == true)
            { thongbao += "\n\rBạn có ghi nhớ."; }
            MessageBox.Show(thongbao, "Thông báo");
            bool isLogin = new LoginServices().Login(this.txtUser.Text, this.txtPass.Text);
            MessageBox.Show(isLogin ? "Đăng nhập thành công" : "Đăng nhập thất bại", "Thông báo");
        }
    }
}
