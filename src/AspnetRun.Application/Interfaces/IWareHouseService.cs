using AspnetRun.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IWareHouseService
    {
        Task<IEnumerable<WareHouseModel>> GetWareHouseList();
        Task<WareHouseModel> GetWareHouseById(int wareHouseId);
        Task<IEnumerable<WareHouseModel>> GetWareHouseByName(string wareHouseName);
        Task<IEnumerable<BuildingModel>> GetWareHouseByBuilding(int buildingId);
        Task<WareHouseModel> Create(WareHouseModel wareHouseModel);
        Task Update(WareHouseModel wareHouseModel);
        Task Delete(WareHouseModel wareHouseModel);
    }
}
