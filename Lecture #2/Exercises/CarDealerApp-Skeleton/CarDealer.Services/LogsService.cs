using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class LogsService : Service
    {
        public LogsService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<AllLogsViewModel> GetAllLogsVm(string username)
        {
            IEnumerable<Log> logs;

            if (username == null)
            {
                logs = this.context.Logs;
            }
            else
            {
                logs = this.context.Logs.Where(x => x.User.Username == username);
            }
                       
            IEnumerable<AllLogsViewModel> viewModels = Mapper
                .Map<IEnumerable<Log>, IEnumerable<AllLogsViewModel>>(logs);

            return viewModels;
        }

        public IEnumerable<AllLogsViewModel> GetAllLogsForUserVm(string username)
        {
            IEnumerable<Log> logs = this.context.Logs.Where(x=>x.User.Username == username);
            IEnumerable<AllLogsViewModel> viewModels = Mapper
                .Map<IEnumerable<Log>, IEnumerable<AllLogsViewModel>>(logs);

            return viewModels;
        }
    }
}
