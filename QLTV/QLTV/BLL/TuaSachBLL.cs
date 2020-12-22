using QLTV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BLL
{
    public class TuaSachBLL
    {
        string maTuaSach;
        string tenTuaSach;
        string maTacGia;
        string maTheLoai;
        string noiDungTomTat;
        public string NoiDungTomTat
        {
            get { return noiDungTomTat; }
            set { noiDungTomTat = value; }
        }
        public string MaTheLoai1
        {
            get { return maTheLoai; }
            set { maTheLoai = value; }
        }

        public string MaTacGia
        {
            get { return maTacGia; }
            set { maTacGia = value; }
        }


        public string TenTuaSach
        {
            get { return tenTuaSach; }
            set { tenTuaSach = value; }
        }

        public string MaTuaSach
        {
            get { return maTuaSach; }
            set { maTuaSach = value; }
        }
        public TuaSachBLL(string matuasach, string tentuasach, string matacgia, string matheloai, string noidungtomtat)
        {
            maTuaSach = matuasach;
            tenTuaSach = tentuasach;
            maTacGia = matacgia;
            maTheLoai = matheloai;
            noiDungTomTat = noidungtomtat;

        }
        public TuaSachBLL(string matuasach)
        {
            maTuaSach = matuasach;
        }
        public TuaSachBLL()
        {

        }

        public int Them()
        {
            TuaSachDAL objTuaSach = new TuaSachDAL();
            int kq = objTuaSach.Them(maTuaSach, tenTuaSach, maTheLoai, maTacGia, noiDungTomTat);
            return kq;

        }
        public int Xoa()
        {
            TuaSachDAL objTuaSach = new TuaSachDAL();
            int kq = objTuaSach.Xoa(maTuaSach);
            return kq;

        }
        public int CapNhat()
        {
            TuaSachDAL objTuaSach = new TuaSachDAL();
            int kq = objTuaSach.CapNhat(maTuaSach, tenTuaSach, maTheLoai, maTacGia, noiDungTomTat);
            return kq;

        }
        public DataTable truyXuatDuLieuBang_TuaSach()
        {
            TuaSachDAL objTuaSach = new TuaSachDAL();
            DataTable dtTemp = objTuaSach.truyXuatDuLieuBang_TuaSach();
            return dtTemp;
        }
    }
}
