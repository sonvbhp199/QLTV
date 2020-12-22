using QLTV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BLL
{
    public class TheLoaiBLL
    {
        string maTheLoai;
        string tenTheLoai;
        public string MaTheLoai
        {
            get { return maTheLoai; }
            set { maTheLoai = value; }
        }
        public string TenTheLoai
        {
            get { return tenTheLoai; }
            set { tenTheLoai = value; }
        }
        public TheLoaiBLL(string matheloai, string tentheloai)
        {
            maTheLoai = matheloai;
            tenTheLoai = tentheloai;

        }
        public TheLoaiBLL(string matheloai)
        {
            maTheLoai = matheloai;
        }
        public TheLoaiBLL()
        {

        }
        public int Them()
        {
            TheLoaiDAL objTheLoai = new TheLoaiDAL();
            int kq = objTheLoai.Them(maTheLoai, tenTheLoai);
            return kq;

        }
        public int Xoa()
        {
            TheLoaiDAL objTheLoai = new TheLoaiDAL();
            int kq = objTheLoai.Xoa(maTheLoai);
            return kq;

        }
        public int CapNhat()
        {
            TheLoaiDAL objTheLoai = new TheLoaiDAL();
            int kq = objTheLoai.CapNhat(maTheLoai, tenTheLoai);
            return kq;

        }
        public DataTable truyXuatDuLieuBang_TheLoai()
        {
            TheLoaiDAL objTheLoai = new TheLoaiDAL();
            DataTable dtTemp = objTheLoai.truyXuatDuLieuBang_TheLoai();
            return dtTemp;
        }
    }
}
