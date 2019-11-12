using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelClickBusinessEntities.Model;
using Dapper;


namespace TravelClickRAL
{
    public class db
    {

        public List<Database> GetAllDB()
        {
            List<Database> lstDB = new List<Database>();
            lstDB.Add(new Database() { DatabaseName = "db1", Id = 1 });
            lstDB.Add(new Database() { DatabaseName = "db2", Id = 2 });
            lstDB.Add(new Database() { DatabaseName = "db3", Id = 3 });
            return lstDB;
            //string strConnection = "";
            //using (SqlConnection con = new SqlConnection(strConnection))
            //{
            //    con.Open();
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.Connection = con;
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.CommandText = SpName.spGetDatabase;
            //        cmd.ExecuteReader();
            //    }
        }
        public IEnumerable<TableDetails> GetAllTableName(string type,string name)
        {
            List<TableDetails> lstTbl = new List<TableDetails>();
            Details d = new Details();
            d.table = null;
            d.view =null;
            d.column = null;
            if(type=="table")
            {
                d.table = name;
            }
            else if (type=="column")
            {
                d.column = name;
            }
            else if(type=="view")
            {
                d.view = name;
            }
            using (IDbConnection con = new SqlConnection("Data Source=SRVDSQL08\\SQL1602;Initial Catalog=APTIFY;uid = mtuser; password=m1nd$Tr3e1918"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ColumName", d.column);
                parameter.Add("@TableName", d.table);
                parameter.Add("@ViewName", d.view);
                parameter.Add("@SPName", null);
                return con.Query<TableDetails>("USP_GetAllDatabaseDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            //return lstTbl;
        }

        //public static IDbConnection conn()
        //{
        //    return (IDbConnection)new SqlConnection(
        //        "Data Source=.;Initial Catalog=master;Integrated Security=True");

        //}
    }
}
