using APIPCHY.Models.DMTruongYCTN;
using APIPCHY.Models.YCTN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;


namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    public class YCTNController : Controller
    {
        YCTNManager db = new YCTNManager();
        [HttpGet("get")]
        [AllowAnonymous]
        [Authorize]
        public IActionResult getDataYCTN(
            string MA_LOAI_YCTN,
            string MA_KH,
            string MA_DVIQLY,
            int CRR_STEP,
            string TEXT_SEARCH)
        {
            return Ok(db.Get_YCTN(MA_LOAI_YCTN, MA_KH, MA_DVIQLY, CRR_STEP, TEXT_SEARCH));
        }


        [HttpGet("getDetail")]
        public IActionResult getDetailYCTN(
            string MA_YCTN)
        {
            return Ok(db.Get_YCTN_ByMaYCTN(MA_YCTN));
        }

        [HttpPost("create")]
        //[Authorize]
        public void InsertYCTN([FromBody] YCTN yctn)
        {
            db.Insert_YCTN(yctn);
        }

        [HttpPatch("updateNhiemVu")]
        //[Authorize]
        public IActionResult Update_NhiemVu_YCTN(string MA_YCTN, string FILE_GIAO_NV, string NGUOI_GIAO_NV, string NGAY_GIAO_NV, string DON_VI_THUCHIEN, int CRR_STEP, int NEXT_STEP)
        {
            db.Update_GIAO_NV_QLTN_YCTN(MA_YCTN,
            FILE_GIAO_NV,
            NGUOI_GIAO_NV,
            NGAY_GIAO_NV,
            DON_VI_THUCHIEN,
            CRR_STEP,
            NEXT_STEP);
            return Ok("Sua thanh cong");
        }

        [HttpPatch("updatePhuongAnThiCong")]
        //[Authorize]
        public IActionResult Update_PATC_YCTN(string MA_YCTN, string NGAY_KS_LAP_PATC, string FILE_PA_TC, string NGUOI_TH_KSPA_TC , int CRR_STEP, int NEXT_STEP)
        {
            db.Update_KS_PATC_QLTN_YCTN(MA_YCTN,
            NGAY_KS_LAP_PATC,
            FILE_PA_TC,
            NGUOI_TH_KSPA_TC,
            CRR_STEP,
            NEXT_STEP);
            return Ok("Sua thanh cong");
        }

        [HttpPatch("updateBanGiao")]
        //[Authorize]
        public IActionResult Update_BAN_GIAO_YCTN(string MA_YCTN, string NGUOI_BAN_GIAO, string DON_VI_NHAN_BAN_GIAO, string NGAY_BAN_GIAO, string GHI_CHU_BAN_GIAO, int CRR_STEP, int NEXT_STEP)
        {
            db.Update_BAN_GIAO_QLTN_YCTN(MA_YCTN,
            NGUOI_BAN_GIAO,
            DON_VI_NHAN_BAN_GIAO,
            NGAY_BAN_GIAO,
            GHI_CHU_BAN_GIAO,
            CRR_STEP,
            NEXT_STEP);
            return Ok("Sua thanh cong");
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult DeleteTRUONGYCTN(string id)
        {
            db.Delete_YCTN(id);
            return Ok("Xoa thanh cong");
        }
    }
}
