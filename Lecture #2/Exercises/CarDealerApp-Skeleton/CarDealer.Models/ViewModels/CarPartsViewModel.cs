using System;
using System.Collections.Generic;

namespace CarDealer.Models.ViewModels
{
    public class CarPartsViewModel
    {
        public Car Car { get; set; }

        public List<Part> Parts { get; set; }
    }
}