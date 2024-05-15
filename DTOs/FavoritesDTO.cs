using AngularBetShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.DTOs
{
    public class FavoritesDTO
    {
        public FavoritesDTO()
        {
            
        }
        public FavoritesDTO(
            string appUserId,
            int productId
           
            )
        {
            this.productId = productId;
            this.appUserId = appUserId;
           
        }
        public string appUserId { get; set; }
        public int productId { get; set; }
       
    }
}
