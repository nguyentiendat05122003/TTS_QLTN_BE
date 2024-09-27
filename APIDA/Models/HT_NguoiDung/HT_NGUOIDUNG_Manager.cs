using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System;
using System.Collections.Generic;

namespace APIPCHY.Models.HT_NguoiDung
{
    public class HT_NGUOIDUNG_Manager
    {
        public string Reset_Password_HT_NGUOIDUNG(string ID, string currentPassword, string newPassword)
        {
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                string hashedPasswordFromDB = Get_HT_NGUOIDUNG_Password(ID);
                if (!PasswordHasher.VerifyHashedString(hashedPasswordFromDB, currentPassword))
                {
                    return "Mật khẩu hiện tại không chính xác.";
                }

                string hashedNewPassword = PasswordHasher.HashString(newPassword);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.update_password_HT_NGUOIDUNG";
                cmd.Parameters.Add("p_USER_ID", ID);
                cmd.Parameters.Add("p_NEW_PASSWORD", hashedNewPassword);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();           
                transaction.Commit();
                return "Cập nhật mật khẩu thành công.";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"Có lỗi xảy ra: {ex.Message}";
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }


        public string Get_HT_NGUOIDUNG_Password(string ID)
        {
            string password = null;
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return null;
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = @"PKG_QLTN_TANH.get_HT_NGUOIDUNG_byID";
                cmd.Parameters.Add("p_ID", ID);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                Console.WriteLine(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    password = ds.Tables[0].Rows[0]["MAT_KHAU"].ToString();
                }
                return password; 
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

    }
}
