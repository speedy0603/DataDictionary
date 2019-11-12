using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelClickBusinessEntities.Model;

namespace TravelClickBusinessLayer
{
    public class TravelClickBL
    {
        public List<Database> GetAllDatabase()
        {
            return new TravelClickRAL.db().GetAllDB();
        }
        public IEnumerable<TableDetails> GetAllTable(string type,string name)
        {
            return new TravelClickRAL.db().GetAllTableName(type,name);
        }
    }
}
