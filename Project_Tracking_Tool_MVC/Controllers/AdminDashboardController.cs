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

        [HttpGet]
        public IActionResult EditProjectFormPartial(Guid id)
        {
            var project = _projectTrackingToolDbContext.Projects.FirstOrDefault(x => x.ProjectId == id);

            if (project != null)
            {
                var editProjectRequest = new EditProjectRequest
                {
                    ProjectId = project.ProjectId, // Make sure to include the ProjectId in the EditProjectRequest
                    ProjectTitle = project.ProjectTitle,
                    ProjectDescription = project.ProjectDescription,
                };
                return PartialView("_EditProjectForm", editProjectRequest);
            }

            // You might want to handle the case where the project is not found differently
            return PartialView("_EditProjectForm", null);
        }

        [HttpPost]
        public IActionResult UpdateProject(EditProjectRequest editProjectRequest)
        {
            if (ModelState.IsValid)
            {
                var existingProject = _projectTrackingToolDbContext.Projects.Find(editProjectRequest.ProjectId);

                if (existingProject != null)
                {
                    existingProject.ProjectTitle = editProjectRequest.ProjectTitle;
                    existingProject.ProjectDescription = editProjectRequest.ProjectDescription;

                    _projectTrackingToolDbContext.SaveChanges();

                    // You might want to return a JSON response for AJAX requests
                    return RedirectToAction(nameof(AdminDashboard));
                }
            }

            // If there are validation errors or the project is not found, return the partial view with errors
            return PartialView("_EditProjectForm", editProjectRequest);
        }

        [HttpPost]
        public IActionResult DeleteProject(EditProjectRequest editProjectRequest) 
        {
            var project = _projectTrackingToolDbContext.Projects.Find(editProjectRequest.ProjectId);

            if (project != null)
            {
                _projectTrackingToolDbContext.Projects.Remove(project);
                _projectTrackingToolDbContext.SaveChanges();

                //show success notification
                return RedirectToAction(nameof(AdminDashboard));
            }

            return PartialView("_EditProjectForm", editProjectRequest);

        }

    }

}
