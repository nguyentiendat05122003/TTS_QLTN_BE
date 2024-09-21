using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace APIPCHY.Models.ThietBiYCTN
{
    public class ThietBiYCTNManager
    {
        public List<ThietBiYCTN> Get_THIET_BI_YCTN_ByMaYCTN(string MA_YCTN_ID)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<ThietBiYCTN>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.get_QLTN_THIET_BI_ByMaYCTN";
                cmd.Parameters.Add("p_MA_YCTN", MA_YCTN_ID);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }

                List<ThietBiYCTN> result = new List<ThietBiYCTN>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ThietBiYCTN ac = new ThietBiYCTN();
                    ac.MA_TBTN = dr["MA_TBTN"].ToString();
                    ac.TEN_THIET_BI = dr["TEN_THIET_BI"].ToString();
                    ac.TEN_LOAI_TB = dr["TEN_LOAI_TB"].ToString();
                    ac.MA_LOAI_TB = dr["MA_LOAI_TB"].ToString();
                    ac.SO_LUONG =Convert.ToInt32(dr["SO_LUONG"].ToString());
                    result.Add(ac);
                }
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
        public List<ThietBiYCTN> Get_THIET_BI_PS_YCTN_ByMaYCTN(string MA_YCTN_ID)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<ThietBiYCTN>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.get_QLTN_THIET_BI_PS_ByMaYCTN";
                cmd.Parameters.Add("p_MA_YCTN", MA_YCTN_ID);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
                List<ThietBiYCTN> result = new List<ThietBiYCTN>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ThietBiYCTN ac = new ThietBiYCTN();
                    ac.MA_TBTN = dr["MA_TBTN"].ToString();
                    ac.TEN_THIET_BI = dr["TEN_THIET_BI"].ToString();
                    ac.TEN_LOAI_TB = dr["TEN_LOAI_TB"].ToString();
                    ac.MA_LOAI_TB = dr["MA_LOAI_TB"].ToString();
                    ac.SO_LUONG = Convert.ToInt32(dr["SO_LUONG"].ToString());
                    result.Add(ac);
                }
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public ThietBiYCTN Insert_QLTN_THIET_BI_YCTN(ThietBiYCTN pr)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return null;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.insert_QLTN_THIET_BI_YCTN";
                cmd.Parameters.Add("p_MA_YCTN", pr.MA_YCTN);
                cmd.Parameters.Add("p_TEN_THIET_BI", pr.TEN_THIET_BI);
                cmd.Parameters.Add("p_MA_LOAI_TB", pr.MA_LOAI_TB);
                cmd.Parameters.Add("p_SO_LUONG", pr.SO_LUONG);
                cmd.Parameters.Add("p_TRANG_THAI", pr.TRANG_THAI);
                cmd.Parameters.Add("P_ERROR", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return pr;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return null;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

        }

        public void Delete_QLTN_THIET_BI_YCTN(string p_MA_TBTN)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.delete_QLTN_THIET_BI_YCTN";
                cmd.Parameters.Add("p_MA_TRUONG_YCTN", p_MA_TBTN);
                cmd.Parameters.Add("P_ERROR", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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
