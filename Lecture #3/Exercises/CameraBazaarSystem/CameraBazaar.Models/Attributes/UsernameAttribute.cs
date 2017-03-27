using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.Attributes
{
    public class UsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string username = value as string;

            if (username.Length < 4 || username.Length > 20)
            {
                return new ValidationResult(UsernameValidationMessage);
            }

            foreach (var symbol in username)
            {
                if (!char.IsLetter(symbol))
                {
                    return new ValidationResult(UsernameValidationMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
