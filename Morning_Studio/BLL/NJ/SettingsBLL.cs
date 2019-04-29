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
    public class SettingsBLL
    {
    /// <summary>
    /// 职位权限
    /// </summary>
    /// <returns></returns>
        public List<Position> GetPositions(string q)
        {
            DAL.NJ.SettingsDAL Settings = new DAL.NJ.SettingsDAL();
            return Settings.getposition(q);
        }
    }
}
