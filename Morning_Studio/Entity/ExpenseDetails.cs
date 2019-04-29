using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{/// <summary>
/// 费用明细
/// </summary>
 public    class ExpenseDetails
    {
        public int ExpenseID { get; set; }//ID
        public string CostType { get; set; }//费用类型（差旅费）
        public string SmallTypeCost { get; set; }//费用小类型（交通费)
        public string EntryTime { get; set; }//录入时间
        public decimal EntryTotalAmount { get; set; }//录入总金额
        public string EntryReaon { get; set; }//录入事由
        public decimal EntryMoneyTax { get; set; }//录入税后金额

    }
}
