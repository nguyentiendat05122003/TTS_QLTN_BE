using APIPCHY.Models.DMTruongYCTN;
using APIPCHY.Models.HTQuyenNguoiDung;
using APIPCHY.Models.NguoiKy;
using APIPCHY.Resources.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class QuyenNguoiDungController : ControllerBase
    {
        QuyenNguoiDungManager db = new QuyenNguoiDungManager();


        [HttpGet("get")]
        [AuthorizePermission(PermissionConstants.QUANLY_THANHVIEN, "VIEW")]
        //[AuthorizePermission("menu-1", "VIEW")]
        public IActionResult getData_QuyenNguoiDung()
        {
            return Ok(db.Get_QUYEN_NGUOIDUNG());
        }

        [HttpPost("create")]
        public void PostInsertQuyen([FromBody] HTQuyenNguoiDung quyen)
        {
            db.Insert_HT_QUYEN_NGUOIDUNG(quyen);
        }

        [HttpPatch("update")]
        public void UpdateQuyen([FromBody] HTQuyenNguoiDung quyen)
        {
            db.Update_HT_QUYEN_NGUOIDUNG(quyen);
        }

        [HttpGet("delete/{id}")]
        //[Authorize]
        public IActionResult DeleteQuyen(int id)
        {
            db.Delete_HT_QUYEN_NGUOIDUNG(id);
            return Ok("Xoa thanh cong");
        }

    }
}
