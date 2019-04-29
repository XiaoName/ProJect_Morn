using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL.NJ
{
   public class InformationBLL
    {
        public List<User> GetUsers(string a,string b,string c)
        {
            if (a=="请选择")
            {
                a = "";
            }
            if (c=="0")
            {
                c = "";
            }
            DAL.NJ.InformationDAL information = new DAL.NJ.InformationDAL();
            return information.GetUsers(a, b,c);
        }

    }
}
