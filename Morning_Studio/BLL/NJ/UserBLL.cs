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
    public class UserBLL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool getUser(User user)
        {
            DAL.UserDAL userdal = new DAL.UserDAL();
            return userdal.getUser(user);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<User> getSeUser(string job,string name)
        {
            DAL.UserDAL userDAL = new UserDAL();
            return userDAL.getSeUser(job,name);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool getUpUser(User user)
        {
            DAL.UserDAL userdal = new UserDAL();
            return userdal.getUpUser(user);
        }
    }
}
