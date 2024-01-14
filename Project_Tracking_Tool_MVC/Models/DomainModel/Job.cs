using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Tracking_Tool_MVC.Models.DomainModel

{
    public class Job
    {
        public Guid JobId { get; set; }

        public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string JobDomain { get; set; }

        public enum JobStatus
        {
            BACKLOG,
            ACTIVE,
            REVIEWING,
            DONE
        }

        public JobStatus Status { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobDeadlineDate { get; set; }


        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

    }
}

