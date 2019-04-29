using Entity;
using System;
using System.Collections.Generic;
using System.Data;
namespace DAL
{
    public class WorkOrderDAL
    {
        /// <summary>
        /// 责任人
        /// </summary>
        /// <returns></returns>
        public List<User> getUser()
        {
            string sql = string.Format("select * from MS_User");
            var table = DBHelper.Select(sql);
            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    UserID = Convert.ToInt32(item["User_Id"]),
                    IdCard = item["User_YGcard"].ToString()
                };
                list.Add(user);
            }
            return list;

        }

        /// <summary>
        /// 创建工作单多条件查询
        /// </summary>
        /// <returns></returns>
        public List<WorkSheet> GetWorkSelect(string number, string TaskName)
        {
            string sql = string.Format("select Work_Order_Number,Responsible_Person,Work_CreatNumber,Worksheet_CreatDate,Work_DealPeople,Work_UploadType,Work_Describle,Work_State, Work_DueTime, Work_DueDeal, Work_TaskName, Work_Reminderlevel, Work_ReminderTime from MS_Worksheet where Work_Order_Number like '%{0}%'and Work_TaskName  like '%{1}%'", number,TaskName);
           

            var table = DBHelper.Select(sql);
            List<WorkSheet> list = new List<WorkSheet>();
            foreach (DataRow item in table.Rows)
            {
                WorkSheet user = new WorkSheet
                {
                    WorkOrderNumber = item["Work_Order_Number"].ToString(),
                    ResponsiblePerson = item["Responsible_Person"].ToString(),
                    WorkDealPeople = item["Work_DealPeople"].ToString(),
                    WorksheetCreatDate = item["Worksheet_CreatDate"].ToString(),
                    WorkUploadType = item["Work_UploadType"].ToString(),
                    MyProWorkDescribleperty = item["Work_Describle"].ToString(),
                    WorkState = item["Work_State"].ToString(),
                    WorkCreatNumber = item["Work_CreatNumber"].ToString(),
                    WorkDueTime = item["Work_DueTime"].ToString(),
                    WorkDueDeal = item["Work_DueDeal"].ToString(),
                    WorkTaskName = item["Work_TaskName"].ToString(),
                    WorkReminderlevel = item["Work_Reminderlevel"].ToString(),
                    WorkReminderTime = item["Work_ReminderTime"].ToString()
                };
                list.Add(user);
            }
            return list;
        }


       


        /// <summary>
        /// 工作单创建明细加载数据库
        /// </summary>
        /// <returns></returns>
        public List<WorkSheet> getCha()
        {
            string sql = string.Format("select * from MS_Worksheet");
            var table = DBHelper.Select(sql);
            List<WorkSheet> list = new List<WorkSheet>();
            foreach (DataRow item in table.Rows)
            {
                WorkSheet user = new WorkSheet
                {
                    WorksheetID = Convert.ToInt32(item["WorksheetID"]),
                    WorkOrderNumber = item["Work_Order_Number"].ToString(),
                    ResponsiblePerson = item["Responsible_Person"].ToString(),
                    WorkDealPeople = item["Work_DealPeople"].ToString(),
                    WorksheetCreatDate = item["Worksheet_CreatDate"].ToString(),
                    WorkUploadType = item["Work_UploadType"].ToString(),
                    MyProWorkDescribleperty = item["Work_Describle"].ToString(),
                    WorkState = item["Work_State"].ToString(),
                    WorkCreatNumber = item["Work_CreatNumber"].ToString(),
                    WorkDueTime = item["Work_DueTime"].ToString(),
                    WorkDueDeal = item["Work_DueDeal"].ToString(),
                    WorkTaskName = item["Work_TaskName"].ToString(),
                    WorkReminderlevel = item["Work_Reminderlevel"].ToString(),
                    WorkReminderTime = item["Work_ReminderTime"].ToString()
                };
                list.Add(user);
            }
            return list;

        }


        //根据id 查询工作单信息:Worksheet_Content
        public WorkSheet Upate_getCha(int id)
        {
            string sql = string.Format("select * from MS_Worksheet where WorksheetID='{0}'", id);
            var table = DBHelper.Select(sql);
            WorkSheet user = new WorkSheet
            {
                WorksheetID = Convert.ToInt32(table.Rows[0]["WorksheetID"]),
                WorkOrderNumber = table.Rows[0]["Work_Order_Number"].ToString(),
                ResponsiblePerson = table.Rows[0]["Responsible_Person"].ToString(),
                WorkDealPeople = table.Rows[0]["Work_DealPeople"].ToString(),
                WorksheetCreatDate = table.Rows[0]["Worksheet_CreatDate"].ToString(),
                WorkUploadType = table.Rows[0]["Work_UploadType"].ToString(),
                MyProWorkDescribleperty = table.Rows[0]["Work_Describle"].ToString(),
                WorkState = table.Rows[0]["Work_State"].ToString(),
                WorkCreatNumber = table.Rows[0]["Work_CreatNumber"].ToString(),
                WorkDueTime = table.Rows[0]["Work_DueTime"].ToString(),
                WorkDueDeal = table.Rows[0]["Work_DueDeal"].ToString(),
                WorkTaskName = table.Rows[0]["Work_TaskName"].ToString(),
                WorkReminderlevel = table.Rows[0]["Work_Reminderlevel"].ToString(),
                WorkReminderTime = table.Rows[0]["Work_ReminderTime"].ToString()
            };
            return user;

        }

        /// <summary>
        /// 工作单创建修改按钮
        /// </summary>
        /// <returns></returns>
        public int Work_Update(WorkSheet workSheet)
        {
            string sql = string.Format("UPDATE[dbo].[MS_Worksheet] SET[Work_Order_Number] = '{0}',[Responsible_Person] = '{1}',[Work_CreatNumber] = '{2}',[Worksheet_CreatDate] = '{3}',[Work_Describle] = '{4}',[Work_DueTime] = '{5}',[Work_TaskName] = '{6}',[Work_Reminderlevel] = '{7}' WHERE WorksheetID = '{8}'", workSheet.WorkOrderNumber, workSheet.ResponsiblePerson, workSheet.WorkCreatNumber, workSheet.WorksheetCreatDate, workSheet.MyProWorkDescribleperty, workSheet.WorkDueTime, workSheet.WorkTaskName, workSheet.WorkReminderlevel, workSheet.WorksheetID);
            return DBHelper.NonQuery(sql);
        }


        /// <summary>
        /// 工作单处理保存按钮
        /// </summary>
        /// <returns></returns>
        public bool WorkProcess_baoc(WorkSheet workSheet)
        {
            string sql = string.Format("INSERT INTO[dbo].[MS_Worksheet]([Work_Order_Number],[Responsible_Person],[Work_CreatNumber],[Worksheet_CreatDate],[Work_DealPeople],[Work_UploadType],[Work_Describle],[Work_State],[Work_DueTime],[Work_DueDeal],[Work_TaskName],[Work_Reminderlevel],[Work_ReminderTime])VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", workSheet.WorkOrderNumber, workSheet.ResponsiblePerson, workSheet.WorkCreatNumber, workSheet.WorksheetCreatDate, workSheet.WorkDealPeople, workSheet.WorkUploadType, workSheet.MyProWorkDescribleperty, workSheet.WorkState, workSheet.WorkDueTime, workSheet.WorkDueDeal, workSheet.WorkTaskName, workSheet.WorkReminderlevel, workSheet.WorkReminderTime);
            return DBHelper.NonQuery(sql) > 0;

        }

        /// <summary>
        /// 工作单申请保存按钮
        /// </summary>
        /// <returns></returns>
        public bool Worksqing_baoc(WorkSheet workSheet)
        {
            string sql = string.Format("INSERT INTO[dbo].[MS_Worksheet]([Work_Order_Number],[Responsible_Person],[Work_CreatNumber],[Worksheet_CreatDate],[Work_DealPeople],[Work_UploadType],[Work_Describle],[Work_State],[Work_DueTime],[Work_DueDeal],[Work_TaskName],[Work_Reminderlevel],[Work_ReminderTime])VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", workSheet.WorkOrderNumber, workSheet.ResponsiblePerson, workSheet.WorkCreatNumber, workSheet.WorksheetCreatDate, workSheet.WorkDealPeople, workSheet.WorkUploadType, workSheet.MyProWorkDescribleperty, workSheet.WorkState, workSheet.WorkDueTime, workSheet.WorkDueDeal, workSheet.WorkTaskName, workSheet.WorkReminderlevel, workSheet.WorkReminderTime);
            return DBHelper.NonQuery(sql) > 0;

        }
    }
}
