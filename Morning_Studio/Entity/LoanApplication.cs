using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 借款申请
    /// </summary>
   public class LoanApplication
    {
        public int LoanId { get; set; }//id
        public string Reason { get; set; }//类别  借款理由
        public string NUmbers { get; set; }//单号
        public decimal Borrowed { get; set; }//借款金额
        public string Customer { get; set; }//借款客户
        public string Explain { get; set; }//说明
        public int MethodID { get; set; }//支付方式
    }
}
