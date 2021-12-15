using AspnetRun.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
  
    public interface IIndexPageService
    {
        Task<IEnumerable<BuildingViewModel>> GetBuildings();

        Task<IEnumerable<RoomViewModel>> GetRooms();
        Task<IEnumerable<WareHouseViewModel>> GetWareHouses();
    }
}
