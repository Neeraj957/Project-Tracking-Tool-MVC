using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Project_Tracking_Tool_MVC.Models.ViewModels;
using Project_Tracking_Tool_MVC.Repositories;

namespace Project_Tracking_Tool_MVC.Controllers
{
    [Authorize]
    public class AdminDashboardController : Controller
    {
        private IProjectRepository _projectRepository;
      

        public AdminDashboardController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
           
        }

        [HttpGet]
        public async Task<IActionResult> AdminDashboard()
        {
            var projects = await _projectRepository.GetAllAsync();

            return View(projects);
        }

        public IActionResult AddProjectFormPartial()
        {
            return PartialView("_AddProjectForm");
        }


        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectRequest addProjectRequest)
        {
            var project = new Project
            {
                ProjectTitle = addProjectRequest.ProjectTitle,
                ProjectDescription = addProjectRequest.ProjectDescription,
                ProjectCreationDate = DateTime.Now
            };

            await _projectRepository.AddAsync(project);

            //return View("~/Views/AdminDashboard/AdminDashboard.cshtml");
            return RedirectToAction(nameof(AdminDashboard));
        }

        [HttpGet]
        public async Task<IActionResult> EditProjectFormPartial(Guid id)
        {
            var project = await _projectRepository.GetAsync(id);

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
        public async Task<IActionResult> UpdateProject(EditProjectRequest editProjectRequest)
        {
            if (ModelState.IsValid)
            {

                var project = new Project
                {
                    ProjectId = editProjectRequest.ProjectId,
                    ProjectTitle = editProjectRequest.ProjectTitle,
                    ProjectDescription = editProjectRequest.ProjectDescription,
                };

                var updatedTag = await _projectRepository.UpdateAsync(project);

                if (updatedTag != null)
                {
                    //Show success notification
                }
                else
                {
                    //Show error notification
                }

                // You might want to return a JSON response for AJAX requests
                return RedirectToAction(nameof(AdminDashboard));

            }

            // If there are validation errors or the project is not found, return the partial view with errors
            return PartialView("_EditProjectForm", editProjectRequest);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(EditProjectRequest editProjectRequest)
        {
            var deletedProject = await _projectRepository.DeleteAsync(editProjectRequest.ProjectId);

            if (deletedProject != null)
            {
                //show success notification
                return RedirectToAction(nameof(AdminDashboard));

            }

            //show an error message
            return PartialView("_EditProjectForm", editProjectRequest);

        }


    }
}
