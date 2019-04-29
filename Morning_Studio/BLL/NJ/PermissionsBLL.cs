using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using DAL;

namespace BLL.NJ
{
    /// <summary>
    /// 菜单维护
    /// </summary>
    public class PermissionsBLL
    {
        /// <summary>
        ///一级菜单
        /// </summary>
        /// <returns></returns>
        public List<Permissios> getSeYJ()
        {
            DAL.NJ.PermissiosDAL permissios = new DAL.NJ.PermissiosDAL();
            return permissios.getSeYJ();
        }
        /// <summary>
        /// 二级菜单
        /// </summary>
        /// <returns></returns>
        public List<Permissios> getSeEJ(string r)
        {
            DAL.NJ.PermissiosDAL permissios = new DAL.NJ.PermissiosDAL();
            return permissios.getSeEJ(r);
        }

        public List<Permissios> getSeCD(string s,string d,string f)
        {
            if (d=="-1")
            {
                d = "";
            }
            if (f == "-1")
            {
                f = "";
            }
            DAL.NJ.PermissiosDAL permissios = new DAL.NJ.PermissiosDAL();
            return permissios.getSeCD(s,d,f);
        }

        /// <summary>
        /// 显示权限
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public List<Permissios> GetPermissios()
        {
            DAL.NJ.PermissiosDAL permissios = new DAL.NJ.PermissiosDAL();
            return permissios.GetPermissios();
        }
    }
}
