using APIPCHY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPCHY.Controllers
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductManager db = new ProductManager();
        //lay toan bo Product ko qua token
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //db.getConnection();
            return db.GetListProduct();
        }
        //khong qua token - lay het du lieu
        [AllowAnonymous]
        [HttpGet("getall")]
        //[Authorize]
        public IActionResult getData()
        {
            return Ok(db.GetListProduct());
        }
        //khong qua token - lay theo dieu kien productID
        [AllowAnonymous]
        [HttpGet("{productID}", Name = "ShowProduct")]
        // [HttpGet("Show/{id}")]
        public IActionResult show(string productID)
        {
            return new JsonResult(db.GetListProductByID(productID));
        }
        //update qua token
        [HttpPost("update")]
        [Authorize]
        public void PostUpdateProduct(Product product)
        {
             db.UpdateProduct(product);
        }
        //them moi
        [HttpPost("themmoi")]
        [Authorize]
        public void PostInsertProduct(Product product)
        {
            db.InsertProduct(product);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteProduct(string id)
        {
            db.DeleteProduct(id);
            return Ok("Xoa thanh cong");
        }

        [HttpGet("Delete/{id}")]
        [Authorize]
        public IActionResult DeleteProduct2(string id)
        {
            db.DeleteProduct(id);
            return Ok("Xoa thanh cong");
        }

    }
}
