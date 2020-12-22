using QLTV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BLL
{
    public class MuonBLL
    {
        #region bien, get, set
        string maMuon;
        string maDocGia;
        string maCuonSach;
        int soLuong;
        DateTime ngayMuon;
        DateTime ngayHenTra;
        DateTime ngayTra;
        string ghiChu;
        public string MaMuon
        {
            get { return maMuon; }
            set { maMuon = value; }
        }
        public string MaDocGia
        {
            get { return maDocGia; }
            set { maDocGia = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public DateTime NgayTra
        {
            get { return ngayTra; }
            set { ngayTra = value; }
        }
        public DateTime NgayHenTra
        {
            get { return ngayHenTra; }
            set { ngayHenTra = value; }
        }

        public DateTime NgayMuon
        {
            get { return ngayMuon; }
            set { ngayMuon = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public string MaCuonSach
        {
            get { return maCuonSach; }
            set { maCuonSach = value; }
        }
        #endregion
        public MuonBLL(string mamuon, string madocgia, string macuonsach, int soluong, DateTime ngaymuon, DateTime ngayhentra, DateTime ngaytra, string ghichu)
        {
            maMuon = mamuon;
            maDocGia = madocgia;
            maCuonSach = macuonsach;
            soLuong = soluong;
            ngayMuon = ngaymuon;
            ngayHenTra = ngayhentra;
            ngayTra = ngaytra;
            ghiChu = ghichu;

        }
        public MuonBLL(string mamuon, string madocgia, string macuonsach, int soluong, DateTime ngaymuon, DateTime ngayhentra, string ghichu)
        {
            maMuon = mamuon;
            maDocGia = madocgia;
            maCuonSach = macuonsach;
            soLuong = soluong;
            ngayMuon = ngaymuon;
            ngayHenTra = ngayhentra;
            ghiChu = ghichu;

        }
        public MuonBLL(string mamuon)
        {
            maMuon = mamuon;
        }
        public MuonBLL()
        {

        }
        public int Them()
        {
            MuonDAL objMuon = new MuonDAL();
            int kq = objMuon.Them(maMuon, maDocGia, maCuonSach, soLuong, ngayMuon, ngayHenTra, ngayTra, ghiChu);
            return kq;

        }
        public int Xoa()
        {
            MuonDAL objMuon = new MuonDAL();
            int kq = objMuon.Xoa(maMuon);
            return kq;

        }
        public int CapNhat()
        {
            MuonDAL objMuon = new MuonDAL();
            int kq = objMuon.CapNhat(maMuon, maDocGia, maCuonSach, soLuong, ngayMuon, ngayHenTra, ngayTra, ghiChu);
            return kq;

        }
        public DataTable truyXuatDuLieuBang_Muon()
        {
            MuonDAL objMuon = new MuonDAL();
            DataTable dtTemp = objMuon.truyXuatDuLieuBang_Muon();
            return dtTemp;
        }

    }
}
