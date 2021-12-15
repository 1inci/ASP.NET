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
using System.Threading;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class WareHouseRepository : Repository<WareHouse>, IWareHouseRepository
    {
        public WareHouseRepository(AspnetRunContext dbContext) : base(dbContext)
        {
            
        }
       
        public async Task<IEnumerable<WareHouse>> GetRoomByBuildingAsync(int wareHouseId)
        {
            return await _dbContext.WareHouses
                .Where(x => x.Id == wareHouseId)
                .ToListAsync();
        }

        
        public async Task<IEnumerable<WareHouse>> GetRoomByNameAsync(string wareHouseName)
        {
            return await _dbContext.WareHouses
                 .Where(x => x.WareHouseName == wareHouseName)
                 .ToListAsync();
        }

        public async Task<IEnumerable<WareHouse>> GetWareHouseListAsync()
        {
            return await _dbContext.WareHouses
                .ToListAsync();
        }

        public async Task<IEnumerable<WareHouse>> GetWareHouseByNameAsync(string wareHouseName)
        {
            return await _dbContext.WareHouses
                 .Where(x => x.WareHouseName == wareHouseName)
                 .ToListAsync();
        }

        public async Task<IEnumerable<WareHouse>> GetWareHouseByBuildingAsync(int buildingId)
        {
            return await _dbContext.WareHouses
                 .Where(x => x.BuildingId == buildingId)
                 .ToListAsync();
        }
    }
}
