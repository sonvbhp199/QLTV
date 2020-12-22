using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV.DAL
{
    public class DAConnect
    {
        public SqlConnection connect;
        string connectionString;
        SqlCommand command;
        public void KetNoi()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            connect = new SqlConnection(connectionString);
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Không thể kết nối được với Server\n" + ex.Message, "Lỗi chương trình");
            }

        }
        public void DongKetNoi()
        {
            try
            {
                connect.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public int ExecuteQuery(string strSQL)
        {
            
                //mở kết nối
                KetNoi();
                command = connect.CreateCommand();
                command.CommandText = strSQL;
      

                
                //truyền câu lệnh sql
                //SqlCommand command = new SqlCommand(strSQL, connect);
                //thực hiện câu sql
                command.ExecuteNonQuery();
                //đóng kết nối
                DongKetNoi();
                return 0;//không có lỗi
            
        }

        //hien thi thong tin bang
        public DataTable HienThiThongTin(string strTable)
        {


            DataSet ds = null;
            try
            {
                //câu lệnh sql
                string strSQL = "select * from " + strTable;
                //kiểm tra kết nối
                connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                connect = new SqlConnection(connectionString);



                //khai báo,tao đối tương cầu nối (data adapter)
                SqlDataAdapter da = new SqlDataAdapter(strSQL, connect);
                //tạo dataset
                ds = new DataSet();
                //4. Nạp dữ liệu vào dataset thông qua phương thức Fill
                da.Fill(ds, strTable);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi trong khi load DL");

            }
            return ds.Tables[0];
        }
        public DataTable HienThiThongTin1()
        {


            DataSet ds = null;
            try
            {
                //câu lệnh sql
                string strSQL = "SELECT TACGIA.*, TUASACH.*, THELOAI.*, DAUSACH.*, CUONSACH.*" + "FROM (THELOAI INNER JOIN (TACGIA INNER JOIN TUASACH ON TACGIA.MaTacGia = TUASACH.MaTacGia) ON THELOAI.MaLoaiSach = TUASACH.MaTheLoai) INNER JOIN (DAUSACH INNER JOIN CUONSACH ON DAUSACH.MaDauSach = CUONSACH.MaDauSach) ON TUASACH.MaTuaSach = DAUSACH.MaTuaSach";
                //kiểm tr kết nối
                connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                connect = new SqlConnection(connectionString);

                //khai báo,tao đối tương cầu nối (data adapter)
                SqlDataAdapter da = new SqlDataAdapter(strSQL, connect);
                //tạo dataset
                ds = new DataSet();
                //4. Nạp dữ liệu vào dataset thông qua phương thức Fill
                da.Fill(ds);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi trong khi load DL");

            }
            return ds.Tables[0];

        }
    }
}
