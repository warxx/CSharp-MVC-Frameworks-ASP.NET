

using System.Collections.Generic;
using System.ComponentModel;

namespace CarDealer.Models.ViewModels
{
    public class AddSaleVm
    {
        [DisplayName("Customer: ")]
        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<Car> Cars { get; set; }

        public List<int> Discounts { get; set; }
    }
}
