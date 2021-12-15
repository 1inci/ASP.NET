using AspnetRun.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
   public class Building : Entity
    {
        public Building()
        {
            Rooms = new HashSet<Room>();

            WareHouses = new HashSet<WareHouse>();
        }

        public string BuildingName { get; set; }

        public string Location { get; set; }

        public int NumberOfFloors { get; set; }

        public string Description { get; set; }

        public int BuildingAge { get; set; }

        public int BuildingPrice { get; set; }

        public ICollection<Room> Rooms { get; private set; }
        public ICollection<WareHouse> WareHouses { get; private set; }

        public static Building Create(int buildingId, string name, string description = null)
        {
            var building = new Building
            {
                Id = buildingId,
                BuildingName = name,
                Description = description
            };
            return building;
        }




    }
}
