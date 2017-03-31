using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.ViewModels
{
    public class LoginUserVm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public string Password { get; set; }
    }
}
