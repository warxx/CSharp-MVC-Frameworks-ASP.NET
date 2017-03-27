namespace CarDealer.Models.ViewModels
{
    public class SaleViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        public long TravelledDistance { get; set; }

        public string CustomerName { get; set; }

        public double? PriceWithDiscount { get; set; }

        public double? PriceWithoutDiscount { get; set; }

        public double Discount { get; set; }
    }
}
