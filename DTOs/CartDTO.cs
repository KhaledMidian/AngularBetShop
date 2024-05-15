using AngularBetShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.DTOs
{
    public class CartDTO
    {
        public CartDTO()
        {
            
        }
        public CartDTO(
            int? quantity,
            decimal? subPrice,
            int productId,
            int orderId)
        {
            this.quantity = quantity;
            this.subPrice = subPrice;
            this.productId = productId;
            this.orderId = orderId;
        }
        public int? quantity { get; set; }
        public decimal? subPrice { get; set; }
        public int productId { get; set; }
        public int orderId { get; set; }
    }
}
