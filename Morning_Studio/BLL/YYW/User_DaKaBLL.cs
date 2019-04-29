using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.YYW;
namespace BLL.YYW
{
   public class User_DaKaBLL
    {
        public static List<AttendanceStandard> DaKa_Time() {
            return User_DaKaDAL.DaKa_Time();
        }
        public static bool DaKa(string gonghao, int dept_id, string dangqian_time, string beizhu, int dakabiaoji)
        {
            return User_DaKaDAL.DaKa(gonghao, dept_id, dangqian_time, beizhu, dakabiaoji);
        }
    }
}
