using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 职位权限表
    /// </summary>
   public class Position
    {
        public PositionTable DimissionId { get; set; }//职位ID
        public Permissios PermissiosID { get; set; }//权限Code
    }
}
