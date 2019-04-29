using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 车辆预定表
    /// </summary>
    public class CarReservation
    {
        public int ReservationCarID { get; set; }//车辆id
        public int ReservationCarNumber { get; set; }//车牌号
        public string ReservationCarBrand { get; set; }//车辆品牌
        public User UserId { get; set; }//用车人（外键）
        public Department DepartID { get; set; }//用车部门（外键）
        public string ReservationBeginTime { get; set; }//开始时间
        public string ReservationEndTime { get; set; }//结束时间
        public User ApproverID { get; set; }//审批人（外键）
        public string ReservationParkingLot { get; set; }//停车场车位
        public string ReservationReason { get; set; }//事由
        public string ReservationRemarks { get; set; }//备注
    }
}
