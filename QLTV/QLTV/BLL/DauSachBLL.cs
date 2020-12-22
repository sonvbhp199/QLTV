using QLTV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BLL
{
    public class DauSachBLL
    {
        #region bien,get,set
        string maDauSach;
        string maTuaSach;
        string ngonNgu;
        string maNSX;
        public string MaNSX
        {
            get { return maNSX; }
            set { maNSX = value; }
        }

        public string NgonNgu
        {
            get { return ngonNgu; }
            set { ngonNgu = value; }
        }

        public string MaTuaSach
        {
            get { return maTuaSach; }
            set { maTuaSach = value; }
        }

        public string MaDausach
        {
            get { return maDauSach; }
            set { maDauSach = value; }
        }
        #endregion
        public DauSachBLL(string madausach, string matuasach, string ngonngu, string mansx)
        {
            maDauSach = madausach;
            maTuaSach = matuasach;
            ngonNgu = ngonngu;
            maNSX = mansx;
        }
        public DauSachBLL(string madausach)
        {
            maDauSach = madausach;

        }
        public DauSachBLL()
        {

        }
        public int Them()
        {
            DauSachDAL objDauSach = new DauSachDAL();
            int kq = objDauSach.Them(maDauSach, maTuaSach, ngonNgu, maNSX);
            return kq;

        }
        public int Xoa()
        {
            DauSachDAL objDauSach = new DauSachDAL();
            int kq = objDauSach.Xoa(maDauSach);
            return kq;

        }
        public int CapNhat()
        {
            DauSachDAL objDauSach = new DauSachDAL();
            int kq = objDauSach.CapNhat(maDauSach, maTuaSach, ngonNgu, maNSX);
            return kq;
        }
        public DataTable truyXuatDuLieuBang_DauSach()
        {
            DauSachDAL objDauSach = new DauSachDAL();
            DataTable dtTemp = objDauSach.truyXuatDuLieuBang_DauSach();
            return dtTemp;
        }
    }
}
