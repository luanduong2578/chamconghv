using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAMCONGHV.DAO
{
    class ChamcongDTTLDAO
    {
        private static ChamcongDTTLDAO instance;

        public static ChamcongDTTLDAO Instance
        {
            get { if (instance == null) instance = new ChamcongDTTLDAO(); return ChamcongDTTLDAO.instance; }
            private set { ChamcongDTTLDAO.instance = value; }
        }
        private ChamcongDTTLDAO() { }
              
        public string LoadNamHienTai()
        {
            DateTime now = DateTime.Now;
            return (now.Year).ToString();
        }

        public bool KIEMTRA_CHAMCONG_TONTAI(string MMYY, int IDHOCVIEN, int IDLOPHOC)
        {
            string query = string.Format("select COUNT(*) from HSOFTDKBD.DT_CHAMCONGDTTL WHERE MMYY = '{0}'  AND MALOP = {1} AND IDHOCVIEN = {2}", MMYY, IDLOPHOC, IDHOCVIEN);
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return result > 0;
        }
        
        public DataTable LoadChamCong_DTTL(string MMYY,int IDKHOAPHONG)
        {
            string query = string.Format("SELECT CC.IDHOCVIEN AS IDHV,HV.HOCVIENHOTEN AS HOC_VIEN,HV.HOCVIENNAMSINH AS NAM_SINH, LOPDTTL.NOIDUNGHOC AS TEN_LOP,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,N11,N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, CC.GHICHU, LOPDTTL.DSLOPDTTLID         FROM HSOFTDKBD.DT_CHAMCONGDTTL CC   INNER JOIN HSOFTDKBD.DT_DSLOPDTTL LOPDTTL ON LOPDTTL.DSLOPDTTLID = CC.MALOP   INNER JOIN HSOFTDKBD.DT_HOCVIEN HV ON HV.HOCVIENID = CC.IDHOCVIEN      WHERE CC.TINHTRANG > 0 AND MMYY ='{0}' AND CC.IDKHOAPHONG = {1}", MMYY, IDKHOAPHONG);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public DataTable LoadChamCong_DTTL_HV(string MMYY,int IDKHOAPHONG, string HOCVIENHOTEN)
        {
            string query = string.Format("SELECT CC.IDHOCVIEN AS IDHV,HV.HOCVIENHOTEN AS HOC_VIEN,HV.HOCVIENNAMSINH AS NAM_SINH, LOPDTTL.NOIDUNGHOC AS TEN_LOP,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,N11,N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, CC.GHICHU, LOPDTTL.DSLOPDTTLID         FROM HSOFTDKBD.DT_CHAMCONGDTTL CC   INNER JOIN HSOFTDKBD.DT_DSLOPDTTL LOPDTTL ON LOPDTTL.DSLOPDTTLID = CC.MALOP   INNER JOIN HSOFTDKBD.DT_HOCVIEN HV ON HV.HOCVIENID = CC.IDHOCVIEN      WHERE CC.TINHTRANG > 0 AND MMYY ='{0}' AND CC.IDKHOAPHONG = {1}  AND + UPPER(HV.HOCVIENHOTEN) LIKE UPPER('%{2}%') ", MMYY, IDKHOAPHONG, HOCVIENHOTEN);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        
        public DataTable Load_TENLOP(int KHOAPHONGID)
        {
            string query = string.Format("SELECT DSLOPDTTLID, NOIDUNGHOC from HSOFTDKBD.DT_DSLOPDTTL WHERE TRANGTHAILOP = 0 and KHOAPHONGID = {0} ORDER BY NOIDUNGHOC ASC ", KHOAPHONGID);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool Kiemtra_MALOP_MMYY_DTTL(int MALOP, string MMYY, int IDHOCVIEN)
        {
            string query = string.Format("select COUNT(*) from HSOFTDKBD.DT_CHAMCONGDTTL WHERE MALOP = {0}  AND MMYY = '{1}' AND IDHOCVIEN = {2}", MALOP, MMYY, IDHOCVIEN);
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return result > 0;
        }
        
  
        public DataTable Load_TENLOP_DTTL(int KHOAPHONGID)
        {
            string query = string.Format("SELECT DSLOPDTTLID, NOIDUNGHOC from HSOFTDKBD.DT_DSLOPDTTL WHERE TRANGTHAILOP = 0 AND KHOAPHONGID = {0} ORDER BY NOIDUNGHOC ASC", KHOAPHONGID);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LoadChamCong_CHONLOP_DTTL(string MMYY, int IDKHOAPHONG, int MALOP)
        {
            string query = string.Format("SELECT CC.IDHOCVIEN AS IDHV,HV.HOCVIENHOTEN AS HOC_VIEN,HV.HOCVIENNAMSINH AS NAM_SINH, LOPDTTL.NOIDUNGHOC AS TEN_LOP,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,N11,N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, CC.GHICHU, LOPDTTL.DSLOPDTTLID         FROM HSOFTDKBD.DT_CHAMCONGDTTL CC   INNER JOIN HSOFTDKBD.DT_DSLOPDTTL LOPDTTL ON LOPDTTL.DSLOPDTTLID = CC.MALOP   INNER JOIN HSOFTDKBD.DT_HOCVIEN HV ON HV.HOCVIENID = CC.IDHOCVIEN      WHERE CC.TINHTRANG > 0 AND MMYY ='{0}' AND CC.IDKHOAPHONG = {1} AND LOPDTTL.DSLOPDTTLID = {2}", MMYY, IDKHOAPHONG, MALOP);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LoadChamCong_CHONLOP_DTTL_change(string MMYY, int IDKHOAPHONG)
        {
            string query = string.Format("SELECT CC.IDHOCVIEN AS IDHV,HV.HOCVIENHOTEN AS HOC_VIEN,HV.HOCVIENNAMSINH AS NAM_SINH, LOPDTTL.NOIDUNGHOC AS TEN_LOP,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,N11,N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, CC.GHICHU, LOPDTTL.DSLOPDTTLID         FROM HSOFTDKBD.DT_CHAMCONGDTTL CC   INNER JOIN HSOFTDKBD.DT_DSLOPDTTL LOPDTTL ON LOPDTTL.DSLOPDTTLID = CC.MALOP   INNER JOIN HSOFTDKBD.DT_HOCVIEN HV ON HV.HOCVIENID = CC.IDHOCVIEN      WHERE CC.TINHTRANG > 0 AND MMYY ='{0}' AND CC.IDKHOAPHONG = {1} AND LOPDTTL.DSLOPDTTLID = 0", MMYY, IDKHOAPHONG);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public bool UpdateChamCong_DTTL(string COT_NGAY, string LOAI_CC, int IDLOP, int IDHOCVIEN, string MMYY, string GHICHU, string DDMMYY)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_CHAMCONGDTTL SET  {0} = '{1}', GHICHU ='{2}' WHERE MALOP = {3} AND MMYY = {4} AND IDHOCVIEN ={5} and to_date('{6}','dd/MM/yyyy') >= to_date(HCKTHOIGIANBATDAU) and to_date('{6}','dd/MM/yyyy') <=  to_date(HCKTHOIGIANKETTHUC )", COT_NGAY, LOAI_CC, GHICHU, IDLOP, MMYY, IDHOCVIEN, DDMMYY);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateChamCong_DTTL_LOAI_CC_NULL(string COT_NGAY, string LOAI_CC, int IDLOP, int IDHOCVIEN, string MMYY, string GHICHU, string DDMMYY)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_CHAMCONGDTTL SET  {0} = NULL, GHICHU ='{1}' WHERE MALOP = {2} AND MMYY = {3} AND IDHOCVIEN ={4} and to_date('{5}','dd/MM/yyyy') >= to_date(HCKTHOIGIANBATDAU) and to_date('{5}','dd/MM/yyyy') <=  to_date(HCKTHOIGIANKETTHUC )", COT_NGAY,  GHICHU, IDLOP, MMYY, IDHOCVIEN, DDMMYY);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateChamCong_DTTL_ALL(string COT_NGAY, string LOAI_CC, string MMYY, int MALOP, int IDKPIDKHOAPHONG, string DDMMYY)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_CHAMCONGDTTL set {0} = '{1}' Where MMYY = '{2}' AND IDKHOAPHONG = {3} AND to_date('{4}','dd/MM/yyyy') >= to_date(HCKTHOIGIANBATDAU) and to_date('{4}','dd/MM/yyyy') <=  to_date(HCKTHOIGIANKETTHUC ) AND MALOP = {5} AND {0} is null", COT_NGAY, LOAI_CC, MMYY, IDKPIDKHOAPHONG, DDMMYY, MALOP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteChamCong_DTTL_ALL(string COT, string MMYY, int IDKP,int MALOP)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_CHAMCONGDTTL set {0} = NULL Where MMYY = '{1}' AND IDKHOAPHONG = {2} AND MALOP = {3} ", COT, MMYY, IDKP,MALOP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
