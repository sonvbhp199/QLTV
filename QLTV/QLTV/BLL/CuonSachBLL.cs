using QLTV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BLL
{
    public class CuonSachBLL
    {
        #region bien,get,set
        private string maCuonSach;
        private string tenCuonSach;
        private string maDauSach;
        private string tinhTrang;
        public string MaCuonSach
        {
            get { return maCuonSach; }
            set { maCuonSach = value; }
        }

        public string TenCuonSach
        {
            get { return tenCuonSach; }
            set { tenCuonSach = value; }
        }

        public string MaDauSach
        {
            get { return maDauSach; }
            set { maDauSach = value; }
        }
        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        #endregion
        public CuonSachBLL(string macuonsach, string tencuonsach, string madausach, string tinhtrang)
        {
            maCuonSach = macuonsach;
            tenCuonSach = tencuonsach;
            maDauSach = madausach;
            tinhTrang = tinhtrang;
        }
        public CuonSachBLL(string macuonsach)
        {
            maCuonSach = macuonsach;
        }
        public CuonSachBLL() { }
        public int Them()
        {
            CuonSachDAL objCuonSach = new CuonSachDAL();
            int kq = objCuonSach.Them(maCuonSach, tenCuonSach, maDauSach, tinhTrang);
            return kq;

        }
        public int Xoa()
        {
            CuonSachDAL objCuonSach = new CuonSachDAL();
            int kq = objCuonSach.Xoa(maCuonSach);
            return kq;
        }
        public int CapNhat()
        {
            CuonSachDAL objCuonSach = new CuonSachDAL();
            int kq = objCuonSach.CapNhat(maCuonSach, tenCuonSach, MaDauSach, tinhTrang);
            return kq;
        }
        public DataTable truyXuatDuLieuBang_CuonSach()
        {
            CuonSachDAL objCuonSach = new CuonSachDAL();
            DataTable dtTemp = objCuonSach.truyXuatDuLieuBang_CuonSach();
            return dtTemp;
        }
        public DataTable truyXuatDuLieuBang_CuonSach1()
        {
            CuonSachDAL objCuonSach = new CuonSachDAL();
            DataTable dtTemp = objCuonSach.truyXuatDuLieuBang_CuonSach1();
            return dtTemp;
        }
    }
}
