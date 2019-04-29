using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using BLL.YYW;
namespace Morning_Studio.YYW.my_Handler
{
    /// <summary>
    /// home_page_handler 的摘要说明
    /// </summary>
    public class home_page_handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request.QueryString["act"];
            switch (act)
            {
                case "user_select":
                    User_Sel();
                    break;
                case "user_dept":
                    User_Dept();
                    break;
                case "jieshouren":
                    User_JieShou();
                    break;
                case "em_rtn":
                    Email_Rtn();
                    break;
                case "em_rtn_sp":
                    Email_Rtn_SP();
                    break;
                case "xj_em_rtn":
                    XJ_Email_Rtn();
                    break;
                case "daka_time":
                    DaKa_Time();
                    break;
                case "user_daka":
                    User_DaKa();
                    break;
                case "kaoqin":
                    KaoQin();
                    break;
                    //以上 请假申请相关代码
            }
        }

        //用户查询
        private void User_Sel()
        {
            var gh = HttpContext.Current.Request["usergonghao"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lst = user_selectBLL.Select(gh);
            string rs = js.Serialize(lst);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }
        //部门查询
        private void User_Dept()
        {
            var dep = HttpContext.Current.Request["usergonghao"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lst = user_selectBLL.Dept(dep);
            string rs = js.Serialize(lst);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }
        //接收人查询
        private void User_JieShou()
        {
            var jieshou = HttpContext.Current.Request["js_user"];
            var gonghao = Convert.ToInt32(HttpContext.Current.Request["gonghao"]);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lst = user_selectBLL.Select_Jieshou(jieshou, gonghao);
            string rs = js.Serialize(lst);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }
        //打卡时间
        private void DaKa_Time()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lst = User_DaKaBLL.DaKa_Time();
            string rs = js.Serialize(lst);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }
        //用户打卡
        private void User_DaKa() {
            var gonghao = HttpContext.Current.Request["userid"];
            var dept_id = Convert.ToInt32(HttpContext.Current.Request["dept_id"]);
            var dangqian_time = HttpContext.Current.Request["dangqian_time"];
            var beizhu = HttpContext.Current.Request["beizhu"];
            var dakabiaoji =Convert.ToInt32( HttpContext.Current.Request["dakabiaoji"]);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lst = User_DaKaBLL.DaKa(gonghao, dept_id, dangqian_time, beizhu, dakabiaoji);
            var obj = new
            {
                msg = "已完成上班打卡!",
                code = 201
            };
            if (lst)
            {
              obj = new
                {
                    msg = "打卡成功!",
                    code = 200
                };
            }    
            string rs = js.Serialize(obj);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }
        //请假按钮
        private void Email_Rtn()
        {
            //请假数据
            var tal = HttpContext.Current.Request["tal"];
            var gonghao = Convert.ToInt32(HttpContext.Current.Request["number"]);
            var js_userid = Convert.ToInt32(HttpContext.Current.Request["js_userid"]);
            var beizhu = HttpContext.Current.Request["beizhu"];
            var t_time = HttpContext.Current.Request["t_time"];
            var start_time = HttpContext.Current.Request["start_time"];
            var end_time = HttpContext.Current.Request["end_time"];
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lis = user_selectBLL.Email_Rtn(tal, gonghao, js_userid, beizhu, t_time,start_time, end_time);
            var obj = new
            {
                msg="发送成功!",
                code=200
            };

            if (!lis)
            {
                obj = new
                {
                    msg = "发送失败!",
                    code = 201
                };
            }
            string rs = js.Serialize(obj);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();

        }
        //请假审批
        private void Email_Rtn_SP() {
            var gonghao=Convert.ToInt32(HttpContext.Current.Request["gonghao"]);
            var userid = Convert.ToInt32(HttpContext.Current.Request["userid"]);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lis = user_selectBLL.Email_Rtn_SP(gonghao, userid);
            string rs = js.Serialize(lis);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }
        //休假按钮
        private void XJ_Email_Rtn()
        {
            //休假数据
            var xj_tal = HttpContext.Current.Request["xj_tal"];
            var xj_gonghao = Convert.ToInt32(HttpContext.Current.Request["xj_number"]);
            var xjjs_userid = Convert.ToInt32(HttpContext.Current.Request["xjjs_userid"]);
            var xj_beizhu = HttpContext.Current.Request["xj_beizhu"];
            var xj_time = HttpContext.Current.Request["xj_time"];
            var start_time = HttpContext.Current.Request["xj_start_time"];
            var end_time = HttpContext.Current.Request["xj_end_time"];
            var xiangmu = "";
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lit = user_selectBLL.XJ_Email_Rtn(xj_tal, xj_gonghao, xjjs_userid, xj_beizhu, xj_time, xiangmu, start_time, end_time);
            var obj = new
            {
                msg = "发送成功!",
                code = 200
            };
            if (!lit)
            {
                obj = new
                {
                    msg = "发送失败!",
                    code = 202
                };
            }
            string rs = js.Serialize(obj);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();
        }
        //以上 请假申请相关代码

        //页面显示-----------------------------
        
        //考勤统计
        private void KaoQin()
        {
            var userid = Convert.ToInt32(HttpContext.Current.Request["userid"]);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lis = Page_XianShiBLL.KaoQin(userid);
            string rs = js.Serialize(lis);
            HttpContext.Current.Response.Write(rs);
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