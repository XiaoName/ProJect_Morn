using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 申请表
    /// </summary>
   public class Application
    {
        /// <summary>
        /// id 主键
        /// </summary>
        public int ApplicatId { get; set; }

        /// <summary>
        /// 申请人Id
        /// </summary>
        public User UserId { get; set; }

        /// <summary>
        /// 申请开始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 申请结束时间   
        /// </summary>
        public string EndTime { get; set; }
        
        /// <summary>
        /// 申请类型
        /// </summary>
        public int Type { get; set; }
    }
}
