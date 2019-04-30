using Entity;
using System;
using System.Collections.Generic;
using System.Data;
namespace DAL.CX
{
    public class PositionTableDAL
    {
        //适用于部门，职位，工号三表联查（下拉框）
        public List<PositionTable> posi(string s)
        {
            List<PositionTable> list = new List<PositionTable>();
            string sql = string.Format("select * from MS_PositionTable where DepartmentID = '{0}'", s);
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                PositionTable positionTable = new PositionTable
                {
                    PositionId = Convert.ToInt32(item["PositionId"]),
                    PositionName = item["PositionName"].ToString()
                };
                list.Add(positionTable);
            }
            return list;
        }
        public List<User> Number(string s)
        {
            List<User> list = new List<User>();
            string sql = string.Format("select * from MS_User where Dutyid='{0}'", s);
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    UserID = Convert.ToInt32(item["User_Id"]),
                    JobNumber = Convert.ToInt32(item["User_JobNumber"]),
                };
                list.Add(user);
            }
            return list;
        }
        public List<User> Name(string s)
        {
            List<User> list = new List<User>();
            string sql = string.Format("select * from MS_User where User_Id='{0}'", s);
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    UserID = Convert.ToInt32(item["User_Id"]),
                    Name=item["User_Name"].ToString(),
                };
                list.Add(user);
            }
            return list;
        }
        public List<User> Names(string s)
        {
            List<User> list = new List<User>();
            string sql = string.Format("select * from MS_User where Dutyid='{0}'", s);
            var table = DBHelper.Select(sql);
            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    UserID = Convert.ToInt32(item["User_Id"]),
                    Name = item["User_Name"].ToString(),
                };
                list.Add(user);
            }
            return list;
        }

    }
}
