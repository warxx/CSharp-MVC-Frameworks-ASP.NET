using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.ViewModels
{
    public class PartViewModel
    {
        public string Name { get; set; }
        public double? Price { get; set; }
        public int Quantity { get; set; }

        public string SupplierName { get; set; }
    }
}
