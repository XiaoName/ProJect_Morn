using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Trvale_Reimbursement
    {
        /// <summary>
        /// 主键      
        /// </summary>
        public int Claim_ID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public User User_ID { get; set; }

        /// <summary>
        /// 有无项目
        /// </summary>
        public string Claim_Projects { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public Application Travel_ID { get; set; }

        /// <summary>
        /// 事由
        /// </summary>
        public string Cause { get; set; }

        /// <summary>
        /// 旅费
        /// </summary>
        public string Cost_ravel { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// 核算不萌
        /// </summary>
        public Department Dep_he { get; set; }

        /// <summary>
        /// 原借支
        /// </summary>
        public string Original_borrowing { get; set; }

    }
}
