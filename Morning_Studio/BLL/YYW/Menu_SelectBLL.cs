using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL.YYW;
namespace BLL.YYW
{
   public class Menu_SelectBLL
    {
        public static List<Permissios> Menu_Select()
        {
            return DAL.YYW.Menu_SelectDAL.Menu_Select();
        }
    }
}
