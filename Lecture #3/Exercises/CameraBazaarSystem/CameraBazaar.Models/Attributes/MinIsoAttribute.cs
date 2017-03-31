using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.Attributes
{
    public class MinIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(RequiredValidationMessage);
            }

            int iso = (int)value;

            if (iso != 50 && iso != 100)
            {
                return new ValidationResult(MinIsoValidationMessage);
            }

            return ValidationResult.Success;
        }
    }
}
