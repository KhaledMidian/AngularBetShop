using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public double? rating { get; set; }
        public int quantity { get; set; }
        public string? image {  get; set; }

        [ForeignKey("category")]
        public int categoryId { get; set; }
        public Category category { get; set; }
        public List<Cart> carts { get; set; }
        public List<Favorites> favoriteCustomers { get; set; }

    }
}
