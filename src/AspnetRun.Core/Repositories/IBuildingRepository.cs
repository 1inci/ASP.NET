using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Task<IEnumerable<Building>> GetBuildingListAsync();
        Task<IEnumerable<Building>> GetBuildingByNameAsync(string productName);
    }
}
