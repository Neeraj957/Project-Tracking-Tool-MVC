using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_Tracking_Tool_MVC.Models.DomainModel
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime ProjectCreationDate { get; set; }

        public ICollection<Task> Tasks { get; set; }

    }
}
