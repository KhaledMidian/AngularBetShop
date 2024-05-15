using AngularBetShop.DTOs;
using AngularBetShop.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularBetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        CartService _service;
        public CartController(CartService service)
        {
            this._service = service;
        }


        // GET: api/<CartController>
        [HttpGet]
        public ActionResult Get()
        {
            if (_service.GetAllCarts() != null) { return Ok(_service.GetAllCarts()); }
            return NotFound();
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (_service.GetCartById(id, "product") != null) { return Ok(_service.GetCartById(id, "product")); }
            return NotFound();
        }

        // POST api/<CartController>
        [HttpPost]
        public ActionResult Post(CartDTO cartDTO)
        {
            if (cartDTO != null)
            {
                _service.AddCart(cartDTO);
                return Ok(cartDTO);
            }
            else { return BadRequest(); }
        }

        // PUT api/<CartController>/5
        [HttpPut]
        public ActionResult Put(CartDTO cartDTO)
        {
            if (cartDTO != null && cartDTO.orderId !=null && cartDTO.productId != null)
            {
                _service.UpdateCart(cartDTO);
                return Ok(cartDTO);
            }
            else { return BadRequest(); }
        }

        // DELETE api/<CartController>/5
        [HttpDelete]
        public ActionResult Delete(CartDTO cartDTO)
        {
            if (cartDTO != null)
            {
                _service.DeleteCart(cartDTO);
                return Ok();
            }
            else { return BadRequest(); }
        }
    }
}
