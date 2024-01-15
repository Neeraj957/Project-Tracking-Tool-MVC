using Microsoft.AspNetCore.Mvc;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Project_Tracking_Tool_MVC.Repositories;
using Project_Tracking_Tool_MVC.Models.ViewModels;

namespace Project_Tracking_Tool_MVC.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly IProjectRepository _projectRepository;

        public EmployeeDashboardController(IJobRepository jobRepository, IProjectRepository projectRepository)
        {
            this._jobRepository = jobRepository;
            this._projectRepository = projectRepository;
        }





        public async Task<IActionResult> EmployeeDashboard()
        {



            var projects = await _projectRepository.GetAllAsync();
            var jobs = await _jobRepository.GetAllAsync();

            EmployeeDashboard employeeDashboard = new EmployeeDashboard()
            {
                ProjectsForDisplay = projects.ToList(),
                JobsForDisplay = jobs.ToList()
            };



            return View(employeeDashboard);
        }



    }
}
