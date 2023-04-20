using System.Linq;
using System.Web;
//using Oracle.DataAccess.Client;
using System.Data;
using System.Text;
//using System.Data.OracleClient;
using System;
//using System.ServiceModel.Web;
using System.Collections.Generic;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;

namespace APIPCHY.Models
{
    public class AccountManage
    {

        //private clsConnect.GetConnect connection;
        //public LienHeManager(clsConnect.GetConnect connection)
        //{
        //    this.connection = connection;
        //}
        public OracleConnection getConnection()
        {
            try
            {
                string connectionString = "User Id=KPI0404;Password=kpi;Data Source=10.47.0.14:1521/cmis2";
                //OracleConnection cn = connection.ConnectDB(ref strErr);
                OracleConnection connection = new OracleConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //clsConnect.GetConnect conn = new clsConnect.GetConnect();
        //WebOperationContext webContext = WebOperationContext.Current;

        //public void InsertAccount(Account account)
        //{
        //    string strErr = "";
        //    OracleConnection connection = getConnection();
        //    connection.Open();
        //    if (strErr != null && strErr != "")
        //    {
        //        //connection.ReturnError(strErr);
        //        return;
        //    }
        //    OracleCommand cmd = new OracleCommand();
        //    cmd.Connection = connection;
        //    OracleTransaction transaction;
        //    //transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
        //    transaction = connection.BeginTransaction();
        //    cmd.Transaction = transaction;
        //    try
        //    {
        //        #region bảng DANHBA
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = @"Select * from ";
        //        cmd.Parameters.Add("P_NAME", lienhe.name);
        //        cmd.Parameters.Add("P_DONVI", lienhe.donvi);
        //        cmd.Parameters.Add("P_SODIENTHOAI", lienhe.sodienthoai);
        //        cmd.Parameters.Add("P_ANHDAIDIEN", lienhe.anhdaidien);
        //        cmd.Parameters.Add("P_ERROR", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
        //        cmd.ExecuteNonQuery();
        //        if (cmd.Parameters["P_ERROR"].Value.ToString().Trim().Length > 0)
        //        {
        //            strErr += "Có lỗi xảy ra với name: " + lienhe.name + ". Hãy kiểm tra lại!" +
        //                "\n" + "(" + cmd.Parameters["P_ERROR"].Value.ToString().Trim() + ")";
        //        }
        //        if (strErr.Trim().Length > 0)
        //            //Co loi, return loi
        //            //return connection.ReturnError(strErr);
        //            return;
        //        #endregion
        //        transaction.Commit();
        //        //return;
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        //return conn.ReturnError(ex.Message);
        //        //WebOperationContext webContext = WebOperationContext.Current;
        //        // webContext.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
        //    }
        //    finally
        //    {
        //        if (connection.State != ConnectionState.Closed)
        //        {
        //            connection.Close();
        //        }
        //    }


        //}
        /*
        public void UpdateLienHe(LienHe lienhe)
        {
            string strErr = "";

            OracleConnection cn = connection.ConnectDB(ref strErr);
            if (strErr != null && strErr != "")
            {
                connection.ReturnError(strErr);
                //return connection.ReturnError(strErr);
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            //transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                #region bảng DANHBA
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_DANHBA.updateDANH_BA";
                cmd.Parameters.AddWithValue("P_ID", lienhe.id);
                cmd.Parameters.AddWithValue("P_NAME", lienhe.name);
                cmd.Parameters.AddWithValue("P_DONVI", lienhe.donvi);
                cmd.Parameters.AddWithValue("P_SODIENTHOAI", lienhe.sodienthoai);
                cmd.Parameters.AddWithValue("P_ANHDAIDIEN", lienhe.anhdaidien);
                cmd.Parameters.Add("P_ERROR", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["P_ERROR"].Value.ToString().Trim().Length > 0)
                {
                    strErr += "Có lỗi xảy ra với name: " + lienhe.name + ". Hãy kiểm tra lại!" +
                        "\n" + "(" + cmd.Parameters["P_ERROR"].Value.ToString().Trim() + ")";
                }
                if (strErr.Trim().Length > 0)
                    //Co loi, return loi
                    //return connection.ReturnError(strErr);
                    return;
                #endregion
                transaction.Commit();
                //return;
                WebOperationContext webContext = WebOperationContext.Current;
                webContext.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                //return conn.ReturnError(ex.Message);
                WebOperationContext webContext = WebOperationContext.Current;
                webContext.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }


        }
        public void DeleteLienHe(int lienHeId)
        {
            string strErr = "";
            OracleConnection cn = getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            //transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                #region bảng DANHBA
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_DANHBA.deleteDANH_BA";
                cmd.Parameters.Add("P_ID", lienHeId);
                cmd.Parameters.Add("P_ERROR", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["P_ERROR"].Value.ToString().Trim().Length > 0)
                {
                    strErr += "Có lỗi xảy ra với name: " + lienHeId + ". Hãy kiểm tra lại!" +
                        "\n" + "(" + cmd.Parameters["P_ERROR"].Value.ToString().Trim() + ")";
                }
                if (strErr.Trim().Length > 0)
                    //Co loi, return loi
                    //return connection.ReturnError(strErr);
                    return;
                #endregion
                transaction.Commit();
                //return;
                WebOperationContext webContext = WebOperationContext.Current;
                webContext.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                WebOperationContext webContext = WebOperationContext.Current;
                webContext.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }


        }
        */

        public Account getLogin(string username,string password)
        {
            string strErr = "";
            OracleConnection cn = getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return null;
            }

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleDataAdapter dap = new OracleDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Select * from FL_Account where Username='{0}' and Password='{1}'",username,password);
            //cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            dap.SelectCommand = cmd;
            DataTable ds = new DataTable();
            dap.Fill(ds);
            Account ac = new Account();
            if (ds.Rows.Count>0)
            {
                DataRow dr = ds.Rows[0];
                ac.AccountId = dr["AccountId"].ToString();
                ac.Username = dr["Username"].ToString();
                ac.FullName = dr["FullName"].ToString();
                ac.Email = dr["Email"].ToString();
                ac.Password = dr["Password"].ToString();
                return ac;
            }
            else
            {
                return null;
            }
                  
            
        }
        public List<Account> ListAccount()
        {
            string strErr = "";
            OracleConnection cn = getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return new List<Account>();
            }

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleDataAdapter dap = new OracleDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"Select * from FL_Account";
            //cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            dap.SelectCommand = cmd;
            DataSet ds = new DataSet();
            dap.Fill(ds);

            List<Account> result = new List<Account>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Account ac = new Account();
                ac.AccountId = dr["AccountId"].ToString();
                ac.Username = dr["Username"].ToString();
                ac.FullName = dr["FullName"].ToString();
                ac.Email = dr["Email"].ToString();
                ac.Password = dr["Password"].ToString();
               
                result.Add(ac);
            }
            return result;
        }

    }
}
