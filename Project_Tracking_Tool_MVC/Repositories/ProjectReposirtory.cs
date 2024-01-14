using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Data;
using Project_Tracking_Tool_MVC.Models.DomainModel;
using Project_Tracking_Tool_MVC.Models.ViewModels;

namespace Project_Tracking_Tool_MVC.Repositories
{
    public class ProjectReposirtory : IProjectRepository
    {
        private readonly ProjectTrackingToolDbContext _projectTrackingToolDbContext;

        public ProjectReposirtory(ProjectTrackingToolDbContext projectTrackingToolDbContext)
        {
            this._projectTrackingToolDbContext = projectTrackingToolDbContext;
        }

        public async Task<Project> AddAsync(Project project)
        {
            await _projectTrackingToolDbContext.Projects.AddAsync(project);
            await _projectTrackingToolDbContext.SaveChangesAsync();

            return project;
        }


        public async Task<Project?> DeleteAsync(Guid id)
        {
            var existingProject = await _projectTrackingToolDbContext.Projects.FindAsync(id);

            if (existingProject != null) 
            {
                _projectTrackingToolDbContext.Projects.Remove(existingProject);
                await _projectTrackingToolDbContext.SaveChangesAsync();
                return existingProject;
            }

            return null;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _projectTrackingToolDbContext.Projects.ToListAsync();

        }

        public Task<Project?> GetAsync(Guid id)
        {
            return _projectTrackingToolDbContext.Projects.FirstOrDefaultAsync(x=> x.ProjectId == id);
        }

        public async Task<Project?> UpdateAsync(Project project)
        {
            var existingProject = await _projectTrackingToolDbContext.Projects.FindAsync(project.ProjectId);

            if (existingProject != null) 
            {
                existingProject.ProjectTitle = project.ProjectTitle;
                existingProject.ProjectDescription = project.ProjectDescription;

                await _projectTrackingToolDbContext.SaveChangesAsync();

                return existingProject;

            }
            return null;
        }
    }
}
