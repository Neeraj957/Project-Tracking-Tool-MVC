using Project_Tracking_Tool_MVC.Models.DomainModel;

namespace Project_Tracking_Tool_MVC.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllAsync();

        Task<Job?> GetAsync(Guid id);

        Task<Job> AddAsync(Job job);

        Task<Job?> UpdateAsync(Job job);

        Task<Job?> DeleteAsync(Guid id);
    }
}
