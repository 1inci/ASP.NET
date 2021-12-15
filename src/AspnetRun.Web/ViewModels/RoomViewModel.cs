using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.ViewModels
{
    public class RoomViewModel : BaseViewModel
    {
        public string RoomName { get; set; }
        public string NumberOfBedRoom { get; set; }
        public string SquareMeters { get; set; }
        public string NumberOfBathroom { get; set; }
        public string NumberOfLivingRoom { get; set; }
        public string Description { get; set; }
        public int? BuildingId { get; set; }
        public BuildingViewModel Building { get; set; }
    }
}
