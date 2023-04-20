using APIPCHY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryManager db = new CategoryManager();
        // GET: api/<CategoryController>
        //khong qua token - lay het du lieu
        [AllowAnonymous]
        [HttpGet("getall")]
        //[Authorize]
        public IActionResult getData2()
        {
            return Ok(db.GetAllCategory());
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //khong qua token - lay het du lieu
        //[AllowAnonymous]
        [HttpGet("getCategory")]
        [Authorize]
        public IActionResult getData()
        {
            return Ok(db.GetAllCategory());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
