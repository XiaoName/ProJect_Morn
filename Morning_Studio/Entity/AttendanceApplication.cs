using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 考勤申请
    /// </summary>
   public  class AttendanceApplication
    {
        public int AttendanceID { get; set; }//id
        public User UserId { get; set; }//姓名id（外键）
        public Department DepartID { get; set; }//部门id（外键
        public PositionTable PositionId { get; set; }//职位id（外键））
        public string AttendanceBeginTime { get; set; }//开始时间
        public string AttendanceEndTime { get; set; }//结束时间
        public string AttendanceMode { get; set; }//考勤方式
        public string AttendanceRemarks { get; set; }//备注
    }
}
