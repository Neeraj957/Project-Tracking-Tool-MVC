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

        public async Task<IActionResult> CreateJobFormPartial()
        {
            await LoadProjectDropdown();
            return PartialView("_CreateJobForm");
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(CreateJobRequest createJobRequest)
        {
            var project = await _projectRepository.GetAsync(createJobRequest.ProjectId);

            var job = new Job
            {
                JobName = createJobRequest.JobName,
                JobDescription = createJobRequest.JobDescription,
                JobDomain = createJobRequest.JobDomain,
                Status = JobStatus.BACKLOG,
                JobStartDate = DateTime.Now,
                JobDeadlineDate = createJobRequest.JobDeadlineDate,
                ProjectId = createJobRequest.ProjectId,
            };

            await _jobRepository.AddAsync(job);
            return RedirectToAction(nameof(ManagerDashboard));
        }

        [HttpGet]
        public async Task<IActionResult> EditJobFormPartial(Guid id)
        {
            var job = await _jobRepository.GetAsync(id);

            if (job != null)
            {
                var project = await _projectRepository.GetAsync(job.ProjectId);


                var editJobRequest = new EditJobRequest
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                    JobDescription = job.JobDescription,
                    JobDomain = job.JobDomain,
                    Status = job.Status,
                    JobDeadlineDate = job.JobDeadlineDate,
                    ProjectId = job.ProjectId,
                    Project = project,
                };
                return PartialView("_EditJobForm", editJobRequest);
            }

            return PartialView("_EditJobForm", null);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJob(EditJobRequest editJobRequest)
        {

            var job = new Job
            {
                JobId = editJobRequest.JobId,
                JobName = editJobRequest.JobName,
                JobDescription = editJobRequest.JobDescription,
                JobDomain = editJobRequest.JobDomain,
                Status = editJobRequest.Status,
                JobDeadlineDate = editJobRequest.JobDeadlineDate,
            };

            var updatedJob = await _jobRepository.UpdateAsync(job);

            if (updatedJob != null)
            {
                //Show success notification
            }
            else
            {
                //Show error notification
            }

            return RedirectToAction(nameof(ManagerDashboard));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteJob(EditJobRequest editJobRequest)
        {
            var deletedJob = await _jobRepository.DeleteAsync(editJobRequest.JobId);

            if (deletedJob != null)
            {
                //show success notification
                return RedirectToAction(nameof(ManagerDashboard));

            }

            //show an error message
            return PartialView("_EditJobForm", editJobRequest);

        }




    }
}
