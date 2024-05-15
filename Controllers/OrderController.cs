using AngularBetShop.DTOs;
using AngularBetShop.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularBetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService _service;
        public OrderController(OrderService service)
        {
            this._service = service;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult Get()
        {
            if (_service.GetAllOrders() != null) { return Ok(_service.GetAllOrders()); }
            return NotFound();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (_service.GetOrderById(id) != null) { return Ok(_service.GetOrderById(id)); }
            return NotFound();
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post(OrderAddDOT orderDTO)
        {
            if (orderDTO != null)
            {
                _service.AddOrder(orderDTO);
                return Ok(orderDTO);
            }
            else { return BadRequest(); }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, OrderDOT orderDTO)
        {
            if (orderDTO != null && orderDTO.id == id && id != 0 && id != null)
            {
                _service.UpdateOrder(orderDTO);
                return CreatedAtAction("Get", new { id = orderDTO.id }, orderDTO);
            }
            else { return BadRequest(); }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                _service.DeleteOrder(id);
                return Ok();
            }
            else { return BadRequest(); }


        }
    }
}
