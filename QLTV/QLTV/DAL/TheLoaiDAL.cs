using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DAL
{
    public class TheLoaiDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public TheLoaiDAL() { }
        public DataTable truyXuatDuLieuBang_TheLoai()
        {
            string strTableName = "THELOAI";
            DataTable dtTemp = objDAconnect.HienThiThongTin(strTableName);
            return dtTemp;
        }
        int stt()
        {
            string constring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            int stt;

            string str = "";
            con.Open();
            command = con.CreateCommand();
            command.CommandText = "SELECT TOP 1  STT FROM dbo.THELOAI ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maTheLoai, string tenTheLoai)
        {
            if (KiemTraMaLoaiSach_BangTheLoai(maTheLoai) == false)
            {
                int so = stt();
                //câu lệnh sql
                string strSQL = "insert into THELOAI (STT,MaLoaiSach,TenLoaiSach) values("+so+",'" + maTheLoai + "','" + tenTheLoai + "')";
                return objDAconnect.ExecuteQuery(strSQL);

            }
            else
                return 2;
        }
        public int CapNhat(string maTheLoai, string tenTheLoai)
        {

            if (KiemTraMaLoaiSach_BangTheLoai(maTheLoai) == true)
            {
                if (KiemTraMaLoaiSach_BangTuaSach(maTheLoai) == false)
                {

                    string strSQL = "update THELOAI set TenLoaiSach='" + tenTheLoai + "' where MaLoaiSach='" + maTheLoai + "'";
                    return objDAconnect.ExecuteQuery(strSQL);

                }
                else
                {
                    return 3;
                }

            }
            else
                return 2;

        }
        public int Xoa(string maTheLoai)
        {
            if (KiemTraMaLoaiSach_BangTheLoai(maTheLoai) == true)
            {
                if (KiemTraMaLoaiSach_BangTuaSach(maTheLoai) == false)
                {
                    //câu lệnh sql
                    string strSQL = "delete from THELOAI where MaLoaiSach='" + maTheLoai + "'";
                    return objDAconnect.ExecuteQuery(strSQL);
                }
                else
                    return 3;
            }
            else
                return 2;
        }

        #region check
        public bool KiemTraMaLoaiSach_BangTheLoai(string maTheLoai)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from THELOAI where MaLoaiSach='" + maTheLoai + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
        public bool KiemTraMaLoaiSach_BangTuaSach(string maTheLoai)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from TUASACH where MaTheLoai='" + maTheLoai + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
