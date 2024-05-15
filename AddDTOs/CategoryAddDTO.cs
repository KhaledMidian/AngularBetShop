using AngularBetShop.Models;

namespace AngularBetShop.DTOs
{
    public class CategoryAddDTO
    {
        public CategoryAddDTO()
        {
            
        }
        public CategoryAddDTO(
            
            string name
            )
        {
            this.name = name;
            
        }
        public string name { get; set; }
    }
}
