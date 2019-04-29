using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 车辆日常事务处理
    /// </summary>
    public class DailyTransactionCar
    {
        public int TransactCarID { get; set; }//ID
        public int TransactCarNumber { get; set; }//车牌号
        public string TransactCarBrand { get; set; }//车辆品牌
        public string TransactLastTime { get; set; }//上次维修时间
        public string TransactLastMaintenanceTime { get; set; }//上次保养时间
    }
}
