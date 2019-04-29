using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
    public class UserPermissionsDAL
    {
        /// <summary>
        /// 角色权限
        /// </summary>
        /// <returns></returns>
        public List<UserPermissions> getUserPer(string q)
        {
            string sql = string.Format("select MS_User.[User_Name],MS_Permissios.Permissions_name,MS_Permissios.Permissions_Id from MS_UserPermissions,MS_User,MS_Permissios " +
                "where MS_UserPermissions.[User_ID]=MS_User.[User_Id] and MS_UserPermissions.Permissios_ID=MS_Permissios.Permissions_Id and MS_User.User_JobNumber like '%{0}%'",q);
            var table = DBHelper.Select(sql);
            List<UserPermissions> list = new List<UserPermissions>();
            foreach (DataRow item in table.Rows)
            {
                UserPermissions permissions = new UserPermissions
                {
                    UserId = new User
                    {
                        Name = item["User_Name"].ToString()
                    },
                    PermissiosID = new Permissios
                    {
                        PermissiosName = item["Permissions_name"].ToString(),
                        PermissiosID=Convert.ToInt32(item["Permissions_Id"])
                    }
                };
                list.Add(permissions);
            }
            return list;
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool getInPer(string a,string b)
        {
            string sql = string.Format("INSERT INTO [dbo].[MS_UserPermissions] ([User_ID],[Permissios_ID]) VALUES((select MS_User.[User_Id] from MS_User where MS_User.User_JobNumber like'%{0}%'),'{1}')",a,b);
            var r = DBHelper.NonQuery(sql);
            return r>0;
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool getDelPer(string a,string b)
        {
            string sql = string.Format("DELETE FROM [dbo].[MS_UserPermissions] WHERE[User_ID] = (select[User_ID] from MS_User where MS_User.User_JobNumber like'%{0}%') and Permissios_ID = '{1}'",a,b);
            var r = DBHelper.NonQuery(sql);
            return r > 0;
        }
    }
}
