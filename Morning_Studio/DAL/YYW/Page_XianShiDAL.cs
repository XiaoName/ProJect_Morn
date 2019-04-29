using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.YYW
{
   public class Page_XianShiDAL
    {
        public static List<int> KaoQin(int userid)
        {
            List<int> lis = new List<int>();
            //迟到
            string sql = "select COUNT(0) as chidao from MS_Attendance_Manage where Manage_Remarks like '%延时%' and User_Id="+ userid;
            DataTable tab1 = DBHelper.Select(sql);
            var a = Convert.ToInt32(tab1.Rows[0]["chidao"]);
            lis.Add(a);
            //缺卡
            string sql2 = "select COUNT(0) as queka from MS_Attendance_Manage where Manage_Remarks like '%缺卡%' and User_Id=" + userid;
            DataTable tab2 = DBHelper.Select(sql2);
            var b = Convert.ToInt32(tab2.Rows[0]["queka"]);
            lis.Add(b);
            //旷工
            string sql3 = "select COUNT(0) as kuanggong from MS_Attendance_Manage where Manage_Remarks like '%旷工%' and User_Id=" + userid;
            DataTable tab3 = DBHelper.Select(sql3);
            var c = Convert.ToInt32(tab3.Rows[0]["kuanggong"]);
            lis.Add(c);
            //全勤
            string sql4 = "select COUNT(0) as quanqin from MS_Attendance_Manage where Manage_Remarks like '%打卡成功%' and User_Id=" + userid;
            DataTable tab4 = DBHelper.Select(sql4);
            var d = Convert.ToInt32(tab4.Rows[0]["quanqin"]);
            lis.Add(d);
            return lis;
        }
    }
}
