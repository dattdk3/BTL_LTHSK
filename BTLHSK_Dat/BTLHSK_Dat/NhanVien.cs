using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLHSK_Dat
{
    public partial class NhanVien : Form
    {
        string constr = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
        public NhanVien()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Them_tblNhanVien";
                        cmd.Parameters.Add("@sMaNV", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@sTenNV", SqlDbType.NVarChar).Value = textBox2.Text;
                        if (radioButton1.Checked == true)
                        {
                            cmd.Parameters.Add("@sGioiTinh", SqlDbType.NVarChar).Value = "Nam";
                        }
                        else
                        {
                            cmd.Parameters.Add("@sGioiTinh", SqlDbType.NVarChar).Value = "Nữ";
                        }
                        cmd.Parameters.Add("@sDiaChi", SqlDbType.NVarChar).Value = textBox3.Text;
                        cmd.Parameters.Add("@dNgaySinh", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                        cmd.Parameters.Add("@sTrangThai", SqlDbType.NVarChar).Value = textBox4.Text;
                        cmd.Parameters.Add("@sSoDienThoai", SqlDbType.NVarChar).Value = textBox5.Text;

                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK);
                            this.tblNhanVienTableAdapter.Fill(this.qLKDDoUongDataSet.tblNhanVien);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại", "thông báo", MessageBoxButtons.OK);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Sua_tblNhanVien";
                    cmd.Parameters.Add("@sMaNV", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@sTenNV", SqlDbType.NVarChar).Value = textBox2.Text;
                    if (radioButton1.Checked == true)
                    {
                        cmd.Parameters.Add("@sGioiTinh", SqlDbType.NVarChar).Value = "Nam";
                    }
                    else
                    {
                        cmd.Parameters.Add("@sGioiTinh", SqlDbType.NVarChar).Value = "Nữ";
                    }
                    cmd.Parameters.Add("@sDiaChi", SqlDbType.NVarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@dNgaySinh", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                    cmd.Parameters.Add("@sTrangThai", SqlDbType.NVarChar).Value = textBox4.Text;
                    cmd.Parameters.Add("@sSoDienThoai", SqlDbType.NVarChar).Value = textBox5.Text;

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Sửa thành công", "thông báo", MessageBoxButtons.OK);
                        this.tblNhanVienTableAdapter.Fill(this.qLKDDoUongDataSet.tblNhanVien);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "thông báo", MessageBoxButtons.OK);
                    }
                }
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Xoa_tblNhanVien";
                    cmd.Parameters.Add("@sMaNV", SqlDbType.VarChar).Value = textBox1.Text;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Xoá thành công", "thông báo", MessageBoxButtons.OK);
                        this.tblNhanVienTableAdapter.Fill(this.qLKDDoUongDataSet.tblNhanVien);
                    }
                    else
                    {
                        MessageBox.Show("xóa thất bại", "thông báo", MessageBoxButtons.OK);
                    }
                    //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    //{
                    //    if (!row.IsNewRow)
                    //    {
                    //        string sMaNV = row.Cells["sMaNVDataGridViewTextBoxColumn"].Value?.ToString();
                    //        bool deleteSuccess = false;

                    //    }
                    //}
                }
                conn.Close();
            }
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKDDoUongDataSet.tblNhanVien' table. You can move, or remove it, as needed.
            this.tblNhanVienTableAdapter.Fill(this.qLKDDoUongDataSet.tblNhanVien);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("searchNV", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        ad.Fill(dt);

                        rptNhanVien r = new rptNhanVien();
                        r.SetDataSource(dt);

                        InThongTin f = new InThongTin();
                        f.crystalReportViewer1.ReportSource = r;
                        f.ShowDialog();
                    }
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
