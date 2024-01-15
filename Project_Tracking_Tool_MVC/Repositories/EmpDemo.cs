using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Data;
using Project_Tracking_Tool_MVC.Models.DomainModel;

namespace Project_Tracking_Tool_MVC.Repositories
{
    public class EmpDemo : IEmpDemocs
    {
        private readonly ProjectTrackingToolDbContext _projectTrackingToolDbContext;


        public EmpDemo(ProjectTrackingToolDbContext projectTrackingToolDbContext)
        {
            this._projectTrackingToolDbContext = projectTrackingToolDbContext;
        }
        public async Task<IEnumerable<Job>> GetAllAsync()
        {

            return await _projectTrackingToolDbContext.Jobs.ToListAsync();

        }
    }
}
