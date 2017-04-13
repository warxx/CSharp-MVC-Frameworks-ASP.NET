using System.Collections.Generic;
using System.Security.AccessControl;

namespace CameraBazaar.Models.ViewModels
{
    public class UserProfileVm
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int InStockCameras { get; set; }

        public int OutStockCameras { get; set; }

        public IEnumerable<AllCamerasVm> UserCameras { get; set; }
    }
}
