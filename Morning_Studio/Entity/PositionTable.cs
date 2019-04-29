using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 职位表
    /// </summary>
   public class PositionTable
    {
        public int PositionId { get; set; }//id
        public Department DepartmentID { get; set; }//部门ID
        public string PositionName { get; set; }//职务名称
    }
}
