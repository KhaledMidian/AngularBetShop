using AngularBetShop.Models;
using NuGet.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AngularBetShop.DTOs
{
    public class AppUserAddDTO
    {
        public AppUserAddDTO()
        {
            
        }
        public AppUserAddDTO(
            string _userName, 
            string _email, 
            string _password,
            string _confirmedPassword,
            string _phoneNumber,
            string _address)
        {
            this.userName = _userName;
            this.email = _email;
            this.password= _password;
            this.confirmedPassword = _confirmedPassword;
            this.phoneNumber = _phoneNumber;
            this.address = _address;

        }
        [MinLength(8, ErrorMessage = "User Name has to be 8 charecters")]
        public string userName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        [Compare("password", ErrorMessage ="Confirmed Password has to be identical to Password")]
        [DataType(DataType.Password)]
        public string confirmedPassword { get; set; }

        [DataType(DataType.Text)]
        public string address { get; set; }
        
           }
}
