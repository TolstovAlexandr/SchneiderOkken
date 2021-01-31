using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    class Unit
    {
        public string Type { get; }
        public string Name { get; set; }
        public int? NumOfPole { get; set; }
        public string TypeOfBreakingCapacity { get; set; }
        public int? ShortСircuitСurrent { get; set; }
        public int? RatedСurrent { get; set; }
        public int? NumOfUnit { get; set; }
        public string Description { get; set; }
        public double? PriceOfUnit { get; set; }
    }
}
