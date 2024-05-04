using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLHSK_Dat
{
    public partial class MenuDoUong : Form
    {
        string constr = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public MenuDoUong()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        private void MenuDoUong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKDDoUongDataSet.tblSize' table. You can move, or remove it, as needed.
            this.tblSizeTableAdapter.Fill(this.qLKDDoUongDataSet.tblSize);
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            string query = "SELECT * FROM tblDoUong";
            dataAdapter = new SqlDataAdapter(query, constr);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

            private void btn_them_Click(object sender, EventArgs e)
        {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Them_tblDoUong";
                        cmd.Parameters.Add("@sMaDoUong", SqlDbType.NVarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@sTenDoUong", SqlDbType.NVarChar).Value = textBox2.Text;
                        cmd.Parameters.Add("@fGiaGoc", SqlDbType.Float).Value = Convert.ToInt32(maskedTextBox1.Text);
                        cmd.Parameters.Add("@sNguyenLieu", SqlDbType.NVarChar).Value = txtNguyenLieu.Text;
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK);
                            
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại", "thông báo", MessageBoxButtons.OK);
                        }
                    }
                    conn.Close();
                }
            }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Sua_tblDoUong";
                    cmd.Parameters.Add("@sMaDoUong", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@sTenDoUong", SqlDbType.NVarChar).Value = textBox2.Text;
                    cmd.Parameters.Add("@fGiaGoc", SqlDbType.Float).Value = Convert.ToInt32(maskedTextBox1.Text);
                    cmd.Parameters.Add("@sNguyenLieu", SqlDbType.NVarChar).Value = txtNguyenLieu.Text;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Sửa thành công", "thông báo", MessageBoxButtons.OK);
                        
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "thông báo", MessageBoxButtons.OK);
                    }
                }
                conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Xoa_tblDoUong";
                    cmd.Parameters.Add("@sMaDoUong", SqlDbType.VarChar).Value = textBox1.Text;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Xoá thành công", "thông báo", MessageBoxButtons.OK);
                        LoadDataIntoDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "thông báo", MessageBoxButtons.OK);
                    }
                }
                conn.Close();
            }
        }

        private void btn_In(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sql = "SELECT *from tblDoUong";
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "tblDoUong");
                rptDoUong objRpt = new rptDoUong();
                objRpt.SetDataSource(ds.Tables[0]);
                InThongTin f = new InThongTin();
                f.crystalReportViewer1.ReportSource = objRpt;
                f.crystalReportViewer1.Refresh();
                f.ShowDialog();
            }
        }
    }
}
