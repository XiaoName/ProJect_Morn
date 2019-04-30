using Entity;
using System;
using System.Collections.Generic;
using System.Data;
namespace DAL
{
    public class RoomManageDAL
    {
        /// <summary>
        /// 会议室
        /// </summary>
        /// <returns></returns>
        public List<ConferenceRoomManagement> getRooms()
        {
            string sql = string.Format("select * from MS_Conference_Room_Management");
            var table = DBHelper.Select(sql);
            List<ConferenceRoomManagement> list = new List<ConferenceRoomManagement>();
            foreach (DataRow item in table.Rows)
            {
                ConferenceRoomManagement room = new ConferenceRoomManagement
                {
                    ConferenceRoomID = Convert.ToInt32(item["Conference_RoomID"]),
                    ConferenceRoomName = item["Conference_Room_Name"].ToString()
                };
                list.Add(room);
            }
            return list;
        }
        /// <summary>
        /// 会议室管理资源图
        /// </summary>
        /// <returns></returns>
        public List<ConferenceManagement> Select_infroation()
        {
            string sql = string.Format("SELECT   dbo.MS_Conference_Room_Management.Conference_Room_Name, dbo.MS_Conference_Room_Management.Conference_Room_Place, dbo.MS_User.User_Name FROM      dbo.MS_Conference_Room_Management INNER JOIN dbo.MS_Conference_management ON dbo.MS_Conference_Room_Management.Conference_RoomID = dbo.MS_Conference_management.Conference_RoomID INNER JOIN dbo.MS_User ON dbo.MS_Conference_management.User_Id = dbo.MS_User.User_Id");
            var table = DBHelper.Select(sql);
            List<ConferenceManagement> list = new List<ConferenceManagement>();
            foreach (DataRow item in table.Rows)
            {
                ConferenceManagement room = new ConferenceManagement
                {
                    //ConferenceRoomID = Convert.ToInt32(item["Conference_RoomID"]),
                    UserId = new User
                    {
                        Name = item["User_Name"].ToString()
                    },
                    ConferenceRoomID = new ConferenceRoomManagement
                    {
                        ConferenceRoomName = item["Conference_Room_Name"].ToString(),
                        ConferenceRoomPlace = item["Conference_Room_Place"].ToString()
                    },
                };


                list.Add(room);
            }
            return list;
        }

        /// <summary>
        /// 会议室管理资源图按条件查询
        /// </summary>
        /// <returns></returns>
        public List<ConferenceManagement> Select_infroationName(string name)
        {
            string sql = string.Format("SELECT   dbo.MS_Conference_Room_Management.Conference_Room_Name, " +
                " dbo.MS_Conference_Room_Management.Conference_Room_Place, dbo.MS_User.User_Name FROM    " +
                "  dbo.MS_Conference_Room_Management INNER JOIN dbo.MS_Conference_management ON " +
                "dbo.MS_Conference_Room_Management.Conference_RoomID = dbo.MS_Conference_management.Conference_RoomID INNER JOIN dbo.MS_User ON " +
                "dbo.MS_Conference_management.User_Id = dbo.MS_User.User_Id WHERE(dbo.MS_User.User_Name LIKE '%{0}%')", name);
            var table = DBHelper.Select(sql);
            List<ConferenceManagement> list = new List<ConferenceManagement>();
            foreach (DataRow item in table.Rows)
            {
                ConferenceManagement room = new ConferenceManagement
                {
                    //ConferenceRoomID = Convert.ToInt32(item["Conference_RoomID"]),
                    UserId = new User
                    {
                        Name = item["User_Name"].ToString()
                    },
                    ConferenceRoomID = new ConferenceRoomManagement
                    {
                        ConferenceRoomName = item["Conference_Room_Name"].ToString(),
                        ConferenceRoomPlace = item["Conference_Room_Place"].ToString()
                    },
                };


                list.Add(room);
            }
            return list;
        }

        /// <summary>
        /// 动态加载会议室数据

        /// </summary>
        /// <returns></returns>
        public List<ConferenceManagement> Room_getCha()
        {
            string sql = string.Format("select  ConferenceID ,User_Name ,Form_Meeting ,DepartName ,Inviter ,Conference_BeginTime,Conference_EndTime, Name_Meeting,Conference_Room_Name, case when Meeting_Status=0 then '空' else '满' end Meeting_Status from MS_Conference_management a,MS_Conference_Room_Management b,MS_User c,MS_Department d where a.User_Id=c.User_Id and a.Conference_RoomID=b.Conference_RoomID and a.DepartID=d.DepartID");
            var table = DBHelper.Select(sql);
            List<ConferenceManagement> list = new List<ConferenceManagement>();
            foreach (DataRow item in table.Rows)
            {
                ConferenceManagement management = new ConferenceManagement();
                management.ConferenceID = Convert.ToInt32(item["ConferenceID"]);
                management.UserId = new User
                {
                    //  UserID = Convert.ToInt32(item["User_Id"]),
                    Name = item["User_Name"].ToString(),
                };
                management.Inviter = item["Inviter"].ToString();
                management.FormMeeting = item["Form_Meeting"].ToString();
                management.NameMeeting = item["Name_Meeting"].ToString();
                management.DepartID = new Department
                {
                    // DepartID = Convert.ToInt32(item["DepartID"]),
                    DepartName = item["DepartName"].ToString(),
                };
                management.ConferenceBeginTime = item["Conference_BeginTime"].ToString();
                management.ConferenceEndTime = item["Conference_EndTime"].ToString();
                management.ConferenceRoomID = new ConferenceRoomManagement
                {
                    // ConferenceRoomID = Convert.ToInt32(item["Conference_RoomID"]),
                    ConferenceRoomName = item["Conference_Room_Name"].ToString(),
                };


                management.MeetingStatus = item["Meeting_Status"].ToString();
                //management.MeetingDescribes = item["Conference_Room_Describes"].ToString();

                list.Add(management);
            };
            return list;
        }

        /// <summary>
        /// 根据会议名称查询会议室数据
        /// 根据会议室名称查询会议室数据
        /// </summary>
        /// <returns></returns>
        public List<ConferenceManagement> Room_getChaName(string Name_Meeting,string Conference_Room_Name)
        {
            string sql = string.Format("select  ConferenceID ,User_Name ,Form_Meeting ,DepartName ,Inviter ,Conference_BeginTime, Conference_EndTime, Name_Meeting, Conference_Room_Name,case when Meeting_Status = 0 then '空' else '满' end Meeting_Status FROM      dbo.MS_Conference_management a  JOIN dbo.MS_Conference_Room_Management  b ON a.Conference_RoomID = b.Conference_RoomID INNER JOIN dbo.MS_User c ON a.User_Id = c.User_Id INNER JOIN dbo.MS_Department ON a.DepartID = dbo.MS_Department.DepartID AND c.Departmentid = dbo.MS_Department.DepartID where Name_Meeting like '%{0}%' and Conference_Room_Name like '%{1}%'", Name_Meeting, Conference_Room_Name);
            var table = DBHelper.Select(sql);
            List<ConferenceManagement> list = new List<ConferenceManagement>();
            foreach (DataRow item in table.Rows)
            {
                ConferenceManagement management = new ConferenceManagement();
                management.ConferenceID = Convert.ToInt32(item["ConferenceID"]);
                management.UserId = new User
                {
                    //  UserID = Convert.ToInt32(item["User_Id"]),
                    Name = item["User_Name"].ToString(),
                };
                management.Inviter = item["Inviter"].ToString();
                management.FormMeeting = item["Form_Meeting"].ToString();
                management.NameMeeting = item["Name_Meeting"].ToString();
                management.DepartID = new Department
                {
                    // DepartID = Convert.ToInt32(item["DepartID"]),
                    DepartName = item["DepartName"].ToString(),
                };
                management.ConferenceBeginTime = item["Conference_BeginTime"].ToString();
                management.ConferenceEndTime = item["Conference_EndTime"].ToString();
                management.ConferenceRoomID = new ConferenceRoomManagement
                {
                    // ConferenceRoomID = Convert.ToInt32(item["Conference_RoomID"]),
                    ConferenceRoomName = item["Conference_Room_Name"].ToString(),
                };


                management.MeetingStatus = item["Meeting_Status"].ToString();
                //management.MeetingDescribes = item["Conference_Room_Describes"].ToString();

                list.Add(management);
            };
            return list;
        }
        

        /// <summary>
        /// 会议室修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ROOM_Update(ConferenceManagement room)
        {
            string sql = string.Format("UPDATE [dbo].[MS_Conference_management] SET [User_Id] = '{0}' ,[Inviter] = '{1}' ,[Form_Meeting] ='{2}' ,[Name_Meeting] ='{3}' ,[DepartID] = '{4}',[Conference_BeginTime] = '{5}',[Conference_EndTime] ='{6}',[Conference_RoomID] ='{7}' ,[Meeting_Status] = '{8}' WHERE ConferenceID='{9}'", room.UserId, room.Inviter, room.FormMeeting, room.NameMeeting, room.DepartID, room.ConferenceBeginTime, room.ConferenceEndTime, room.ConferenceRoomID, room.MeetingStatus, room.ConferenceID);
            return DBHelper.NonQuery(sql);
        }


        //根据id 查询会议室信息:Rooms_Content
        public ConferenceManagement RoomsContent_getCha(int id)
        {
            string sql = string.Format("select  ConferenceID,User_Name,User_Name,User_Name,Form_Meeting ,DepartName ,Inviter ,Conference_BeginTime,Conference_EndTime,Name_Meeting,Conference_Room_Name, case when Meeting_Status=0 then '空' else '满' end Meeting_Status from MS_Conference_management a,MS_Conference_Room_Management b,MS_User c,MS_Department d where a.User_Id=c.User_Id and a.Conference_RoomID=b.Conference_RoomID and a.DepartID=d.DepartID  and ConferenceID={0}", id);
            var table = DBHelper.Select(sql);
            ConferenceManagement user = new ConferenceManagement();
            user.ConferenceID = Convert.ToInt32(table.Rows[0]["ConferenceID"]);//ID
            user.ConferenceBeginTime = table.Rows[0]["Conference_BeginTime"].ToString();//开始时间
            user.ConferenceEndTime = table.Rows[0]["Conference_EndTime"].ToString();//结束时间
            user.FormMeeting = table.Rows[0]["Form_Meeting"].ToString();//会议形式
            user.Inviter = table.Rows[0]["Inviter"].ToString();//邀请人员
            user.NameMeeting = table.Rows[0]["Name_Meeting"].ToString();//会议名称
            user.MeetingStatus = table.Rows[0]["Meeting_Status"].ToString();//状态
                                                                            //  user.MeetingDescribes = table.Rows[0]["Meeting_Describes"].ToString();//描述
            user.UserId = new User
            {
                //  UserID = Convert.ToInt32(table.Rows[0]["UserID"]),//ID
                Name = table.Rows[0]["User_Name"].ToString(),//姓名
            };
            user.DepartID = new Department
            {
                //  DepartID = Convert.ToInt32(table.Rows[0]["DepartID"]),//ID
                DepartName = table.Rows[0]["DepartName"].ToString(),//部门

            };
            user.ConferenceRoomID = new ConferenceRoomManagement
            {
                //  ConferenceRoomID = Convert.ToInt32(table.Rows[0]["ConferenceRoomID"]),//ID
                ConferenceRoomName = table.Rows[0]["Conference_Room_Name"].ToString(),//会议室名称
            };

            return user;

        }

        /// <summary>
        /// 会议室审核保存按钮
        /// </summary>
        /// <returns></returns>
        public bool RoomExmin_baoc(ConferenceManagement management)
        {
            string sql = string.Format("INSERT INTO [dbo].[MS_Conference_management] ([User_Id],[Inviter],[Form_Meeting],[Name_Meeting] ,[DepartID] ,[Conference_BeginTime]  ,[Conference_EndTime] ,[Conference_RoomID],[Meeting_Status],Meeting_Describes) VALUES ({0},'{1}','{2}','{3}' ,'{4}' ,'{5}','{6}','{7}','{8}','{9}')", management.UserId.UserID, management.Inviter, management.FormMeeting, management.NameMeeting, management.DepartID.DepartID, management.ConferenceBeginTime, management.ConferenceEndTime, management.ConferenceRoomID.ConferenceRoomID, management.MeetingStatus, management.MeetingDescribes);
            return DBHelper.NonQuery(sql) > 0;
        }

        /// <summary>
        /// 会议室申请保存按钮
        /// </summary>
        /// <returns></returns>
        public bool RoomApplay_baoc(ConferenceManagement management)
        {
            string sql = string.Format("INSERT INTO [dbo].[MS_Conference_management] ([User_Id],[Inviter],[Form_Meeting],[Name_Meeting] ,[DepartID] ,[Conference_BeginTime]  ,[Conference_EndTime] ,[Conference_RoomID],[Meeting_Status],Meeting_Describes) VALUES ({0},'{1}','{2}','{3}' ,'{4}' ,'{5}','{6}','{7}','{8}','{9}')", management.UserId.UserID, management.Inviter, management.FormMeeting, management.NameMeeting, management.DepartID.DepartID, management.ConferenceBeginTime, management.ConferenceEndTime, management.ConferenceRoomID.ConferenceRoomID, management.MeetingStatus, management.MeetingDescribes);
            return DBHelper.NonQuery(sql) > 0;
        }

        /// <summary>
        /// 会议室邀请人
        /// </summary>
        /// <returns></returns>
        public List<User> RoomsPeople(string s)
        {
            List<User> users = new List<User>();
            string sql = string.Format("select * from MS_User where User_Id = '{0}'", s);
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User();
                user.UserID = Convert.ToInt32(item["User_Id"]);
                user.JobNumber = Convert.ToInt32(item["User_JobNumber"]);
                users.Add(user);

            }
            return users;
        }

        /// <summary>
        /// 会议室预约人：Rooms_Information
        /// </summary>
        /// <returns></returns>
        public List<User> Rooms_Informations_Order(string DepartName)
        {
            List<User> users = new List<User>();
            string sql = string.Format("SELECT  dbo.MS_User.User_JobNumber, dbo.MS_User.[User_Name], " +
                " dbo.MS_Department.DepartName,dbo.MS_PositionTable.PositionName,dbo.MS_User.User_WorkStart FROM " +
                "dbo.MS_Department INNER JOIN dbo.MS_PositionTable ON" +
                " dbo.MS_Department.DepartID = dbo.MS_PositionTable.DepartmentID INNER JOIN " +
                " dbo.MS_User ON dbo.MS_Department.DepartID = dbo.MS_User.Departmentid AND " +
                "dbo.MS_PositionTable.PositionId = dbo.MS_User.Dutyid INNER JOIN " +
                "dbo.MS_GZstateld ON dbo.MS_User.GZstateId = dbo.MS_GZstateld.stateld_id " +
                "where MS_Department.DepartName like '%{0}%'", DepartName);
            var table = DBHelper.Select(sql);

            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User us = new User
                {
                    JobNumber = Convert.ToInt32(item["User_JobNumber"]),
                    Name = item["User_Name"].ToString(),
                    Departmentid = new Department
                    {
                        DepartName = item["DepartName"].ToString(),
                        //      DepartID = Convert.ToInt32(item["DepartID"])
                    },
                    Dutyud = new PositionTable
                    {
                        PositionName = item["PositionName"].ToString(),
                        //PositionId = Convert.ToInt32(item["PositionId"])
                    },


                    WorkStart = item["User_WorkStart"].ToString(),

                };
                list.Add(us);
            }
            return list;
        }

        /// <summary>
        /// 会议室预约人：Rooms_Information
        /// </summary>
        /// <returns></returns>
        public List<User> Rooms_Informations_OrderSelects()
        {
            List<User> users = new List<User>();
            string sql = string.Format("SELECT  dbo.MS_User.User_JobNumber, dbo.MS_User.[User_Name],  dbo.MS_Department.DepartName,dbo.MS_PositionTable.PositionName,dbo.MS_User.User_WorkStart FROM dbo.MS_Department INNER JOIN dbo.MS_PositionTable ON dbo.MS_Department.DepartID = dbo.MS_PositionTable.DepartmentID INNER JOIN  dbo.MS_User ON dbo.MS_Department.DepartID = dbo.MS_User.Departmentid AND dbo.MS_PositionTable.PositionId = dbo.MS_User.Dutyid INNER JOIN dbo.MS_GZstateld ON dbo.MS_User.GZstateId = dbo.MS_GZstateld.stateld_id ");
            var table = DBHelper.Select(sql);

            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User us = new User
                {
                    JobNumber = Convert.ToInt32(item["User_JobNumber"]),
                    Name = item["User_Name"].ToString(),
                    Departmentid = new Department
                    {
                        DepartName = item["DepartName"].ToString(),
                        //      DepartID = Convert.ToInt32(item["DepartID"])
                    },
                    Dutyud = new PositionTable
                    {
                        PositionName = item["PositionName"].ToString(),
                        //PositionId = Convert.ToInt32(item["PositionId"])
                    },


                    WorkStart = item["User_WorkStart"].ToString(),

                };
                list.Add(us);
            }
            return list;
        }

    }
}
