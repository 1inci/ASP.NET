using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class WareHouseWithBuildingSpecification : BaseSpecification<WareHouse>
    {
        public WareHouseWithBuildingSpecification(string warehouseName) 
            : base(p => p.WareHouseName.ToLower().Contains(warehouseName.ToLower()))
        {
            AddInclude(p => p.Building);
        }

        public WareHouseWithBuildingSpecification() : base(null)
        {
            AddInclude(p => p.Building);
        }
    }
}
