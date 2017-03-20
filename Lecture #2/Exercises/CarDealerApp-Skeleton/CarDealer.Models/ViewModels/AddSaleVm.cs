

using System.Collections.Generic;

namespace CarDealer.Models.ViewModels
{
    public class AddSaleVm
    {
        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<Car> Cars { get; set; }

        public List<int> Discounts { get; set; }
    }
}
