using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public interface IBlock
    {
        string Type { get; set; }
        int? NumOfUnit { get; set; }
        string Description { get; set; }
        double? PriceOfUnit { get; set; }
    }
}
