using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permissios
    {
        public int PermissiosID { get; set; }//权限Code
        public string PermissiosName { get; set; }//权限名称
        public int ParentPermissions { get; set; }//父级权限Code
        public string PermissionsCode { get; set; }//权限编号
        public string PermissiosName1 { get; set; }//子权限
        public List<Permissios> PermissiosName2 { get; set; }//子权限1
    }
}
