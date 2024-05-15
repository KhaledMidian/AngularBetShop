using AngularBetShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.DTOs
{
    public class ProductAddDTO
    {
        public ProductAddDTO()
        {
            
        }
        public ProductAddDTO(
            
            string name,
            string? description,
            decimal price,
            double? rating,
            int quantity,
            int categoryId,
            string? image
            )
        {
            
            this.name = name;
            this.description = description;
            this.price = price;
            this.rating = rating;
            this.quantity = quantity;
            this.categoryId = categoryId;
            this.image = image;
        }
        
        public string name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public double? rating { get; set; }
        public int quantity { get; set; }
        public int categoryId { get; set; }
        public string? image { get; set; }

    }
}
