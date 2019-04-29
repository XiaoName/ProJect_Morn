using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{/// <summary>
 /// 报销申请
 /// </summary>
    public class ClaimReimbursement
    {
        public int ClaimID { get; set; }//ID
        public char ClaimProjects { get; set; }//有无项目
        public int ItemNumberID { get; set; }//项目编号（立项通过（外键））
        public string ClaimStartTime { get; set; }//开始时间
        public string ClaimEndTime { get; set; }//结束时间
        public string ClaimDestination { get; set; }//目的地
        public string ClaimExplain { get; set; }//说明
        public string OddNumbers { get; set; }//单号
        public string ReimbursementMatters { get; set; }//报销事项
        public string ClaimTypeEvent { get; set; }//事项类型（出差 1、购置办公用品 2）
    }
}
