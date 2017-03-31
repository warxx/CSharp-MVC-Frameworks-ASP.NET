using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.ViewModels
{
    public class RegisterUserVm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(UsernameRegex, ErrorMessage = UsernameValidationMessage)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PasswordRegex, ErrorMessage = PasswordValidationMessage)]
        public string Password { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PasswordRegex, ErrorMessage = PasswordValidationMessage)]
        [Compare("Password", ErrorMessage = ConfirmPasswordValidationMsg)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }
    }
}
