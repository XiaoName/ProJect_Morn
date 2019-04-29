using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BLL
{
   public class LoginBLL
    {/// <summary>
     /// 用户登录判断
     /// </summary>
     /// <param name="User_YGcard">员工卡号</param>
     /// <param name="User_Passwored">密码</param>
     /// <returns>判断是否登录成功</returns>
        public static User Login(string JobNumber, string Passwored)
        {
            return DAL.LoginDAL.GetItems(JobNumber, Passwored);
        }
    }
}
