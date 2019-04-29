using Entity;
using System;
using System.Collections.Generic;
using System.Data;
namespace DAL.CX
{
    public class ModifyLoginPwdDAL
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool GetUpUser(User user)
        {
            string sql = string.Format("UPDATE MS_User SET  User_Passwored='{0}' WHERE User_JobNumber='{1}'", user.Passwored, user.JobNumber);
            return DBHelper.NonQuery(sql) > 0;
        }
    }
}
