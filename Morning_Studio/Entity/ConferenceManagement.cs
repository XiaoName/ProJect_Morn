using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{/// <summary>
/// 会议管理
/// </summary>
   public  class ConferenceManagement
    {
        public int ConferenceID { get; set; }//ID
        public User UserId { get; set; }// 发起人id
        public string Inviter{ get; set; }//邀请人员
        public string FormMeeting { get; set; }//会议形式
        public string NameMeeting  { get; set; }//会议名称
        public Department DepartID { get; set; }//会议部门id
        public string ConferenceBeginTime { get; set; }//开始时间
        public string ConferenceEndTime { get; set; }//结束时间
        public ConferenceRoomManagement ConferenceRoomID { get; set; }//会议室管理id
        public string MeetingStatus { get; set; }//会议状态（审核）
        public string MeetingDescribes { get; set; }//描述
    }
}
