using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;
namespace BLL.CX
{
   public class ModifyLoginPwdBLL
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool GetUpuser(User user)
        {
            DAL.CX.ModifyLoginPwdDAL modify = new DAL.CX.ModifyLoginPwdDAL();
            return modify.GetUpUser(user);
        }
    }
}
