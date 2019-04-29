using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.YYW;
namespace BLL.YYW
{
    public class user_selectBLL
    {
        //查询用户
        public static User Select(string gonghao)
        {
            return user_selectDAL.Select(gonghao);
        }
        //查询用户部门
        public static Department Dept(string dep)
        {
            return user_selectDAL.Dept(dep);
        }
        //查询请求接收人
        public static List<User> Select_Jieshou(string jieshou, int gonghao)
        {
            return user_selectDAL.Select_Jieshou(jieshou, gonghao);
        }
        //发送邮件
        public static bool Email_Rtn(string tal, int gonghao, int js_userid, string beizhu, string t_time, string start_time, string end_time)
        {
            return user_selectDAL.Email_Rtn(tal, gonghao, js_userid, beizhu, t_time, start_time, end_time);
        }
        public static bool XJ_Email_Rtn(string xj_tal, int xj_gonghao, int xj_js_userid, string xj_beizhu, string xj_time, string xiangmu, string start_time, string end_time)
        {
            return user_selectDAL.XJ_Email_Rtn(xj_tal, xj_gonghao, xj_js_userid, xj_beizhu, xj_time, xiangmu, start_time, end_time);
        }
        //审批请求
        public static List<MessageManage> Email_Rtn_SP(int gonghao,int userid)
        {
            return user_selectDAL.Email_Rtn_SP(gonghao,userid);
        }
    }
}
