using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIPCHY.Models
{
    public class ProductManager
    {
        //lay tat ca
        public List<Product> GetListProduct()
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return new List<Product>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"Select * from FL_Product";
                //cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<Product> result = new List<Product>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Product ac = new Product();
                    ac.ProductId = dr["ProductId"].ToString();
                    ac.ProductName = dr["ProductName"].ToString();
                    ac.CategoryId = int.Parse(dr["CategoryId"].ToString());
                    ac.Picture = dr["Picture"].ToString();
                    ac.Price = double.Parse(dr["Price"].ToString());
                    ac.Note = dr["Note"].ToString();
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
        //lay theo productId
        public List<Product> GetListProductByID(string productId)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return new List<Product>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("Select * from FL_Product where productId='{0}' ", productId); 
                //cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<Product> result = new List<Product>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Product ac = new Product();
                    ac.ProductId = dr["ProductId"].ToString();
                    ac.ProductName = dr["ProductName"].ToString();
                    ac.CategoryId = int.Parse(dr["CategoryId"].ToString());
                    ac.Picture = dr["Picture"].ToString();
                    ac.Price = double.Parse(dr["Price"].ToString());
                    ac.Note = dr["Note"].ToString();
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
        //update FL_Product
        public void UpdateProduct(Product pr)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return; //new List<Product>();
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            //transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                
                #region bảng FL_Product
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                string query = string.Format("Update FL_Product set PRODUCTNAME='{0}'," +
                    " CATEGORYID='{1}',PRICE='{2}' where productId='{3}' ", pr.ProductName, pr.CategoryId, pr.Price, pr.ProductId);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                #endregion
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
        //them moi
        public Product InsertProduct(Product pr)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return null; //new List<Product>();
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            //transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
     
               
                #region bảng FL_Product
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                string sql= string.Format("Insert into FL_Product (CATEGORYID, NOTE, PICTURE,PRICE, PRODUCTID, PRODUCTNAME) VALUES ('{0}'," +
                    " '{1}','{2}','{3}','{4}','{5}' )", pr.CategoryId, pr.Note, pr.Picture, pr.Price, pr.ProductId, pr.ProductName);
                //if (strErr.Trim().Length > 0)
                cmd.CommandText = sql;
                //Co loi, return loi
                //return connection.ReturnError(strErr);
                //return;
                cmd.ExecuteNonQuery();
                #endregion
                transaction.Commit();
                return pr;
                //return;
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
        //
        public void DeleteProduct(String id)
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
            //transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {

                
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                string query = string.Format("Delete FL_Product where PRODUCTID='{0}'", id);
                cmd.CommandText = query;
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
        //
    }
}
