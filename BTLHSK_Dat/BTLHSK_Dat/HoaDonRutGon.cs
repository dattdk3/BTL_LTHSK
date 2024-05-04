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
    public partial class HoaDonRutGon : Form
    {
        string constr = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public HoaDonRutGon()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CheckDateHD";
                    cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value);
                    cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value);
                    try
                    {
                        // Tạo SqlDataAdapter để đổ dữ liệu vào DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();

                        // Đổ dữ liệu từ stored procedure vào DataTable
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ
                        Console.WriteLine(ex.Message);
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
                    SqlCommand cmd = new SqlCommand("CheckDateHD", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CheckDateHD";
                    cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value);
                    cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value);
                    ad.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    rptSearchHDbyDate r = new rptSearchHDbyDate();
                   
                    r.SetDataSource(dt);
                    InThongTin f = new InThongTin();
                    f.crystalReportViewer1.ReportSource = r;
                    f.ShowDialog();
                }
            }
        }

        private void HoaDonRutGon_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Lấy dòng hiện tại được chọn trong DataGridView
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;

                // Lấy dữ liệu từ cột "iMaHD" của dòng được chọn
                if (selectedRow.Cells["iMaHD"].Value != null)
                {
                    int iMaHDValue;
                    if (int.TryParse(selectedRow.Cells["iMaHD"].Value.ToString(), out iMaHDValue))
                    {
                        // Tạo một instance của Form2
                        XemChiTietHoaDon r = new XemChiTietHoaDon();


                        // Hoặc sử dụng thuộc tính nếu nó là public
                         r.getMaHD = iMaHDValue;

                        // Hiển thị Form2
                        r.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không thể chuyển đổi iMaHD thành số nguyên.");
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị iMaHD không hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu từ DataGridView.");
            }
        }

    }
}
