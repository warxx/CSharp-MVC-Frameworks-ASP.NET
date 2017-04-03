using System.ComponentModel;
using CameraBazaar.Models.Enums;

namespace CameraBazaar.Models.ViewModels
{
    public class DeleteCameraVm
    {
        public Make Make { get; set; }

        [DisplayName("Camera Model")]
        public string CameraModel { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [DisplayName("Min Shutter Speed")]
        public int MinShutterSpeed { get; set; }

        [DisplayName("Max Shutter Speed")]
        public int MaxShutterSpeed { get; set; }

        [DisplayName("Min ISO")]
        public int MinIso { get; set; }

        [DisplayName("Max ISO")]
        public int MaxIso { get; set; }

        [DisplayName("Is Full Frame")]
        public bool IsFullFrame { get; set; }

        [DisplayName("Video Resolution")]
        public string VideoResolution { get; set; }

        [DisplayName("Light Metering")]
        public LightMetering LightMetering { get; set; }

        public string Description { get; set; }

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
    }
}
