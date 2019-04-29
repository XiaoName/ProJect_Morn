using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class AttendanceStandard
    {
        public int StandardID { get; set; }//Id
        public string StandardBeginHours { get; set; }//上班时间
        public string StandardBeginHours_max { get; set; }//最迟上班时间
        public string StandardEndHours { get; set; }//下班时间
        public string StandardEndHours_max { get; set; }//最迟下班时间
        public string StandardSeason { get; set; }//季节
    }
}
