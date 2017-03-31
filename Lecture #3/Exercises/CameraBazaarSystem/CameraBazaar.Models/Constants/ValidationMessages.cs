
namespace CameraBazaar.Models.Constants
{
    public class ValidationMessages
    {
        public const string UsernameValidationMessage =
            "Username must be between 4 and 20 symbols long and must contain only letters.";
        
        public const string RequiredValidationMessage = "The field is required !";
        public const string PasswordValidationMessage =
            "Password must be at least 3 symbols long and can contain only lowercase letters and digits.";

        public const string ConfirmPasswordValidationMsg = "Cofirmation password doesn't match.";
        public const string PhoneValidationMessage = 
            "Phone must start with \"+\" sign followed by 10 to 12 digits.";

        public const string QuantityValidationMessage = "Quantity must be in range 0-100.";
        public const string MinShutterSpeedValidationMsg = "Min shutter speed must be in range 1-30(seconds).";
        public const string MaxShutterSpeedValidationMsg = "Min shutter speed must be in range 2000-8000(fraction of a second).";
        public const string MinIsoValidationMessage = "Min ISO can be 50 or 100.";
        public const string MaxIsoValidationMessage = "Max ISO must be in range 200 to 409600 and must be dividable by 100.";
        public const string VideoResolutionValidationMsg = "Video resolution must be described with text no longer than 15 symbols.";
        public const string DescriptionValidationMsg = "Description for the camera must be no more than 6000 symbols";
        public const string ImageUrlValidationMsg = "Image URL must start with http:// or https://";

    }
}
