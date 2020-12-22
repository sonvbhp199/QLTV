using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QLTV.DAL
{
    public class DauSachDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public DauSachDAL(){ }
        public DataTable truyXuatDuLieuBang_DauSach()
        {
            string strTableName = "DAUSACH";
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
            con.Open();
            command = con.CreateCommand();
            command.CommandText = "SELECT TOP 1  STT FROM dbo.DauSach ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maDauSach, string maTuaSach, string ngonNgu, string maNSX)
        {
            if (KiemTraMaDauSach_BangDauSach(maDauSach) == false)
            {
                int so = stt();
                if ((KiemTraMaTuaSach_BangTuaSach(maTuaSach) == true) && (KiemTraMaNhaNSX_BangNXB(maNSX) == true))
                {
                    //câu lệnh sql
                    string strSQL = "insert into DAUSACH (STT,MaDauSach,MaTuaSach,NgonNgu,MaNSX) values("+so+",'" + maDauSach + "','" + maTuaSach + "','" + ngonNgu + "','" + maNSX + "')";
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
        public int CapNhat(string maDauSach, string maTuaSach, string ngonNgu, string maNSX)
        {

            if (KiemTraMaDauSach_BangDauSach(maDauSach) == true)
            {
                if ((KiemTraMaTuaSach_BangTuaSach(maTuaSach) == true) && (KiemTraMaNhaNSX_BangNXB(maNSX) == true))
                {

                    string strSQL = "update DAUSACH set MaTuaSach=" + maTuaSach + "',NgonNgu='" + ngonNgu + "',MaNXB='" + maNSX + "' where MaDauSach='" + maDauSach + "'";
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
        public int Xoa(string maDauSach)
        {
            if (KiemTraMaDauSach_BangDauSach(maDauSach) == true)
            {
                //câu lệnh sql
                string strSQL = "delete from DAUSACH where MaDauSach='" + maDauSach + "'";
                return objDAconnect.ExecuteQuery(strSQL);
            }
            else
                return 2;
        }

        #region check
        public bool KiemTraMaTuaSach_BangTuaSach(string maTuaSach)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from TUASACH where MaTuaSSach='" + maTuaSach + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
        public bool KiemTraMaDauSach_BangDauSach(string maDauSach)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from DAUSACH where MaDauSach='" + maDauSach + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
        public bool KiemTraMaNhaNSX_BangNXB(string maNSX)
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
        #endregion
    }
}
