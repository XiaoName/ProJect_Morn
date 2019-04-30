using BLL;
using Entity;
using System;
using System.Web;
using System.Web.Script.Serialization;
namespace Morning_Studio.CX
{
    /// <summary>
    /// CX_Handler 的摘要说明
    /// </summary>
    public class CX_Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;
            if (files.Count > 0)
            {

                string path = "upload/" + System.IO.Path.GetFileName(files[0].FileName);
                files[0].SaveAs(context.Server.MapPath("~/" + path));
                string msg = "{\"img\":\"" + path + "\"}";
                context.Response.Write(msg);
                context.Response.End();

            }
            string act = context.Request.QueryString["act"];
            switch (act)
            {
                case "Depart"://部门
                    this.Depart();
                    break;
                case "Numbers"://工号
                    this.Numbers();
                    break;
                case "Name"://姓名
                    this.Name();
                    break;
                case "Names"://姓名
                    this.Names();
                    break;
                case "GetCha":// 工作单创建明细加载数据库
                    this.GetCha();
                    break;
                case "WorkGetList"://创建工作单多条件查询
                    this.WorkGetList();
                    break;
                case "WorkUpdate"://工作单创建明细修改按钮
                    Work_Update();
                    break;
                case "Rooms"://会议室
                    Rooms();
                    break;
                case "WorkPeople"://工作单 卡号与姓名 MS_User表
                    WorkPeople();
                    break;
                case "WorkProcessBaoc"://工作单处理保存按钮
                    WorkProcess_baoc();
                    break;
                case "RoomGetcha":// 动态加载会议室数据
                    RoomGetCha();
                    break;
                case "UpateCha": //根据id 查工作单
                    UpateCha();
                    break;
                case "Worksqing_Baoc"://工作单申请保存按钮
                    Worksqing_Baoc();
                    break;
                case "RoomsContents_GetCha"://根据id 查询会议室信息:Rooms_Content
                    RoomsContents_GetCha();
                    break;
                case "Room_getChaName"://// 根据会议室名称/会议名称查询会议室数据
                    Room_getChaName();
                    break;
           
                case "RoomExmin_baoC":// 会议室审核保存按钮
                    RoomExmin_baoC();
                    break;
                case "RoomsPeople"://会议室邀请人
                    RoomsPeople();
                    break;
                case "RoomApplay"://会议室申请保存按钮
                    RoomApplay();
                    break;
                case "Rooms_InformationsOrders":// 会议室预约人：Rooms_Information
                    Rooms_InformationsOrders();
                    break;
                case "PositionTable"://在线人员统计
                    this.PositionTable();
                    break;
                case "getUpUser"://系统管理中的修改密码
                    getUpUser();
                    break;
                case "GetUsers"://系统管理中的部门维护
                    GetUsers();
                    break;
                case "DepartUSERS"://系统管理中的部门维护
                    Depart_USERS();
                    break;
                case "GetUpUsers":  //系统管理中的修改个人信息保存按钮
                    GetUpUsers();
                    break;
                case "OnlinePeople"://在线人员统计
                    OnlinePeople();
                    break;
                case "getInformation"://在线人员统计查询按钮
                    this.getInformation();
                    break;
                case "ROOMS_Update":
                    ROOMS_Update();//会议室修改页面
                    break;
                case "Select_infroations":// 会议室管理资源图
                    Select_infroations();
                    break;
                case "Select_infroationsNmae":/// 会议室管理资源图按条件查询
                    Select_infroationsNmae();
                    break;
                case "Rooms_Informations_OrderSelects":  /// 会议室预约人：Rooms_Information
                    Rooms_Informations_OrderSelects();
                    break;


            }
        }
        /// <summary>
        /// 部门
        /// </summary>
        private void Depart()
        {
            BLL.DepartBLL departBLL = new DepartBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = departBLL.getDepart();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 职位
        /// </summary>
        private void PositionTable()
        {
            BLL.PositionTableBLL positionTable = new PositionTableBLL();
            var s = HttpContext.Current.Request.Form["id"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = positionTable.GetPositions(s);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 工号
        /// </summary>
        private void Numbers()
        {
            BLL.CX.PositionTableBLL position = new BLL.CX.PositionTableBLL();
            var s = HttpContext.Current.Request.Form["Id"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = position.Number(s);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 姓名
        /// </summary>
        private void Name()
        {
            BLL.CX.PositionTableBLL position = new BLL.CX.PositionTableBLL();
            var s = HttpContext.Current.Request.Form["IId"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = position.Name(s);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 姓名2
        /// </summary>
        private void Names()
        {
            BLL.CX.PositionTableBLL position = new BLL.CX.PositionTableBLL();
            var s = HttpContext.Current.Request.Form["IId"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = position.Names(s);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 工作单创建明细修改按钮
        /// </summary>
        /// <returns></returns>
        private void Work_Update()
        {
            int WorksheetID = Convert.ToInt32(HttpContext.Current.Request.Form["WorksheetID"]);
            string WorkOrderNumber = HttpContext.Current.Request.Form["WorkOrderNumber"];
            string ResponsiblePerson = HttpContext.Current.Request.Form["ResponsiblePerson"];
            string WorkCreatNumber = HttpContext.Current.Request.Form["WorkCreatNumber"];
            string WorksheetCreatDate = HttpContext.Current.Request.Form["WorksheetCreatDate"];
            string WorkDescrible = HttpContext.Current.Request.Form["WorkDescrible"];
            string WorkDueTime = HttpContext.Current.Request.Form["WorkDueTime"];
            string WorkTaskName = HttpContext.Current.Request.Form["WorkTaskName"];
            string WorkReminderlevel = HttpContext.Current.Request.Form["WorkReminderlevel"];
            WorkSheet sheet = new WorkSheet
            {
                WorksheetID = WorksheetID,
                WorkOrderNumber = WorkOrderNumber,
                ResponsiblePerson = ResponsiblePerson,
                WorkCreatNumber = WorkCreatNumber,
                WorksheetCreatDate = WorksheetCreatDate,
                MyProWorkDescribleperty = WorkDescrible,
                WorkDueTime = WorkDueTime,
                WorkTaskName = WorkTaskName,
                WorkReminderlevel = WorkReminderlevel
            };
            WorkOrderBLL orderBLL = new WorkOrderBLL();

            var obj = new { msg = "修改成功！", code = 200 };
            if (!orderBLL.Work_Update(sheet))
            {
                obj = new { msg = "修改失败！", code = 201 };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string rs = js.Serialize(obj);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();


        }


        // 工作单创建明细加载数据库
        private void GetCha()
        {
            BLL.WorkOrderBLL orderBLL = new WorkOrderBLL();
            var table = orderBLL.getCha();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var rs = js.Serialize(table);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 创建工作单多条件查询
        /// </summary>
        /// <returns></returns>
        private void WorkGetList()
        {
            string WorkOrderNumber = HttpContext.Current.Request["WorkOrderNumber"];
            string WorkTaskName = HttpContext.Current.Request["WorkTaskName"];
            BLL.WorkOrderBLL orderBLL = new WorkOrderBLL();
            var table = orderBLL.GetWorkSelect(WorkOrderNumber, WorkTaskName);
            Serialize1(table);
        }

        ///工作单 卡号与姓名 MS_User表
        /// </summary>
        private void WorkPeople()
        {
            BLL.WorkOrderBLL workOrder = new WorkOrderBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = workOrder.getUser();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 工作单处理保存按钮
        /// </summary>
        /// <returns></returns>
        private void WorkProcess_baoc()
        {

            BLL.WorkOrderBLL orderBLL = new WorkOrderBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            WorkSheet workSheet = new WorkSheet();
            workSheet.WorkOrderNumber = HttpContext.Current.Request.Form["WorkOrderNumber"];//工作单单号
            workSheet.ResponsiblePerson = HttpContext.Current.Request.Form["ResponsiblePerson"];//责任人/处理人姓名
            workSheet.WorkCreatNumber = HttpContext.Current.Request.Form["WorkCreatNumber"];//创建人工号
            workSheet.WorksheetCreatDate = HttpContext.Current.Request.Form["WorksheetCreatDate"];//工作单创建日期
            workSheet.WorkDealPeople = HttpContext.Current.Request.Form["WorkDealPeople"];//处理人（默认为当前创建人，可以是上级）
            workSheet.WorkUploadType = HttpContext.Current.Request.Form["WorkUploadType"];////上传类型
            workSheet.MyProWorkDescribleperty = HttpContext.Current.Request.Form["MyProWorkDescribleperty"];//描述
            workSheet.WorkState = HttpContext.Current.Request.Form["WorkState"];//状态
            workSheet.WorkDueTime = HttpContext.Current.Request.Form["WorkDueTime"];//到期时间
            workSheet.WorkDueDeal = HttpContext.Current.Request.Form["WorkDueDeal"];//到期处理
            workSheet.WorkTaskName = HttpContext.Current.Request.Form["WorkTaskName"];//任务名称
            workSheet.WorkReminderlevel = HttpContext.Current.Request.Form["WorkReminderlevel"];//催办等级
            workSheet.WorkReminderTime = HttpContext.Current.Request.Form["WorkReminderTime"];//催办时效


            var obj = new { msg = "保存成功！", code = 200 };
            if (!orderBLL.WorkProcess_Baoc(workSheet))
            {
                obj = new { msg = "保存失败！", code = 201 };
            }
            string rs = js.Serialize(workSheet);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 工作单申请保存按钮
        /// </summary>
        /// <returns></returns>
        private void Worksqing_Baoc()
        {

            BLL.WorkOrderBLL orderBLL = new WorkOrderBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            WorkSheet workSheet = new WorkSheet();
            workSheet.WorksheetID = Convert.ToInt32(HttpContext.Current.Request.Form["WorksheetID"]);
            workSheet.WorkOrderNumber = HttpContext.Current.Request.Form["WorkOrderNumber"];//工作单单号
            workSheet.ResponsiblePerson = HttpContext.Current.Request.Form["ResponsiblePerson"];//责任人/处理人姓名
            workSheet.WorkCreatNumber = HttpContext.Current.Request.Form["WorkCreatNumber"];//创建人工号
            workSheet.WorksheetCreatDate = HttpContext.Current.Request.Form["WorksheetCreatDate"];//工作单创建日期
            workSheet.WorkDealPeople = HttpContext.Current.Request.Form["WorkDealPeople"];//处理人（默认为当前创建人，可以是上级）
            workSheet.WorkUploadType = HttpContext.Current.Request.Form["WorkUploadType"];////上传类型
            workSheet.MyProWorkDescribleperty = HttpContext.Current.Request.Form["MyProWorkDescribleperty"];//描述
            workSheet.WorkState = HttpContext.Current.Request.Form["WorkState"];//状态
            workSheet.WorkDueTime = HttpContext.Current.Request.Form["WorkDueTime"];//到期时间
            workSheet.WorkDueDeal = HttpContext.Current.Request.Form["WorkDueDeal"];//到期处理
            workSheet.WorkTaskName = HttpContext.Current.Request.Form["WorkTaskName"];//任务名称
            workSheet.WorkReminderlevel = HttpContext.Current.Request.Form["WorkReminderlevel"];//催办等级
            workSheet.WorkReminderTime = HttpContext.Current.Request.Form["WorkReminderTime"];//催办时效


            var obj = new { msg = "保存成功！", code = 200 };
            if (!orderBLL.Worksqing_Baoc(workSheet))
            {
                obj = new { msg = "保存失败！", code = 201 };
            }
            string rs = js.Serialize(workSheet);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }

        //根据id 查工作单
        private void UpateCha()
        {
            int id = Convert.ToInt32(HttpContext.Current.Request.Form["UpateID"]);
            BLL.WorkOrderBLL orderBLL = new WorkOrderBLL();
            var work_Infro = orderBLL.Upate_gaCha_Bll(id);
            Serialize1(work_Infro);

        }
        /// <summary>
        /// 会议室
        /// </summary>
        /// <returns></returns>
        private void Rooms()
        {
            BLL.RoomManageBLL room = new RoomManageBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = room.GetRooms();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 动态加载会议室数据
        /// </summary>
        /// <returns></returns>
        private void RoomGetCha()
        {
            RoomManageBLL room = new RoomManageBLL();
            var table = room.Room_getCha();
            Serialize1(table);
        }
        /// <summary>
        /// 根据会议名称查询会议室数据
        /// 根据会议室名称查询会议室数据
        /// </summary>
        /// <returns></returns>
        private void Room_getChaName()
        {
            string Conference_Room_Name = HttpContext.Current.Request.Form["Conference_Room_Name"];
            string Name_Meeting = HttpContext.Current.Request.Form["Name_Meeting"];
            BLL.RoomManageBLL a = new RoomManageBLL();
            var b = a.Room_getChaName(Name_Meeting,Conference_Room_Name);
            Serialize1(b);

        }

        /// <summary>
        ///根据id 查询会议室信息:Rooms_Content
        /// </summary>
        /// <returns></returns>
        private void RoomsContents_GetCha()
        {
            int id = 4;
            RoomManageBLL room = new RoomManageBLL();
            var table = room.RoomsContents_getCha(id);
            Serialize1(table);
        }

        /// <summary>
        /// 会议室审核保存按钮
        /// </summary>
        /// <returns></returns>
        private void RoomExmin_baoC()
        {

            ConferenceManagement management = new ConferenceManagement();
            //management.ConferenceID = Convert.ToInt32(HttpContext.Current.Request.Form["ConferenceID"]);
            management.UserId = new User { UserID = 5, };
            management.Inviter = HttpContext.Current.Request.Form["Inviter"];
            management.FormMeeting = HttpContext.Current.Request.Form["FormMeeting"];
            management.NameMeeting = HttpContext.Current.Request.Form["NameMeeting"];
            management.DepartID = new Department
            {
                DepartID = 5,
                // DepartName=HttpContext.Current.Request.Form["DepartName"]
            };
            management.ConferenceBeginTime = HttpContext.Current.Request.Form["ConferenceBeginTime"];
            management.ConferenceEndTime = HttpContext.Current.Request.Form["ConferenceEndTime"];
            management.ConferenceRoomID = new ConferenceRoomManagement { ConferenceRoomID = 1, };
            management.MeetingStatus = HttpContext.Current.Request.Form["MeetingStatus"];
            management.MeetingDescribes = HttpContext.Current.Request.Form["MeetingDescribes"];
            RoomManageBLL room = new RoomManageBLL();
            var r = room.RoomExmin_Baoc(management);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "添加失败", code = 201 };
            if (r)
            {
                obj = new { msg = "添加成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 会议室邀请人
        /// </summary>
        /// <param name="Wirte"></param>
        private void RoomsPeople()
        {
            RoomManageBLL room = new RoomManageBLL();
            var s = HttpContext.Current.Request.Form["id"];
            var table = room.RoomPeople(s);
            Serialize1(table);

        }
        /// <summary>
        /// 会议室预约人：Rooms_Information
        /// </summary>
        /// <returns></returns>
        public void Rooms_InformationsOrders()
        {
            var id = HttpContext.Current.Request.Form["DepartID"];
            RoomManageBLL room = new RoomManageBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = room.Rooms_Informations_Orders(id);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();

        }
        /// <summary>
        /// 会议室预约人：Rooms_Information
        /// </summary>
        public void Rooms_Informations_OrderSelects()
        {
            RoomManageBLL room = new RoomManageBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = room.Rooms_Informations_OrderSelects();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();

        }
        /// <summary>
        /// 会议室申请保存按钮
        /// </summary>
        /// <returns></returns>
        private void RoomApplay()
        {
            ConferenceManagement management = new ConferenceManagement();
            management.ConferenceID = Convert.ToInt32(HttpContext.Current.Request.Form["ConferenceID"]);//id
            management.UserId = new User { UserID = 7 };//发起人
            management.Inviter = HttpContext.Current.Request.Form["Inviter"];//邀请人
            management.FormMeeting = HttpContext.Current.Request.Form["FormMeeting"];//会议名称
            management.NameMeeting = HttpContext.Current.Request.Form["NameMeeting"];//会议形式
            //management.DepartID = new Department
            //{
            //    DepartID = 7,//部门id
            //    //DepartName=HttpContext.Current.Request.Form["DepartName"]
            //};
            management.DepartID = new Department { DepartID = Convert.ToInt32(HttpContext.Current.Request.Form["DepartID"]) };
            management.ConferenceBeginTime = HttpContext.Current.Request.Form["ConferenceBeginTime"];//开始时间
            management.ConferenceEndTime = HttpContext.Current.Request.Form["ConferenceEndTime"];//结束时间


            management.ConferenceRoomID = new ConferenceRoomManagement { ConferenceRoomID = Convert.ToInt32(HttpContext.Current.Request.Form["ConferenceRoomID"]) };//会议室id
            management.MeetingStatus = HttpContext.Current.Request.Form["MeetingStatus"];//会议室状态

            management.MeetingDescribes = HttpContext.Current.Request.Form["MeetingDescribes"];//描述
            RoomManageBLL room = new RoomManageBLL();
            var r = room.RoomApplay_baoc(management);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "添加失败", code = 201 };
            if (r)
            {
                obj = new { msg = "添加成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 会议室修改页面
        /// </summary>
        /// <returns></returns>
        public void ROOMS_Update()
        {
            ConferenceManagement management = new ConferenceManagement();
            management.ConferenceID = Convert.ToInt32(HttpContext.Current.Request.Form["ConferenceID"]);//id
            management.UserId = new User { UserID = 7 };//发起人
            management.Inviter = HttpContext.Current.Request.Form["Inviter"];//邀请人
            management.FormMeeting = HttpContext.Current.Request.Form["FormMeeting"];//会议名称
            management.NameMeeting = HttpContext.Current.Request.Form["NameMeeting"];//会议形式
            management.DepartID = new Department
            {
                DepartID = 7,//部门id
                //DepartName=HttpContext.Current.Request.Form["DepartName"]
            };
            management.ConferenceBeginTime = HttpContext.Current.Request.Form["ConferenceBeginTime"];//开始时间
            management.ConferenceEndTime = HttpContext.Current.Request.Form["ConferenceEndTime"];//结束时间
            management.ConferenceRoomID = new ConferenceRoomManagement { ConferenceRoomID = 1, };//会议室id
            management.MeetingStatus = HttpContext.Current.Request.Form["MeetingStatus"];//会议室状态

            management.MeetingDescribes = HttpContext.Current.Request.Form["MeetingDescribes"];//描述
            RoomManageBLL room = new RoomManageBLL();
            var a = room.ROOMS_Update(management);

            var obj = new { msg = "修改成功！", code = 200 };
            if (!room.ROOMS_Update(management))
            {
                obj = new { msg = "修改失败！", code = 201 };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string rs = js.Serialize(obj);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 会议室管理资源图
        /// </summary> 
        /// <returns></returns>
        public void Select_infroations()
        {
            RoomManageBLL room = new RoomManageBLL();
            var table = room.Select_infroations();
            Serialize1(table);

        }
        /// <summary>
        /// 会议室管理资源图按条件查询
        /// </summary>
        /// <returns></returns>
        public void Select_infroationsNmae()
        {
            string name = HttpContext.Current.Request.Form["Name"];
            RoomManageBLL room = new RoomManageBLL();
            var table = room.Select_infroationName(name);
            Serialize1(table);

        }

        /// <summary>
        /// 系统管理中的修改密码
        /// </summary>
        /// <returns></returns>
        public void getUpUser()
        {
            User user = new User();
            user.JobNumber = Convert.ToInt32(HttpContext.Current.Request.Form["JobNumber"]);
            user.Passwored = HttpContext.Current.Request.Form["Passwored"].ToString();
            BLL.CX.ModifyLoginPwdBLL userBLL = new BLL.CX.ModifyLoginPwdBLL();
            var r = userBLL.GetUpuser(user);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "修改失败", code = 201 };
            if (r)
            {
                obj = new { msg = "修改成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();

        }


        /// <summary>
        ///系统管理中的修改个人信息保存按钮
        /// </summary>
        /// <returns></returns>
        public void GetUpUsers()
        {

            User user = new User();
            user.JobNumber = Convert.ToInt32(HttpContext.Current.Request.Form["JobNumber"]);
            user.YGcard = HttpContext.Current.Request.Form["YGcard"].ToString();
            user.Email = HttpContext.Current.Request.Form["Email"].ToString();
            user.Address = HttpContext.Current.Request.Form["Address"].ToString();
            user.Account = HttpContext.Current.Request.Form["Account"].ToString();
            user.IdCard = HttpContext.Current.Request.Form["IdCard"].ToString();
            user.Phone = HttpContext.Current.Request.Form["Phone"].ToString();
           // user.ImageUrl = HttpContext.Current.Request.Form["ImageUrl"].ToString();
            var r = BLL.CX.PersonalInformationBLL.GetUpUsers(user);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "修改失败", code = 201 };
            if (r)
            {
                obj = new { msg = "修改成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();

        }
        /// <summary>
        /// 系统管理中的部门维护
        /// </summary>
        /// <param name="Wirte"></param>
        private void GetUsers()
        {
            BLL.CX.DepartMaintenanceBLL bLL = new BLL.CX.DepartMaintenanceBLL();
            var table = bLL.GetUser();
            Serialize1(table);
        }
        /// <summary>
        /// 系统管理中的部门维护
        /// </summary>
        /// <param name="Wirte"></param>
        private void Depart_USERS()
        {
            BLL.CX.DepartMaintenanceBLL bLL = new BLL.CX.DepartMaintenanceBLL();
            var table = bLL.Depart_USERS();
            Serialize1(table);
        }
        /// <summary>
        /// 在线人员统计
        /// </summary>
        /// <param name="Wirte"></param>
        private void OnlinePeople()
        {
            BLL.CX.OlineBLL oline = new BLL.CX.OlineBLL();
            var table = oline.OnlineUser();
            Serialize1(table);
        }
        /// <summary>
        /// 在线人员统计查询按钮
        /// </summary>
        public void getInformation()
        {
            BLL.CX.OnlineInformationBLL userBLL = new BLL.CX.OnlineInformationBLL();
            var s = HttpContext.Current.Request.Form["dep"];
            var d = HttpContext.Current.Request.Form["curr"];
            var f = HttpContext.Current.Request.Form["pos"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = userBLL.GetUsers(s, d, f);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        //序列化方法
        private void Serialize1(object Wirte)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string rs = js.Serialize(Wirte);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();


        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}