using AngularBetShop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularBetShop.DTOs
{
    public class OrderDOT
    {
        public OrderDOT()
        {
            
        }
        public OrderDOT(
            int id,
            int? quantity,
            char state,
            decimal? totalPrice,
            DateTime? checkOutDate,
            string appUserId
           
            )
        {
            this.id = id;
            this.quantity = quantity;
            this.state = state;
            this.totalPrice = totalPrice;
            this.checkOutDate = checkOutDate;
            this.appUserId = appUserId;
            
        }
        public int id { get; set; }
        public int? quantity { get; set; }
        public char state { get; set; }
        public decimal? totalPrice { get; set; }
        public DateTime? checkOutDate { get; set; }
        public string appUserId { get; set; }
    }
}
