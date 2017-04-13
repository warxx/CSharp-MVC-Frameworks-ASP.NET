using System;

namespace CameraBazaar.Models.EntityModels
{
    public class Login
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public virtual User User { get; set; }

        public DateTime? LoginTime { get; set; }

        public bool IsActive { get; set; }
    }
}
