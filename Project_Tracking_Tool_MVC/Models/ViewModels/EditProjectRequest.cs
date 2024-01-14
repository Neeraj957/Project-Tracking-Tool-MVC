namespace Project_Tracking_Tool_MVC.Models.ViewModels
{
    public class EditProjectRequest
    {

        public Guid ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

    }
}
