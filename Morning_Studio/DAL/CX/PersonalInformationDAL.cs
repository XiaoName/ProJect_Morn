using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace DAL.CX
{
    public class PersonalInformationDAL
    {  /// <summary>
       /// 修改
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
        public static bool GetUpUser(User user)
        {
            //string sql = string.Format("UPDATE [dbo].[MS_User] SET  [User_Email] = '{0}',[User_Address] = '{1}',[User_Account] = '{2}'," +
            //    "[User_IdCard] = '{3}',[User_Phone] ='{4}',[User_ImageUrl] = '{5}',User_YGcard='{6}' WHERE [User_JobNumber]='{7}'",
            //    user.Email, user.Address, user.Account,user.IdCard, user.Phone,user.ImageUrl,user.YGcard,user.JobNumber);
            return true;
        }
    }
}
