using Project_Tracking_Tool_MVC.Models.DomainModel;

namespace Project_Tracking_Tool_MVC.Models.ViewModels
{
    public class EditJobStatusRequest
    {

        public Guid JobId { get; set; }

        public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string JobDomain { get; set; }

        public Job.JobStatus Status { get; set; }

        public DateTime JobDeadlineDate { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }


    }
}
