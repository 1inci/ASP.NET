using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface IWareHouseRepository : IRepository<WareHouse>
    {
        Task<IEnumerable<WareHouse>> GetWareHouseListAsync();
        Task<IEnumerable<WareHouse>> GetWareHouseByNameAsync(string wareHouse);
        Task<IEnumerable<WareHouse>> GetWareHouseByBuildingAsync(int buildingId);
    }
}
