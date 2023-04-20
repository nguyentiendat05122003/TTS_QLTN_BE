using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
namespace APIPCHY.Models
{
    public class CategoryManager
    {
        //
        public List<Category> GetAllCategory()
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                //cn.ReturnError(strErr);
                return new List<Category>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"Select * from FL_CATEGORY";
                //cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<Category> result = new List<Category>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Category ac = new Category();
                    ac.CategoryId = int.Parse(dr["CategoryId"].ToString());
                    ac.CategoryName = dr["CategoryName"].ToString();
                    
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
        //
    }
}
