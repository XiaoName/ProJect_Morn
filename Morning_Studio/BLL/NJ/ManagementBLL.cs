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
   public class ManagementBLL
    {
        /// <summary>
        /// 权限查询
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<User> getManagement(string a,string b,string c)
        {
            DAL.NJ.ManagementDAL management = new DAL.NJ.ManagementDAL();
            if (a== "请选择")
            {
                a = "";
            }
            if (c=="0")
            {
                c = "";
            }
            return management.getManage(a, b, c);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool getUpManage(string a,string b)
        {
            DAL.NJ.ManagementDAL dAL = new DAL.NJ.ManagementDAL();
            return dAL.getUpManage(a, b);
        }
    }
}
