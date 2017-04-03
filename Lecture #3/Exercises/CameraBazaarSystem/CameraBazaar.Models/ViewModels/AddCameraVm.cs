using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using CameraBazaar.Models.Enums;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.ViewModels
{
    public class AddCameraVm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        public Make Make { get; set; }

        [DisplayName("Model")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(CameraModelRegex, ErrorMessage = CameraModelValidationMsg)]
        public string CameraModel { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [Range(0, 100, ErrorMessage = QuantityValidationMessage)]
        public int Quantity { get; set; }

        [DisplayName("Min Shutter Speed")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [Range(1, 30, ErrorMessage = MinShutterSpeedValidationMsg)]
        public int MinShutterSpeed { get; set; }

        [DisplayName("Max Shutter Speed")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [Range(2000, 8000, ErrorMessage = MaxShutterSpeedValidationMsg)]
        public int MaxShutterSpeed { get; set; }

        [MinIso]
        [DisplayName("Min ISO")]
        public int MinIso { get; set; }

        [Range(200, 409600, ErrorMessage = MaxIsoValidationMessage)]
        [MaxIso]
        [DisplayName("Max ISO")]
        public int MaxIso { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [DisplayName("Is Full Frame")]
        public bool IsFullFrame { get; set; }

        [DisplayName("Video Resolution")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MaxLength(15, ErrorMessage = VideoResolutionValidationMsg)]
        public string VideoResolution { get; set; }

        [DisplayName("Light Metering")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        public LightMetering LightMetering { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MaxLength(6000, ErrorMessage = DescriptionValidationMsg)]
        public string Description { get; set; }

        [DisplayName("Image URL")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlValidationMsg)]
        public string ImageUrl { get; set; }
    }
}
