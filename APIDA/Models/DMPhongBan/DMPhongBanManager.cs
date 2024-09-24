using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace APIPCHY.Models.DMPhongBan
{
    public class DMPhongBanManager
    {
        public List<DMPhongBan> GetPhongBanByDonVi(string donViId)
        {
            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand
                    {
                        Connection = cn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PKG_QLTN_TANH.get_DM_PHONGBAN_byDONVI"
                    };

                    cmd.Parameters.Add("p_DM_DONVI_ID", OracleDbType.Varchar2).Value = donViId ?? (object)DBNull.Value;
                    cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter dap = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dap.Fill(ds);

                    List<DMPhongBan> results = new List<DMPhongBan>();

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            DMPhongBan result = new DMPhongBan
                            {
                                ID = dr["ID"].ToString(),
                                TEN = dr["TEN"].ToString()
                            };
                            results.Add(result);
                        }
                    }

                    return results;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
