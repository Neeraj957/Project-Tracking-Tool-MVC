using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Job = Project_Tracking_Tool_MVC.Models.DomainModel.Job;

namespace Project_Tracking_Tool_MVC.Data
{
    public class ProjectTrackingToolDbContext : IdentityDbContext
    {
        public ProjectTrackingToolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
