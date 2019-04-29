using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.YYW;
namespace BLL.YYW
{
   public class Page_XianShiBLL
    {
        public static List<int> KaoQin(int userid) {
            return DAL.YYW.Page_XianShiDAL.KaoQin(userid);
        }
    }
}
