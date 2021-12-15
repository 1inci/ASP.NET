using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(AspnetRunContext dbContext) : base(dbContext)
        {            
        }

        public async Task<IEnumerable<Building>> GetBuildingByNameAsync(int buildingId)
        {
            var spec = new BuildingWithComponentSpecification(buildingId);
            var building = (await GetAsync(spec)).FirstOrDefault();
            return (IEnumerable<Building>)building;            
        }

        public async Task<IEnumerable<Building>> GetBuildingByNameAsync(string buildingName)
        {
            return await _dbContext.Buildings
                .Where(x => x.BuildingName == buildingName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Building>> GetBuildingListAsync()
        {
            return await _dbContext.Buildings
                .ToListAsync();
        }
        

    }
}
