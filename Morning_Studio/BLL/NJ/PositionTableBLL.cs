using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
   public class PositionTableBLL
    {
        public List<PositionTable> GetPositions(string s)
        {
            DAL.PositionTableDAL positionTable = new PositionTableDAL();
            return positionTable.posi(s);
        }
    }
}
