using System;

namespace CarDealer.Models
{
    public class Log
    {
        public int Id { get; set; }

        public User User { get; set; }

        public OperationLog Operation { get; set; }

        public string ModifiedTable { get; set; }

        public DateTime ModifyingDate { get; set; }
    }

    public enum OperationLog
    {
        Add, Edit, Delete
    }
}
