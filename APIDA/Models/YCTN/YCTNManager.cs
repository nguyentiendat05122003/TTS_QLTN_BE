using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System;
using System.Collections.Generic;

namespace APIPCHY.Models.YCTN
{
    public class YCTNManager
    {
        public List<YCTN> Get_YCTN(string MA_LOAI_YCTN, string MA_KH,string MA_DVIQLY,int CRR_STEP,string TEXT_SEARCH)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<YCTN>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.get_QLTN_YCTN";
                cmd.Parameters.Add("p_MA_LOAI_YCTN", MA_LOAI_YCTN);
                cmd.Parameters.Add("p_MA_KH", MA_KH);
                cmd.Parameters.Add("p_MA_DVIQLY", MA_DVIQLY);
                cmd.Parameters.Add("p_CRR_STEP", 1);
                cmd.Parameters.Add("p_text_search", TEXT_SEARCH);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                Console.WriteLine(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
                List<YCTN> result = new List<YCTN>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    YCTN ac = new YCTN();
                    ac.MA_YCTN = dr["MA_YCTN"].ToString();
                    ac.TEN_YCTN = dr["TEN_YCTN"].ToString();
                    ac.NGAY_TAO =DateTime.Parse(dr["NGAY_TAO"].ToString());
                    ac.CRR_STEP_NAME = dr["CRR_STEP_NAME"].ToString();
                    ac.NEXT_STEP_NAME = dr["NEXT_STEP_NAME"].ToString();
                    ac.TEN_LOAI_YCTN = dr["TEN_LOAI_YCTN"].ToString();
                    ac.TEN_DON_VI_THUC_HIEN = dr["TEN_DON_VI_THUC_HIEN"].ToString();
                    ac.GIA_TRI_DU_TOAN_SAU_THUE = dr["GIA_TRI_DU_TOAN_SAU_THUE"].ToString();
                    ac.TEN_KHACH_HANG = dr["TEN_KHACH_HANG"].ToString();
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

        public List<YCTN> Get_YCTN_ByMaYCTN(string MA_YCTN)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<YCTN>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.get_QLTN_YCTN_ByMaYCTN";
                cmd.Parameters.Add("p_MA_YCTN", MA_YCTN);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                Console.WriteLine(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
                List<YCTN> result = new List<YCTN>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    YCTN ac = new YCTN();
                    ac.MA_YCTN = dr["MA_YCTN"].ToString();
                    ac.TEN_YCTN = dr["TEN_YCTN"].ToString();
                    ac.FILE_UPLOAD = dr["FILE_UPLOAD"].ToString();
                    ac.FILE_GIAO_NV = dr["FILE_GIAO_NV"].ToString();
                    ac.NGUOI_GIAO_NV = dr["NGUOI_GIAO_NV"].ToString();
                    ac.NGAY_GIAO_NV = DateTime.Parse(dr["NGAY_GIAO_NV"].ToString());
                    ac.DON_VI_THUCHIEN = dr["DON_VI_THUCHIEN"].ToString();
                    ac.NGAY_KS_LAP_PATC = DateTime.Parse(dr["NGAY_KS_LAP_PATC"].ToString());
                    ac.FILE_PA_TC = dr["FILE_PA_TC"].ToString();
                    ac.NGUOI_TH_KSPA_TC = dr["NGUOI_TH_KSPA_TC"].ToString();
                    ac.DON_VI_NHAN_BAN_GIAO = dr["DON_VI_NHAN_BAN_GIAO"].ToString();
                    ac.NGUOI_BAN_GIAO = dr["NGUOI_BAN_GIAO"].ToString();
                    ac.NGAY_BAN_GIAO = dr["NGAY_BAN_GIAO"] != DBNull.Value ? DateTime.Parse(dr["NGAY_BAN_GIAO"].ToString()) : DateTime.MinValue;
                    ac.GHI_CHU_BAN_GIAO = dr["GHI_CHU_BAN_GIAO"].ToString();
                    ac.MA_LOAI_TS = dr["MA_LOAI_TS"].ToString();
                    ac.TEN_LTS = dr["TEN_LTS"].ToString();
                    ac.TRUONG_GIA_TRI = dr["TRUONG_GIA_TRI"].ToString();
                    ac.NGAY_TAO = DateTime.Parse(dr["NGAY_TAO"].ToString());
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
        public YCTN Insert_YCTN(YCTN pr)
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
                cmd.CommandText = @"PKG_QLTN_DAT.insert_QLTN_YCTN";
                cmd.Parameters.Add("p_TEN_YCTN", pr.TEN_YCTN);
                cmd.Parameters.Add("p_MA_LOAI_YCTN", pr.MA_LOAI_YCTN);
                cmd.Parameters.Add("p_MA_LOAI_TS", pr.MA_LOAI_TS);
                cmd.Parameters.Add("p_FILE_UPLOAD", pr.FILE_UPLOAD);
                cmd.Parameters.Add("p_MA_KH", pr.MA_KH);
                cmd.Parameters.Add("p_NOI_DUNG", pr.NOI_DUNG);
                cmd.Parameters.Add("p_NGAY_XAY_RA_SU_CO", pr.NGAY_XAY_RA_SU_CO);
                cmd.Parameters.Add("p_NGAY_KI_HOP_DONG", pr.NGAY_KI_HOP_DONG);
                cmd.Parameters.Add("p_GIA_TRI_DU_TOAN_TRUOC_THUE", pr.GIA_TRI_DU_TOAN_TRUOC_THUE);
                cmd.Parameters.Add("p_PHAN_TRAM_TRIET_GIAM", pr.PHAN_TRAM_TRIET_GIAM);
                cmd.Parameters.Add("p_GIA_TRI_TRIET_GIAM", pr.GIA_TRI_TRIET_GIAM);
                cmd.Parameters.Add("p_GIA_TRI_SAU_TRIET_GIAM", pr.GIA_TRI_SAU_TRIET_GIAM);
                cmd.Parameters.Add("p_PHAN_TRAM_THUE",pr.PHAN_TRAM_THUE);
                cmd.Parameters.Add("p_THUE",pr.THUE);
                cmd.Parameters.Add("p_GIA_TRI_DU_TOAN_SAU_THUE",pr.GIA_TRI_DU_TOAN_SAU_THUE);
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

        public void Update_GIAO_NV_QLTN_YCTN (string MA_YCTN, string FILE_GIAO_NV, string NGUOI_GIAO_NV, string NGAY_GIAO_NV, string DON_VI_THUCHIEN, int CRR_STEP, int NEXT_STEP)
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
                cmd.CommandText = @"PKG_QLTN_DAT.update_GIAO_NV_QLTN_YCTN";
                cmd.Parameters.Add("p_MA_YCTN", MA_YCTN);
                cmd.Parameters.Add("p_FILE_GIAO_NV", FILE_GIAO_NV);
                cmd.Parameters.Add("p_NGUOI_GIAO_NV", NGUOI_GIAO_NV);
                cmd.Parameters.Add("p_NGAY_GIAO_NV", NGAY_GIAO_NV);
                cmd.Parameters.Add("p_DON_VI_THUCHIEN", DON_VI_THUCHIEN);
                cmd.Parameters.Add("p_CRR_STEP", CRR_STEP);
                cmd.Parameters.Add("p_NEXT_STEP", NEXT_STEP);
                cmd.Parameters.Add("P_ERROR", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return ;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public void Update_KS_PATC_QLTN_YCTN(string MA_YCTN, string NGAY_KS_LAP_PATC, string FILE_PA_TC, string NGUOI_TH_KSPA_TC, int CRR_STEP, int NEXT_STEP)
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
                cmd.CommandText = @"PKG_QLTN_DAT.update_KS_PATC_QLTN_YCTN";
                cmd.Parameters.Add("p_MA_YCTN", MA_YCTN);
                cmd.Parameters.Add("p_NGAY_KS_LAP_PATC", NGAY_KS_LAP_PATC);
                cmd.Parameters.Add("p_FILE_PA_TC", FILE_PA_TC);
                cmd.Parameters.Add("p_NGUOI_TH_KSPA_TC", NGUOI_TH_KSPA_TC);
                cmd.Parameters.Add("p_CRR_STEP", CRR_STEP);
                cmd.Parameters.Add("p_NEXT_STEP", NEXT_STEP);
                cmd.Parameters.Add("P_ERROR", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }


        public void Update_BAN_GIAO_QLTN_YCTN(string MA_YCTN, string NGUOI_BAN_GIAO, string DON_VI_NHAN_BAN_GIAO, string NGAY_BAN_GIAO,string GHI_CHU_BAN_GIAO, int CRR_STEP, int NEXT_STEP)
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
                cmd.CommandText = @"PKG_QLTN_DAT.update_KS_PATC_QLTN_YCTN";
                cmd.Parameters.Add("p_MA_YCTN", MA_YCTN);
                cmd.Parameters.Add("p_NGUOI_BAN_GIAO", NGUOI_BAN_GIAO);
                cmd.Parameters.Add("p_DON_VI_NHAN_BAN_GIAO", DON_VI_NHAN_BAN_GIAO);
                cmd.Parameters.Add("p_NGAY_BAN_GIAO", NGAY_BAN_GIAO);
                cmd.Parameters.Add("p_GHI_CHU_BAN_GIAO", GHI_CHU_BAN_GIAO);
                cmd.Parameters.Add("p_CRR_STEP", CRR_STEP);
                cmd.Parameters.Add("p_NEXT_STEP", NEXT_STEP);
                cmd.Parameters.Add("P_ERROR", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public void Delete_YCTN(string MA_YCTN)
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
                cmd.CommandText = @"PKG_QLTN_DAT.delete_QLTN_YCTN";
                cmd.Parameters.Add("p_MA_YCTN", MA_YCTN);
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
