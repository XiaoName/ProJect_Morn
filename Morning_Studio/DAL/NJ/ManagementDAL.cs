using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
   public class ManagementDAL
    {
        /// <summary>
        /// 权限查询
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<User> getManage(string a,string b,string c)
        {
            string sql = string.Format("SELECT  dbo.MS_Department.DepartName, dbo.MS_PositionTable.PositionName, dbo.MS_User.[User_Name], " +
                   "dbo.MS_User.User_JobNumber " +
                   "FROM dbo.MS_User, dbo.MS_Department, dbo.MS_PositionTable where dbo.MS_User.Departmentid = dbo.MS_Department.DepartID " +
                   "and dbo.MS_User.Dutyid = dbo.MS_PositionTable.PositionId AND " +
                   "dbo.MS_Department.DepartID = dbo.MS_PositionTable.DepartmentID  and Physical_Deletipn='true' and(MS_User.User_JobNumber like'%{0}%' " +
                   "or MS_User.[User_Name] like'%{0}%')and MS_Department.DepartName like '%{1}%'and MS_PositionTable.PositionName like '%{2}%'",b,a,c);
            var table = DBHelper.Select(sql);
            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    JobNumber=Convert.ToInt32(item["User_JobNumber"]),
                    Name=item["User_Name"].ToString(),
                    Departmentid=new Department
                    {
                        DepartName=item["DepartName"].ToString()
                    },
                    Dutyud=new PositionTable
                    {
                        PositionName=item["PositionName"].ToString()
                    }
                };
                list.Add(user);
            }
            return list;
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool getUpManage(string a,string b)
        {
            string sql = string.Format("UPDATE [dbo].[MS_User] SET [Physical_Deletion] = '{0}' WHERE [User_JobNumber] like '%2017001%'", a, b);
            var r = DBHelper.NonQuery(sql);
            return r > 0;
        }
    }
}
