using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
   public class User
    {
        public int UserID { get; set; }//ID
        public int JobNumber { get; set; }//工号
        public string Name { get; set; }//姓名
        public string YGcard { get; set; }//员工卡号
        public string Passwored { get; set; }//密码
        public Department Departmentid { get; set; }//部门id
        public PositionTable Dutyud { get; set; }//职务ID
        public string Sex { get; set; }//性别
        public string Email { get; set; }//邮箱
        public string Address { get; set; }//地址
        public string Account { get; set; }//户口
        public string Brithday { get; set; }//出生日期
        public string IdCard { get; set; }//身份证
        public string Dimission { get; set; }//离职日期
        public GZstateld GZstateId { get; set; }//工作状态
        public string WorkStart { get; set; }//开始时间
        public string Phone { get; set; }//电话
        public string PhysicalDeletion { get; set; }//是否删除
        public int count { get; set; }//统计人数
    }
}
