using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
   public class DepartBLL
    {
        /// <summary>
        /// 部门
        /// </summary>
        /// <returns></returns>
        public List<Department> getDepart()
        {
            DepartDAL depart = new DepartDAL();
            depart.getDepart();
            return depart.getDepart();
        }
    }
}
