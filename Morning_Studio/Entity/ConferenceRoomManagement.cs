using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 会议室管理
    /// </summary>
  public  class ConferenceRoomManagement
    {
        public int ConferenceRoomID { get; set; }//id
        public string ConferenceRoomName { get; set; }//会议室名称
        public int ConferenceRoomStatus { get; set; }//会议室状态（0-空闲  1-使用 2-维护）
        public string Accommoadtepeople { get; set; }//容纳人数
        public string ConferenceRoomDescribes { get; set; }//会议室描述
        public string ConferenceRoomPlace { get; set; }//会议室地址
        public string ConferenceRoomremarks { get; set; }//备注
    }
}
