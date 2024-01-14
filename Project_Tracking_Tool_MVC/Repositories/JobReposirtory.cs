using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Data;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Project_Tracking_Tool_MVC.Models.ViewModels;

namespace Project_Tracking_Tool_MVC.Repositories
{
    public class JobReposirtory : IJobRepository
    {
        private readonly ProjectTrackingToolDbContext _projectTrackingToolDbContext;

        public JobReposirtory(ProjectTrackingToolDbContext projectTrackingToolDbContext)
        {
            this._projectTrackingToolDbContext = projectTrackingToolDbContext;
        }

        public async Task<Job> AddAsync(Job job)
        {
            await _projectTrackingToolDbContext.Jobs.AddAsync(job);
            await _projectTrackingToolDbContext.SaveChangesAsync();

            return job;
        }

        public async Task<Job?> DeleteAsync(Guid id)
        {
            var existingJob = await _projectTrackingToolDbContext.Jobs.FindAsync(id);

            if (existingJob != null) 
            {
                _projectTrackingToolDbContext.Jobs.Remove(existingJob);
                await _projectTrackingToolDbContext.SaveChangesAsync();
                return existingJob;
            }

            return null;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _projectTrackingToolDbContext.Jobs.ToListAsync();

        }

        public Task<Job?> GetAsync(Guid id)
        {
            return _projectTrackingToolDbContext.Jobs.FirstOrDefaultAsync(x=> x.JobId == id);
        }

        public async Task<Job?> UpdateAsync(Job job)
        {
            var existingJob = await _projectTrackingToolDbContext.Jobs.FindAsync(job.JobId);

            if (existingJob != null) 
            {
                existingJob.JobName = job.JobName;
                existingJob.JobDescription = job.JobDescription;

                await _projectTrackingToolDbContext.SaveChangesAsync();

                return existingJob;

            }
            return null;
        }


    }
}
