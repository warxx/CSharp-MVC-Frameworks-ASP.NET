
namespace CarDealer.Data
{
    public class Data
    {
        private static CarDealerContext context;

        public static CarDealerContext Context => context = context ?? (context = new CarDealerContext());
    }
}
