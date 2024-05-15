using AngularBetShop.Models;

namespace AngularBetShop.DTOs
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            
        }
        public CategoryDTO(
            int id,
            string name
            )
        {
            this.id = id;
            this.name = name;
            
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}
