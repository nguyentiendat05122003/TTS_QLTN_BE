using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace APIPCHY.Models.DMTruongYCTN
{
    public class DMTruongYCTNManager
    {
        public List<DMTruongYCTN> Get_DM_TRUONG_YCTN_ByMaLoaiYCTN(string MA_LOAI_YCTN_ID)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<DMTruongYCTN>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = @"PKG_QLTN_DAT.get_DM_TRUONG_YCTN_ByMaLoaiYCTN";
                cmd.Parameters.Add("p_Ma_Loai_YCTN", MA_LOAI_YCTN_ID);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
                List<DMTruongYCTN> result = new List<DMTruongYCTN>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DMTruongYCTN ac = new DMTruongYCTN();
                    ac.MA_TRUONG_YCTN = dr["MA_TRUONG_YCTN"].ToString();
                    ac.TEN_TRUONG = dr["TEN_TRUONG"].ToString();
                    ac.GHI_CHU = dr["GHI_CHU"].ToString();
                    ac.LOAI = dr["LOAI"].ToString();
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

        public DMTruongYCTN Insert_DM_TRUONG_YCTN(DMTruongYCTN pr)
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
                cmd.CommandText = @"PKG_QLTN_DAT.insert_DM_TRUONG_YCTN";
                cmd.Parameters.Add("p_TEN_TRUONG", pr.TEN_TRUONG);
                cmd.Parameters.Add("p_MA_LOAI_YCTN", pr.MA_LOAI_YCTN);
                cmd.Parameters.Add("p_GHI_CHU", pr.GHI_CHU);
                cmd.Parameters.Add("p_LOAI", pr.LOAI);
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

        public void Delete_DM_TRUONG_YCTN(string idTruong)
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
                cmd.CommandText = @"PKG_QLTN_DAT.delete_DM_TRUONG_YCTN";
                cmd.Parameters.Add("p_MA_TRUONG_YCTN", idTruong);
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


        public DMTruongYCTN Update_DM_TRUONG_YCTN(DMTruongYCTN pr)
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
                cmd.CommandText = @"PKG_QLTN_DAT.update_DM_TRUONG_YCTN";
                cmd.Parameters.Add("p_MA_TRUONG_YCTN", pr.MA_TRUONG_YCTN);
                cmd.Parameters.Add("p_TEN_TRUONG", pr.TEN_TRUONG);
                cmd.Parameters.Add("p_MA_LOAI_YCTN", pr.MA_LOAI_YCTN);
                cmd.Parameters.Add("p_GHI_CHU", pr.GHI_CHU);
                cmd.Parameters.Add("p_LOAI", pr.LOAI);
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
    }
}
