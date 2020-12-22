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
    public class MuonDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public MuonDAL() { }
        public DataTable truyXuatDuLieuBang_Muon()
        {
            string strTableName = "MUON";
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
            command.CommandText = "SELECT TOP 1  STT FROM dbo.Muon ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maMuon, string maDocGia, string maCuonSach, int soLuong, DateTime ngayMuon, DateTime ngayHenTra, DateTime ngayTra, string ghiChu)
        {
            //int so = stt();
;            if (KiemTraMaMuon_BangMuon(maMuon) == false)
            {
                if ((KiemTraMaDocGia_BangDocGia(maDocGia) == true) && (KiemTraMaCuonSach_BangCuonSach(maCuonSach) == true))
                {

                    string strSQL = "insert into MUOn (MaMuon,MaDocGia,MaCuonSach,SoLuong,NgayMuon,NgayHenTra,NgayTra,GhiChu) " +
                    "values('" + maMuon + "','" + maDocGia + "','" + maCuonSach + "','" + soLuong + "','" + ngayMuon + "','" + ngayHenTra + "','" + ngayTra + "','" + ghiChu + "')";
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
        public int CapNhat(string maMuon, string maDocGia, string maCuonSach, int soLuong, DateTime ngayMuon, DateTime ngayHenTra, DateTime ngayTra, string chiChu)
        {

            if (KiemTraMaMuon_BangMuon(maMuon) == true)
            {
                if ((KiemTraMaDocGia_BangDocGia(maDocGia) == true) && (KiemTraMaCuonSach_BangCuonSach(maCuonSach) == true))
                {
                    string strSQL = "update MUON set MaDocGia='" + maDocGia + "',MaCuonSach='" + maCuonSach + "',SoLuong=" + soLuong + ",NgayMuon='" + ngayMuon + "',NgayHenTra='" + ngayHenTra + "',NgayTra='" + ngayTra + "',GhiChu='" + chiChu + "' where MaMuon='" + maMuon + "'";
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
        public int Xoa(string maMuon)
        {
            if (KiemTraMaMuon_BangMuon(maMuon) == true)
            {

                //câu lệnh sql
                string strSQL = "delete from MUON where MaMuon='" + maMuon + "'";
                return objDAconnect.ExecuteQuery(strSQL);
            }
            else
                return 2;
        }

        #region check
        public bool KiemTraMaMuon_BangMuon(string maMuon)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from MUON where MaMuon='" + maMuon + "'";
            objDAconnect.KetNoi();
            SqlCommand command = new SqlCommand(strSQL, objDAconnect.connect);
            int sodong = (int)command.ExecuteScalar();
            if (sodong > 0)
                return true;
            else
                return false;
        }
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
        public bool KiemTraMaDocGia_BangDocGia(string maDocGia)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from DOCGIA where MaDocGia='" + maDocGia + "'";
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
