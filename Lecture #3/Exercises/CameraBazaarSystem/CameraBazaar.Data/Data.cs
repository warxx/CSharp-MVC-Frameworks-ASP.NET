
namespace CameraBazaar.Data
{
    public class Data
    {
        private CameraBazaarContext context;

        public CameraBazaarContext Context => context = context ?? (context = new CameraBazaarContext());
    }
}
