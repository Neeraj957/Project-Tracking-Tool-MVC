using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Task = Project_Tracking_Tool_MVC.Models.DomainModel.Task;

namespace Project_Tracking_Tool_MVC.Data
{
    public class ProjectTrackingToolDbContext : DbContext
    {
        public ProjectTrackingToolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
