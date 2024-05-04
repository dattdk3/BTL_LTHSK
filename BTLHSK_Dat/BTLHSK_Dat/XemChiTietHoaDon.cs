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
    public partial class XemChiTietHoaDon : Form
    {
        string constr = "Data Source=ADMIN;Initial Catalog=QLKDDoUong;Integrated Security=True";
        public int getMaHD { get; set; }
        public XemChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand("searchHD", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "searchHD";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@iMaHD", label10.Text);
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

        private void XemChiTietHoaDon_Load(object sender, EventArgs e)
        {
            label10.Text = getMaHD.ToString();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "searchHD";
                    cmd.Parameters.Add("@iMaHD", SqlDbType.Int).Value = getMaHD;
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        comboBox1.Text = reader["sTenNV"].ToString();
                        dateTimePicker1.Value = reader.GetDateTime(reader.GetOrdinal("dNgayBan"));
                        label13.Text = reader["iMaKH"].ToString();
                        textBox1.Text = reader["sTenKH"].ToString();
                        textBox2.Text = reader["sSoDienThoai"].ToString();
                        textBox3.Text = reader["sDiaChi"].ToString();
                        string gioiTinh = reader["sGioiTinh"].ToString();
                        if (gioiTinh == "Nam")
                        {
                            radioButton1.Checked = true;
                        }
                        else if (gioiTinh == "Nữ")
                        {
                            radioButton2.Checked = true;
                        }
                        label12.Text = reader["fTongTienThanhToan"].ToString();

                        do
                        {
                            string maDoUong = reader["sMaDoUong"].ToString();
                            string tenDoUong = reader["sTenDoUong"].ToString();
                            string size = reader["sSizeDoUong"].ToString();
                            int SoLuong = Convert.ToInt32(reader["iSoLuongBan"]);
                            float GiamGia = Convert.ToSingle(reader["fMucGiamGia"]);
                            float GiaBan = Convert.ToSingle(reader["fGiaBan"]);
                            float DonGia = GiaBan / (((float)SoLuong) - ((float)GiamGia)*SoLuong);

                            int index = dataGridView2.Rows.Add();
                            dataGridView2.Rows[index].Cells["column1"].Value = maDoUong;
                            dataGridView2.Rows[index].Cells["column2"].Value = tenDoUong;
                            dataGridView2.Rows[index].Cells["column3"].Value = size;
                            dataGridView2.Rows[index].Cells["column4"].Value = SoLuong;
                            dataGridView2.Rows[index].Cells["column5"].Value = DonGia;
                            dataGridView2.Rows[index].Cells["column6"].Value = GiamGia;
                            dataGridView2.Rows[index].Cells["column7"].Value = GiaBan;
                        } while (reader.Read());
                    }

                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn.");
                    }
                }
                conn.Close();
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Sửa thông tin trong bảng tblKhachHang
                        string updateKhachHangQuery = "UPDATE tblKhachHang SET sTenKH = @sTenKH, sDiaChi = @sDiaChi, sSoDienThoai = @sSoDienThoai, sGioiTinh = @sGioiTinh WHERE iMaKH = @iMaKH";

                        using (SqlCommand updateKhachHangCommand = new SqlCommand(updateKhachHangQuery, connection, transaction))
                        {
                            updateKhachHangCommand.Parameters.AddWithValue("@sTenKH", textBox1.Text);
                            updateKhachHangCommand.Parameters.AddWithValue("@sDiaChi", textBox3.Text);
                            updateKhachHangCommand.Parameters.AddWithValue("@sSoDienThoai", textBox2.Text);
                            updateKhachHangCommand.Parameters.AddWithValue("@sGioiTinh", radioButton1.Checked ? "Nam" : "Nữ");
                            updateKhachHangCommand.Parameters.AddWithValue("@iMaKH", label13.Text);

                            // Thực hiện cập nhật thông tin trong bảng tblKhachHang
                            updateKhachHangCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Đã cập nhật thông tin thành công");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn chưa!", "Xác nhận", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // Xóa thông tin từ bảng tblChiTietHD
                            string deleteChiTietHDQuery = "DELETE FROM tblChiTietHD WHERE iMaHD = @iMaKH";

                            using (SqlCommand deleteChiTietHDCommand = new SqlCommand(deleteChiTietHDQuery, connection, transaction))
                            {
                                deleteChiTietHDCommand.Parameters.AddWithValue("@iMaKH", label10.Text);
                                deleteChiTietHDCommand.ExecuteNonQuery();
                            }

                            // Xóa thông tin từ bảng tblHoaDon
                            string deleteHoaDonQuery = "DELETE FROM tblHoaDon WHERE iMaHD = @iMaHD";

                            using (SqlCommand deleteHoaDonCommand = new SqlCommand(deleteHoaDonQuery, connection, transaction))
                            {
                                deleteHoaDonCommand.Parameters.AddWithValue("@iMaKH", label10.Text);
                                deleteHoaDonCommand.ExecuteNonQuery();
                            }

                            // Xóa thông tin từ bảng tblKhachHang
                            string deleteKhachHangQuery = "DELETE FROM tblKhachHang WHERE iMaKH = @iMaKH";

                            using (SqlCommand deleteKhachHangCommand = new SqlCommand(deleteKhachHangQuery, connection, transaction))
                            {
                                deleteKhachHangCommand.Parameters.AddWithValue("@iMaKH", label13.Text);
                                deleteKhachHangCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Đã xóa thông tin thành công");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa thông tin: " + ex.Message);
                    }
                }
            }
        }
    }
}
