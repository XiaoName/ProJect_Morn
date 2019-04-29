using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 工作单
    /// </summary>
    public class WorkSheet
    {
        public int WorksheetID { get; set; }//ID
        public string WorkOrderNumber { get; set; }//工作单单号
        public string ResponsiblePerson { get; set; }//责任人/处理人姓名
        public string WorkCreatNumber { get; set; }//创建人工号(外键)
        public string WorksheetCreatDate { get; set; }//工作单创建日期
        public string WorkDealPeople { get; set; }//处理人（默认为当前创建人，可以是上级）
        public string WorkUploadType { get; set; }//上传类型
        public string MyProWorkDescribleperty { get; set; }//描述
        public string WorkState { get; set; }//状态
        public string WorkDueTime { get; set; }//到期时间
        public string WorkDueDeal { get; set; }//到期处理
        public string WorkTaskName { get; set; }//任务名称
        public string WorkReminderlevel { get; set; }//催办等级
        public string WorkReminderTime { get; set; }//催办时效
    }
}
