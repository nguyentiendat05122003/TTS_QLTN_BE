using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APIPCHY.Models.ChiTietYCTN;
using System;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]

    public class ChiTietYCTNController : Controller
    {
        ChiTietYCTNManager db = new ChiTietYCTNManager();

        [HttpPost("create")]
        //[Authorize]
        public void Insert_CHITIET_YCTN([FromBody] ChiTietYCTN chitiet)
        {
            db.Insert_QLTN_CHI_TIET_THI_NGHIEM(chitiet);
        }


        [HttpPatch("update")]
        //[Authorize]
        public void Update_CHITIET_YCTN([FromBody] ChiTietYCTN chitiet)
        {
            db.Update_QLTN_CHI_TIET_THI_NGHIEM(chitiet);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete_CHITIET_YCTN(string id)
        {
            db.Delete_QLTN_CHI_TIET_THI_NGHIEM(id);
            return Ok("Xoa thanh cong");
        }
    }
}
