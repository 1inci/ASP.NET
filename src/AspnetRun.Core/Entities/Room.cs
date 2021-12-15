using AspnetRun.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
   public class Room : Entity
    {
        public Room()
        {
           
        }
        public string RoomName { get; set; }

        public int NumberOfBedRoom { get; set; }

        public int SquareMeters { get; set; }

        public int NumberOfBathroom { get; set; }

        public int NumberOfLivingRoom { get; set; }

        public string Description { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public static Room Create(int roomId, int buildingId, string roomName)
        {
            var room = new Room
            {
                Id = roomId,
                BuildingId =buildingId,
                RoomName = roomName

            };
            return room;
        }

    }
}
