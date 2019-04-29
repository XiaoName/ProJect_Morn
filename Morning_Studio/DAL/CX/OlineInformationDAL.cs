using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DAL.CX
{
 public   class OlineInformationDAL
    {
        public List<User> GetUsers(string a, string b, string c)
        {
            string sql = string.Format("SELECT  dbo.MS_User.User_JobNumber, dbo.MS_User.User_Name, dbo.MS_Department.DepartName, dbo.MS_User.User_Sex, " +
                   "dbo.MS_User.User_Email, dbo.MS_User.User_Address, dbo.MS_User.User_YGcard, dbo.MS_User.User_IdCard," +
                   "dbo.MS_User.User_Phone " +
                   "FROM dbo.MS_User, " +
                   "dbo.MS_Department where dbo.MS_User.Departmentid = dbo.MS_Department.DepartID and Departmentid like'%{0}%' and (User_JobNumber like '%{1}%' or [User_Name] like'%{1}%') and GZstateId like'%{2}%'", a, b, c);
            List<User> list = new List<User>();
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    JobNumber = Convert.ToInt32(item["User_JobNumber"]),
                    Name = item["User_Name"].ToString(),
                    Departmentid = new Department
                    {
                        DepartName = item["DepartName"].ToString()
                    }
                    //Dutyud = new PositionTable()
                    //{
                    // //   PositionId=Convert.ToInt32(item["PositionId"]),
                    //   PositionName = item["PositionName"].ToString()
                    //}
                };
                list.Add(user);
            }
            return list;
        }
    }
}
