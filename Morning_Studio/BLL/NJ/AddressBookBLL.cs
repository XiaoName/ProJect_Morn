using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL.NJ
{
    public class AddressBookBLL
    {
        public List<User> GetUsers(string a, string b)
        {
            if (b== "请选择...")
            {
                b = "";
            }
            DAL.NJ.AddressBookDAL add = new DAL.NJ.AddressBookDAL();
            return add.GetUsers(a, b);
        }
    }
}
