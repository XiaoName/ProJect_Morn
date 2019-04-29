using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace DAL
{
   public class DepartDAL
    {
        /// <summary>
        /// 部门
        /// </summary>
        /// <returns></returns>
        public List<Department> getDepart()
        {
            string sql = string.Format("select * from MS_Department");
            var table = DBHelper.Select(sql);
            List<Department> list = new List<Department>();
            foreach (DataRow item in table.Rows)
            {
                Department depart = new Department
                {
                    DepartID = Convert.ToInt32(item["DepartID"]),
                    DepartName = item["DepartName"].ToString()
                };
                list.Add(depart);
            }
            return list;
        }
    }
}
