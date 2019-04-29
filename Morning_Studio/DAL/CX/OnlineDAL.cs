using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.CX
{
    public class OnlineDAL
    {
        public List<User> OnlineUser()
        {
            string sql = string.Format("SELECT   dbo.MS_User.User_JobNumber, dbo.MS_User.User_Name, dbo.MS_PositionTable.PositionName,  dbo.MS_Department.DepartName, dbo.MS_User.User_WorkStart FROM      dbo.MS_User INNER JOIN dbo.MS_PositionTable ON dbo.MS_User.Dutyid = dbo.MS_PositionTable.PositionId INNER JOIN  dbo.MS_Department ON dbo.MS_User.Departmentid = dbo.MS_Department.DepartID AND dbo.MS_PositionTable.DepartmentID = dbo.MS_Department.DepartID");
            var table = DBHelper.Select(sql);
            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    JobNumber = Convert.ToInt32(item["User_JobNumber"]),
                    Name = item["User_Name"].ToString(),
                    WorkStart=item["User_WorkStart"].ToString(),
                    Departmentid = new Department
                    {
                        DepartName = item["DepartName"].ToString(),
                    },
                    Dutyud = new PositionTable()
                    {
                        PositionName = item["PositionName"].ToString()
                    }

                };
                list.Add(user);

            }
            return list;
        }
    }
}
