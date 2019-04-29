using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DAL.CX
{
    public  class DepartMaintenanceDAL
    {
        public List<User> GetUsers()
        {
          string sql = string.Format("SELECT  MS_User.User_JobNumber, MS_User.User_Name,MS_Department.DepartName,MS_PositionTable.PositionName,MS_Department.DepartID FROM  MS_User INNER JOIN MS_Department ON MS_User.Departmentid = MS_Department.DepartID INNER JOIN MS_PositionTable ON MS_User.Dutyid = MS_PositionTable.PositionId AND MS_Department.DepartID =MS_PositionTable.DepartmentID");
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
                        DepartID=Convert.ToInt32(item["DepartID"]),
                        DepartName = item["DepartName"].ToString(),
                    },
                    Dutyud = new PositionTable() {
                        PositionName = item["PositionName"].ToString()
                    }

                };
                list.Add(user);
            }
            return list;
        }
        public List<User> Depart_USER()
        {
            string sql = string.Format("select * from MS_User");
            List<User> list = new List<User>();
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {      UserID =Convert.ToInt32( item["User_Id"]),
                    JobNumber = Convert.ToInt32(item["User_JobNumber"]),
              
                   
                };
                list.Add(user);
            }
            return list;
        }

    }
}
