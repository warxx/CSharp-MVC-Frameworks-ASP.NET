
namespace CameraBazaar.Models.Constants
{
    public class ValidationMessages
    {
        public const string UsernameValidationMessage =
            "Username must be between 4 and 20 symbols long and must contain only letters.";
        
        public const string RequiredValidationMessage = "The field is required !";
        public const string PasswordValidationMessage =
            "Password must be at least 3 symbols long and can contain only lowercase letters and digits.";
        public const string PhoneValidationMessage = 
            "Phone must start with \"+\" sign followed by 10 to 12 digits";

    }
}
