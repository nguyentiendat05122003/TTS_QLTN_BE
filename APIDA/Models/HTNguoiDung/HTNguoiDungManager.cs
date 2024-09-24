using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace APIPCHY.Models.HTNguoiDung
{
    public class HTNguoiDungManager
    {
        public List<UserResponse> FILTER_HT_NGUOIDUNG(UserFilterRequest request)
        {
            OracleConnection cn = new ConnectionOracle().getConnection();
            try
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_QLTN_TANH.search_HT_NGUOIDUNG";

                // Add input parameters with checks for null or empty
                cmd.Parameters.Add("p_HO_TEN", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.HO_TEN) ? (object)DBNull.Value : request.HO_TEN;
                cmd.Parameters.Add("p_TEN_DANG_NHAP", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.TEN_DANG_NHAP) ? (object)DBNull.Value : request.TEN_DANG_NHAP;
                cmd.Parameters.Add("p_TRANG_THAI", OracleDbType.Int32).Value = request.TRANG_THAI.HasValue ? (object)request.TRANG_THAI.Value : DBNull.Value;
                cmd.Parameters.Add("p_DM_DONVI_ID", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.DM_DONVI_ID) ? (object)DBNull.Value : request.DM_DONVI_ID;
                cmd.Parameters.Add("p_DM_PHONGBAN_ID", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.DM_PHONGBAN_ID) ? (object)DBNull.Value : request.DM_PHONGBAN_ID;
                cmd.Parameters.Add("p_DM_CHUCVU_ID", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.DM_CHUCVU_ID) ? (object)DBNull.Value : request.DM_CHUCVU_ID;

                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter dap = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                dap.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    List<UserResponse> results = new List<UserResponse>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UserResponse result = new UserResponse
                        {
                            HO_TEN = dr["HO_TEN"] != DBNull.Value ? dr["HO_TEN"].ToString() : null,
                            TEN_DANG_NHAP = dr["TEN_DANG_NHAP"] != DBNull.Value ? dr["TEN_DANG_NHAP"].ToString() : null,
                            TRANG_THAI = dr["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI"]) : 0, 
                            TEN_DONVI = dr["TEN_DONVI"] != DBNull.Value ? dr["TEN_DONVI"].ToString() : null,
                            TEN_PHONGBAN = dr["TEN_PHONGBAN"] != DBNull.Value ? dr["TEN_PHONGBAN"].ToString() : null,
                            TEN_CHUCVU = dr["TEN_CHUCVU"] != DBNull.Value ? dr["TEN_CHUCVU"].ToString() : null,
                            EMAIL = dr["EMAIL"] != DBNull.Value ? dr["EMAIL"].ToString() : null,
                        };
                        results.Add(result);
                    }
                    return results;
                }
                else
                {
                    return new List<UserResponse>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
    }
}
