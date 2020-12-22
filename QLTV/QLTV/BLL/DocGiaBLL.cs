using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DAL;

namespace QLTV.BLL
{
    public class DocGiaBLL
    {
        #region bien, get, set
        string maDocGia;
        string hoDocGia;
        string tenlotDocGia;
        string tenDocGia;
        DateTime ngaySinh;
        string soNha;
        string duong;
        string quan;
        string soDienThoai;
        DateTime ngayDangKi;
        DateTime ngayHetHanDK;
        public string MaDocGia
        {
            get { return maDocGia; }
            set { maDocGia = value; }
        }

        public string HoDocGia
        {
            get { return hoDocGia; }
            set { hoDocGia = value; }
        }
        public string TenlotDocGia
        {
            get { return tenlotDocGia; }
            set { tenlotDocGia = value; }
        }
        public string TenDocGia
        {
            get { return tenDocGia; }
            set { tenDocGia = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        public string SoNha
        {
            get { return soNha; }
            set { soNha = value; }
        }
        public string Duong
        {
            get { return duong; }
            set { duong = value; }
        }
        public string Quan
        {
            get { return quan; }
            set { quan = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public DateTime NgayDangKi
        {
            get { return ngayDangKi; }
            set { ngayDangKi = value; }
        }
        public DateTime NgayHetHanDK
        {
            get { return ngayHetHanDK; }
            set { ngayHetHanDK = value; }
        }
        #endregion
        public DocGiaBLL(string madocgia, string hodocgia, string tenlotdocgia, string tendocgia, DateTime ngaysinh,
          string sonha, string duong, string quan, string sodienthoai, DateTime ngaydangki, DateTime ngayhethandk)
        {
            maDocGia = madocgia;
            hoDocGia = hodocgia;
            tenlotDocGia = tenlotdocgia;
            tenDocGia = tendocgia;
            ngaySinh = ngaysinh;
            soNha = sonha;
            this.duong = duong;
            this.quan = quan;
            soDienThoai = sodienthoai;
            ngayDangKi = ngaydangki;
            ngayHetHanDK = ngayhethandk;
        }
        public DocGiaBLL(string madocgia)
        {
            maDocGia = madocgia;
        }
        public DocGiaBLL()
        {

        }
        public int Them()
        {
            DocGiaDAL objDocGia = new DocGiaDAL();
            int kq = objDocGia.Them(maDocGia, hoDocGia, tenlotDocGia, tenDocGia, ngaySinh, soNha, duong, quan, soDienThoai, ngayDangKi, ngayHetHanDK);
            return kq;

        }
        public int Xoa()
        {
            DocGiaDAL objDocGia = new DocGiaDAL();
            int kq = objDocGia.Xoa(maDocGia);
            return kq;

        }
        public int CapNhat()
        {
            DocGiaDAL objDocGia = new DocGiaDAL();
            int kq = objDocGia.CapNhat(maDocGia, hoDocGia, tenlotDocGia, tenDocGia, ngaySinh, soNha, duong, quan, soDienThoai, ngayDangKi, ngayHetHanDK);
            return kq;

        }
        public DataTable truyXuatDuLieuBang_DocGia()
        {
            DocGiaDAL objDocGia = new DocGiaDAL();
            DataTable dtTemp = objDocGia.truyXuatDuLieuBang_DocGia();
            return dtTemp;
        }
    }
}
