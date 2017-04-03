namespace CarDealer.Models.ViewModels
{
    public class SaleReviewVm
    {
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public double? Discount { get; set; }

        public string CustomerName { get; set; }

        public string CarName { get; set; }

        public double? CarPrice { get; set; }

        public double? FinalCarPrice { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
