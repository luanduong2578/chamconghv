using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAMCONGHV.DAO
{
    class PASS
    {

        private static PASS instance;

        public static PASS Instance
        {
            get { if (instance == null) instance = new PASS(); return PASS.instance; }
            private set { PASS.instance = value; }
        }
        private PASS() { }

        public bool UpdatePASS(string TENKP, string PASS)
        {
            string query = string.Format("UPDATE HSOFTDKBD.DT_KHOAPHONG set PASS = '{0}' Where KHOAPHONGTEN = '{1}'", PASS, TENKP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
