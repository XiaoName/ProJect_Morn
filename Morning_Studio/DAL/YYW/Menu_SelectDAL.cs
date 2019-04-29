using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL.YYW
{
    public class Menu_SelectDAL
    {
        public static List<Permissios> Menu_Select()
        {
            string sql = "select * from MS_Permissios where Parent_Permissions is null";
            DataTable table = DBHelper.Select(sql);
            List<Permissios> lst_permissios = new List<Permissios>();
            foreach (DataRow row in table.Rows)
            {
                Permissios permissios = new Permissios
                {
                    PermissiosID = Convert.ToInt32(row["Permissions_Id"]),
                    PermissiosName = row["Permissions_name"].ToString(),
                    PermissiosName2 = new List<Permissios>()
                };
                lst_permissios.Add(permissios);
                string sql2 = "select * from MS_Permissios where  [Parent_Permissions]=" + permissios.PermissiosID;
                DataTable table2 = DBHelper.Select(sql2);
                foreach (DataRow item in table2.Rows)
                {
                    Permissios per = new Permissios
                    {
                        PermissiosID = Convert.ToInt32(item["Permissions_Id"]),
                        PermissiosName = item["Permissions_name"].ToString()
                    };
                    
                    permissios.PermissiosName2.Add(per);
                }
            }
            return lst_permissios;
        }
    }
}
