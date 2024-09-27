using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using APIPCHY.Models.DMDViQL;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class DM_DVIQL_Controller : ControllerBase
    {
        DM_DVIQL_Manager _dm = new DM_DVIQL_Manager();

        [HttpGet("getAll")]
        public ActionResult<List<DM_DVIQL>> GetDonViQL()
        {
            try
            {
                var result = _dm.GET_DONVI_QUANLY();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet("getByMaDviQL/{maDviQL}")]
        public ActionResult<List<DM_DVIQL>> GetByMaDviQL(string maDviQL)
        {
            try
            {
                var result = _dm.GetDonViByMaDviQL(maDviQL);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
