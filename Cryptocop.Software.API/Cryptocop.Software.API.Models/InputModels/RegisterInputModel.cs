using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        public string FullName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [MinLength(8)]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}

/*
RegisterInputModel
• Email* (string) => Must be a valid email address
• FullName* (string) => A minimum length of 3 characters
• Password* (string) => A minimum length of 8 characters
• PasswordConfirmation* (string) => A minimum length of 8 characters => Must be the same value as the property Password
*/