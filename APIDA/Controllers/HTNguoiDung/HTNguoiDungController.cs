using Microsoft.AspNetCore.Mvc; 
using APIPCHY.Models.HTNguoiDung;
using APIPCHY.Services;
using System.Collections.Generic;
using System;
using APIPCHY.Models.NguoiKy;
using System.Runtime.Intrinsics.Arm;
using APIPCHY.Models.HTQuyenNguoiDung;

namespace APIPCHY.Controllers.HTNguoiDung
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class HTNguoiDungController : ControllerBase
    {
        HTNguoiDungManager _userService = new HTNguoiDungManager();

        [HttpPost("get")]
        public IActionResult GET_HT_NGUOIDUNG([FromBody] Dictionary<string, string> formData)
        {
            try
            {
                long total = 0;

                if (formData == null || !formData.ContainsKey("pageIndex") || !formData.ContainsKey("pageSize"))
                {
                    return BadRequest("Invalid request data. pageIndex and pageSize are required.");
                }
                if (!int.TryParse(formData["pageIndex"], out int pageIndex) ||
                    !int.TryParse(formData["pageSize"], out int pageSize))
                {
                    return BadRequest("Invalid pageIndex or pageSize format.");
                }

                var data = _userService.GET_HT_NGUOIDUNG(pageIndex, pageSize, out total);

                var result = new
                {
                    page = pageIndex,
                    Total = total,
                    PageSize = pageSize,
                    Data = data
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"ERROR: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetNguoiDungById(string id)
        {
            try
            {
                var nguoiDung = _userService.GETDATA_DM_NGUOIDUNG_byID(id);
                if (nguoiDung == null)
                {
                    return NotFound($"Không tìm thấy người dùng với ID: {id}");
                }
                return Ok(nguoiDung);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }


        [HttpPost("create")]
        public IActionResult PostInsertNguoiDung([FromBody] HTNguoiDungDTO nd)
        {
             var result = _userService.Insert_QLTN_NGUOI_DUNG(nd);

             return Ok(new { message = "Thêm người dùng thanh công", data = result });
           

        }

        [HttpPatch("update")]
        public void UpdateQuyen([FromBody] HTNguoiDungDTO nd)
        {
            _userService.Update_HT_NGUOIDUNG(nd);
        }

        //[HttpPost("search")]
        //public IActionResult FilterUsers([FromBody] UserFilterRequest request)
        //{
        //    try
        //    {
        //        List<UserResponse> users = _userService.FILTER_HT_NGUOIDUNG(request);
        //        return Ok(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpPost("search")]
        public IActionResult FilterUsers([FromBody] UserFilterRequest request)
        {
            try
            {
                // Gọi phương thức FILTER_HT_NGUOIDUNG từ service
                int totalRecords;
                List<UserResponse> users = _userService.FILTER_HT_NGUOIDUNG(request, out totalRecords);

                // Tính tổng số trang
                int totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

                // Tạo đối tượng ẩn danh để trả về
                var result = new
                {
                    page = request.PageNumber,
                    TotalRecords = totalRecords,
                    TotalPages = totalPages,
                    PageSize = request.PageSize,
                    Data = users
                };

                return Ok(result); // Trả về kết quả với mã trạng thái 200
            }
            catch (Exception ex)
            {
                // Trả về mã lỗi 500 và thông điệp lỗi
                return StatusCode(500, ex.Message);
            }
        }
    }
}
