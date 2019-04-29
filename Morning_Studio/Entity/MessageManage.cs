using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class MessageManage
    {
        public int MessageID { get; set; }//ID
        public User SenderID { get; set; }//发送人id
        public User RecipientID { get; set; }//接收人id
        public string MessageSendTime { get; set; }//发送时间
        public string MessageContent { get; set; }//消息内容
        public string MessageTitle { get; set; }//消息标题
        public string MessageType { get; set; }//类型
        public char MessagePublic { get; set; }//是否公开
        public char MessageRead { get; set; }//是否阅读
        public string MessageReceiveSendTime { get; set; }//收发时间
        public string name { get; set; } //发送人姓名

    }
}
