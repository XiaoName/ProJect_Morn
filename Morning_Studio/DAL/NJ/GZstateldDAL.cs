using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
    /// <summary>
    /// 员工类型
    /// </summary>
   public class GZstateldDAL
    {
        public List<GZstateld> gettatelds()
        {
            List<GZstateld> list = new List<GZstateld>();
            string str = "select * from MS_GZstateld";
            var table = DBHelper.Select(str);
            foreach (DataRow item in table.Rows)
            {
                GZstateld gZstateld = new GZstateld
                {
                    stateldId = Convert.ToInt32(item["stateld_id"]),
                    stateldName = item["stateld_Name"].ToString()
                };
                list.Add(gZstateld);
            }
            return list;
        }
    }
}
