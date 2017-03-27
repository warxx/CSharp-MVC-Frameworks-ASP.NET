using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;

namespace CameraBazaar.Models.EntityModels
{
    public class User
    {

        public User()
        {
            this.Cameras = new HashSet<Camera>();
        }

        public int Id { get; set; }

        [Required, Username]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }

        public virtual ICollection<Camera> Cameras { get; set; }
    }
}
