using Microsoft.AspNetCore.Mvc;
using APIPCHY.Models.ThietBiYCTN;
using Microsoft.AspNetCore.Authorization;

using System;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    public class ThieiBiYCTNController : Controller
    {
        ThietBiYCTNManager db= new ThietBiYCTNManager();
        [HttpGet("getthietbi")]
        [AllowAnonymous]
        [Authorize]
        public IActionResult getDsThietBiYCTN(string MA_YCTN)
        {
            return Ok(db.Get_THIET_BI_YCTN_ByMaYCTN(MA_YCTN));
        }

        [HttpGet("getthietbiPS")]
        [AllowAnonymous]
        [Authorize]
        public IActionResult getDsThietBiPSYCTN(string MA_YCTN)
        {
            return Ok(db.Get_THIET_BI_PS_YCTN_ByMaYCTN(MA_YCTN));
        }

        [HttpPost("create")]
        //[Authorize]
        public void InsertYCTN([FromBody] ThietBiYCTN tb)
        {
            db.Insert_QLTN_THIET_BI_YCTN(tb);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult DeleteThietBiYCTN(string id)
        {
            db.Delete_QLTN_THIET_BI_YCTN(id);
            return Ok("Xoa thanh cong");
        }
    }
}
