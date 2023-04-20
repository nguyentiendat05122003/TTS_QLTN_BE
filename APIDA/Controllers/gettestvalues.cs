using Microsoft.AspNetCore.Mvc;
using APIPCHY.Models.Test;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPCHY.Controllers
{
   
    [Route("APIPCHY/getLienHe")]
    [ApiController]
    public class gettestvalues : ControllerBase
    {
        // GET: api/<gettestvalues>
        //không qua token
        [HttpGet]
        public IActionResult Get()
        {
            try
            {                
                LienHeManager lh = new LienHeManager();
                OracleConnection cn = lh.getConnection();
                cn.Open();               
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
                cn.Close();
                return Ok(result);
            }
            catch
            {
                //LogException(e);
                return StatusCode(500);
            }
            
        }

        //có qua token
        [HttpGet("getData")]
        [Authorize]
        public IActionResult Get1()
        {
            try
            {
                LienHeManager lh = new LienHeManager();
                OracleConnection cn = lh.getConnection();
                cn.Open();
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
                cn.Close();
                return Ok(result);
            }
            catch
            {
                //LogException(e);
                return StatusCode(500);
            }

        }
        // GET api/<gettestvalues>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<gettestvalues>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<gettestvalues>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<gettestvalues>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
