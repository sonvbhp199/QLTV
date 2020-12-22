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
    public class NhaXuatBanDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public NhaXuatBanDAL() { }
        public DataTable truyXuatDuLieuBang_NhaXuatBan()
        {
            string strTableName = "NHAXUATBAN";
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
            command.CommandText = "SELECT TOP 1  STT FROM dbo.NHAXUATBAN ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maNSX, string tenNSX)
        {
            int so = stt();
            if (KiemTraMaNSX_BangNhaXuatBan(maNSX) == false)
            {

                //câu lệnh sql
                string strSQL = "insert into NHAXUATBAN (STT,MaNSX,TenNSX) values("+so+",'" + maNSX + "','" + tenNSX + "')";
                return objDAconnect.ExecuteQuery(strSQL);

            }
            else
                return 2;
        }
        public int CapNhat(string maNSX, string tenNSX)
        {

            if (KiemTraMaNSX_BangNhaXuatBan(maNSX) == true)
            {
                if (KiemTraMaNSX_BangDauSach(maNSX) == false)
                {

                    string strSQL = "update NHAXUATBAN set TenNSX='" + tenNSX + "' where MaNSX='" + maNSX + "'";
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
        public int Xoa(string maNSX)
        {
            if (KiemTraMaNSX_BangNhaXuatBan(maNSX) == true)
            {
                if (KiemTraMaNSX_BangDauSach(maNSX) == false)
                {
                    //câu lệnh sql
                    string strSQL = "delete from NHAXUATBAN where MaNSX='" + maNSX + "'";
                    return objDAconnect.ExecuteQuery(strSQL);
                }
                else
                    return 3;
            }
            else
                return 2;
        }
        #region check
        public bool KiemTraMaNSX_BangNhaXuatBan(string maNSX)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from NHAXUATBAN where MaNSX='" + maNSX + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
        public bool KiemTraMaNSX_BangDauSach(string maNSX)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from DAUSACH where MaNSX='" + maNSX + "'";
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
