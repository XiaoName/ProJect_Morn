using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 审核过程表
    /// </summary>
  public  class AuditProcess
    {
        public int AuditProcessId { get; set; }//id
        public Audit AuditId { get; set; }//申请id
        public User UserId { get; set; }//审核人
        public string AuditProcessTime { get; set; }//审核时间
        public string Result { get; set; }//审核结果
        public int Type { get; set; }//类型编号
        public string Remarks { get; set; }//备注
    }
}
