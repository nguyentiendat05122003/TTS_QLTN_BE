using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System;

namespace APIPCHY.Models.NguoiKy
{
    public class NguoiKyManager
    {
        public NguoiKy Insert_QLTN_NGUOI_KY(NguoiKy pr)
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
                cmd.CommandText = @"PKG_QLTN_DAT.insert_QLTN_NGUOI_KY";
                cmd.Parameters.Add("p_NHOM_NGUOI_KY", pr.NHOM_NGUOI_KY);
                cmd.Parameters.Add("p_MA_CHI_TIET_TN", pr.MA_CHI_TIET_TN);
                cmd.Parameters.Add("p_ID_NGUOI_KY", pr.ID_NGUOI_KY);
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

        public NguoiKy Update_QLTN_NGUOI_KY(NguoiKy pr)
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
                cmd.CommandText = @"PKG_QLTN_DAT.update_QLTN_NGUOI_KY";
                cmd.Parameters.Add("p_ID", pr.ID);
                cmd.Parameters.Add("p_TRANG_THAI_KY", pr.TRANG_THAI_KY);
                cmd.Parameters.Add("p_NHOM_NGUOI_KY", pr.NHOM_NGUOI_KY);
                cmd.Parameters.Add("p_LYDO_TUCHOI", pr.LYDO_TUCHOI);
                cmd.Parameters.Add("p_ID_NGUOI_KY", pr.ID_NGUOI_KY);
                cmd.Parameters.Add("p_THOI_GIAN_KY", pr.THOI_GIAN_KY);
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

        public void Delete_QLTN_NGUOI_KY(string p_MA_NGUOI_KY)
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
                cmd.CommandText = @"PKG_QLTN_DAT.delete_QLTN_NGUOI_KY";
                cmd.Parameters.Add("p_MA_NGUOI_KY", p_MA_NGUOI_KY);
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
