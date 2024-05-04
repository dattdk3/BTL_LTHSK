using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLHSK_Dat
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtTaiKhoan.Text == "Dat") && (txtMatKhau.Text == "1234") || (txtTaiKhoan.Text == "admin") && (txtMatKhau.Text == "1234"))
            {
                MessageBox.Show("Dang Nhap Thanh Cong!", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Hide();
                TrangChu f = new TrangChu();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Dang Nhap That Bai!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
