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

namespace APIPCHY.Models.Test
{
    public class LienHeManager
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
                string connectionString = "User Id=mobile01;Password=mobile01;Data Source=10.47.0.16:1522/mobile";
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
        
        public void InsertLienHe(LienHe lienhe)
        {
            string strErr = "";
            OracleConnection connection = getConnection();
            connection.Open();           
            if (strErr != null && strErr != "")
            {
                //connection.ReturnError(strErr);
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            OracleTransaction transaction;
            //transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                #region bảng DANHBA
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_DANHBA.insertDANHBA";
                cmd.Parameters.Add("P_NAME", lienhe.name);
                cmd.Parameters.Add("P_DONVI", lienhe.donvi);
                cmd.Parameters.Add("P_SODIENTHOAI", lienhe.sodienthoai);
                cmd.Parameters.Add("P_ANHDAIDIEN", lienhe.anhdaidien);
                cmd.Parameters.Add("P_ERROR", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
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
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                //return conn.ReturnError(ex.Message);
                //WebOperationContext webContext = WebOperationContext.Current;
               // webContext.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }


        }
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
        public List<LienHe> ListLienHe()
        {
            string strErr = "";
            OracleConnection cn = getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return new List<LienHe>();
            }

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleDataAdapter dap = new OracleDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = @"PKG_DANHBA.getDanhBa";
            cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            dap.SelectCommand = cmd;
            DataSet ds = new DataSet();
            dap.Fill(ds);

            List<LienHe> result = new List<LienHe>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LienHe lienhe = new LienHe();
                lienhe.id = int.Parse(dr["id"].ToString());
                lienhe.name = dr["name"].ToString();
                lienhe.sodienthoai = dr["sodienthoai"].ToString();
                lienhe.donvi = dr["donvi"].ToString();
                lienhe.anhdaidien = dr["anhdaidien"].ToString();
                result.Add(lienhe);
            }
            return result;
        }
        
    }
}
