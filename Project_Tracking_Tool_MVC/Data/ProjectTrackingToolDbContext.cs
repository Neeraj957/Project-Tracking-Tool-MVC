using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Job = Project_Tracking_Tool_MVC.Models.DomainModel.Job;

namespace Project_Tracking_Tool_MVC.Data
{
    public class ProjectTrackingToolDbContext : DbContext
    {
        public ProjectTrackingToolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Job> Jobs { get; set; }
    }
}
