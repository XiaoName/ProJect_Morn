using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 待办事项
    /// </summary>
   public class Todo
    {
        public int TodoID { get; set; }//id
        public string TodoBeginTime { get; set; }//开始时间
        public string TodoEndTime { get; set; }//结束时间
        public string TodoBeginDateTime { get; set; }//开始日开始时间
        public string TodoEndDateTime { get; set; }//结束日结束时间
        public string TodoRemindTime { get; set; }//提醒时间（提前提示）
        public string TodoLocation { get; set; }//地点（可空，如果是会议室类型的待办，就有用。。）
        public string TodoUserInformation { get; set; }//人员信息（当事人唯一，关联人不唯一）
        public string TodoParty { get; set; }//当事人
        public string TodoAssociatedPerson { get; set; }//关联人
        public string TodoContactPhone { get; set; }//当事人联系方式
        public string TodoEventDescription { get; set; }//事件说明（可以上传文件）
        public string TodoDegreeImportance { get; set; }//重要程度
        public string TodoEventTitle { get; set; }//事项标题（用于显示）
        public string TodoDetailsMatter { get; set; }//事项详细说明
        public string TodoAttachPackageID { get; set; }//附件包ID
        public string TodoCompletionInformation { get; set; }//办结信息
        public string TodoEventCompletionTime { get; set; }//事件办结时间
    }
}
