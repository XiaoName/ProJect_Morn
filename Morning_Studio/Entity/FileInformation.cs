using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class FileInformation
    {
        public int FileId { get; set; }//ID
        public string FileName { get; set; }//文件名称
        public User UserId { get; set; }//用户ID
        public string FileReamrks { get; set; }//文件信息备注
        public string FileCreatTime { get; set; }//创建时间
        public string FillePath { get; set; }//文件路径
        public char FileDelete { get; set; }//是否删除

    }
}
