using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelClickBusinessEntities.Model
{
    public class TableDetails
    {
        //public string TableName { get; set; }
        //public int? DatabaseId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Datatype { get; set; }
        public string Description { get; set; }
        public string nvarcharSize { get; set; }
        public string AllowNulls { get; set; }
        public string Constraints { get; set; }
        public string IsIdentity { get; set; }
        public string ReferenceTable { get; set; }

    }
}
