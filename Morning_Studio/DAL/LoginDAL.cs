using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class LoginDAL
    {
        public static User GetItems(string JobNumber, string Passwored)
        {
            string sql = "select * from MS_User where User_JobNumber='" + JobNumber + "'and User_Passwored='" + Passwored + "'";
            DataTable table= DBHelper.Select(sql);
            User user = new User();
            foreach (DataRow row in table.Rows)
            {
                user.UserID = Convert.ToInt32(row["User_Id"]);
                user.Name = row["User_Name"].ToString();
                user.Departmentid = new Department();
                user.Departmentid.DepartID = Convert.ToInt32(row["Departmentid"].ToString());
            }
            return user;
        }
    }
}
