using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;

namespace BLL.NJ
{
   public class Dep_StatisticsBLL
    {
        /// <summary>
        /// 查询部门人数
        /// </summary>
        /// <returns></returns>
        public List<User> getDepCount(string q,string w,string r)
        {
            if (q=="0")
            {
                q = "";
            }
            DAL.NJ.Dep_StatisticsDAL dep_ = new DAL.NJ.Dep_StatisticsDAL();
            return dep_.getDepCount(q,w,r);
        }
    }
}
