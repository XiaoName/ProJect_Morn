using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL.NJ
{
    /// <summary>
    /// 菜单维护
    /// </summary>
    public class PermissiosDAL
    {
        /// <summary>
        /// 一级菜单
        /// </summary>
        /// <returns></returns>
        public List<Permissios> getSeYJ()
        {
            string sql = string.Format("select * from MS_Permissios where Parent_Permissions IS null ");
            var table = DBHelper.Select(sql);
            List<Permissios> list = new List<Permissios>();
            foreach (DataRow item in table.Rows)
            {
                Permissios permissios = new Permissios {
                    PermissiosID = Convert.ToInt32(item["Permissions_Id"]),
                    PermissiosName = item["Permissions_name"].ToString(),
                    PermissionsCode=item["Permissions_Code"].ToString()
                };
                list.Add(permissios);
            }
            return list;
        }
        /// <summary>
        /// 二级菜单
        /// </summary>
        /// <returns></returns>
        public List<Permissios> getSeEJ(string r)
        {
            string sql = string.Format("select * from MS_Permissios where Parent_Permissions IS not null and Parent_Permissions like '%{0}%'",r);
            var table = DBHelper.Select(sql);
            List<Permissios> list = new List<Permissios>();
            foreach (DataRow item in table.Rows)
            {
                Permissios permissios = new Permissios
                {
                    PermissiosID = Convert.ToInt32(item["Permissions_Id"]),
                    PermissiosName = item["Permissions_name"].ToString(),
                    PermissionsCode = item["Permissions_Code"].ToString(),
                    ParentPermissions=Convert.ToInt32(item["Parent_Permissions"])
                    
                };
                list.Add(permissios);
            }
            return list;
        }
        /// <summary>
        /// 菜单
        /// </summary>
        public List<Permissios> getSeCD(string s,string d,string f)
        {
            string sql = string.Format("select a.Permissions_Id f,b.Permissions_Id a,a.Permissions_name b,b.Permissions_Code c,b.Permissions_name d from MS_Permissios " +
                "a join MS_Permissios b on a.Permissions_Id=b.Parent_Permissions where a.Permissions_Id like '%{0}%' and b.Permissions_Id like '%{1}%' and a.Permissions_name like '%{2}%'", d,f,s);
            var table = DBHelper.Select(sql);
            List<Permissios> list = new List<Permissios>();
            foreach (DataRow item in table.Rows)
            {
                Permissios permissios = new Permissios
                {
                    PermissiosID = Convert.ToInt32(item["a"]),
                    PermissiosName = item["b"].ToString(),
                    PermissionsCode = item["c"].ToString(),
                    PermissiosName1 = item["d"].ToString()
                };
                list.Add(permissios);
            }
            return list;
        }
        /// <summary>
        /// 显示权限
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public List<Permissios> GetPermissios()
        {
            string sql = string.Format("select * from MS_Permissios where Parent_Permissions IS null ");
            var table = DBHelper.Select(sql);
            List<Permissios> list = new List<Permissios>();
            foreach (DataRow item in table.Rows)
            {
                Permissios permissios = new Permissios
                {
                    PermissiosID = Convert.ToInt32(item["Permissions_Id"]),
                    PermissiosName = item["Permissions_name"].ToString(),
                    PermissionsCode = item["Permissions_Code"].ToString(),
                    PermissiosName2=new List<Permissios>()
                };
                list.Add(permissios);
                string sql1 = string.Format("select * from MS_Permissios where Parent_Permissions IS not null and Parent_Permissions like '%{0}%'", Convert.ToInt32(item["Permissions_Id"]));
                var table1 = DBHelper.Select(sql1);
                foreach (DataRow item1 in table1.Rows)
                {
                    Permissios per = new Permissios
                    {
                        PermissiosID = Convert.ToInt32(item1["Permissions_Id"]),
                        PermissiosName1 =item1["Permissions_name"].ToString()
                    };
                    permissios.PermissiosName2.Add(per);
                }
                
            }
            return list;
        }
    }
}
