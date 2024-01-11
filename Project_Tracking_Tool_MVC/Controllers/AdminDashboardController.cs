using Microsoft.AspNetCore.Mvc;
using Project_Tracking_Tool_MVC.Data;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Project_Tracking_Tool_MVC.Models.ViewModels;

namespace Project_Tracking_Tool_MVC.Controllers
{
    public class AdminDashboardController : Controller
    {

        private ProjectTrackingToolDbContext _projectTrackingToolDbContext;
        public AdminDashboardController(ProjectTrackingToolDbContext projectTrackingToolDbContext)
        {
            _projectTrackingToolDbContext = projectTrackingToolDbContext;
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            var projects = _projectTrackingToolDbContext.Projects.ToList();

            return View(projects);
        }


        public IActionResult AddProjectFormPartial()
        { 
            return PartialView("_AddProjectForm");
        }


        [HttpPost]
        public IActionResult AddProject(AddProjectRequest addProjectRequest)
        {


            var project = new Project
            {
                ProjectTitle = addProjectRequest.ProjectTitle,
                ProjectDescription = addProjectRequest.ProjectDescription,
                ProjectCreationDate = DateTime.Now
            };

            _projectTrackingToolDbContext.Projects.Add(project);
            _projectTrackingToolDbContext.SaveChanges();

            //return View("~/Views/AdminDashboard/AdminDashboard.cshtml");
            return RedirectToAction(nameof(AdminDashboard));
        }
    }

}
