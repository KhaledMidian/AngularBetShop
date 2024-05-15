using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.Models
{
    public class Favorites
    {
        [ForeignKey("appUser")]
        public string appUserId { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        public AppUser appUser { get; set; }
        public Product product { get; set; }
    }
}
