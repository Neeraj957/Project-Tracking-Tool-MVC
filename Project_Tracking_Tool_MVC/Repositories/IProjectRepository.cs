using Project_Tracking_Tool_MVC.Models.DomainModel;

namespace Project_Tracking_Tool_MVC.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();

        Task<Project?> GetAsync(Guid id);

        Task<Project> AddAsync(Project project);

        Task<Project?> UpdateAsync(Project project);

        Task<Project?> DeleteAsync(Guid id);
    }
}
