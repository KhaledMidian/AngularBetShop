using AngularBetShop.DTOs;
using AngularBetShop.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularBetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        FavoritesSevice _service;
        public FavoritesController(FavoritesSevice service)
        {
            this._service = service;
        }


        // GET: api/<FavoritesController>
        [HttpGet]
        public ActionResult Get()
        {
            if (_service.GetAllFavoritess() != null) { return Ok(_service.GetAllFavoritess()); }
            return NotFound();
        }

        // GET api/<FavoritesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            if (_service.GetFavoritesById(id, "product") != null) { return Ok(_service.GetFavoritesById(id, "product")); }
            return NotFound();
        }

        // POST api/<FavoritesController>
        [HttpPost]
        public ActionResult Post(FavoritesDTO FavoritesDTO)
        {
            if (FavoritesDTO != null)
            {
                _service.AddFavorites(FavoritesDTO);
                return Ok(FavoritesDTO);
            }
            else { return BadRequest(); }
        }

        // PUT api/<FavoritesController>/5
        [HttpPut]
        public ActionResult Put(FavoritesDTO FavoritesDTO)
        {
            if (FavoritesDTO != null && FavoritesDTO.appUserId != null && FavoritesDTO.productId != null)
            {
                _service.UpdateFavorites(FavoritesDTO);
                return Ok(FavoritesDTO);
            }
            else { return BadRequest(); }
        }

        // DELETE api/<FavoritesController>/5
        [HttpDelete]
        public ActionResult Delete(FavoritesDTO FavoritesDTO)
        {
            if (FavoritesDTO != null)
            {
                _service.DeleteFavorites(FavoritesDTO);
                return Ok();
            }
            else { return BadRequest(); }
        }
    }
}
