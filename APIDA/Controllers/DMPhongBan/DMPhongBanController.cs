using APIPCHY.Models.DMPhongBan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class DMPhongBanController : ControllerBase
    {
        DMPhongBanManager _pb = new DMPhongBanManager();

        [HttpGet("getByDonVi/{donViId}")]
        public ActionResult<List<DMPhongBan>> GetByDonVi(string donViId)
        {
            try
            {
                var result = _pb.GetPhongBanByDonVi(donViId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
