using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System;

namespace APIPCHY.Models.ChiTietYCTN
{
    public class ChiTietYCTNManager
    {
        public ChiTietYCTN Insert_QLTN_CHI_TIET_THI_NGHIEM(ChiTietYCTN pr)
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
                cmd.CommandText = @"PKG_QLTN_DAT.insert_QLTN_CHI_TIET_THI_NGHIEM";
                cmd.Parameters.Add("p_MA_TBTN", pr.MA_TBTN);
                cmd.Parameters.Add("p_SO_LUONG", pr.SO_LUONG);
                cmd.Parameters.Add("p_MA_LOAI_BB", pr.MA_LOAI_BB);
                cmd.Parameters.Add("p_MA_YCTN", pr.MA_YCTN);
                cmd.Parameters.Add("p_FILE_UPLOAD", pr.FILE_UPLOAD);
                cmd.Parameters.Add("p_NGAY_TT_TN", pr.NGAY_TT_TN);
                cmd.Parameters.Add("p_LANTHU", pr.LANTHU);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
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

        public ChiTietYCTN Update_QLTN_CHI_TIET_THI_NGHIEM(ChiTietYCTN pr)
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
                cmd.CommandText = @"PKG_QLTN_DAT.update_QLTN_CHI_TIET_THI_NGHIEM";
                cmd.Parameters.Add("p_MA_CHI_TIET_TN", pr.MA_CHI_TIET_TN);
                cmd.Parameters.Add("p_SO_LUONG", pr.SO_LUONG);
                cmd.Parameters.Add("p_MA_LOAI_BB", pr.MA_LOAI_BB);
                cmd.Parameters.Add("p_FILE_UPLOAD", pr.FILE_UPLOAD);
                cmd.Parameters.Add("p_NGAY_TT_TN", pr.NGAY_TT_TN);
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

        public void Delete_QLTN_CHI_TIET_THI_NGHIEM(string ID)
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
                cmd.CommandText = @"PKG_QLTN_DAT.delete_QLTN_CHI_TIET_THI_NGHIEM";
                cmd.Parameters.Add("p_MA_CHI_TIET_TN", ID);
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
