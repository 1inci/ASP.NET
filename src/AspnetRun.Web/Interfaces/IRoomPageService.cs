using AspnetRun.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IRoomPageService
    {
        Task<IEnumerable<RoomViewModel>> GetRoom(string roomName);
        Task<RoomViewModel> GetRoomById(int roomId);
        Task<IEnumerable<RoomViewModel>> GetRoomByBuilding(int buildingId);
        Task<IEnumerable<BuildingViewModel>> GetBuildings();
        Task<RoomViewModel> CreateRoom(RoomViewModel roomViewModel);
        Task UpdateRoom(RoomViewModel roomViewModel);
        Task DeleteRoom(RoomViewModel roomViewModel);
    }
}
