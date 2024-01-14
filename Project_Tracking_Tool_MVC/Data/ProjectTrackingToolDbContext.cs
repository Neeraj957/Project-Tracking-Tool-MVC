using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Task = Project_Tracking_Tool_MVC.Models.DomainModel.Task;

namespace Project_Tracking_Tool_MVC.Data
{
    public class ProjectTrackingToolDbContext : IdentityDbContext
    {
        public ProjectTrackingToolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
