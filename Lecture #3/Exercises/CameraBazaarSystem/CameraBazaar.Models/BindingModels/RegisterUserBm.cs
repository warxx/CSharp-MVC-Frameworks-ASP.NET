using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.BindingModels
{
    public class RegisterUserBm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        [Username]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PasswordRegex, ErrorMessage = PasswordValidationMessage)]
        public string Password { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }
    }
}
