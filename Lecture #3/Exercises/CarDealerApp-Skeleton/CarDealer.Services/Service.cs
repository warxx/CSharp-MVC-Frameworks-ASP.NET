using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Data;

namespace CarDealer.Services
{
    public abstract class Service
    {
        protected CarDealerContext context;

        protected Service(CarDealerContext context)
        {
            this.context = context;
        }
    }
}
