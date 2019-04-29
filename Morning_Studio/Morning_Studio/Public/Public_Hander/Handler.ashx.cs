using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using Morning_Studio;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.Text;
using BLL;
using BLL.YYW;
namespace Morning_Studio.Public.Public_Hander
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request["act"];
            switch (act)
            {
                case "login":
                    this.Login();
                    break;
                case "menu_select":
                    Memu_Two_Select();
                    break;
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        private void Login()
        {
            string name = HttpContext.Current.Request.Form["JobNumber"];                 
            string pwd = HttpContext.Current.Request.Form["Passwored"]; 
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lst = BLL.LoginBLL.Login(name, pwd);                  
            string rs = js.Serialize(lst);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();           
        }

        /// <summary>
        /// 第二级菜单个数查询
        /// </summary>
        private void Memu_Two_Select()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var lst = Menu_SelectBLL.Menu_Select();
            string rs = js.Serialize(lst);
            HttpContext.Current.Response.Write(rs);
            HttpContext.Current.Response.End();

        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input">需要加密的明文</param>
        /// <returns></returns>
        private static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
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