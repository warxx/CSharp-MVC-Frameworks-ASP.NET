﻿using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using CameraBazaar.Models.Enums;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.EntityModels
{
    public class Camera
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public Make Make { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(CameraModelRegex, ErrorMessage = CameraModelValidationMsg)]
        public string CameraModel { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [Range(0, 100, ErrorMessage = QuantityValidationMessage)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [Range(1, 30, ErrorMessage = MinShutterSpeedValidationMsg)]
        public int MinShutterSpeed { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [Range(2000, 8000, ErrorMessage = MaxShutterSpeedValidationMsg)]
        public int MaxShutterSpeed { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinIso]
        public int MinIso { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [Range(200, 409600, ErrorMessage = MaxIsoValidationMessage)]
        [MaxIso]
        public int MaxIso { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public bool IsFullFrame { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MaxLength(15, ErrorMessage = VideoResolutionValidationMsg)]
        public string VideoResolution { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public LightMetering LightMetering { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MaxLength(6000, ErrorMessage = DescriptionValidationMsg)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlValidationMsg)]
        public string ImageUrl { get; set; }

        public virtual User Seller { get; set; }
    }
}
