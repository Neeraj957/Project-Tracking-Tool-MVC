using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Tracking_Tool_MVC.Models.DomainModel
{
    [Authorize]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime ProjectCreationDate { get; set; }

        public ICollection<Job> Jobs { get; set; }

    }
}
