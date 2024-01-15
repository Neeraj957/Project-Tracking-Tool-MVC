using Microsoft.Build.Evaluation;

namespace Project_Tracking_Tool_MVC.Models.ViewModels
{
    public class CreateJobRequest
    {
        public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string JobDomain { get; set; }

        public DateTime JobDeadlineDate { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

    }
}
