using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 审核流程配置表
    /// </summary>
   public class Audit
    {
        public string AuditType { get; set; }//请假流程类型编号
        public User UserId { get; set; }//审核人
        public string Hierarchy { get; set; }//层级
    }
}
