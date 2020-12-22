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
    public class CuonSachDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public CuonSachDAL() { }
        public DataTable truyXuatDuLieuBang_CuonSach()
        {
            string strTableName = "CUONSACH";
            DataTable dtTemp = objDAconnect.HienThiThongTin(strTableName);
            return dtTemp;
        }
        public DataTable truyXuatDuLieuBang_CuonSach1()
        {
            // string strTableName = "CUONSACH";
            DataTable dtTemp = objDAconnect.HienThiThongTin1();
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
            command.CommandText = "SELECT TOP 1  STT FROM dbo.CuonSach ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maCuonSach, string tenCuonSach, string maDauSach, string tinhTrang)
        {
            int so = stt();
            if (KiemTraMaCuonSach_BangCuonSach(maCuonSach) == false)
            {
                if ((KiemTraMaDauSach_BangDauSach(maDauSach) == true))
                {
                    bool flag = false;
                    if (tinhTrang == "Chưa Mượn")
                    {
                        flag = false;
                    }
                    string strSQL = "insert into CUONSACH (STT,MaCuonSach,TenCuonSach,MaDauSach,TinhTrang) values("+so+",'" + maCuonSach + "','" + tenCuonSach + "','" + maDauSach + "','" + flag.ToString() + "')";

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

        public int CapNhat(string maCuonSach, string tenCuonSach, string maDauSach, string tinhTrang)
        {

            if (KiemTraMaCuonSach_BangCuonSach(maCuonSach) == true)
            {
                if ((KiemTraMaDauSach_BangDauSach(maDauSach) == true))
                {
                    bool flag = true;
                    if (tinhTrang == "Đã Mượn")
                    {

                        return 4;
                    }

                    else
                    {
                        flag = false;
                        string strSQL = "update CUONSACH set TenCuonSach='" + tenCuonSach + "',MaDauSach='" + maDauSach + "',TinhTrang='" + flag.ToString() + "' where MaCuonSach='" + maCuonSach + "'";
                        return objDAconnect.ExecuteQuery(strSQL);
                    }

                }
                else
                {
                    return 3;
                }

            }
            else
                return 2;

        }

        public int Xoa(string maCuonSach)
        {
            if (KiemTraMaCuonSach_BangCuonSach(maCuonSach) == true)
            {
                //câu lệnh sql
                string strSQL = "delete  from CUONSACH where MaCuonSach='" + maCuonSach + "'";
                return objDAconnect.ExecuteQuery(strSQL);
            }
            else
                return 2;
        }

        #region check
        public bool KiemTraMaCuonSach_BangCuonSach(string maCuonSach)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from CUONSACH where MaCuonSach='" + maCuonSach + "'";
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
        public bool KiemTraMaCuonSach_BangMuon(string maCuonSach)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from MUON where MaCuonSach='" + maCuonSach + "'";
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
