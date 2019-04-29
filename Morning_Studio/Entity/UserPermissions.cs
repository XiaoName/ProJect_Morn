using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 用户权限表
    /// </summary>
   public class UserPermissions
    {
        public User UserId { get; set; }//用户ID
        public Permissios PermissiosID { get; set; }//权限Code
    }
}
