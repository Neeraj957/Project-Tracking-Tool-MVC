using Microsoft.AspNetCore.Identity;

namespace Project_Tracking_Tool_MVC.Models.DomainModel
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
