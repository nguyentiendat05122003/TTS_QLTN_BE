using APIPCHY.Helpers;
using APIPCHY.Models.DMDViQL;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace APIPCHY.Models.HTNhomQuyen
{
    public class NhomQuyenManager
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
                        CommandText = "PKG_QLTN_TANH.get_DONVI_NHOMQUYEN"
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
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        public List<NhomQuyen> GET_NHOMQUYEN_BY_DVIQLY(string maDviqly)
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
                        CommandText = "PKG_QLTN_TANH.get_NHOMQUYEN_BY_DVIQLY"  
                    };

                    cmd.Parameters.Add("p_ma_dviqly", OracleDbType.Varchar2).Value = maDviqly;
                    cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter dap = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dap.Fill(ds);

                    List<NhomQuyen> results = new List<NhomQuyen>();

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            NhomQuyen result = new NhomQuyen
                            {
                                NHOM_ID = Convert.ToInt32(dr["NHOM_ID"]),
                                TEN_NHOM = dr["TEN_NHOM"].ToString()
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
