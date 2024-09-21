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
                string connectionString = "User Id=QLTN;Password=QLTN;Data Source=117.0.33.2:1523/QLTN";
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
