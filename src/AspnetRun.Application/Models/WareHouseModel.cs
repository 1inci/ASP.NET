using AspnetRun.Application.Models.Base;

namespace AspnetRun.Application.Models
{
    public class WareHouseModel : BaseModel
    {
        public string WareHouseName { get; set; }

        public string SquareMeters { get; set; }
        public string Description { get; set; }

        public int? BuildingId { get; set; }
        public BuildingModel Building { get; set; }
    }
}
