using Project_Tracking_Tool_MVC.Models.DomainModel;

namespace Project_Tracking_Tool_MVC.Repositories
{
    public interface IEmpDemocs
    {
        Task<IEnumerable<Job>> GetAllAsync();
    }
}
