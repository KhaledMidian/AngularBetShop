using System.ComponentModel.DataAnnotations;

namespace AngularBetShop.DTOs
{
    public class logInDTO
    {
        [MinLength(8, ErrorMessage = "User Name has to be 8 charecters")]
        public string userName { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool remember { get; set; }
    }
}
