using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL.CX
{
    public class OlineBLL
    {
        public List<User> OnlineUser()
        {
            DAL.CX.OnlineDAL online = new DAL.CX.OnlineDAL();
            return online.OnlineUser();
        }
    }
}
