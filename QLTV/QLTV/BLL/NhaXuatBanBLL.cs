using QLTV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BLL
{
    public class NhaXuatBanBLL
    {
        #region bien
        string maNSX;
        string tenNSX;
        public string TenNSX
        {
            get { return tenNSX; }
            set { tenNSX = value; }
        }

        public string MaNSX
        {
            get { return maNSX; }
            set { maNSX = value; }
        }
        #endregion
        public NhaXuatBanBLL(string mansx, string tennsx)
        {
            maNSX = mansx;
            tenNSX = tennsx;

        }
        public NhaXuatBanBLL(string mansx)
        {
            maNSX = mansx;
        }
        public NhaXuatBanBLL()
        {

        }

        public int Them()
        {
            NhaXuatBanDAL objNhaSanXuat = new NhaXuatBanDAL();
            int kq = objNhaSanXuat.Them(maNSX, tenNSX);
            return kq;

        }
        public int Xoa()
        {
            NhaXuatBanDAL objNhaSanXuat = new NhaXuatBanDAL();
            int kq = objNhaSanXuat.Xoa(maNSX);
            return kq;

        }
        public int CapNhat()
        {
            NhaXuatBanDAL objNhaSanXuat = new NhaXuatBanDAL();
            int kq = objNhaSanXuat.CapNhat(maNSX, tenNSX);
            return kq;

        }
        public DataTable truyXuatDuLieuBang_NhaXuatBan()
        {
            NhaXuatBanDAL objNhaSanXuat = new NhaXuatBanDAL();
            DataTable dtTemp = objNhaSanXuat.truyXuatDuLieuBang_NhaXuatBan();
            return dtTemp;
        }


    }
}
