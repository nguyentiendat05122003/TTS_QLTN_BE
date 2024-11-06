using APIPCHY.Models.DMTruongYCTN;
using APIPCHY.Models.HT_NguoiDung;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIPCHY.Controllers.HT_NguoiDung
{
    [Route("APIPCHY/[controller]")]

    public class HT_NguoiDungController : Controller
    {
        HT_NGUOIDUNG_Manager db = new HT_NGUOIDUNG_Manager();
        [HttpPost("resetPassword")]
        //[AllowAnonymous]
        //[Authorize]
        public IActionResult Reset_Password_HT_NGUOIDUNG(string ID,string currentPassword,string newPassword)
        {
            string resultMessage = db.Reset_Password_HT_NGUOIDUNG(ID, currentPassword, newPassword);
            if (resultMessage == "Mật khẩu hiện tại không chính xác.")
            {
                return Unauthorized(new { message = resultMessage });
            }

            return Ok(new { message = resultMessage });
        }
    }
}
