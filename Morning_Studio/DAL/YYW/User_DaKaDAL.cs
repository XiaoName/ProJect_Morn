using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.YYW
{
   public class User_DaKaDAL
    {
        public static List<AttendanceStandard> DaKa_Time()
        {
            string sql = "select * from MS_Attendance_Standard";
            DataTable table = DBHelper.Select(sql);  
            List<AttendanceStandard> lis = new List<AttendanceStandard>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                AttendanceStandard atts = new AttendanceStandard();
                atts.StandardBeginHours = table.Rows[i]["Standard_BeginHours"].ToString();
                atts.StandardBeginHours_max = table.Rows[i]["Standard_BeginHours_Max"].ToString();
                atts.StandardEndHours = table.Rows[i]["Standard_EndHours"].ToString();
                atts.StandardEndHours_max = table.Rows[i]["Standard_EndHours_Max"].ToString();
                atts.StandardSeason = table.Rows[i]["Standard_Season"].ToString();
                lis.Add(atts);
            }
            return lis;

        }
        public static bool DaKa(string gonghao, int dept_id, string dangqian_time, string beizhu, int dakabiaoji)
        {       
            string sql2 = "select * from MS_Attendance_Manage where Manage_Remarks like '%上班%' and (Manage_CardTime like '%"+ dangqian_time + "%' and User_Id like '%"+gonghao +"%') ";
            DataTable tabel = DBHelper.Select(sql2);
            string sql3 = "select * from MS_Attendance_Manage where Manage_Remarks like '%下班%' and (Manage_CardTime like '%" + dangqian_time + "%' and User_Id like '%" + gonghao + "%')";
            DataTable tabe2 = DBHelper.Select(sql3);
            if (tabel.Rows.Count <= 0 && tabe2.Rows.Count<=0)
            {
                string sql = string.Format("insert into MS_Attendance_Manage(User_Id,Manage_CardTime,Manage_Mark,DepartID,Manage_Remarks)" + " " +
                "values('{0}','{1}','{2}','{3}','{4}')", gonghao, dangqian_time, dakabiaoji, dept_id, beizhu);
                int rs = DBHelper.NonQuery(sql);
                return rs > 0;
            }
            if (tabel.Rows.Count > 0 && tabe2.Rows.Count <= 0)
            {
                string sql = string.Format("insert into MS_Attendance_Manage(User_Id,Manage_CardTime,Manage_Mark,DepartID,Manage_Remarks)" + " " +
                "values('{0}','{1}','{2}','{3}','{4}')", gonghao, dangqian_time, dakabiaoji, dept_id, beizhu);
                int rs = DBHelper.NonQuery(sql);
                return rs > 0;
            }
            else
                return false;
       
        }
    }
}
