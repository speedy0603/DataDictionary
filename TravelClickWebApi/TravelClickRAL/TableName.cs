using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelClickBusinessEntities.Model;

namespace TravelClickRAL
{
    public class TableName
    {
        public List<TableDetails> GetAllTableName()
        {
            List<TableDetails> lstTbl = new List<TableDetails>();
            //lstTbl.Add(new Table() { TableName = "Table1", DatabaseId = 1 });
            //lstTbl.Add(new Table() { TableName = "Table2", DatabaseId = 1 });
            //lstTbl.Add(new Table() { TableName = "Table3", DatabaseId = 1 });
            //lstTbl.Add(new Table() { TableName = "Table4", DatabaseId = 1 });
            return lstTbl;
        }
    }
}
