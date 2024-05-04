using CrystalDecisions.CrystalReports.Engine;
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
    public partial class LapHoaDon : Form
    {
        string str = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
        public LapHoaDon()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private DataTable LoadKSDU()
        {
            DataTable dataTable = new DataTable();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT sTenDoUong FROM tblDoUong", conn))
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
        private DataTable LoadKSNV()
        {
            DataTable dataTable = new DataTable();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT sTenNV FROM tblNhanVien", conn))
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


        private void LapHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKDDoUongDataSet.tblChiTietHD' table. You can move, or remove it, as needed.
            this.tblChiTietHDTableAdapter.Fill(this.qLKDDoUongDataSet.tblChiTietHD);
          
            // Gọi hàm loadKS() hoặc loadKD() để lấy DataTable chứa dữ liệu từ cột sTenDoUong
            DataTable dataDU = LoadKSDU(); // Hoặc loadKD()
            // Gọi hàm FillComboBoxFromColumn để điền dữ liệu vào ComboBox
            FillComboBoxFromColumn(dataDU, cboDU, "sTenDoUong");
            //cboDU.DataSource = dataDU;
            //cboDU.DisplayMember = "sTenDoUong";

            DataTable dataNV = LoadKSNV(); // Hoặc loadKD()
            // Gọi hàm FillComboBoxFromColumn để điền dữ liệu vào ComboBox
            FillComboBoxFromColumn(dataNV, cboNV, "sTenNV");
            //cboNV.DataSource = dataNV;
            //cboNV.DisplayMember = "sTenNV";

            //btnHien.Enabled = false;
        }

        private void FillComboBoxFromColumn(DataTable dataTable, ComboBox comboBox, string columnName)
        {
            comboBox.DataSource = dataTable; // Sử dụng DataTable làm nguồn dữ liệu
            comboBox.DisplayMember = columnName; // Chỉ định cột hiển thị trong ComboBox
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public string GetMaNhanVien(string tennhanvien)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT sMaNV FROM tblNhanVien WHERE sTenNV = @tennhanvien", connection))
                {
                    command.Parameters.AddWithValue("@tennhanvien", tennhanvien);

                    string NVCode = (string)command.ExecuteScalar();

                    return NVCode;
                }
            }
        }

        static int GetLatestID()
        {
            string str = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(str))
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 iMaHD FROM tblHoaDon ORDER BY iMaHD DESC", connection);

                connection.Open();

                int latestID = (int)command.ExecuteScalar();

                return latestID;
            }
        }

        private void btnThem(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                            // Thêm thông tin vào bảng tblKH
                            using (SqlCommand khCommand = connection.CreateCommand())
                            {
                                khCommand.Transaction = transaction;

                                khCommand.CommandText = "INSERT INTO tblKhachHang (sTenKH, sDiaChi, sSoDienThoai, sGioiTinh) VALUES (@sTenKH, @sDiaChi, @sSoDienThoai, @sGioiTinh); SELECT SCOPE_IDENTITY();";

                                khCommand.Parameters.AddWithValue("@sTenKH", txtNameKH.Text);
                                khCommand.Parameters.AddWithValue("@sDiaChi", txtDiaChiKH.Text);
                                khCommand.Parameters.AddWithValue("@sSoDienThoai", txtSDT.Text);
                                khCommand.Parameters.AddWithValue("@sGioiTinh", rdNam.Checked ? "Nam" : "Nữ");

                                int iMaKH = Convert.ToInt32(khCommand.ExecuteScalar());

                                // Thêm thông tin vào bảng tblHoaDon
                                using (SqlCommand hdCommand = connection.CreateCommand())
                                {
                                    hdCommand.Transaction = transaction;

                                    hdCommand.CommandText = "INSERT INTO tblHoaDon (sMaNV, iMaKH, dNgayBan) VALUES (@sMaNV, @iMaKH, @dNgayBan); SELECT SCOPE_IDENTITY();";

                                    hdCommand.Parameters.AddWithValue("@sMaNV", GetMaNhanVien(cboNV.Text));
                                    hdCommand.Parameters.AddWithValue("@iMaKH", iMaKH);
                                    hdCommand.Parameters.AddWithValue("@dNgayBan", dateTime_MuaHang.Value);
                                    //hdCommand.Parameters.AddWithValue("@fTongTienThanhToan", float.Parse(textBox6.Text));
                                    //hdCommand.Parameters.AddWithValue("@sTrangThaiHD", "SomeValue");

                                    int iMaHD = Convert.ToInt32(hdCommand.ExecuteScalar());

                                    // Thêm thông tin vào bảng tblChiTietHD
                                    using (SqlCommand ctCommand = connection.CreateCommand())
                                    {
                                        ctCommand.Transaction = transaction;

                                        foreach (DataGridViewRow row in dataGridView1.Rows)
                                        {
                                            if (!row.IsNewRow)
                                            {
                                                string sMaDoUong = row.Cells["Column1"].Value.ToString();
                                                string sSizeDoUong = row.Cells["Column3"].Value.ToString();
                                                int iSoLuong = Convert.ToInt32(row.Cells["Column4"].Value);
                                                float fMucGiamGia = Convert.ToSingle(row.Cells["Column6"].Value);

                                                ctCommand.CommandText = "INSERT INTO tblChiTietHD (iMaHD, sMaDoUong, sSizeDoUong, iSoLuongBan, fMucGiamGia) VALUES (@MaHD, @sMaDoUong, @sSizeDoUong, @iSoLuong, @fMucGiamGia)";

                                                ctCommand.Parameters.Clear();
                                                ctCommand.Parameters.AddWithValue("@MaHD", iMaHD);
                                                ctCommand.Parameters.AddWithValue("@sMaDoUong", sMaDoUong);
                                                ctCommand.Parameters.AddWithValue("@sSizeDoUong", sSizeDoUong);
                                                ctCommand.Parameters.AddWithValue("@iSoLuong", iSoLuong);
                                                ctCommand.Parameters.AddWithValue("@fMucGiamGia", fMucGiamGia);

                                                ctCommand.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }

                                transaction.Commit();
                                MessageBox.Show("Đã lưu hoá đơn thành công");
                            }

                        } 
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            }
            else
            {
                MessageBox.Show("Thiếu thông tin nước!");
            }
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }
        
        public string GetMaDoUong(string tendouong)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT sMaDoUong FROM tblDoUong WHERE sTenDoUong = @tendouong", connection))
                {
                    command.Parameters.AddWithValue("@tendouong", tendouong);

                    string DrinkCode = (string)command.ExecuteScalar();

                    return DrinkCode;
                }
            }
        }

        private float GetPriceByDrinkName(string drinkName)
        {
            float price = 0;

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT fGiaGoc FROM tblDoUong WHERE sTenDoUong = @name", connection))
                {
                    command.Parameters.AddWithValue("@name", drinkName);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        price = Convert.ToSingle(reader["fGiaGoc"]);
                    }
                }
            }

            return price;
        }


        private void btn_addDrink_Click(object sender, EventArgs e)
        {
            // Get the selected RadioButton text
            RadioButton selectedRadioButton = panel_Size.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);

            // Get the value from the NumericUpDown
            decimal numeric_quantity = numeric_quantityDU.Value;

            // Get the value from the NumericUpDown
            decimal numeric_discount = numeric_Discount.Value / 100;

            if (numeric_quantity == 0 || selectedRadioButton == null || cboDU.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                return;
            }
            else
            {
                // Get the selected item from the ComboBox
                //cboDU.DisplayMember = "sTenDoUong";
                string namedrink = cboDU.Text;

                //Getsize
                string sizedrinks = selectedRadioButton.Text;

                float pricedrinks = 0;
                if (sizedrinks == "S")
                {
                    pricedrinks += GetPriceByDrinkName(namedrink);
                }
                else if (sizedrinks == "M")
                {
                    pricedrinks += (float)(GetPriceByDrinkName(namedrink) * 1.2);
                }
                else if (sizedrinks == "L")
                {
                    pricedrinks += (float)(GetPriceByDrinkName(namedrink) * 1.4);
                }

                float totalprice_1drink = pricedrinks * (((float)numeric_quantity) - ((float)numeric_discount));

                // Add a new row to the DataGridView with these values
                dataGridView1.Rows.Add(GetMaDoUong(namedrink), namedrink, sizedrinks, numeric_quantity, pricedrinks, numeric_discount, totalprice_1drink);

                //Total Price and Show in Label
                float sum = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    float value = 0;
                    if (row.Cells[6].Value != null && float.TryParse(row.Cells[6].Value.ToString(), out value))
                    {
                        sum += value;
                    }
                }
                label15.Text = sum.ToString();

                // After adding the row, reset all controls
                cboDU.SelectedIndex = -1; // Reset the ComboBox
                foreach (RadioButton rb in panel_Size.Controls.OfType<RadioButton>()) // Reset all RadioButtons
                {
                    rb.Checked = false;
                }
                numeric_quantityDU.Value = numeric_quantityDU.Minimum; // Reset the NumericUpDown
                numeric_Discount.Value = numeric_Discount.Minimum;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand("searchHD", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "searchHD";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@iMaHD", GetLatestID());
                    ad.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    rptInHD r = new rptInHD();
                    r.SetDataSource(dt);
                    InThongTin f = new InThongTin();
                    f.crystalReportViewer1.ReportSource = r;
                    f.ShowDialog();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
        //    if (dataGridView1.RowCount > 1)
        //    {
        //        if (dataGridView1.SelectedRows.Count > 0)
        //        {
        //            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

        //            // Lấy thông tin từ DataGridView
        //            int id = Convert.ToInt32(selectedRow.Cells["ID_Column"].Value);
        //            string sMaDoUong = selectedRow.Cells["Column1"].Value.ToString();
        //            string column2Value = selectedRow.Cells["Column2"].Value.ToString();
        //            // ...

        //            // Gọi stored procedure để cập nhật dữ liệu trong cơ sở dữ liệu
        //            using (SqlConnection conn = new SqlConnection(str))
        //            {
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandText = "sp_Sua_tblChiTietHD";
        //                    cmd.Parameters.Add("@iMaHD", SqlDbType.Int).Value = GetLatestID();
        //                    cmd.Parameters.Add("@sMaDoUong", SqlDbType.NVarChar).Value = textBox1.Text;
        //                    cmd.Parameters.Add("@sTenDoUong", SqlDbType.NVarChar).Value = textBox2.Text;
        //                    cmd.Parameters.Add("@fGiaGoc", SqlDbType.Float).Value = Convert.ToInt32(maskedTextBox1.Text);
        //                    conn.Open();
        //                    int i = cmd.ExecuteNonQuery();
        //                    if (i > 0)
        //                    {
        //                        MessageBox.Show("Sửa thành công", "thông báo", MessageBoxButtons.OK);
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Sửa thất bại", "thông báo", MessageBoxButtons.OK);
        //                    }
        //                }
        //                conn.Close();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Vui lòng chọn một hàng để sửa!");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Chưa chọn nước!");
        //    }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            string sMaDoUong = row.Cells["column1"].Value?.ToString();
                            string sSizeDoUong = row.Cells["column3"].Value?.ToString();
                            int iSoLuongBan;

                            if (!string.IsNullOrEmpty(sMaDoUong) && !string.IsNullOrEmpty(sSizeDoUong) &&
                                row.Cells["column4"].Value != null && int.TryParse(row.Cells["column4"].Value.ToString(), out iSoLuongBan))
                            {
                                int iMaHD = GetLatestID(); // Đoạn này cần xem xét lại nếu không muốn lấy mã hoá đơn mỗi lần
                                bool deleteSuccess = false;
                                deleteby(iMaHD, sMaDoUong, sSizeDoUong, iSoLuongBan);

                                deleteSuccess = true; // Giả sử xóa thành công

                                if (!deleteSuccess)
                                {
                                    dataGridView1.Rows.Remove(row); // Xoá dòng trong DataGridView chỉ khi xóa từ CSDL thành công
                                }
                                else
                                {
                                    MessageBox.Show("Xóa thất bại. Không xoá dòng dữ liệu.", "Thông báo", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void deleteby(int iMaHD, string sMaDoUong, string sSizeDoUong, int iSoLuongBan)
        {
            
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Xoa_tblChiTietHD";
                    cmd.Parameters.AddWithValue("@iMaHD", iMaHD);
                    cmd.Parameters.AddWithValue("@sMaDoUong", sMaDoUong);
                    cmd.Parameters.AddWithValue("@sSizeDoUong", sSizeDoUong);
                    cmd.Parameters.AddWithValue("@iSoLuongBan", iSoLuongBan);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Xoá thành công", "thông báo", MessageBoxButtons.OK);
                    }
                }
                conn.Close();
            }
        }

        private void txtNameKH_TextChanged(object sender, EventArgs e)
        {
            //if(txtNameKH.Text != null)
            //{
            //    btnHien.Enabled = true;
            //}
        }
    }
}
