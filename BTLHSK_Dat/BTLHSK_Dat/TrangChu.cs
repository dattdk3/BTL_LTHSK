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
    public partial class TrangChu : Form
    {
        private bool checkExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void activechildhold(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        public TrangChu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lậpHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistForm("LapHoaDon"))
            {
                LapHoaDon lhd = new LapHoaDon();
                lhd.MdiParent = this;
                lhd.Show();
            }
            else
                activechildhold("LapHoaDon");
        }

        private void hoáĐơnRútGọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistForm("HoaDonRutGon"))
            {
                HoaDonRutGon hdrg = new HoaDonRutGon();
                hdrg.MdiParent = this;
                hdrg.Show();
            }
            else
                activechildhold("HoaDonRutGon");
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistForm("NhanVien"))
            {
                NhanVien nv = new NhanVien();
                nv.MdiParent = this;
                nv.Show();
            }
            else
                activechildhold("NhanVien");
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!checkExistForm("KhachHang"))
            {
                KhachHang kh = new KhachHang();
                kh.MdiParent = this;
                kh.Show();
            }
            else
                activechildhold("KhachHang");
        }

        private void menuĐồUốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistForm("MenuDoUong"))
            {
                MenuDoUong du = new MenuDoUong();
                du.MdiParent = this;
                du.Show();
            }
            else
                activechildhold("MenuDoUong");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn chưa!", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                dn.ShowDialog();
                this.Close(); // Đăng xuất khi chọn Yes
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
