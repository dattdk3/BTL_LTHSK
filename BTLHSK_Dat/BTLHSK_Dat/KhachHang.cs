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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLHSK_Dat
{
    public partial class KhachHang : Form
    {
        string str = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        public KhachHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet, "tblKhachHang");
                MessageBox.Show("Dữ liệu đã được cập nhật thành công vào cơ sở dữ liệu.");
                LoadDataIntoDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadDataIntoDataGridView()
        {
            sqlConnection = new SqlConnection(str);

            // Tải dữ liệu từ SQL vào DataGridView
            string query = "SELECT * FROM tblKhachHang";
            dataAdapter = new SqlDataAdapter(query, sqlConnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "tblKhachHang");
            dataGridView1.DataSource = dataSet.Tables["tblKhachHang"];
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            //listView1.MouseClick += new MouseEventHandler(listView1_SelectedIndexChanged);
            //sqlConnection = new SqlConnection(str);
            //string query = "SELECT sTenKH FROM tblKhachhang";
            //dataAdapter = new SqlDataAdapter(query, sqlConnection);
            //// Thực hiện truy vấn và lưu kết quả vào DataTable
            //DataTable dt = new DataTable();
            //// ...
            ////dataAdapter.Fill(dataSet, "tblKhachHang");
            //// Hiển thị dữ liệu trong ListView
            //foreach (DataRow row in dataSet.Tables["tblKhachHang"].Rows)
            //{
            //    listView1.Items.Add(row["sTenKH"].ToString());
            //}
        }

        //private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    richTextBox1.Clear(); // Xóa nội dung cũ trong RichTextBox
        //    foreach (ListViewItem item in listView1.SelectedItems)
        //    {
        //        // Lấy dữ liệu từ dòng được chọn
        //        string selectedName = item.Text;

        //        // Hiển thị dữ liệu tương ứng trong RichTextBox
        //        richTextBox1.Text += selectedName + Environment.NewLine; // Hiển thị tên khách hàng trong RichTextBox, mỗi tên trên một dòng
        //    }
        //}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
