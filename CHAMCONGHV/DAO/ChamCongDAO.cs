using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAMCONGHV.DAO
{
    class ChamCongDAO
    {
        private static ChamCongDAO instance;

        public static ChamCongDAO Instance
        {
            get { if (instance == null) instance = new ChamCongDAO(); return ChamCongDAO.instance; }
            private set { ChamCongDAO.instance = value; }
        }
        private ChamCongDAO() { }

        public int Get_IDKP_by_TEN(string KP)
        {
            string query = string.Format("select KHOAPHONGID from HSOFTDKBD.DT_KHOAPHONG WHERE KHOAPHONGTEN ='{0}'", KP);
            int data = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return data;
        }
        public DataTable LoadChamCong_by_MMYY_IDKP(string MMYY, int IDKP,string NGAYCHAMCONG)
        {

            string query = string.Format("SELECT HCK.HCKMASO AS MA_LOP, HV.HOCVIENHOTEN AS HOC_VIEN,HV.HOCVIENNAMSINH AS NAM_SINH, HCK.HCKNOIDUNGDAOTAO AS TEN_LOP,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,N11,N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, GHICHU,CC.IDHCK FROM HSOFTDKBD.DT_CHAMCONG CC INNER JOIN HSOFTDKBD.DT_HOCCHUYENKHOA HCK ON HCK.HCKID = CC.IDHCK INNER JOIN HSOFTDKBD.DT_HOCVIEN HV ON HV.HOCVIENID = CC.IDHOCVIEN  WHERE CC.TINHTRANG > 0 AND MMYY = '{0}' AND CC.IDKHOAPHONG = {1} AND to_date('{2}','dd/MM/yyyy') >= to_date(HCK.HCKTHOIGIANBATDAU) and to_date('{2}','dd/MM/yyyy') <=  to_date(HCK.HCKTHOIGIANKETTHUC)  ORDER BY HV.HOCVIENHOTEN ASC ", MMYY, IDKP, NGAYCHAMCONG);
            // string query = string.Format("SELECT hck.HCKID as MA_HCK,hck.HCKNAM as NAM_DT, hv.HOCVIENHOTEN as HO_TEN_HV,(select p.PHAITEN from HSOFTDKBD.DT_PHAI p where p.PHAITEN = hv.HOCVIENPHAI) as PHAI, hv.HOCVIENNAMSINH, (select cd.ChucDanhTen from HSOFTDKBD.DT_CHUCDANH cd where cd.CHUCDANHID = hv.IDCHUCDANH) as CHUC_DANH, (select dvct.DONVITEN from HSOFTDKBD.DT_BENHVIEN dvct where dvct.DONVIID = hv.IDDONVI) as DON_VI_CONG_TAC,(select kp.KHOAPHONGTEN from HSOFTDKBD.DT_KHOAPHONG kp where kp.KHOAPHONGID = hv.IDKHOAPHONG) as KHOA_PHONG,(select kpdt.KHOAPHONGTEN from HSOFTDKBD.DT_KHOAPHONG kpdt where kpdt.KHOAPHONGID = hck.KPDAOTAOID) as KHOA_PHONG_DAO_TAO,HCKNOIDUNGDAOTAO as NOI_DUNG_DAO_TAO, (select ttdt.TTDTTEN from HSOFTDKBD.DT_TINHTRANGDAOTAO ttdt where ttdt.TTDTID = hck.HCKTINHTRANGDTID) as TINH_TRANG_DAO_TAO, HCKKINHPHI as KINH_PHI,HCKTHOIGIANDAOTAO  as SO_THANG_HOC,HCKTHOIGIANBATDAU as THOI_GIAN_BD,HCKTHOIGIANKETTHUC as THOI_GIAN_KT,HCKKETQUATB as KET_QUA_TB,HCKKETQUALT as KET_QUA_LT,HCKKETQUATH as KET_QUA_TH,(select cn.CNDTTEN from hsoftdkbd.DT_CNDAOTAO cn where cn.CNDTID = hck.HCKCHUNGNHANID) as LOAI_CHUNG_NHAN, HCKGHICHU as GHI_CHU FROM HSOFTDKBD.DT_HOCCHUYENKHOA hck left join HSOFTDKBD.DT_HOCVIEN hv on hck.HCKHOCVIENID = hv.HOCVIENID", namDT);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LoadChamCong_by_MMYY_IDKP_txbTimHV(string MMYY, int IDKP, string NGAYCHAMCONG, string TIMHV)
        {

            string query = string.Format("SELECT HCK.HCKMASO AS MA_LOP, HV.HOCVIENHOTEN AS HOC_VIEN,HV.HOCVIENNAMSINH AS NAM_SINH, HCK.HCKNOIDUNGDAOTAO AS TEN_LOP,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,N11,N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, GHICHU,CC.IDHCK FROM HSOFTDKBD.DT_CHAMCONG CC INNER JOIN HSOFTDKBD.DT_HOCCHUYENKHOA HCK ON HCK.HCKID = CC.IDHCK INNER JOIN HSOFTDKBD.DT_HOCVIEN HV ON HV.HOCVIENID = CC.IDHOCVIEN  WHERE CC.TINHTRANG > 0 AND MMYY = '{0}' AND CC.IDKHOAPHONG = {1} AND to_date('{2}','dd/MM/yyyy') >= to_date(HCK.HCKTHOIGIANBATDAU) and to_date('{2}','dd/MM/yyyy') <=  to_date(HCK.HCKTHOIGIANKETTHUC) AND  + UPPER(HV.HOCVIENHOTEN) LIKE UPPER('%{3}%') ORDER BY HV.HOCVIENHOTEN ASC ", MMYY, IDKP, NGAYCHAMCONG,TIMHV);
            // string query = string.Format("SELECT hck.HCKID as MA_HCK,hck.HCKNAM as NAM_DT, hv.HOCVIENHOTEN as HO_TEN_HV,(select p.PHAITEN from HSOFTDKBD.DT_PHAI p where p.PHAITEN = hv.HOCVIENPHAI) as PHAI, hv.HOCVIENNAMSINH, (select cd.ChucDanhTen from HSOFTDKBD.DT_CHUCDANH cd where cd.CHUCDANHID = hv.IDCHUCDANH) as CHUC_DANH, (select dvct.DONVITEN from HSOFTDKBD.DT_BENHVIEN dvct where dvct.DONVIID = hv.IDDONVI) as DON_VI_CONG_TAC,(select kp.KHOAPHONGTEN from HSOFTDKBD.DT_KHOAPHONG kp where kp.KHOAPHONGID = hv.IDKHOAPHONG) as KHOA_PHONG,(select kpdt.KHOAPHONGTEN from HSOFTDKBD.DT_KHOAPHONG kpdt where kpdt.KHOAPHONGID = hck.KPDAOTAOID) as KHOA_PHONG_DAO_TAO,HCKNOIDUNGDAOTAO as NOI_DUNG_DAO_TAO, (select ttdt.TTDTTEN from HSOFTDKBD.DT_TINHTRANGDAOTAO ttdt where ttdt.TTDTID = hck.HCKTINHTRANGDTID) as TINH_TRANG_DAO_TAO, HCKKINHPHI as KINH_PHI,HCKTHOIGIANDAOTAO  as SO_THANG_HOC,HCKTHOIGIANBATDAU as THOI_GIAN_BD,HCKTHOIGIANKETTHUC as THOI_GIAN_KT,HCKKETQUATB as KET_QUA_TB,HCKKETQUALT as KET_QUA_LT,HCKKETQUATH as KET_QUA_TH,(select cn.CNDTTEN from hsoftdkbd.DT_CNDAOTAO cn where cn.CNDTID = hck.HCKCHUNGNHANID) as LOAI_CHUNG_NHAN, HCKGHICHU as GHI_CHU FROM HSOFTDKBD.DT_HOCCHUYENKHOA hck left join HSOFTDKBD.DT_HOCVIEN hv on hck.HCKHOCVIENID = hv.HOCVIENID", namDT);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LoadlistDMCC()
        {
            string query = "select DMCDVIETTAT, DMCDTEN FROM HSOFTDKBD.DT_DMCHAMCONG ORDER BY DMCDTEN ASC";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateChamCong(string COT, string CHAMCONG, int IDHCK, string MMYY, string DDMMYY,string GHICHU)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_CHAMCONG set {0} = '{1}', GHICHU = '{2}' Where IDHCK = {3} AND MMYY = '{4}' AND to_date('{5}','dd/MM/yyyy') >= to_date(HCKTHOIGIANBATDAU) and to_date('{5}','dd/MM/yyyy') <=  to_date(HCKTHOIGIANKETTHUC) ", COT, CHAMCONG, GHICHU, IDHCK, MMYY, DDMMYY);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateChamCong_ALL(string COT, string CHAMCONG, string MMYY, string DDMMYY,int IDKPIDKHOAPHONG)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_CHAMCONG set {0} = '{1}' Where MMYY = '{2}' AND IDKHOAPHONG = {3} AND to_date('{4}','dd/MM/yyyy') >= to_date(HCKTHOIGIANBATDAU) and to_date('{4}','dd/MM/yyyy') <=  to_date(HCKTHOIGIANKETTHUC ) AND {0} is null", COT, CHAMCONG, MMYY,IDKPIDKHOAPHONG, DDMMYY);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Kiemtra_KH(string DMCDTEN)
        {
            string query = string.Format("select count(DMCDVIETTAT) from HSOFTDKBD.DT_DMCHAMCONG where DMCDTEN ='{0}'", DMCDTEN);
            int data = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return data > 0;
        }
        public string GetKH_By_DMChamCong(string DMCDTEN)
        {
            string data = "";
            string query = string.Format("select DMCDVIETTAT from HSOFTDKBD.DT_DMCHAMCONG where DMCDTEN = '{0}'", DMCDTEN);
            data = DataProvider.Instance.ExecuteScalar(query).ToString();
            return data;
        }
        public bool DeleteChamCong(string COT, string MMYY, int IDKP)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_CHAMCONG set {0} = NULL Where MMYY = '{1}' AND IDKHOAPHONG = {2} ", COT, MMYY, IDKP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


        public bool Kiemtra_MK(string TENKP, string PASS)
        {
            string query = string.Format("select count(*) from HSOFTDKBD.DT_KHOAPHONG where KHOAPHONGTEN ='{0}' AND PASS = '{1}'", TENKP, PASS);
            int data = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return data > 0;
        }

    }
}
