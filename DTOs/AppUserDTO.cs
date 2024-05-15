using AngularBetShop.Models;

namespace AngularBetShop.DTOs
{
    public class AppUserDTO
    {
        public AppUserDTO()
        {
            
        }
        public AppUserDTO(string _id, 
            string _userName, 
            string _email, 
            string _passwordHash, 
            string _phoneNumber)
        {
            this.id = _id;
            this.userName = _userName;
            
            this.email = _email;
            this.passwordHash= _passwordHash;
            this.phoneNumber = _phoneNumber;
        }
        public string id { get; set; }
        public string userName { get; set; }
        
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string phoneNumber { get; set; }
        public List<Order> orderList { get; set; }
        public List<Favorites> favoriteProducts { get; set; }
    }
}
