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
    public partial class fdiemdanh : Form
    {
        public fdiemdanh(string ngay_cc, string kp)
        {
            InitializeComponent();
            LoadDMCHAMCONG();
            LoadDMCHAMCONG_DTTL();

            txbNgay_CC.Text = ngay_cc;
            txbKP.Text = kp;
            txbMMYY.Text = ngay_cc.Substring(3, 2) + ngay_cc.Substring(8, 2);
            txbNGAY.Text = ngay_cc.Substring(0, 2);
            txbIDKP.Text = ChamCongDAO.Instance.Get_IDKP_by_TEN(kp).ToString();
            LoadChamCong();
            LoadChamCong_DTTL();
            cbbChamcong.Text = "";
            txbIDHCK.Text = "";
            LoadDS_Lop_DTTL();
            txbIDCHONLOP.Text = "0";
        }
        public fdiemdanh()
        {
            InitializeComponent();
        }

        void LoadChamCong()
        {
            int i = 4;
            dtgvHCK.DataSource = ChamCongDAO.Instance.LoadChamCong_by_MMYY_IDKP(txbMMYY.Text, Convert.ToInt32(txbIDKP.Text), txbNgay_CC.Text);
            dtgvHCK.Columns[0].Width = 70;
            dtgvHCK.Columns[1].Width = 130;
            dtgvHCK.Columns[2].Width = 70;
            dtgvHCK.Columns[3].Width = 200;

            dtgvHCK.Columns[0].Frozen = true;
            dtgvHCK.Columns[1].Frozen = true;
            dtgvHCK.Columns[2].Frozen = true;
            dtgvHCK.Columns[3].Frozen = true;
            dtgvHCK.Columns[36].Visible = false;

            for (i = 4; i < 35; i++)
            {
                dtgvHCK.Columns[i].Width = 40;
            }
            dtgvHCK.Columns[35].Width = 300;
            dtgvHCK.Columns[Convert.ToInt32(txbNGAY.Text) + 3].Width = 80;

            //            dtgrvChamCong.Rows[0].Cells[25].Style.BackColor = Color.Blue;

            //           SetColumnColor(Convert.ToInt32(txbNGAY.Text) + 3, Color.Blue);

        }
        void LoadDMCHAMCONG()
        {
            cbbChamcong.DataSource = ChamCongDAO.Instance.LoadlistDMCC();
            cbbChamcong.ValueMember = "DMCDVIETTAT";
            cbbChamcong.DisplayMember = "DMCDTEN";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void dtgvHCK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvHCK.Rows[e.RowIndex];
                txbIDHCK.Text = row.Cells[36].Value.ToString();
                txbHV.Text = row.Cells[1].Value.ToString();
                txbGhiChu_HCK.Text = row.Cells[35].Value.ToString();
                cbbChamcong.Text = "";


            }
        }
        private void SetColumnColor(int indexCol, Color color)
        {
            for (int row = 0; row < dtgvHCK.Rows.Count; row++)
            {
                dtgvHCK.Rows[row].Cells[indexCol].Style.BackColor = color;
            }
        }

        private void dtgvHCK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColumnColor(Convert.ToInt32(txbNGAY.Text) + 3, Color.LightGray);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string COT = 'N' + Convert.ToInt32(txbNGAY.Text).ToString();
            string CHAMCONG = txbKH.Text;
            string MMYY = txbMMYY.Text;
            string DDMMYY = txbNgay_CC.Text;
            string GhiChu = DataProvider.Instance.FormatStringInput(txbGhiChu_HCK.Text);
            int IDHCK = 0;
            if (Int32.TryParse(txbIDHCK.Text, out IDHCK))
            {
                ChamCongDAO.Instance.UpdateChamCong(COT, CHAMCONG, IDHCK, MMYY, DDMMYY, GhiChu);
                LoadChamCong();
                txbKH.Text = " ";
                cbbChamcong.Text = "";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string COT = 'N' + Convert.ToInt32(txbNGAY.Text).ToString();
            string CHAMCONG = "H";
            string MMYY = txbMMYY.Text;
            string DDMMYY = txbNgay_CC.Text;
            int IDKHOAPHONG = 0;
            if (Int32.TryParse(txbIDKP.Text, out IDKHOAPHONG))
            {
                ChamCongDAO.Instance.UpdateChamCong_ALL(COT, CHAMCONG, MMYY, DDMMYY, IDKHOAPHONG);
                LoadChamCong();
            }
        }

        private void cbbChamcong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChamCongDAO.Instance.Kiemtra_KH(cbbChamcong.Text))
            {
                txbKH.Text = ChamCongDAO.Instance.GetKH_By_DMChamCong(cbbChamcong.Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string COT = 'N' + Convert.ToInt32(txbNGAY.Text).ToString();
            string MMYY = txbMMYY.Text;
            int IDKHOAPHONG = 0;
            if (Int32.TryParse(txbIDKP.Text, out IDKHOAPHONG))
            {
                ChamCongDAO.Instance.DeleteChamCong(COT, MMYY, IDKHOAPHONG);
                LoadChamCong();
            }
        }

        private void txbTimHV_HCK_MouseUp(object sender, MouseEventArgs e)
        {
            txbTimHV_HCK.Text = "";
        }

        private void txbTimHV_HCK_TextChanged(object sender, EventArgs e)
        {
            dtgvHCK.DataSource = ChamCongDAO.Instance.LoadChamCong_by_MMYY_IDKP_txbTimHV(txbMMYY.Text, Convert.ToInt32(txbIDKP.Text), txbNgay_CC.Text, txbTimHV_HCK.Text);
        }




        /// <summary>
        /// //DTTL
        /// </summary>
        void LoadChamCong_DTTL()
        {

            int IDCHONLOP = 0;
            if (Int32.TryParse(txbIDCHONLOP.Text, out IDCHONLOP))
            {
                int i = 4;
                dtgvDTTL.DataSource = ChamcongDTTLDAO.Instance.LoadChamCong_CHONLOP_DTTL(txbMMYY.Text, Convert.ToInt32(txbIDKP.Text), IDCHONLOP);
                dtgvDTTL.Columns[0].Width = 40;
                dtgvDTTL.Columns[1].Width = 150;
                dtgvDTTL.Columns[2].Width = 70;
                dtgvDTTL.Columns[3].Width = 200;

                dtgvDTTL.Columns[0].Frozen = true;
                dtgvDTTL.Columns[1].Frozen = true;
                dtgvDTTL.Columns[2].Frozen = true;
                dtgvDTTL.Columns[3].Frozen = true;
                dtgvDTTL.Columns[36].Visible = false;

                for (i = 4; i < 35; i++)
                {
                    dtgvDTTL.Columns[i].Width = 40;
                }
                dtgvDTTL.Columns[35].Width = 300;
                dtgvDTTL.Columns[Convert.ToInt32(txbNGAY.Text) + 3].Width = 80;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbTimHV_DTTL_TextChanged(object sender, EventArgs e)
        {
            dtgvDTTL.DataSource = ChamcongDTTLDAO.Instance.LoadChamCong_DTTL_HV(txbMMYY.Text, Convert.ToInt32(txbIDKP.Text), txbTimHV_DTTL.Text);
        }

        private void txbTimHV_DTTL_MouseUp(object sender, MouseEventArgs e)
        {
            txbTimHV_DTTL.Text = "";
        }

        private void dtgvDTTL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDTTL.Rows[e.RowIndex];
                txbIDHOCVIEN_DTTL.Text = row.Cells[0].Value.ToString();
                txbHVHOTEN_DTTL.Text = row.Cells[1].Value.ToString();
                txbGhichu_DTTL.Text = row.Cells[35].Value.ToString();
                cbbChamcong_DTTL.Text = "";


            }
        }
        void LoadDMCHAMCONG_DTTL()
        {
            cbbChamcong_DTTL.DataSource = ChamCongDAO.Instance.LoadlistDMCC();
            cbbChamcong_DTTL.ValueMember = "DMCDVIETTAT";
            cbbChamcong_DTTL.DisplayMember = "DMCDTEN";
        }

        private void cbbChamcong_DTTL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChamCongDAO.Instance.Kiemtra_KH(cbbChamcong_DTTL.Text))
            {
                txbKyHieu_DTTL.Text = ChamCongDAO.Instance.GetKH_By_DMChamCong(cbbChamcong_DTTL.Text);
            }
        }
        private void SetColumnColor_DTTL(int indexCol, Color color)
        {
            for (int row = 0; row < dtgvDTTL.Rows.Count; row++)
            {
                dtgvDTTL.Rows[row].Cells[indexCol].Style.BackColor = color;
            }
        }

        private void dtgvDTTL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColumnColor_DTTL(Convert.ToInt32(txbNGAY.Text) + 3, Color.LightGray);
        }




        void LoadDS_Lop_DTTL()
        {
            cbbChonLop_DTTL.DataSource = ChamcongDTTLDAO.Instance.Load_TENLOP_DTTL(Convert.ToInt32(txbIDKP.Text));
            cbbChonLop_DTTL.ValueMember = "DSLOPDTTLID";
            cbbChonLop_DTTL.DisplayMember = "NOIDUNGHOC";
        }

        private void cbbChonLop_DTTL_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbIDCHONLOP.Text = cbbChonLop_DTTL.SelectedValue.ToString();
            int IDCHONLOP = 0;
            if (Int32.TryParse(txbIDCHONLOP.Text, out IDCHONLOP))
            {
                if (txbIDCHONLOP.Text == "0")
                {
                    MessageBox.Show("Chọn lớp");
                }
                else
                {
                    LoadChamCong_DTTL();
                }
            }

        }

        void LoadChamcong_ChonLop_DTTL(int IDCHONLOP)
        {
            dtgvDTTL.DataSource = ChamcongDTTLDAO.Instance.LoadChamCong_CHONLOP_DTTL(txbMMYY.Text, Convert.ToInt32(txbIDKP.Text), IDCHONLOP);

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void btnCapnhat_DTTL_Click(object sender, EventArgs e)
        {
            string COT_NGAY = 'N' + Convert.ToInt32(txbNGAY.Text).ToString();
            string LOAI_CC = txbKyHieu_DTTL.Text;
            int IDHOCVIEN = 0;
            string MMYY = txbMMYY.Text;
            string DDMMYY = txbNgay_CC.Text;
            string GhiChu = DataProvider.Instance.FormatStringInput(txbGhichu_DTTL.Text);
            int IDLOP = 0;

            if (Int32.TryParse(txbIDCHONLOP.Text, out IDLOP))
            {
                if (LOAI_CC == " ")
                {
                    if (IDLOP > 0)
                    {
                        if (Int32.TryParse(txbIDHOCVIEN_DTTL.Text, out IDHOCVIEN))
                        {
                            ChamcongDTTLDAO.Instance.UpdateChamCong_DTTL_LOAI_CC_NULL(COT_NGAY, LOAI_CC, IDLOP, IDHOCVIEN, MMYY, GhiChu, DDMMYY);
                            LoadChamCong_DTTL();
                            txbKyHieu_DTTL.Text = " ";
                            cbbChamcong_DTTL.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Chọn học viên");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chọn lớp");
                    }

                }
                else
                {
                    if (IDLOP > 0)
                    {
                        if (Int32.TryParse(txbIDHOCVIEN_DTTL.Text, out IDHOCVIEN))
                        {
                            ChamcongDTTLDAO.Instance.UpdateChamCong_DTTL(COT_NGAY, LOAI_CC, IDLOP, IDHOCVIEN, MMYY, GhiChu, DDMMYY);
                            LoadChamCong_DTTL();
                            txbKyHieu_DTTL.Text = " ";
                            cbbChamcong_DTTL.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Chọn học viên");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chọn lớp");
                    }
                }
            }

            else
            {
                MessageBox.Show("Chọn lớp");
            }
        }


        private void btnLuuAll_DTTL_Click(object sender, EventArgs e)
        {
            string COT_NGAY = 'N' + Convert.ToInt32(txbNGAY.Text).ToString();
            string LOAI_CC = "H";
            string MMYY = txbMMYY.Text;
            string DDMMYY = txbNgay_CC.Text;
            int IDKHOAPHONG = 0;
            int MALOP = 0;
            if (Int32.TryParse(txbIDKP.Text, out IDKHOAPHONG))
            {
                if (Int32.TryParse(txbIDCHONLOP.Text, out MALOP))
                {
                    ChamcongDTTLDAO.Instance.UpdateChamCong_DTTL_ALL(COT_NGAY, LOAI_CC, MMYY, MALOP, IDKHOAPHONG, DDMMYY);
                    LoadChamCong_DTTL();
                }
            }
        }

        private void btnXoa_DTTL_ALL_Click(object sender, EventArgs e)
        {
            string COT = 'N' + Convert.ToInt32(txbNGAY.Text).ToString();
            string MMYY = txbMMYY.Text;
            int IDKHOAPHONG = 0;
            int MALOP = 0;
            if (Int32.TryParse(txbIDKP.Text, out IDKHOAPHONG))
            {
                if (Int32.TryParse(txbIDCHONLOP.Text, out MALOP))
                {
                    ChamcongDTTLDAO.Instance.DeleteChamCong_DTTL_ALL(COT, MMYY, IDKHOAPHONG, MALOP);
                    LoadChamcong_ChonLop_DTTL(MALOP);
                }
                else
                {
                    MessageBox.Show("Chọn lớp");
                }
            }
            else
            {
                MessageBox.Show("Chọn khoa phòng");
            }
        }

        private void fdiemdanh_Load(object sender, EventArgs e)
        {

        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string KP = "";
            KP = txbKP.Text;
            fMatkhau f = new fMatkhau(KP);
            f.Show();
        }
    }
}


