using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL.NJ
{
    /// <summary>
    /// 员工类型
    /// </summary>
    public class GZstateldBLL
    {
        public List<GZstateld> GetGZstatelds()
        {
            DAL.NJ.GZstateldDAL gZstateld = new DAL.NJ.GZstateldDAL();
            return gZstateld.gettatelds();
        }
    }
}
