
namespace CameraBazaar.Data
{
    public class Data
    {
        private static CameraBazaarContext context;

        public static CameraBazaarContext Context => context = context ?? (context = new CameraBazaarContext());
    }
}
