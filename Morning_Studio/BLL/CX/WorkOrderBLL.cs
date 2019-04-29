using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;

namespace BLL
{
    public class WorkOrderBLL
    {
        private static DAL.WorkOrderDAL r = new DAL.WorkOrderDAL();
        /// <summary>
      /// 责任人查询
      /// </summary>
      /// <returns></returns>
        public List<User> getUser()
        {
            return r.getUser();
        }

        /// <summary>
        /// 创建工作单多条件查询
        /// </summary>
        /// <returns></returns>
        public List<WorkSheet> GetWorkSelect(string number, string TaskName)
        {
            if (number == "" &&TaskName == "") {
                return r.getCha();
             }
            return r.GetWorkSelect(number,TaskName);
         
         
        }

            /// <summary>
            /// 工作单创建修改按钮
            /// </summary>
            /// <returns></returns>
            public bool Work_Update(WorkSheet workSheet)
        {           
                var a = r.Work_Update(workSheet);
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }

        /// <summary>
        /// 工作单创建明细加载数据库
        /// </summary>
        /// <returns></returns>
        public List<WorkSheet> getCha()
        {
            return r.getCha();
        }

        /// <summary>
        /// 工作单申请保存按钮
        /// </summary>
        /// <returns></returns>
        public bool Worksqing_Baoc(WorkSheet workSheet)
        {
            return r.Worksqing_baoc(workSheet);

        }
        /// <summary>
        /// 工作单处理保存按钮
        /// </summary>
        /// <returns></returns>
        public bool WorkProcess_Baoc(WorkSheet workSheet)
        {
            return r.WorkProcess_baoc(workSheet);
        }

        public WorkSheet Upate_gaCha_Bll(int id) {
            return r.Upate_getCha(id);
        }
    }
}
