using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models.ViewModels.Users
{
    public class EditUsersVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
