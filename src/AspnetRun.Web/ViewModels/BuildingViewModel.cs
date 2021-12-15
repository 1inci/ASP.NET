using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.ViewModels
{
    public class BuildingViewModel : BaseViewModel
    {
        public string BuildingName { get; set; }
        public string Location { get; set; }
        public string NumberOfFloors { get; set; }
        public string Description { get; set; }
        public string BuildingAge { get; set; }
    }
}
