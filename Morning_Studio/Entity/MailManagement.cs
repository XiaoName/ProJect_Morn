using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class MailManagement
    {
        public int MailId { get; set; }//Id
        public int UserId { get; set; }//发起人（外键）
        public string MailIdentification { get; set; }//接收人标识
        public string MailSendTime { get; set; }//发送时间
        public string MailContents { get; set; }//邮件内容
        public string MailTitle { get; set; }//邮件标题
        public string MailAttachmentPath { get; set; }//附件路径
        public char MailReceipt { get; set; }//是否要回执（0-否 1-是）
        public char MialStatus { get; set; }//邮件状态（1-已读 2-未读）
        public char MialDelete { get; set; }//是否删除
    }
}
