using AngularBetShop.DTOs;
using AngularBetShop.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularBetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService _service;
        public CategoryController(CategoryService service)
        {
            this._service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult Get()
        {
            if (_service.GetAllCategories() != null) { return Ok(_service.GetAllCategories()); }
            return NotFound();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (_service.GetCategoryById (id) != null) { return Ok(_service.GetCategoryById(id)); }
            return NotFound();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult Post(CategoryAddDTO categoryDTO)
        {
            if (categoryDTO != null)
            {
                _service.AddCategory(categoryDTO);
                return Ok(categoryDTO);
            }
            else { return BadRequest(); }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, CategoryDTO categoryDTO)
        {
            if (categoryDTO != null && categoryDTO.id==id && categoryDTO.id!=0 && id!=null)
            {
                _service.UpdateCategory(categoryDTO);
                return CreatedAtAction("Get", new { id = categoryDTO.id }, categoryDTO);
            }
            else { return BadRequest(); }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                _service.DeleteCategory(id);
                return Ok();
            }
            else { return BadRequest(); }


        }
    }
}
