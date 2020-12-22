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
    public class TuaSachDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public TuaSachDAL() { }
        public DataTable truyXuatDuLieuBang_TuaSach()
        {
            string strTableName = "TUASACH";
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
            command.CommandText = "SELECT TOP 1  STT FROM dbo.TuaSach ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maTuaSach, string tenTuaSach, string maTheLoai, string maTacGia, string nDTomTat)
        {
            if (KiemTraMaTuaSach_BangTuaSach(maTuaSach) == false)
            {
                if ((KiemTraMaLoaiSach_BangTheLoai(maTheLoai) == true))
                {
                    if ((KiemTraMaTacGia_BangTacGia(maTacGia) == true))
                    {
                        int so = stt();
                        //câu lệnh sql
                        string strSQL = "insert into TUASACH (STT,MaTuaSach,TenTuaSach,MaTheLoai,MaTacGia,NDTomTat) values("+so+",'" + maTuaSach + "','" + tenTuaSach + "','" + maTheLoai + "','" + maTacGia + "','" + nDTomTat + "')";
                        return objDAconnect.ExecuteQuery(strSQL);
                    }
                    else
                        return 4;
                }
                else
                {
                    return 3;
                }
            }
            else
                return 2;
        }
        public int CapNhat(string maTuaSach, string tenTuaSach, string maTheLoai, string maTacGia, string nDTomTat)
        {

            if (KiemTraMaTuaSach_BangTuaSach(maTuaSach) == true)
            {
                if ((KiemTraMaLoaiSach_BangTheLoai(maTheLoai) == true))
                {
                    if ((KiemTraMaTacGia_BangTacGia(maTacGia) == true))
                    {

                        string strSQL = "update TUASACH set TenTuaSach='" + tenTuaSach + "',MaTheLoai='" + maTheLoai + "',MaTacGia='" + maTacGia + "',NDTomTat='" + nDTomTat + "' where MaTuaSach='" + maTuaSach + "'";
                        return objDAconnect.ExecuteQuery(strSQL);
                    }
                    else
                        return 4;

                }
                else
                {
                    return 3;
                }

            }
            else
                return 2;

        }
        public int Xoa(string maTuaSach)
        {
            if (KiemTraMaTuaSach_BangTuaSach(maTuaSach) == true)
            {
                //câu lệnh sql
                string strSQL = "delete from TUASACH where MaTuaSach='" + maTuaSach + "'";
                return objDAconnect.ExecuteQuery(strSQL);
            }
            else
                return 2;
        }

        #region check
        public bool KiemTraMaTuaSach_BangTuaSach(string maTuaSach)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from TUASACH where MaTuaSach='" + maTuaSach + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
        public bool KiemTraMaLoaiSach_BangTheLoai(string maLoaiSach)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from THELOAI where MaLoaiSach='" + maLoaiSach + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
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

        #endregion
    }
}
