using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAMCONGHV.DAO
{
    class NgayCCDAO
    {
        private static NgayCCDAO instance;

        public static NgayCCDAO Instance
        {
            get { if (instance == null) instance = new NgayCCDAO(); return NgayCCDAO.instance; }
            private set { NgayCCDAO.instance = value; }
        }
        private NgayCCDAO() { }

        public DataTable LoadListKhoaPhong()
        {
            string query = "select KHOAPHONGID, KHOAPHONGTEN FROM HSOFTDKBD.DT_KHOAPHONG ORDER BY KHOAPHONGTEN ASC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool Kiemtra_MoChamCong(string NGAYCHAMCONG)
        {
            string query = string.Format("SELECT count(MOCCID) FROM HSOFTDKBD.DT_MOCHAMCONG where to_date('{0}','dd/MM/yyyy') >= to_date(HCKTHOIGIANBATDAU) and to_date('{0}','dd/MM/yyyy') <=  to_date(HCKTHOIGIANKETTHUC)  ",NGAYCHAMCONG);
            int data = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return data > 0;
        }


    }
}
