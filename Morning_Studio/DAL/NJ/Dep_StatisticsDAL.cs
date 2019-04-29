using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
    public class Dep_StatisticsDAL
    {
        /// <summary>
        /// 查询部门人数
        /// </summary>
        /// <returns></returns>
        public List<User> getDepCount(string q,string w,string r)
        {
            string sql = string.Format("select MS_Department.DepartID,MS_Department.DepartName,COUNT(MS_User.Departmentid) 人数 from MS_User,MS_Department where MS_User.Departmentid=MS_Department.DepartID "+
                                      "and MS_User.Departmentid like '%{0}%'and MS_User.User_WorkStart between '{1}' and '{2}' "+
                                      "group by MS_Department.DepartID, MS_Department.DepartName",q,w,r);
            var table = DBHelper.Select(sql);
            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    Departmentid = new Department
                    {
                        DepartID = Convert.ToInt32(item["DepartID"]),
                        DepartName = item["DepartName"].ToString()
                    },
                    count = Convert.ToInt32(item["人数"])
                };
                list.Add(user);
            }
            return list;
        }
    }
}
