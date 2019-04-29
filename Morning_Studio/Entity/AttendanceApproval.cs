using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class AttendanceApproval
    {
        public int ApprovalId { get; set; }//id
        public User UserNumber { get; set; }//工号（外键）
        public string ApprovalLeaveDays { get; set; }//请假天数
        public string ApprovalState { get; set; }//状态
        public User ApprovalPeople { get; set; }//审批人（外键）
    }
}
