using Microsoft.AspNetCore.Mvc;
using APIPCHY.Models.DMDViQL;
using APIPCHY.Models.HTNhomQuyen;
using System.Collections.Generic;
using System;

namespace APIPCHY.Controllers.HTNhomQuyen
{
    [ApiController]
    [Route("APIPCHY/[controller]")]
    public class HTNhomQuyenController : ControllerBase
    {
        NhomQuyenManager _nhomquyen = new NhomQuyenManager();

        [HttpGet("donvi-quanly")]
        public ActionResult<List<DM_DVIQL>> GetDonViQuanLy()
        {
            try
            {
                var donviList = _nhomquyen.GET_DONVI_QUANLY();
                return Ok(donviList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("nhomquyen/{maDviqly}")]
        public ActionResult<List<NhomQuyen>> GetNhomQuyenByDviqly(string maDviqly)
        {
            try
            {
                var nhomList = _nhomquyen.GET_NHOMQUYEN_BY_DVIQLY(maDviqly);
                if (nhomList == null || nhomList.Count == 0)
                {
                    return NotFound("KHONG TIM THAY DC CHUA");
                }
                return Ok(nhomList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
