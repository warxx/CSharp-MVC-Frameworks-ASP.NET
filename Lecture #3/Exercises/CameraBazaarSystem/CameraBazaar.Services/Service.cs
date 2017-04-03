using CameraBazaar.Data;

namespace CameraBazaar.Services
{
    public abstract class Service
    {
        protected Data.Data data;

        protected Service()
        {
            this.data = new Data.Data();
        }
    }
}
