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
    public class DocGiaDAL
    {
        private SqlConnection cnn;
        private DAConnect objDAconnect = new DAConnect();
        public DocGiaDAL(){ }

        public DataTable truyXuatDuLieuBang_DocGia()
        {
            string strTableName = "DOCGIA";
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
            command.CommandText = "SELECT TOP 1  STT FROM dbo.DOCGIA ORDER BY STT DESC";
            adapter.SelectCommand = command;
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            stt = Convert.ToInt32(tb.Rows[0][0]) + 1;
            con.Close();
            return stt;
        }
        public int Them(string maDocGia, string hoDocGia, string tenLotDocGia, string tenDocGia, DateTime ngaySinh, string soNha, string duong, string quan, string soDienThoai, DateTime ngayDK, DateTime ngayHetHanDK)
        {
            int so = stt();
            if (KiemTraMaDocGia_BangDocGia(maDocGia) == false)
            {
                string strSQL = "INSERT INTO dbo.DOCGIA(STT,MaDocGia,HoDocGia,TenLotDocGia,TenDocGia,  NgaySinh, SoNha,Duong,Quan,SoDienThoai, NgayDangKi,NgayHetHanDK) " +
                    "values("+so+",'" + maDocGia + "','" + hoDocGia + "','" + tenLotDocGia + "','" + tenDocGia + "','" + ngaySinh + "','" + soNha + "','" + duong + "','" + quan + "','" + soDienThoai + "','" + ngayDK + "','" + ngayHetHanDK + "')";
                return objDAconnect.ExecuteQuery(strSQL);

            }
            else
                return 2;
        }
        public int CapNhat(string maDocGia, string hoDocGia, string tenLotDocGia, string tenDocGia, DateTime ngaySinh, string soNha, string duong, string quan, string soDienThoai, DateTime ngayDK, DateTime ngayHetHanDK)
        {

            if (KiemTraMaDocGia_BangDocGia(maDocGia) == true)
            {
                if ((KiemTraMaDocGia_BangMuon(maDocGia) == false))
                {

                    string strSQL = "update DOCGIA set HoDocGia='" + hoDocGia + "',TenLotDocGia= '" + tenLotDocGia + "',TenDocGia='" + tenDocGia + "',NgaySinh='" + ngaySinh + "',Sonha='" + soNha + "',Duong='" + duong + "',Quan='" + quan + "',SoDienThoai='" + soDienThoai + "',NgayDangKi='" + ngayDK + "',NgayHethanDK='" + ngayHetHanDK + "' where MaDocGia='" + maDocGia + "'";
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
        public int Xoa(string maDocGia)
        {
            if (KiemTraMaDocGia_BangDocGia(maDocGia) == true)
            {
                if (KiemTraMaDocGia_BangMuon(maDocGia) == false)
                {
                    //câu lệnh sql
                    string strSQL = "delete from DOCGIA where MaDocGia='" + maDocGia + "'";
                    return objDAconnect.ExecuteQuery(strSQL);
                }
                else
                    return 3;
            }
            else
                return 2;
        }

        #region check
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
        public bool KiemTraMaDocGia_BangMuon(string maDocGia)
        {
            //câu lệnh sql
            string strSQL = "select count (*) from MUON where MaDocGia='" + maDocGia + "'";
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
