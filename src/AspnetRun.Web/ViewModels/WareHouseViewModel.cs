using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.ViewModels
{
    public class WareHouseViewModel : BaseViewModel
    {
        public string WareHouseName { get; set; }

        public string SquareMeters { get; set; }
        public string Description { get; set; }

        public int? BuildingId { get; set; }
        public BuildingViewModel Building { get; set; }
    }
}
