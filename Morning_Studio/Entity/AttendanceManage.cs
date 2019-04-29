using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class AttendanceManage
    {
        public int ManageID { get; set; }//打卡Id(主键)
        public User UserId { get; set; }//用户id
        public string ManageCardTime { get; set; }//打卡时间
        public string ManageRemarks { get; set; }//备注
        public string ManageMark { get; set; }//打卡标记
        public string ManageEndTime { get; set; }//结束时间
        public Department DepartID { get; set; }//部门id
    }
}
