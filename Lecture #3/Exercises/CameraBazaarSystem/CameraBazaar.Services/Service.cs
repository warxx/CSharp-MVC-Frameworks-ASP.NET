using CameraBazaar.Data;

namespace CameraBazaar.Services
{
    public abstract class Service
    {
        protected CameraBazaarContext context;

        protected Service(CameraBazaarContext context)
        {
            this.context = context;
        }
    }
}
