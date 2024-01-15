using Project_Tracking_Tool_MVC.Models.DomainModel;

namespace Project_Tracking_Tool_MVC.Models.ViewModels
{
    public class ManagerDashboard
    {
        public List<Project> ProjectsForDisplay { get; set; }
        public List<Job> JobsForDisplay { get; set; }
    }
}
