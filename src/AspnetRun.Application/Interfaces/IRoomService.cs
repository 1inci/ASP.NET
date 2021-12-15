using AspnetRun.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomModel>> GetRoomList();
        Task<RoomModel> GetRoomById(int roomId);
        Task<IEnumerable<RoomModel>> GetRoomByName(string roomName);
        Task<IEnumerable<BuildingModel>> GetRoomByBuilding(int buildingId);
        Task<RoomModel> Create(RoomModel productModel);
        Task Update(RoomModel roomModel);
        Task Delete(RoomModel roomModel);
    }
}
