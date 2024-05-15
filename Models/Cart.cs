using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.Models
{
    public class Cart
    {
        public int? quantity { get; set; }
        public decimal? subPrice { get; set;}

        [ForeignKey("product")]
        public int productId { get; set; }
        public Product product { get; set; }

        [ForeignKey("order")]
        public int orderId { get; set; }

        public Order order { get; set; }
    }
}
