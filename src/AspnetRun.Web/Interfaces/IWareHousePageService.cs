using AspnetRun.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IWareHousePageService
    {
        Task<IEnumerable<WareHouseViewModel>> GetWareHouse(string wareHouseName);
        Task<WareHouseViewModel> GetWareHouseById(int wareHouseId);
        Task<IEnumerable<WareHouseViewModel>> GetWareHouseByBuilding(int buildingId);
        Task<IEnumerable<BuildingViewModel>> GetBuildings();
        Task<WareHouseViewModel> CreateWareHouse(WareHouseViewModel wareHouseViewModel);
        Task UpdateWareHouse(WareHouseViewModel wareHouseViewModel);
        Task DeleteWareHouse(WareHouseViewModel wareHouseViewModel);
    }
}
