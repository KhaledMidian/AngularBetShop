using AngularBetShop.DTOs;
using AngularBetShop.Models;
using AngularBetShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularBetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService _service;
        public ProductController(ProductService service)
        {
            this._service = service;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            if (_service.GetAllProducts() != null) { return Ok(_service.GetAllProducts()); }
            return NotFound();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (_service.GetProductById(id) != null) { return Ok(_service.GetProductById(id)); }
            return NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post(ProductAddDTO productDTO)
        {
            if (productDTO != null)
            {
                _service.AddProduct(productDTO);
                return Ok(productDTO);
            }
            else { return BadRequest(); }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id ,ProductDTO productDTO)
        {
            if (productDTO != null && productDTO.id==id && id!=0 && id!=null ) 
            {
                _service.UpdateProduct(productDTO);
                return CreatedAtAction("Get", new { id = productDTO.id }, productDTO);
            }
            else { return BadRequest(); }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                _service.DeleteProduct(id);
                return Ok();
            }
            else { return BadRequest(); }


        }
    }
}
