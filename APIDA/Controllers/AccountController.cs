using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPCHY.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountManage db = new AccountManage();
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            db.getConnection();
            return db.ListAccount();
        }
        IConfiguration config;
        public AccountController(IConfiguration config)
        {
            // this.db = db;
            this.config = config;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel model)
        {
            //mã hóa password thành chuỗi MD5
            var password_md5 = GenerateMD5(model.Password);
            //lấy người dùng trong db
            var user = db.getLogin(model.Username,password_md5);//db.Accounts.FirstOrDefault(x => x.Username == model.Username && x.Password == password_md5);
            //nếu tồn tại thì xử lý sing token
            if (user != null)
            {
                //lấy key trong file cấu hình
                var key = config["Jwt:Key"];
                //mã hóa ky
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                //ký vào key đã mã hóa
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                //tạo claims chứa thông tin người dùng (nếu cần)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Name,model.Username),
                    new Claim(ClaimTypes.MobilePhone,"0961902588"),
                    new Claim(ClaimTypes.Country,"Vietnam"),
                };
                //tạo token với các thông số khớp với cấu hình trong startup để validate
                //biến token và cấu tạo thời gian của token
                var token = new JwtSecurityToken
                    (
                        issuer: config["Jwt:Issuer"],
                        audience: config["Jwt:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredential,
                        claims: claims
                    );
                //sinh ra chuỗi token với các thông số ở trên
                var token1 = new JwtSecurityTokenHandler().WriteToken(token);
                //trả về kết quả cho client username và chuỗi token
                return new JsonResult(new { username = model.Username, token = token1 });
            }
            //trả về lỗi
            return new JsonResult(new { message = "Đăng nhập sai" });
        }
        //hàm mã hóa 1 chuỗi sử dụng MD5
        private string GenerateMD5(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
