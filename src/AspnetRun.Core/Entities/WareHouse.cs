using AspnetRun.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
    public class WareHouse : Entity
    {
        public WareHouse()
        { }

        public string WareHouseName { get; set; }

        public int SquareMeters { get; set; }

        public string Description { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }


    }
}
