using AspnetRun.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IBuildingService
    {
        Task<IEnumerable<BuildingModel>> GetBuildingList();
        Task<BuildingModel> Create(BuildingModel buildingModel);
        Task Update(BuildingModel buildingModel);
        Task Delete(BuildingModel buildingModel);
        Task<BuildingModel> GetBuildingById(int buildingId);
    }
}
