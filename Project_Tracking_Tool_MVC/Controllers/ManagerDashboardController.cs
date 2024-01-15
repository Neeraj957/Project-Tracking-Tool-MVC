using Microsoft.AspNetCore.Mvc;
using Project_Tracking_Tool_MVC.Models.ViewModels;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Project_Tracking_Tool_MVC.Repositories;
using static Project_Tracking_Tool_MVC.Models.DomainModel.Job;

namespace Project_Tracking_Tool_MVC.Controllers
{
    public class ManagerDashboardController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly IProjectRepository _projectRepository;

        public ManagerDashboardController(IJobRepository jobRepository, IProjectRepository projectRepository)
        {
            this._jobRepository = jobRepository;
            this._projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ManagerDashboard()
        {
            var projects = await _projectRepository.GetAllAsync();

            var jobs = await _jobRepository.GetAllAsync();

            ManagerDashboard managerDashboard = new ManagerDashboard()
            {
                ProjectsForDisplay = projects.ToList(),
                JobsForDisplay = jobs.ToList()

            };

            return View(managerDashboard);
        }



        public async Task<IActionResult> LoadProjectDropdown()
        {
            var projects = await _projectRepository.GetAllAsync();

            ViewBag.Projects = projects.ToList();
            return View("EmptyView");
        }

        public IActionResult CreateJobFormPartial()
        {
            LoadProjectDropdown().Wait();
            return PartialView("_CreateJobForm");
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(CreateJobRequest createJobRequest)
        {
            var job = new Job
            {
                JobName = createJobRequest.JobName,
                JobDescription = createJobRequest.JobDescription,
                JobDomain = createJobRequest.JobDomain,
                Status = JobStatus.BACKLOG,
                JobStartDate = DateTime.Now,
                JobDeadlineDate = createJobRequest.JobDeadlineDate,
                ProjectId = createJobRequest.ProjectId
            };

            await _jobRepository.AddAsync(job);
            return RedirectToAction(nameof(ManagerDashboard));
        }

        [HttpPost]  
        public async Task<IActionResult> DeleteJob()
        {
            
            return View();

        }


    }
}
