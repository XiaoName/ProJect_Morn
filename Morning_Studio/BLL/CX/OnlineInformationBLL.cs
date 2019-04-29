using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL.CX
{
  public  class OnlineInformationBLL
    {
        public List<User> GetUsers(string a, string b, string c)
        {
            if (a == "请选择")
            {
                a = "";
            }
            if (c == "0")
            {
                c = "";
            }
            DAL.CX.OlineInformationDAL information = new DAL.CX.OlineInformationDAL();
            return information.GetUsers(a, b, c);
        }

    }
}
