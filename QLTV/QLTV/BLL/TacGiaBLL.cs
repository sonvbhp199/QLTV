using QLTV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BLL
{
    public class TacGiaBLL
    {
        string maTacGia;
        string tenTacGia;
        public string MaTacGia
        {
            get { return maTacGia; }
            set { maTacGia = value; }
        }
        public string TenTacGia
        {
            get { return tenTacGia; }
            set { tenTacGia = value; }
        }
        public TacGiaBLL(string matacgia, string tentacgia)
        {
            maTacGia = matacgia;
            tenTacGia = tentacgia;

        }
        public TacGiaBLL(string matacgia)
        {
            maTacGia = matacgia;
        }
        public TacGiaBLL()
        {

        }
        public int Them()
        {
            TacGiaDAL objTacGia = new TacGiaDAL();
            int kq = objTacGia.Them(maTacGia, tenTacGia);
            return kq;

        }
        public int Xoa()
        {
            TacGiaDAL objTacGia = new TacGiaDAL();
            int kq = objTacGia.Xoa(maTacGia);
            return kq;

        }
        public int CapNhat()
        {
            TacGiaDAL objTacGia = new TacGiaDAL();
            int kq = objTacGia.CapNhat(maTacGia, tenTacGia);
            return kq;

        }
        public DataTable truyXuatDuLieuBang_TacGia()
        {
            TacGiaDAL objTacGia = new TacGiaDAL();
            DataTable dtTemp = objTacGia.truyXuatDuLieuBang_TacGia();
            return dtTemp;
        }
    }
}
