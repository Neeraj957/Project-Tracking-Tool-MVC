using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Tracking_Tool_MVC.Models.DomainModel

{
    public class Task
    {
        public Guid TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public string TaskDomain { get; set; }

        public enum TaskStatus
        {
            BACKLOG,
            ACTIVE,
            REVIEWING,
            DONE
        }

        public TaskStatus Status { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskDeadlineDate { get; set; }


        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

    }
}

