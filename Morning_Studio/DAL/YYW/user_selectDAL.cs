using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace DAL.YYW
{
   public class user_selectDAL
    {
        //查询用户
        public static User Select(string gonghao)
        {            
            int gh = Convert.ToInt32(gonghao);
            string sql = string.Format("SELECT * FROM MS_User join MS_Department on MS_User.Departmentid=MS_Department.DepartID where User_JobNumber = '{0}'", gh);
            DataTable table = DBHelper.Select(sql);
            User user = new User();
            foreach (DataRow row in table.Rows)
            {
                user.UserID = Convert.ToInt32(row["User_Id"]);
                user.JobNumber = Convert.ToInt32(row["User_JobNumber"]);
                user.Name = row["User_Name"].ToString();
                user.YGcard = row["User_YGcard"].ToString();
                user.Passwored = row["User_Passwored"].ToString();

                user.Departmentid = new Department();
                user.Departmentid.DepartID = Convert.ToInt32(row["Departmentid"].ToString());
                user.Dutyud = new PositionTable();
                user.Dutyud.PositionId = Convert.ToInt32(row["Dutyid"].ToString());
                
                user.Sex = row["User_Sex"].ToString();
                user.Email = row["User_Email"].ToString();
                user.Address = row["User_Address"].ToString();
                user.Account = row["User_Account"].ToString();
                user.Brithday = row["User_Brithday"].ToString();
                user.IdCard = row["User_IdCard"].ToString();
                user.Phone = row["User_Phone"].ToString();

                user.GZstateId = new GZstateld();
                user.GZstateId.stateldId = Convert.ToInt32(row["GZstateId"].ToString());

                user.Dimission = row["User_Dimission"].ToString();
                user.WorkStart = row["User_WorkStart"].ToString();
            }
            return user;
        }
        //查询用户部门
        public static Department Dept(string dep)
        {
            int gh = Convert.ToInt32(dep);
            string sql = string.Format("SELECT * FROM MS_User join MS_Department on MS_User.Departmentid=MS_Department.DepartID where User_JobNumber = '{0}'", gh);
            DataTable table = DBHelper.Select(sql);
            Department dept = new Department();
            foreach (DataRow row in table.Rows)
            {
                dept.DepartID = Convert.ToInt32(row["User_Id"]);
                dept.DepartName =row["DepartName"].ToString();
            }
            return dept;
        }
        //查询请求接收人
        public static List<User> Select_Jieshou(string jieshou,int gonghao)
        {

            int Deptid = Convert.ToInt32(jieshou);
            string sql = string.Format("select [User_Id],User_JobNumber,[User_Name],DepartName,MS_User.Departmentid,Dutyid,MS_PositionTable.PositionName from MS_User join MS_Department on MS_User.Departmentid=MS_Department.DepartID" + " "+
            "join MS_PositionTable on MS_User.Dutyid = MS_PositionTable.PositionId where MS_User.Departmentid = '"+Deptid+ "' and(PositionName like '%经理%' or PositionName like '%总裁%') and User_JobNumber!='"+gonghao+"'");
            DataTable table = DBHelper.Select(sql);
            List<User> lis = new List<User>();           
            foreach (DataRow row in table.Rows)
            {
                User user = new User();
                user.UserID = Convert.ToInt32(row["User_Id"]);
                user.JobNumber = Convert.ToInt32(row["User_JobNumber"]);
                user.Name = row["User_Name"].ToString();
                lis.Add(user);
            }
            return lis ;
        }
        //发送请假申请
        public static bool Email_Rtn(string tal, int gonghao, int js_userid, string beizhu,string t_time,string start_time,string end_time)
        {
            int leixing = 2;
            int gongkai = 0;
            int read = 0;
            int shenpi = 0;
            string sql = string.Format("insert into MS_Message_Manage(SenderID,RecipientID,Message_SendTime,Message_Content,Message_Title,Message_Typeid,Message_Public,Message_Read,Message_Approval,Message_Start_time,Message_End_time) " + " "+
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",gonghao, js_userid, t_time,beizhu,tal,leixing, gongkai, read,shenpi,start_time,end_time);
            int rs=DBHelper.NonQuery(sql);
            return rs > 0;
        }
        public static bool XJ_Email_Rtn(string xj_tal, int xj_gonghao, int xj_js_userid, string xj_beizhu, string xj_time,string xiamgmu, string start_time, string end_time)
        {
            int leixing = 2;
            int gongkai = 0;
            int read = 0;
            int shenpi = 0;
            string sql = string.Format("insert into MS_Message_Manage(SenderID,RecipientID,Message_SendTime,Message_Content,Message_Title,Message_Typeid,Message_Public,Message_Read,Message_Approval,Message_Start_time,Message_End_time) " + " " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", xj_gonghao, xj_js_userid, xj_time, "项目:"+xiamgmu+"完成，请求休假....PS:"+ xj_beizhu, xj_tal, leixing, gongkai, read, shenpi,start_time,end_time);
            int rs = DBHelper.NonQuery(sql);
            return rs > 0;
        }
        //审批请求
        public static List<MessageManage> Email_Rtn_SP(int gonghao,int userid)
        {
            string sql = "select distinct User_JobNumber from ms_user join MS_PositionTable on MS_User.Departmentid=MS_PositionTable.DepartmentID where MS_User.Dutyid in(select distinct PositionId from MS_PositionTable where PositionName like '%经理%' or PositionName like '%人事%')and User_JobNumber="+gonghao;
            DataTable table = DBHelper.Select(sql);
            List<MessageManage> list = new List<MessageManage>();
            if (table.Rows.Count > 0)
            {
                string sql2 = "select *,MS_User.[User_Name] as name from MS_Message_Manage join MS_User on MS_User.[User_Id]=MS_Message_Manage.SenderID where RecipientID=" + userid;
                DataTable table2 = DBHelper.Select(sql2);
                foreach (DataRow row in table2.Rows)
                {
                    MessageManage mes = new MessageManage();
                    mes.SenderID = new User();
                    mes.SenderID.UserID = Convert.ToInt32(row["SenderID"]);
                    mes.MessageSendTime = row["Message_SendTime"].ToString();
                    mes.MessageContent = row["Message_Content"].ToString();
                    mes.MessageTitle = row["Message_Title"].ToString();
                    mes.name = row["name"].ToString();
                    list.Add(mes);
                }
                return list;
            }
            return null;
        }
    }
}
