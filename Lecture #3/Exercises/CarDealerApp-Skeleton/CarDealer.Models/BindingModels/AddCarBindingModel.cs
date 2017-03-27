
namespace CarDealer.Models.BindingModels
{
    public class AddCarBindingModel
    {
        public string Make { get; set; }

        public string CarModel { get; set; }
        public long TravelledDistance { get; set; }

        public int[] PartsId { get; set; }
    }
}
