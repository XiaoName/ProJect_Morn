using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
   public class AddressBookDAL
    {
        public List<User> GetUsers(string a, string b)
        {
            string sql = string.Format("SELECT [User_JobNumber],[User_Name],[User_Email],[User_Address],[User_Phone] FROM [dbo].[MS_User] where " +
                "Departmentid like'%{0}%' and (User_JobNumber like '%{1}%' or [User_Name] like'%{1}%')", b, a);
            List<User> list = new List<User>();
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    Name = item["User_Name"].ToString(),
                    Email = item["User_Email"].ToString(),
                    Address = item["User_Address"].ToString(),
                    Phone = item["User_Phone"].ToString()
                };
                list.Add(user);
            }
            return list;
        }
    }
}
