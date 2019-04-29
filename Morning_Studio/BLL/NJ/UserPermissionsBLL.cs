using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;

namespace BLL.NJ
{
    public class UserPermissionsBLL
    {
        /// <summary>
        /// 角色权限
        /// </summary>
        /// <returns></returns>
        public List<UserPermissions> GetPermissions( string q)
        {
            DAL.NJ.UserPermissionsDAL dAL = new DAL.NJ.UserPermissionsDAL();
            return dAL.getUserPer(q);
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool getInper(string a,string b)
        {
            DAL.NJ.UserPermissionsDAL dAL = new DAL.NJ.UserPermissionsDAL();
            return dAL.getInPer(a,b);
        }

        public bool getDelPer(string a,string b)
        {
            DAL.NJ.UserPermissionsDAL dAL = new DAL.NJ.UserPermissionsDAL();
            return dAL.getDelPer(a, b);
        }
    }
}
