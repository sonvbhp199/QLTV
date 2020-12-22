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
    public class TacGiaDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public TacGiaDAL() { }
        public DataTable truyXuatDuLieuBang_TacGia()
        {
            string strTableName = "TACGIA";
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
            command.CommandText = "SELECT TOP 1  STT FROM dbo.TACGIA ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maTacGia, string tenTacGia)
        {
            int so = stt();
            if (KiemTraMaTacGia_BangTacGia(maTacGia) == false)
            {

                //câu lệnh sql
                string strSQL = "insert into TACGIA (STT,MaTacGia,TenTacGia) values("+so+",'" + maTacGia + "','" + tenTacGia + "')";
                return objDAconnect.ExecuteQuery(strSQL);

            }
            else
                return 2;
        }
        public int CapNhat(string maTacGia, string tenTacGia)
        {

            if (KiemTraMaTacGia_BangTacGia(maTacGia) == true)
            {
                if (KiemTraMaTacGia_BangTuaSach(maTacGia) == false)
                {

                    string strSQL = "update TACGIA set TenTacGia='" + tenTacGia + "' where MaTacGia='" + maTacGia + "'";
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
        public int Xoa(string maTacGia)
        {
            if (KiemTraMaTacGia_BangTacGia(maTacGia) == true)
            {
                if (KiemTraMaTacGia_BangTuaSach(maTacGia) == false)
                {
                    //câu lệnh sql
                    string strSQL = "delete from TACGIA where MaTacGia='" + maTacGia + "'";
                    return objDAconnect.ExecuteQuery(strSQL);
                }
                else
                    return 3;
            }
            else
                return 2;
        }

        #region check
        public bool KiemTraMaTacGia_BangTacGia(string maTacGia)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from TACGIA where MaTacGia='" + maTacGia + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
        public bool KiemTraMaTacGia_BangTuaSach(string maTacGia)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from TUASACH where MaTacGia='" + maTacGia + "'";
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
