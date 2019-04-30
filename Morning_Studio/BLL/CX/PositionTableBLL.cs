using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL.CX
{
   public class PositionTableBLL
    {
        public List<PositionTable> GetPositions(string s)
        {
            DAL.PositionTableDAL positionTable = new PositionTableDAL();
            return positionTable.posi(s);
        }
        public List<User> Number(string s)
        {
            DAL.CX.PositionTableDAL position = new DAL.CX.PositionTableDAL();
            return position.Number(s);
        }

        public List<User> Name(string s)
        {
            DAL.CX.PositionTableDAL position = new DAL.CX.PositionTableDAL();
            return position.Name(s);
        }
        public List<User> Names(string s)
        {
            DAL.CX.PositionTableDAL position = new DAL.CX.PositionTableDAL();
            return position.Names(s);
        }
    }
}
