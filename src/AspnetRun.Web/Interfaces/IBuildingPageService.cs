using AspnetRun.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IBuildingPageService
    {
        Task<IEnumerable<BuildingViewModel>> GetBuildings();
        Task<BuildingViewModel> GetBuildingById(int buildingId);
        Task<BuildingViewModel> CreateBuilding(BuildingViewModel buildingViewModel);
        Task UpdateBuilding(BuildingViewModel buildingViewModel);
        Task DeleteBuilding(BuildingViewModel buildingViewModel);
    }
}
