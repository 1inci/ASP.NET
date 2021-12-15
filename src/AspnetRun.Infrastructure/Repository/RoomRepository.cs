using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Room>> GetProductListAsync()
        {
            var spec = new RoomtWithBuildingSpecification();
            return await GetAsync(spec);
                        
        }


        public async Task<IEnumerable<Room>> GetRoomByBuildingAsync(int buildingId)
        {
            return await _dbContext.Rooms
                .Where(x => x.BuildingId == buildingId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomListAsync()
        {
            return await _dbContext.Rooms
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomByNameAsync(string roomName)
        {
            return await _dbContext.Rooms
                 .Where(x => x.RoomName == roomName)
                 .ToListAsync();
        }
        
    }
}
