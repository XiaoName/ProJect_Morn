using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL.CX
{
   public class PersonalInformationBLL
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool GetUpUsers(User user)
        {
            return DAL.CX.PersonalInformationDAL.GetUpUser(user);
        }
        }
}
