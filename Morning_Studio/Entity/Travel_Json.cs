using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class Travel_Json
    {
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Phone { get; set; }
        public string DataKs { get; set; }
        public string DataJs { get; set; }
        public string Place { get; set; }
        public int chengcheVal { get; set; }
        public string chengcheText { get; set; }
        public string Dep_txt { get; set; }
        public int selectVal { get; set; }
        public string selecttxt { get; set; }
        public string Dep_Person { get; set; }
        public string Person_Phone { get; set; }
        public string ccomPerson { get; set; }
        public string Reasons { get; set; }
    }
}
