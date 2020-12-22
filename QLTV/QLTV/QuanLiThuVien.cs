using QLTV.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserconTrol();
        }
        public void LoadUserconTrol()
        {
            LoaduscDanhMucSach();
            LoaduscTraCuuTheoNXB_TacGia();
            LoaduscTraCuuTheoDauSach_TheLoai_TuaSach();
            LoaduscMuonSach();
            LoaduscDocGia();

        }

        void LoaduscDanhMucSach()
        {
            Usc_DanhMucSach usc = new Usc_DanhMucSach();
            tabDanhMucSach.Controls.Clear();
            tabDanhMucSach.Controls.Add(usc);
        }


        void LoaduscMuonSach()
        {
            Usc_Muon_TraSach usc = new Usc_Muon_TraSach();
            tabMuon_TraSach.Controls.Clear();
            tabMuon_TraSach.Controls.Add(usc);
        }

        void LoaduscTraCuuTheoDauSach_TheLoai_TuaSach()
        {
            Usc_TraCuuTheoTheloai_TuaSach usc = new Usc_TraCuuTheoTheloai_TuaSach();
            tabTraCuuTheoDauSach_TheLoai_TuaSach.Controls.Clear();
            tabTraCuuTheoDauSach_TheLoai_TuaSach.Controls.Add(usc);
        }

        void LoaduscTraCuuTheoNXB_TacGia()
        {
            Usc_TraCuuTheoNXB_TacGia usc = new Usc_TraCuuTheoNXB_TacGia();
            tabTraCuu_NhaSX_TacGia.Controls.Clear();
            tabTraCuu_NhaSX_TacGia.Controls.Add(usc);
        }



        void LoaduscDocGia()
        {
            Usc_DocGia usc = new Usc_DocGia();
            tabDocGia.Controls.Clear();
            tabDocGia.Controls.Add(usc);
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
                this.Close();
        }

        private void toolTroGiup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hê qua sdt: 03545487213.", "Trợ giúp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DocGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabChucNang.SelectedIndex = 0;
        }

        private void MuonSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabChucNang.SelectedIndex = 1;
        }

        private void DanhMucSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabChucNang.SelectedIndex = 2;
        }

        private void TraCuuTheoNXBTacGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabChucNang.SelectedIndex = 3;
        }

        private void TraCuuTheoDS_TL_TSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabChucNang.SelectedIndex = 4;
        }

        private void tabChucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabChucNang.SelectedIndex == 0)
            {
                LoaduscDocGia();
            }
            if (tabChucNang.SelectedIndex == 1)
            {
                LoaduscMuonSach();
            }
            if (tabChucNang.SelectedIndex == 2)
            {
                LoaduscDanhMucSach();
            }
            if (tabChucNang.SelectedIndex == 3)
            {
                LoaduscTraCuuTheoNXB_TacGia();
            }
            if (tabChucNang.SelectedIndex == 4)
            {
                LoaduscTraCuuTheoDauSach_TheLoai_TuaSach();
            }
        }
    }
}
