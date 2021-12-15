using AspnetRun.Application.Models.Base;

namespace AspnetRun.Application.Models
{
    public class BuildingModel : BaseModel
    {
        public string BuildingName { get; set; }
        public string Location { get; set; }
        public string NumberOfFloors { get; set; }
        public string Description { get; set; }
        public string BuildingAge { get; set; }
        public int BuildingPrice { get; set; }
    }
}
