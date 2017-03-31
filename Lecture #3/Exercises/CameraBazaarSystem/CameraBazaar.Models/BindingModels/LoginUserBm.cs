using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.BindingModels
{
    public class LoginUserBm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public string Password { get; set; }
    }
}
