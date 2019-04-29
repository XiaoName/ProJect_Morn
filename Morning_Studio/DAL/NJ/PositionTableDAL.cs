using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;


namespace DAL
{
   public class PositionTableDAL
    {
        public List<PositionTable> posi(string s)
        {
            List<PositionTable> list = new List<PositionTable>();
            string sql = string.Format("select * from MS_PositionTable where DepartmentID = '{0}'",s);
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                PositionTable positionTable = new PositionTable
                {
                    PositionId = Convert.ToInt32(item["PositionId"]),
                    PositionName = item["PositionName"].ToString()
                };
                list.Add(positionTable);
            }
            return list;
        }
    }
}
