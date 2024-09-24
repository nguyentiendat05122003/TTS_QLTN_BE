using Microsoft.AspNetCore.Mvc; 
using APIPCHY.Models.HTNguoiDung;
using APIPCHY.Services;
using System.Collections.Generic;
using System;

namespace APIPCHY.Controllers.HTNguoiDung
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class HTNguoiDungController : ControllerBase
    {
        HTNguoiDungManager _userService = new HTNguoiDungManager();
        [HttpPost("search")]
        public IActionResult FilterUsers([FromBody] UserFilterRequest request)
        {
            try
            {
                List<UserResponse> users = _userService.FILTER_HT_NGUOIDUNG(request);
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception (có thể sử dụng logging framework)
                return StatusCode(500, ex.Message);
            }
        }
    }
}
