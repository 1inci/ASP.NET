using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IEnumerable<Room>> GetRoomListAsync();
        Task<IEnumerable<Room>> GetRoomByNameAsync(string roomName);
        Task<IEnumerable<Room>> GetRoomByBuildingAsync(int buildingId);
    }
}
