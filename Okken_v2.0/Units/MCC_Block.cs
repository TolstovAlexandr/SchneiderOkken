using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Okken
{
    public class MCC_Block : IBlock
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int? NumOfPole { get; set; }
        public string TypeOfBreakingCapacity { get; set; }
        public int? ShortСircuitСurrent { get; set; }
        public double? MinPower { get; set; }
        public double? MaxPower { get; set; }
        public int? NumOfUnit { get; set; }
        public string Description { get; set; }
        public double? PriceOfUnit { get; set; }

        public MCC_Block(string Type,
            string Name,
            int? NumOfPole,
            string TypeOfBreakingCapacity,
            int? ShortСircuitСurrent,
            double? MinPower,
            double? MaxPower,
            int? NumOfUnit,
            string Description,
            double? PriceOfUnit)
        {
            this.Type = Type;
            this.Name = Name;
            this.NumOfPole = NumOfPole;
            this.TypeOfBreakingCapacity = TypeOfBreakingCapacity;
            this.ShortСircuitСurrent = ShortСircuitСurrent;
            this.MinPower = MinPower;
            this.MaxPower = MaxPower;
            this.NumOfUnit = NumOfUnit;
            this.Description = Description;
            this.PriceOfUnit = PriceOfUnit;
        }
    }
}
