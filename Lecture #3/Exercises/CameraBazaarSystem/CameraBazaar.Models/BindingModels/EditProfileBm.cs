using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.BindingModels
{
    public class EditProfileBm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PasswordRegex, ErrorMessage = PasswordValidationMessage)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PasswordRegex, ErrorMessage = PasswordValidationMessage)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }
    }
}
