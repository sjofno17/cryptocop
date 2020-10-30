using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}

/*
LoginInputModel
• Email* (string)
• Must be a valid email address
• Password* (string)
• A minimum length of 8 characters 
*/