using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace APIPCHY.Helpers
{
    public class ConnectionOracle
    {
        public OracleConnection getConnection()
        {
            try
            {
                string connectionString = "User Id=KPI0404;Password=kpi;Data Source=10.47.0.14:1521/cmis2";
                //OracleConnection cn = connection.ConnectDB(ref strErr);
                OracleConnection connection = new OracleConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
