using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 出差申请
    /// </summary>
   public class TravelApplication
    {
        /// <summary>
        /// id 主键
        /// </summary>
        public int TravelId { get; set; }

        /// <summary>
        /// 部门负责人电话
        /// </summary>
        public string DepPhone { get; set; }

        /// <summary>
        /// 出差部门负责人
        /// </summary>
        public string DepResponsible { get; set; }

        /// <summary>
        /// 出行方式
        /// </summary>
        public int Travel_mode { get; set; }

        /// <summary>
        /// 出差地点
        /// </summary>
        public string Location1 { get; set; }

        /// <summary>
        /// 出差事由
        /// </summary>
        public string Reasons { get; set; }


        /// <summary>
        /// 本人联系方式
        /// </summary>
        public string oneself_Phone { get; set; }


        /// <summary>
        /// 随行人员
        /// </summary>
        public string Travel_SuiXing { get; set; }

        /// <summary>
        /// 出差类型
        /// </summary>
       public Travel_Type type { get; set; }

        /// <summary>
        /// 申请共用表 Appliaction
        /// </summary>
        public Application lication { get; set; }
    }
}
