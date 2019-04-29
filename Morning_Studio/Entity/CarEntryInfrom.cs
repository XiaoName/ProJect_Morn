using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{/// <summary>
/// 车辆信息录入表
/// </summary>
 public    class CarEntryInfrom
    {
        public int CarEntryID { get; set; }//ID
        public string CarNumber { get; set; }//车牌号
        public string ReservationCarBrand { get; set; }//车辆品牌
        public User CarBrand { get; set; }//持车人（外键）
        public Department DepartID { get; set; }//所属部门（外键）
        public string CarType { get; set; }//车辆类型
    }
}
