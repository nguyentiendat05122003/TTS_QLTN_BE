using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System;
using System.Collections.Generic;

namespace APIPCHY.Models.HTQuyenNguoiDung
{
    public class QuyenNguoiDungManager
    {

        public List<HTQuyenNguoiDung> Get_QUYEN_NGUOIDUNG()
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<HTQuyenNguoiDung>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_TANH.get_QUYEN_NGUOIDUNG";
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<HTQuyenNguoiDung> result = new List<HTQuyenNguoiDung>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HTQuyenNguoiDung qnd = new HTQuyenNguoiDung
                    {
                        ID = int.Parse(dr["ID"]?.ToString()),
                        TenNguoiDung = dr["HO_TEN"]?.ToString(),   
                        TenDonVi = dr["TEN_DVIQLY"]?.ToString(),
                        TenNhom = dr["TEN_NHOM"]?.ToString(),
                    };

                    result.Add(qnd);

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public HTQuyenNguoiDung Insert_HT_QUYEN_NGUOIDUNG(HTQuyenNguoiDung qnd)
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
                cmd.CommandText = @"PKG_QLTN_TANH.grant_HT_QUYEN_NGUOIDUNG";
                cmd.Parameters.Add("p_MA_NGUOI_DUNG", qnd.MA_NGUOI_DUNG);
                cmd.Parameters.Add("p_NHOM_QUYEN_ID", qnd.MA_NHOM_TV);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();  
                transaction.Commit();
                return qnd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public HTQuyenNguoiDung Update_HT_QUYEN_NGUOIDUNG(HTQuyenNguoiDung quyen)
        {
            string strErr = "";
            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();

                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = cn;
                    using (OracleTransaction transaction = cn.BeginTransaction())
                    {
                        cmd.Transaction = transaction;

                        try
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = @"PKG_QLTN_TANH.update_HT_QUYEN_NGUOIDUNG";

                            cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = Convert.ToInt32(quyen.ID); // Chuyển đổi sang int
                            cmd.Parameters.Add("p_MA_NGUOI_DUNG", quyen.MA_NGUOI_DUNG);
                            cmd.Parameters.Add("p_NHOM_QUYEN_ID", quyen.MA_NHOM_TV);
                            cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return quyen; 
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Cập nhật quyền người dùng thất bại: " + ex.Message);
                        }
                    }
                }
            }
        }

        public void Delete_HT_QUYEN_NGUOIDUNG(int id)
        {
            string strErr = "";
            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleTransaction transaction = cn.BeginTransaction();
                cmd.Transaction = transaction;

                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"PKG_QLTN_TANH.delete_HT_QUYEN_NGUOIDUNG";

                    cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id;
                    cmd.Parameters.Add("p_Error", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex; // Hoặc xử lý lỗi theo cách bạn muốn
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
}
