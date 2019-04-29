using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
namespace BLL.CX
{
   public class DepartMaintenanceBLL
    {
        public List<User> GetUser() {
            DAL.CX.DepartMaintenanceDAL dAL = new DAL.CX.DepartMaintenanceDAL();
           return  dAL.GetUsers();
        }
        public List<User> Depart_USERS()
        {
            DAL.CX.DepartMaintenanceDAL dAL = new DAL.CX.DepartMaintenanceDAL();
            return dAL.Depart_USER();
        }
    }
}
