using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class RoomtWithBuildingSpecification : BaseSpecification<Room>
    {
        public RoomtWithBuildingSpecification(string roomName) 
            : base(p => p.RoomName.ToLower().Contains(roomName.ToLower()))
        {
            AddInclude(p => p.Building);
        }

        public RoomtWithBuildingSpecification() : base(null)
        {
            AddInclude(p => p.Building);
        }
    }
}
