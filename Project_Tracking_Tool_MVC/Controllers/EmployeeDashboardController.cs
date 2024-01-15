using Microsoft.AspNetCore.Mvc;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Project_Tracking_Tool_MVC.Repositories;

namespace Project_Tracking_Tool_MVC.Controllers
{
    public class EmployeeDashboardController : Controller
    {

        private IProjectRepository _projectRepository;
        public async Task<IActionResult> EmployeeDashboard()
        {

            List<Job> jobs = new List<Job>
            {
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = "Task 1",
                    JobDescription = "Description for Task 1",
                    JobDomain = "frontend",
                    Status = Job.JobStatus.BACKLOG,
                    JobStartDate = DateTime.Now,
                    JobDeadlineDate = DateTime.Now.AddDays(7),
                    ProjectId = Guid.NewGuid(),
                    Project = new Project { ProjectId = Guid.NewGuid(), ProjectTitle = "Project 1" }
                },
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = "Task 2",
                    JobDescription = "Description for Task 2",
                    JobDomain = "frontend",
                    Status = Job.JobStatus.ACTIVE,
                    JobStartDate = DateTime.Now,
                    JobDeadlineDate = DateTime.Now.AddDays(10),
                    ProjectId = Guid.NewGuid(),
                    Project = new Project { ProjectId = Guid.NewGuid(), ProjectTitle = "Project 2" }
                },
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = "Task 3",
                    JobDescription = "Description for Task 3",
                    JobDomain = "backend",
                    Status = Job.JobStatus.REVIEWING,
                    JobStartDate = DateTime.Now,
                    JobDeadlineDate = DateTime.Now.AddDays(5),
                    ProjectId = Guid.NewGuid(),
                    Project = new Project { ProjectId = Guid.NewGuid(), ProjectTitle = "Project 3" }
                },
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = "Task 4",
                    JobDescription = "Description for Task 4",
                    JobDomain = "database",
                    Status = Job.JobStatus.DONE,
                    JobStartDate = DateTime.Now,
                    JobDeadlineDate = DateTime.Now.AddDays(14),
                    ProjectId = Guid.NewGuid(),
                    Project = new Project { ProjectId = Guid.NewGuid(), ProjectTitle = "Project 4" }
                },
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = "Task 5",
                    JobDescription = "Description for Task 5",
                    JobDomain = "backend",
                    Status = Job.JobStatus.BACKLOG,
                    JobStartDate = DateTime.Now,
                    JobDeadlineDate = DateTime.Now.AddDays(8),
                    ProjectId = Guid.NewGuid(),
                    Project = new Project { ProjectId = Guid.NewGuid(), ProjectTitle = "Project 5" }
                }
            };



          //  var jobs = await _projectRepository.GetAllAsync();
            return View(jobs);
        }



    }
}
