using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace APIPCHY.Models.DMDViQL
{
    public class DM_DVIQL_Manager
    {
        public List<DM_DVIQL> GET_DONVI_QUANLY()
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
                        CommandText = "PKG_QLTN_TANH.get_all_DM_DVQLY"
                    };

                    cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter dap = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dap.Fill(ds);

                    List<DM_DVIQL> results = new List<DM_DVIQL>();

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            DM_DVIQL result = new DM_DVIQL
                            {
                                MA_DVIQLY = dr["MA_DVIQLY"].ToString(),
                                TEN_DVIQLY = dr["TEN_DVIQLY"].ToString()
                            };
                            results.Add(result);
                        }
                    }

                    return results;
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        public List<DM_DVIQL> GetDonViByMaDviQL(string maDviQL)
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
                        CommandText = "PKG_QLTN_TANH.get_DM_DONVI_byDVQL"
                    };

                    cmd.Parameters.Add("p_MA_DVIQLY", OracleDbType.Varchar2).Value = maDviQL ?? (object)DBNull.Value;
                    cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter dap = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dap.Fill(ds);

                    List<DM_DVIQL> results = new List<DM_DVIQL>();

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            DM_DVIQL result = new DM_DVIQL
                            {
                                MA_DVIQLY = dr["ID"].ToString(),
                                TEN_DVIQLY = dr["TEN"].ToString()
                            };
                            results.Add(result);
                        }
                    }

                    return results;
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }

        }
    }
}
