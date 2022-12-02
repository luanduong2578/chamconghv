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
    public partial class fMatkhau : Form
    {
        public fMatkhau(string kp)
        {
            InitializeComponent();
            txbKPMK.Text = kp;

        }
        public fMatkhau()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (ChamCongDAO.Instance.Kiemtra_MK(txbKPMK.Text, txbmkcu.Text))
            {
                if(PASS.Instance.UpdatePASS(txbKPMK.Text,txbmkm.Text))
                {
                    MessageBox.Show("Cập nhật thành công");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
            }
        }
    }
}
