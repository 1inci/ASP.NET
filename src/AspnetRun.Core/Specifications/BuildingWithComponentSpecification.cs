using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Specifications
{
    public sealed class BuildingWithComponentSpecification : BaseSpecification<Building>
    {
        public BuildingWithComponentSpecification(int buildingId)
            : base(b => b.Id == buildingId)
        {
            AddInclude(b => b.Rooms);
            AddInclude(b => b.WareHouses);
        }
    }    
}
