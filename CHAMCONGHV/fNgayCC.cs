using CHAMCONGHV.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHAMCONGHV
{
    public partial class fNgayCC : Form
    {

        public fNgayCC()
        {
            InitializeComponent();
            LoadDSKhoaPhong();

        }
      
        void LoadDSKhoaPhong()
        {
            cbbKP.DataSource = NgayCCDAO.Instance.LoadListKhoaPhong();
            cbbKP.ValueMember = "KHOAPHONGID";
            cbbKP.DisplayMember = "KHOAPHONGTEN";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (ChamCongDAO.Instance.Kiemtra_MK(cbbKP.Text, txbmk.Text))
            {
                string ngayhethong = DateTime.Today.ToString("dd/MM/yyyy");
                if (dtpkNgayCC.Text == ngayhethong)
                {
                    string ngay_cc = dtpkNgayCC.Text;
                    string KP = cbbKP.Text;
                    fdiemdanh f = new fdiemdanh(ngay_cc, KP);
                    this.Hide();
                    f.Show();
                }
                else if (NgayCCDAO.Instance.Kiemtra_MoChamCong(dtpkNgayCC.Text))
                {
                    string ngay_cc = dtpkNgayCC.Text;
                    string KP = cbbKP.Text;
                    fdiemdanh f = new fdiemdanh(ngay_cc, KP);
                    this.Hide();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Hết giờ điểm danh (Liên hệ Phòng Đào tạo - Chỉ đạo tuyến)");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng");
            }
            
        }
    }
}
