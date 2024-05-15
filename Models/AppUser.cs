using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularBetShop.Models
{
    public class AppUser:IdentityUser
    {
        public string address { get; set; }
        public List<Order> orderList { get; set; }
        public List<Favorites> favoriteProducts { get; set; }
    }
}
