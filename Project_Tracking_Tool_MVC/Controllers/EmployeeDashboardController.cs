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


        [HttpGet]
        public async Task<IActionResult> EditJobStatusPartial(Guid id)
        {
            var job = await _jobRepository.GetAsync(id);

            if (job != null)
            {
                var project = await _projectRepository.GetAsync(job.ProjectId);


                var editJobStatusRequest = new EditJobStatusRequest
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
                return PartialView("_EditJobStatusForm", editJobStatusRequest);
            }

            return PartialView("_EditJobStatusForm", null);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobStatus(EditJobStatusRequest editJobStatusRequest)
        {

            var job = new Job
            {
                JobId = editJobStatusRequest.JobId,
                JobName = editJobStatusRequest.JobName,
                JobDescription = editJobStatusRequest.JobDescription,
                JobDomain = editJobStatusRequest.JobDomain,
                Status = editJobStatusRequest.Status,
                JobDeadlineDate = editJobStatusRequest.JobDeadlineDate,
            };

            var updatedJob = await _jobRepository.UpdateJobStatusAsync(job);

            if (updatedJob != null)
            {
                //Show success notification
            }
            else
            {
                //Show error notification
            }

            return RedirectToAction(nameof(EmployeeDashboard));
        }


    }
}
