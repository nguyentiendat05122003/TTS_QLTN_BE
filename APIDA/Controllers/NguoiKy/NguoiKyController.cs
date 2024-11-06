using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APIPCHY.Models.DMTruongYCTN;
using APIPCHY.Models.NguoiKy;
using System;
using APIPCHY.Resources.Constants;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]

    public class NguoiKyController : Controller
    {
        NguoiKyManager db = new NguoiKyManager();

        [HttpPost("create")]
        //[Authorize]
        public void PostInsertNguoiKy([FromBody] NguoiKy nguoiKy)
        {
            db.Insert_QLTN_NGUOI_KY(nguoiKy);
        }

        [HttpPatch("edit")]
        //[Authorize]
        public void UpdateNguoiKy([FromBody] NguoiKy nguoiKy)
        {
            db.Update_QLTN_NGUOI_KY(nguoiKy);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult DeleteNguoiKy(string id)
        {
            db.Delete_QLTN_NGUOI_KY(id);
            return Ok("Xoa thanh cong");
        }
    }
}
