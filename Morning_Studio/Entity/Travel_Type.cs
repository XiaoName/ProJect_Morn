using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Travel_Type
    {
        /// <summary>
        /// 出差类型 id 
        /// </summary>
        public int TypeID { get; set; }

        /// <summary>
        /// 出差类型名
        /// </summary>
        public string Type_Name { get; set; }


      /// <summary>
      /// 自关联 出差类型id
      /// </summary>
        public int type_ID1 { get; set; }
    }
}
