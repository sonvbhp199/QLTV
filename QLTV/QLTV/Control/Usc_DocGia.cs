using QLTV.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV.Control
{
    public partial class Usc_DocGia : UserControl
    {
        public Usc_DocGia()
        {
            InitializeComponent();
        }
        #region các hàm xử lí


        void LoadDocGia()
        {
            DataTable dtdocgia = new DocGiaBLL().truyXuatDuLieuBang_DocGia();
            if (dtdocgia.Rows.Count > 0)
            {
                lvwDSDocGia.Items.Clear();
                int i = 1;
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dg in dtdocgia.Rows)
                {

                    ListViewItem li = lvwDSDocGia.Items.Add(dg["MaDocGia"].ToString());
                    // li.SubItems.Add(dg["MaDocGia"].ToString());
                    li.SubItems.Add(dg["HoDocGia"].ToString() + " " + dg["TenLotDocGia"] + " " + dg["TenDocGia"]);
                    li.SubItems.Add(dg["NgaySinh"].ToString());
                    li.SubItems.Add(dg["SoNha"].ToString() + "," + dg["Duong"].ToString() + "," + dg["Quan"].ToString());
                    li.SubItems.Add(dg["NgayDangKi"].ToString());
                    li.SubItems.Add(dg["NgayHetHanDK"].ToString());
                    li.SubItems.Add(i.ToString());
                    li.SubItems.Add(dg["SoDienThoai"].ToString());
                    li.Tag = dg["MaDocGia"].ToString();
                    i++;
                }
            }
        }

        void LuuMoiDocGia(string MaDocGia, string HoDocGia, string TenLotDocGia, string TenDocGia, DateTime NgaySinh, string SoNha, string Duong,
            string Quan, string SoDienThoai, DateTime NgayDangKi, DateTime NgayHethanDK)
        {

            DocGiaBLL cls = new DocGiaBLL(MaDocGia, HoDocGia, TenLotDocGia, TenDocGia, NgaySinh, SoNha, Duong, Quan, SoDienThoai, NgayDangKi, NgayHethanDK);

            int kq = cls.Them();

            switch (kq)
            {
                case 0:
                    {
                        MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDocGia();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Thêm Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Trùng Mã đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaDocGia.Focus();
                        break;
                    }

            }
        }

        void HienDocGiaTheoMa(string MaDocGia)
        {
            DataTable dt = new DocGiaBLL().truyXuatDuLieuBang_DocGia();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["MaDocGia"].ToString() == MaDocGia)
                    {
                        txtMaDocGia.Text = dr["MaDocGia"].ToString();
                        txtHoTenDocGia.Text = dr["HoDocGia"].ToString() + " " + dr["TenLotDocGia"].ToString() + " " + dr["TenDocGia"].ToString();
                        txtDiaChi.Text = dr["SoNha"].ToString() + "," + dr["Duong"].ToString() + "," + dr["Quan"].ToString(); ;
                        dtbNgaySinh.Text = dr["NgaySinh"].ToString();
                        dtNgayDangKi.Text = dr["NgayDangKi"].ToString();
                        dtNgayHetHan.Text = dr["NgayHetHanDK"].ToString();
                        txtSoDienThoaiDG.Text = dr["SoDienThoai"].ToString();


                        



                    }
                }
            }
        }

        void XoaDocGia(string MaDocGia)
        {
            DocGiaBLL cls = new DocGiaBLL(MaDocGia);
            int kq = cls.Xoa();

            switch (kq)
            {
                case 0:
                    {
                        MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDocGia();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Xóa Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Không Tồn Tại Mã đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Đọc gỉa này đang mượn sách.Không thể xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
        }


        void CapNhatDocGia(string MaDocGia, string HoDocGia, string TenLotDocGia, string TenDocGia, DateTime NgaySinh, string SoNha, string Duong,
                            string Quan, string SoDienThoai, DateTime NgayDangKi, DateTime NgayHetHanDK)
        {
            DocGiaBLL cls = new DocGiaBLL(MaDocGia, HoDocGia, TenLotDocGia, TenDocGia, NgaySinh, SoNha, Duong, Quan, SoDienThoai, NgayDangKi, NgayHetHanDK);

            int kq = cls.CapNhat();

            switch (kq)
            {
                case 0:
                    {
                        MessageBox.Show("Cập Nhật Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDocGia();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Cập Nhật Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Không Có Mã đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaDocGia.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Không Có đang mượn sách không thể sữa thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaDocGia.Focus();
                        break;
                    }
            }
        }


        
        bool KiemTra(string MaDocGia, string HoDocGia, string TenLotDocGia, string TenDocGia, string SoNha, string Duong,
                           string Quan, string SoDienThoai)
        {

            bool bolMaDocGia = false, bolHoDocGia = false, bolTenLotDocGia = false; bool bolTenDocGia = false;
            bool bolSoNha = false, bolDuong = false, bolQuan = false; bool bolSoDienThoai = false;// bolNgayDangKi = false, bolNgayHethanDk = false, bolNgaySinh = false;

            if (txtMaDocGiaTC.Text.Trim() != "")
            {
                bolMaDocGia = MaDocGia.ToLower().Contains(txtMaDocGiaTC.Text.ToLower()) ? true : false;
            }
            //lấy họ
            if (txtHoDGTC.Text.Trim() != "")
            {
                bolHoDocGia = HoDocGia.ToLower().Contains(txtHoDGTC.Text.ToLower()) ? true : false;
            }

            if (txtTenDG.Text.Trim() != "")
            {
                bolTenDocGia = TenDocGia.ToLower().Contains(txtTenDG.Text.ToLower()) ? true : false;
            }
            if (txtTenLotDG.Text.Trim() != "")
            {
                bolTenLotDocGia = TenLotDocGia.ToLower().Contains(txtTenLotDG.Text.ToLower()) ? true : false;
            }
            if (txtSDT_TC.Text.Trim() != "")
            {
                bolSoDienThoai = SoDienThoai.ToLower().Contains(txtSDT_TC.Text.ToLower()) ? true : false;
            }
            if (txtSoNhaDG.Text.Trim() != "")
            {
                bolSoNha = SoNha.ToLower().Contains(txtSoNhaDG.Text.ToLower()) ? true : false;
            }
            if (txtQuanDG.Text.Trim() != "")
            {
                bolQuan = Quan.ToLower().Contains(txtQuanDG.Text.ToLower()) ? true : false;
            }
            //lấy đường
            if (txtDuongDGTC.Text.Trim() != "")
            {
                bolDuong = Duong.ToLower().Contains(txtDuongDGTC.Text.ToLower()) ? true : false;
            }

            if (bolMaDocGia || bolHoDocGia || bolTenLotDocGia || bolTenDocGia|| bolSoDienThoai || bolSoNha || bolQuan || bolDuong)
                return true;


            return false;
        }



        void TraCuu()
        {
            DataTable dt = new DocGiaBLL().truyXuatDuLieuBang_DocGia();
            if (dt.Rows.Count > 0)
            {
                lvwDSDocGia.Items.Clear();
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    if (KiemTra(dr["MaDocGia"].ToString(), dr["HoDocGia"].ToString(), dr["TenLotDocGia"].ToString(), dr["TenDocGia"].ToString(), dr["Sonha"].ToString(),
                        dr["Duong"].ToString(), dr["Quan"].ToString(), dr["SoDienThoai"].ToString()))
                    {
                        ListViewItem li = lvwDSDocGia.Items.Add(dr["MaDocGia"].ToString());

                        li.SubItems.Add(dr["HoDocGia"].ToString() + " " + dr["TenLotDocGia"].ToString() + " " + dr["TenDocGia"].ToString());
                        li.SubItems.Add(dr["NgaySinh"].ToString());

                        li.SubItems.Add(dr["SoNha"].ToString() + "," + dr["Duong"].ToString() + "," + dr["Quan"].ToString());
                        li.SubItems.Add(dr["NgayDangKi"].ToString());
                        li.SubItems.Add(dr["NgayHethanDK"].ToString());
                        li.SubItems.Add(i.ToString());
                        li.SubItems.Add(dr["SoDienThoai"].ToString());

                        i++;
                    }

                }
            }
        }

        #endregion

        private void Usc_DocGia_Load(object sender, EventArgs e)
        {
            LoadDocGia();
            btnCapNhatDocGia.Enabled = false;
            btnXoaDocGia.Enabled = false;
        }

        private void btnThemMoiDocGia_Click(object sender, EventArgs e)
        {

            LoadDocGia();
            btnLuuDocGia.Enabled = true;
            btnTraCuuDG.Enabled = true;
            btnCapNhatDocGia.Enabled = false;
            btnXoaDocGia.Enabled = false;
            txtMaDocGia.Clear();
            txtHoTenDocGia.Clear();
            txtDiaChi.Clear();
            txtSoDienThoaiDG.Clear();
            //dtbNgaySinh.va = DateTime.Today();
            txtMaDocGia.Focus();
        }

        private void btnLuuDocGia_Click(object sender, EventArgs e)
        {

            if (txtMaDocGia.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Mã đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDocGia.Focus();
                return;
            }
            if (txtHoTenDocGia.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập tên đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTenDocGia.Focus();
                return;
            }


            //tách họ tên            
            string ho = "", ten = "", tenLot = "", hoTen = ""; int a, b, lengh;
            hoTen = Convert.ToString(txtHoTenDocGia.Text).Trim();
            lengh = hoTen.LastIndexOf("");
            a = hoTen.IndexOf(" ");//vi tri rong dau tien
            b = hoTen.LastIndexOf(" ");//vi tri rong cuoi
            ho = hoTen.Substring(0, a).Trim();
            ten = hoTen.Substring(b).Trim();
            tenLot = hoTen.Substring(a, b - a).Trim();


            //tách địa chỉ
            string sonha = "", duong = "", quan = "", diachi = ""; int c, d, leng;
            diachi = Convert.ToString(txtDiaChi.Text).Trim();
            leng = diachi.LastIndexOf("");
            c = diachi.IndexOf(",");//vi tri  dau tien_dấu phẩy
            d = diachi.LastIndexOf(",");//vi tri cuoi_dấu phẩy
            sonha = diachi.Substring(0, c).Trim();
            quan = diachi.Substring(d + 1).Trim();
            duong = diachi.Substring(c + 1, d - (c + 1)).Trim();
            //giới tính
            

            LuuMoiDocGia(txtMaDocGia.Text.Trim(), ho, tenLot, ten, dtbNgaySinh.Value, sonha, duong, quan, txtSoDienThoaiDG.Text, dtNgayDangKi.Value, dtNgayHetHan.Value); ;
        }

        private void lvwDSDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in lvwDSDocGia.SelectedIndices)
            {
                string MaDocGia = lvwDSDocGia.Items[i].Tag.ToString();
                HienDocGiaTheoMa(MaDocGia);
                break;
            }
            btnCapNhatDocGia.Enabled = true;
            btnXoaDocGia.Enabled = true;
            btnLuuDocGia.Enabled = false;
            btnThemMoiDocGia.Enabled = true;
            btnTraCuuDG.Enabled = false;
        }

        private void btnXoaDocGia_Click(object sender, EventArgs e)
        {
            if (txtMaDocGia.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Mã đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XoaDocGia(txtMaDocGia.Text);
            btnThemMoiDocGia_Click(sender, e);
        }

        private void btnCapNhatDocGia_Click(object sender, EventArgs e)
        {
            if (txtMaDocGia.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Mã  đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDocGia.Focus();
                return;
            }
            if (txtHoTenDocGia.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Tên đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTenDocGia.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return;
            }


           
            //tách họ tên            
            string ho = "", ten = "", tenLot = "", hoTen = ""; int a, b, lengh;
            hoTen = Convert.ToString(txtHoTenDocGia.Text).Trim();
            lengh = hoTen.LastIndexOf("");
            a = hoTen.IndexOf(" ");//vi tri rong dau tien
            b = hoTen.LastIndexOf(" ");//vi tri rong cuoi
            ho = hoTen.Substring(0, a).Trim();
            ten = hoTen.Substring(b).Trim();
            tenLot = hoTen.Substring(a, b - a).Trim();


            //tách địa chỉ
            string sonha = "", duong = "", quan = "", diachi = ""; int c, d, leng;
            diachi = Convert.ToString(txtDiaChi.Text).Trim();
            leng = diachi.LastIndexOf("");
            c = diachi.IndexOf(",");//vi tri  dau tien_dấu phẩy
            d = diachi.LastIndexOf(",");//vi tri cuoi_dấu phẩy
            sonha = diachi.Substring(0, c).Trim();
            quan = diachi.Substring(d + 1).Trim();
            duong = diachi.Substring(c + 1, d - (c + 1)).Trim();
            //giới tính
            
            CapNhatDocGia(txtMaDocGia.Text.Trim(), ho, tenLot, ten, dtbNgaySinh.Value, sonha, duong, quan, txtSoDienThoaiDG.Text, dtNgayDangKi.Value, dtNgayHetHan.Value);
        }

        private void btnTraCuuDG_Click(object sender, EventArgs e)
        {
            TraCuu();
        }
    }
}
