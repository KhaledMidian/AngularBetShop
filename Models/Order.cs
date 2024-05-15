using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int? quantity { get; set; }
        public char state { get; set; }
        public decimal? totalPrice { get; set; }
        public DateTime? checkOutDate { get; set; }

        [ForeignKey("appUser")]
        public string appUserId { get; set;}
        public AppUser appUser { get; set;}
        public List<Cart> carts { get; set;}
    }
}
