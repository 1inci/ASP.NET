using AspnetRun.Application.Models.Base;

namespace AspnetRun.Application.Models
{
    public class RoomModel : BaseModel
    {
        public string RoomName { get; set; }
        public string NumberOfBedRoom { get; set; }
        public string SquareMeters { get; set; }
        public string NumberOfBathroom { get; set; }
        public string NumberOfLivingRoom { get; set; }
        public string Description { get; set; }
        public int? BuildingId { get; set; }
        public BuildingModel Building { get; set; }
    }
}
