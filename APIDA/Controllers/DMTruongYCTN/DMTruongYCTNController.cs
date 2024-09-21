using APIPCHY.Models.DMTruongYCTN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    public class DMTruongYCTNController : Controller
    {
        DMTruongYCTNManager db = new DMTruongYCTNManager();
        [HttpGet("getDMTruongYCTN")]
        [AllowAnonymous]
        [Authorize]
        public IActionResult getDataDMTruongYCTN(string ID_Ma_Loai_YCTN)
        {
            return Ok(db.Get_DM_TRUONG_YCTN_ByMaLoaiYCTN(ID_Ma_Loai_YCTN));
        }


        [HttpPost("create")]
        //[Authorize]
        public void PostInsertTRUONGYCTN([FromBody] DMTruongYCTN truongYCTN)
        {
            db.Insert_DM_TRUONG_YCTN(truongYCTN);
        }

        [HttpPatch("edit")]
        //[Authorize]
        public void UpdateTRUONGYCTN([FromBody] DMTruongYCTN truongYCTN)
        {
            db.Update_DM_TRUONG_YCTN(truongYCTN);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult DeleteTRUONGYCTN(string id)
        {
            Console.WriteLine(id);
            db.Delete_DM_TRUONG_YCTN(id);
            return Ok("Xoa thanh cong");
        }
    }
}
