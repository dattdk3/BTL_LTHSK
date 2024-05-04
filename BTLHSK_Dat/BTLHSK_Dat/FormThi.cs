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
    public partial class FormThi : Form
    {
        string constr = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
        public FormThi()
        {
            InitializeComponent();
        }

        private void FormThi_Load(object sender, EventArgs e)
        {
            DataTable dataNV = LoadKSHD(); // Hoặc loadKD()
            // Gọi hàm FillComboBoxFromColumn để điền dữ liệu vào ComboBox
            FillComboBoxFromColumn(dataNV, cbo, "iMaHD");
        }

        private DataTable LoadKSHD()
        {
            DataTable dataTable = new DataTable();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT iMaHD FROM tblHoaDon", conn))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void FillComboBoxFromColumn(DataTable dataTable, ComboBox comboBox, string columnName)
        {
            comboBox.DataSource = dataTable; // Sử dụng DataTable làm nguồn dữ liệu
            comboBox.DisplayMember = columnName; // Chỉ định cột hiển thị trong ComboBox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand("searchKHbyidHD", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "searchKHbyidHD";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@iMaHD", textBox1.Text);
                    ad.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                    if (dataGridView1.CurrentRow != null)
                    {
                    }

                    else
                    {
                        MessageBox.Show("Không Tìm Thấy!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand("searchKHbyidHD", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "searchKHbyidHD";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@iMaHD", cbo.Text);
                    ad.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    rptT3 r = new rptT3();
                    r.SetDataSource(dt);
                    InThongTin f = new InThongTin();
                    f.crystalReportViewer1.ReportSource = r;
                    f.ShowDialog();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
