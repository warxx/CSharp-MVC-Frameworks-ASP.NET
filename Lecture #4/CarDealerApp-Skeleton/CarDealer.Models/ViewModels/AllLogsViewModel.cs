using System;

namespace CarDealer.Models.ViewModels
{
    public class AllLogsViewModel
    {
        public string Username { get; set; }

        public OperationLog Operation { get; set; }

        public string ModifiedTable { get; set; }

        public DateTime ModifyingDate { get; set; }

    }
}
