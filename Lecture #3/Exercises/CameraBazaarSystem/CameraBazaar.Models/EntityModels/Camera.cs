﻿
using CameraBazaar.Models.Enums;

namespace CameraBazaar.Models.EntityModels
{
    public class Camera
    {

        public int Id { get; set; }
        public Make Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int MinShutterSpeed { get; set; }
        public int MaxShutterSpeed { get; set; }
        public int MinISO { get; set; }
        public int MaxISO { get; set; }
        public bool IsFullFrame { get; set; }
        public string VideoResolution { get; set; }
        public LightMetering LightMetering { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
