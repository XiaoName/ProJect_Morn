using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
    public class SettingsDAL
    {
        /// <summary>
        /// 查询职位权限
        /// </summary>
        /// <returns></returns>
        public List<Position> getposition(string q)
        {
            string sql = string.Format("select MS_PositionTable.PositionName,MS_Permissios.Permissions_name,MS_Permissios.Permissions_Id from MS_User,MS_Department,MS_Permissios,MS_PositionTable,MS_Position where " +
                          "MS_User.Departmentid = MS_Department.DepartID " +
                          "and MS_Department.DepartID = MS_PositionTable.DepartmentID and " +
                          "MS_PositionTable.PositionId = MS_Position.Permissios_ID and MS_Position.Dimission_ID =" +
                          "MS_Permissios.Permissions_Id and  MS_User.User_JobNumber like '%{0}%'", q);
            var table = DBHelper.Select(sql);
            List<Position> list = new List<Position>();
            foreach (DataRow item in table.Rows)
            {
                Position pos = new Position
                {
                    PermissiosID = new Permissios
                    {
                        PermissiosName = item["Permissions_name"].ToString(),
                        PermissiosID = Convert.ToInt32(item["Permissions_Id"])
                    },
                    DimissionId = new PositionTable
                    {
                        PositionName = item["PositionName"].ToString()
                    }
                };
                list.Add(pos);
            }
            return list;
        }
    }
}
