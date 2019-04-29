using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;


namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool getUser(User user)
        {
            string sql = string.Format("INSERT INTO MS_User([User_JobNumber],[User_Name],[User_YGcard],[User_Passwored],[Departmentid],[Dutyid],[User_Sex],[User_Email],[User_Address],[User_Account],[User_Brithday],[User_IdCard],[User_Phone],[GZstateId],[User_Dimission],[User_WorkStart]) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", user.JobNumber, user.Name, user.YGcard, user.Passwored, user.Departmentid.DepartID, user.Dutyud.PositionId, user.Sex, user.Email, user.Address, user.Account, user.Brithday, user.IdCard, user.Phone, user.GZstateId.stateldId, user.Dimission, user.WorkStart);
            return DBHelper.NonQuery(sql) > 0;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<User> getSeUser(string job,string name)
        {

            string sql = string.Format("SELECT  dbo.MS_Department.DepartName, dbo.MS_PositionTable.PositionName, dbo.MS_GZstateld.stateld_Name,dbo.MS_Department.DepartID,dbo.MS_PositionTable.PositionId,dbo.MS_GZstateld.stateld_id, "
                  + " dbo.MS_User.User_JobNumber, dbo.MS_User.[User_Name], dbo.MS_User.User_YGcard, dbo.MS_User.User_Sex,"
                   + "dbo.MS_User.User_Email, dbo.MS_User.User_Address, dbo.MS_User.User_Account, dbo.MS_User.User_Brithday,dbo.MS_User.User_Passwored,"
                   + "dbo.MS_User.User_IdCard, dbo.MS_User.User_Phone, dbo.MS_User.User_WorkStart,dbo.MS_User.User_Dimission "
                   + "FROM dbo.MS_Department INNER JOIN "
                   + "dbo.MS_PositionTable ON dbo.MS_Department.DepartID = dbo.MS_PositionTable.DepartmentID INNER JOIN "
                   + "dbo.MS_User ON dbo.MS_Department.DepartID = dbo.MS_User.Departmentid AND "
                   + "dbo.MS_PositionTable.PositionId = dbo.MS_User.Dutyid INNER JOIN "
                   + "dbo.MS_GZstateld ON dbo.MS_User.GZstateId = dbo.MS_GZstateld.stateld_id where User_JobNumber like '%{0}%' "
                   + "and[User_Name] like '%{1}%'", job,name);
            var table = DBHelper.Select(sql);
            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User us = new User
                {
                    JobNumber = Convert.ToInt32(item["User_JobNumber"]),
                    Name = item["User_Name"].ToString(),
                    YGcard = item["User_YGcard"].ToString(),
                    Departmentid = new Department { DepartName = item["DepartName"].ToString(),
                    DepartID=Convert.ToInt32(item["DepartID"])
                    },
                    Dutyud = new PositionTable { PositionName = item["PositionName"].ToString(),
                    PositionId=Convert.ToInt32(item["PositionId"])
                    },
                    Sex = item["User_Sex"].ToString(),
                    Email = item["User_Email"].ToString(),
                    Address = item["User_Address"].ToString(),
                    Account = item["User_Account"].ToString(),
                    Brithday = item["User_Brithday"].ToString(),
                    IdCard = item["User_IdCard"].ToString(),
                    GZstateId = new GZstateld { stateldName = item["stateld_Name"].ToString(),
                    stateldId=Convert.ToInt32(item["stateld_id"])
                    },
                    Dimission = item["User_Dimission"].ToString(),
                    WorkStart = item["User_WorkStart"].ToString(),
                    Phone = item["User_Phone"].ToString(),
                    Passwored=item["User_Passwored"].ToString()
                };
                list.Add(us);
            }
            return list;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool getUpUser(User user)
        {
            string sql = string.Format("UPDATE MS_User SET [User_JobNumber] = '{0}',[User_Name] = '{1}',[User_YGcard] = '{2}'," +
                "[User_Passwored] = '{3}',[Departmentid] = '{4}',[Dutyid] = '{5}',[User_Sex] = '{6}',[User_Email] = '{7}'," +
                "[User_Address] = '{8}',[User_Account] = '{9}',[User_Brithday] = '{10}',[User_IdCard] = '{11}',[User_Phone] = '{12}'," +
                "[GZstateId] = '{13}',[User_Dimission] = '{14}',[User_WorkStart] = '{15}'WHERE [User_JobNumber] = '{0}'",user.JobNumber,
                user.Name,user.YGcard,user.Passwored,user.Departmentid.DepartID,user.Dutyud.PositionId,user.Sex,user.Email,user.Address,user.Account,user.Brithday,
                user.IdCard,user.Phone,user.GZstateId.stateldId,user.Dimission,user.WorkStart);
            return DBHelper.NonQuery(sql) > 0;
        }
    }
}
