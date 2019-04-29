using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Entity;
using System.Web.Script.Serialization;
using System.Data;

namespace Morning_Studio
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request.QueryString["act"];
            switch (act)
            {
                case "Depart":
                    this.Depart();
                    break;
                case "PositionTable":
                    this.PositionTable();
                    break;
                case "EmployeeInsert":
                    this.EmployeeInsert();
                    break;
                case "GZstateld":
                    this.GZstateld();
                    break;
                case "getSeUser":
                    this.getSeUser();
                    break;
                case "getUpUser":
                    this.getUpUser();
                    break;
                case "getSePermissios":
                    this.getSePermissios();
                    break;
                case "getSePermissios1":
                    this.getSePermissios1();
                    break;
                case "getSePermissios2":
                    this.getSePermissios2();
                    break;
                case "getaddressbook":
                    this.getaddressbook();
                    break;
                case "getInformation":
                    this.getInformation();
                    break;
                case "getManagement":
                    this.getManagement();
                    break;
                case "getSttings":
                    this.getSttings();
                    break;
                case "gerPermissions":
                    this.gerPermissions();
                    break;
                case "getDepcount":
                    this.getDepcount();
                    break;
                case "getQX":
                    this.getQX();
                    break;
                case "getInper":
                    this.getInper();
                    break;
                case "getDelPer":
                    this.getDelPer();
                    break;
                case "getUpnabage":
                    this.getUpnabage();
                    break;
            }
        }
        /// <summary>
        /// 部门
        /// </summary>
        private void Depart()
        {
            BLL.DepartBLL departBLL = new DepartBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = departBLL.getDepart();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 职位
        /// </summary>
        private void PositionTable()
        {
            BLL.PositionTableBLL positionTable = new PositionTableBLL();
            var s = HttpContext.Current.Request.Form["id"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = positionTable.GetPositions(s);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// User新增
        /// </summary>
        private void EmployeeInsert()
        {
            User user = new User();
            user.JobNumber = Convert.ToInt32(HttpContext.Current.Request.Form["JobNumber"]);
            user.Name = HttpContext.Current.Request.Form["Name"].ToString();
            user.YGcard = HttpContext.Current.Request.Form["YGcard"].ToString();
            user.Passwored = HttpContext.Current.Request.Form["Passwored"].ToString();
            user.Departmentid = new Department { DepartID = Convert.ToInt32(HttpContext.Current.Request.Form["DepartID"]) };
            user.Dutyud = new PositionTable { PositionId = Convert.ToInt32(HttpContext.Current.Request.Form["PositionId"]) };
            user.Sex = HttpContext.Current.Request.Form["Sex"].ToString();
            user.Email = HttpContext.Current.Request.Form["Email"].ToString();
            user.Address = HttpContext.Current.Request.Form["Address"].ToString();
            user.Account = HttpContext.Current.Request.Form["Account"].ToString();
            user.Brithday = HttpContext.Current.Request.Form["Brithday"].ToString();
            user.IdCard = HttpContext.Current.Request.Form["IdCard"].ToString();
            user.GZstateId = new GZstateld { stateldId = Convert.ToInt32(HttpContext.Current.Request.Form["stateldId"]) };
            user.Dimission = HttpContext.Current.Request.Form["Dimission"].ToString();
            user.WorkStart = HttpContext.Current.Request.Form["WorkStart"].ToString();
            user.Phone = HttpContext.Current.Request.Form["Phone"].ToString();
            BLL.NJ.UserBLL userBLL = new BLL.NJ.UserBLL();
            var r = userBLL.getUser(user);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "添加失败", code = 201 };
            if (r)
            {
                obj = new { msg = "添加成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 员工类型
        /// </summary>
        public void GZstateld()
        {
            BLL.NJ.GZstateldBLL gzstateld = new BLL.NJ.GZstateldBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = gzstateld.GetGZstatelds();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 查询
        /// </summary>
        public void getSeUser()
        {
            var job = HttpContext.Current.Request.Form["JobNumber"];
            var Name = HttpContext.Current.Request.Form["Name"];
            BLL.NJ.UserBLL userBLL = new BLL.NJ.UserBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = userBLL.getSeUser(job,Name);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void getUpUser()
        {
            User user = new User();
            user.JobNumber = Convert.ToInt32(HttpContext.Current.Request.Form["JobNumber"]);
            user.Name = HttpContext.Current.Request.Form["Name"].ToString();
            user.YGcard = HttpContext.Current.Request.Form["YGcard"].ToString();
            user.Passwored = HttpContext.Current.Request.Form["Passwored"].ToString();
            user.Departmentid = new Department { DepartID = Convert.ToInt32(HttpContext.Current.Request.Form["DepartID"]) };
            user.Dutyud = new PositionTable { PositionId = Convert.ToInt32(HttpContext.Current.Request.Form["PositionId"]) };
            user.Sex = HttpContext.Current.Request.Form["Sex"].ToString();
            user.Email = HttpContext.Current.Request.Form["Email"].ToString();
            user.Address = HttpContext.Current.Request.Form["Address"].ToString();
            user.Account = HttpContext.Current.Request.Form["Account"].ToString();
            user.Brithday = HttpContext.Current.Request.Form["Brithday"].ToString();
            user.IdCard = HttpContext.Current.Request.Form["IdCard"].ToString();
            user.GZstateId = new GZstateld { stateldId = Convert.ToInt32(HttpContext.Current.Request.Form["stateldId"]) };
            user.Dimission = HttpContext.Current.Request.Form["Dimission"].ToString();
            user.WorkStart = HttpContext.Current.Request.Form["WorkStart"].ToString();
            user.Phone = HttpContext.Current.Request.Form["Phone"].ToString();
            BLL.NJ.UserBLL userBLL = new BLL.NJ.UserBLL();
            var r = userBLL.getUpUser(user);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "修改失败", code = 201 };
            if (r)
            {
                obj = new { msg = "修改成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 一级菜单
        /// </summary>
        public void getSePermissios()
        {
            BLL.NJ.PermissionsBLL userBLL = new BLL.NJ.PermissionsBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = userBLL.getSeYJ();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 二级菜单
        /// </summary>
        public void getSePermissios1()
        {
            BLL.NJ.PermissionsBLL userBLL = new BLL.NJ.PermissionsBLL();
            var r = HttpContext.Current.Request.Form["caidan1"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = userBLL.getSeEJ(r);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 菜单
        /// </summary>
        public void getSePermissios2()
        {
            BLL.NJ.PermissionsBLL userBLL = new BLL.NJ.PermissionsBLL();
            var s = HttpContext.Current.Request.Form["caidan"];
            var d = HttpContext.Current.Request.Form["caidan1"];
            var f = HttpContext.Current.Request.Form["caidan2"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = userBLL.getSeCD(s,d,f);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 通讯录查询
        /// </summary>
        public void getaddressbook()
        {
            BLL.NJ.AddressBookBLL userBLL = new BLL.NJ.AddressBookBLL();
            var a = HttpContext.Current.Request.Form["curr"];
            var b = HttpContext.Current.Request.Form["dep"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = userBLL.GetUsers(a,b);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 员工信息查询
        /// </summary>
        public void getInformation()
        {
            BLL.NJ.InformationBLL userBLL = new BLL.NJ.InformationBLL();
            var s = HttpContext.Current.Request.Form["dep"];
            var d = HttpContext.Current.Request.Form["curr"];
            var f = HttpContext.Current.Request.Form["pos"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = userBLL.GetUsers(s, d, f);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 员工权限信息查询
        /// </summary>
        public void getManagement()
        {
            BLL.NJ.ManagementBLL manbll = new BLL.NJ.ManagementBLL();
            var s = HttpContext.Current.Request.Form["dep"];
            var d = HttpContext.Current.Request.Form["curr"];
            var f = HttpContext.Current.Request.Form["pos"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = manbll.getManagement(s, d, f);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 职位权限
        /// </summary>
        public void getSttings()
        {
            BLL.NJ.SettingsBLL settingsBLL = new BLL.NJ.SettingsBLL();
            var r = HttpContext.Current.Request.Form["mucc"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = settingsBLL.GetPositions(r);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 角色权限
        /// </summary>
        public void gerPermissions()
        {
            BLL.NJ.UserPermissionsBLL permissionsBLL = new BLL.NJ.UserPermissionsBLL();
            var r = HttpContext.Current.Request.Form["mucc"];
            var table = permissionsBLL.GetPermissions(r);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 查询部门人数
        /// </summary>
        public void getDepcount()
        {
            BLL.NJ.Dep_StatisticsBLL dep = new BLL.NJ.Dep_StatisticsBLL();
            var s = HttpContext.Current.Request.Form["bumen"];
            var d = HttpContext.Current.Request.Form["kai"];
            var f = HttpContext.Current.Request.Form["jie"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = dep.getDepCount(s,d,f);
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        public void getQX()
        {
            BLL.NJ.PermissionsBLL permissionsBLL = new BLL.NJ.PermissionsBLL();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var table = permissionsBLL.GetPermissios();
            string str = js.Serialize(table);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        public void getInper()
        {
            BLL.NJ.UserPermissionsBLL dep = new BLL.NJ.UserPermissionsBLL();
            var s = HttpContext.Current.Request.Form["bumen"];
            var d = HttpContext.Current.Request.Form["mucc"];
            var r = dep.getInper(d,s);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "添加失败", code = 201 };
            if (r)
            {
                obj = new { msg = "添加成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        public void getDelPer()
        {
            BLL.NJ.UserPermissionsBLL dep = new BLL.NJ.UserPermissionsBLL();
            var s = HttpContext.Current.Request.Form["bumen"];
            var d = HttpContext.Current.Request.Form["mucc"];
            var r = dep.getDelPer(d, s);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "删除失败", code = 201 };
            if (r)
            {
                obj = new { msg = "删除成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        public void getUpnabage()
        {
            BLL.NJ.ManagementBLL dep = new BLL.NJ.ManagementBLL();
            var s = "false";
            var d = HttpContext.Current.Request.Form["job"];
            var r = dep.getUpManage(s,d);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = new { msg = "删除失败", code = 201 };
            if (r)
            {
                obj = new { msg = "删除成功", code = 200 };
            }
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}