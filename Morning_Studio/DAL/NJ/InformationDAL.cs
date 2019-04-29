using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
    public class InformationDAL
    {
        public List<User> GetUsers(string a, string b, string c)
        {
            string sql = string.Format("SELECT  dbo.MS_User.User_JobNumber, dbo.MS_User.User_Name, dbo.MS_Department.DepartName, dbo.MS_User.User_Sex, " +
                   "dbo.MS_User.User_Email, dbo.MS_User.User_Address, dbo.MS_User.User_YGcard, dbo.MS_User.User_IdCard," +
                   "dbo.MS_User.User_Phone " +
                   "FROM dbo.MS_User, " +
                   "dbo.MS_Department where dbo.MS_User.Departmentid = dbo.MS_Department.DepartID and Departmentid like'%{0}%' and Physical_Deletipn ='true' and (User_JobNumber like '%{1}%' or [User_Name] like'%{1}%') and GZstateId like'%{2}%'", a, b, c);
            List<User> list = new List<User>();
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    JobNumber=Convert.ToInt32( item["User_JobNumber"]),
                    Name = item["User_Name"].ToString(),
                    Email = item["User_Email"].ToString(),
                    Address = item["User_Address"].ToString(),
                    Phone = item["User_Phone"].ToString(),
                    Departmentid=new Department
                    {
                        DepartName=item["DepartName"].ToString()
                    },
                    Sex=item["User_Sex"].ToString(),
                    YGcard=item["User_YGcard"].ToString(),
                    IdCard=item["User_IdCard"].ToString()
                };
                list.Add(user);
            }
            return list;
        }
    }
}
