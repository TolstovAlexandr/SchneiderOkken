using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class PFC_Unit : IUnit
    {
        public string Type { get; set; }
        public double? Power { get; set; } //Мощность конденсаторной установки
        public int? NumOfUnit { get; set; }
        public string Description { get; set; }
        public double? PriceOfUnit { get; set; }

        public PFC_Unit(string Type,
            double? Power,
            int? NumOfUnit,
            string Description,
            double? PriceOfUnit)
        {
            this.Type = Type;
            this.Power = Power;
            this.NumOfUnit = NumOfUnit;
            this.Description = Description;
            this.PriceOfUnit = PriceOfUnit;
        }
    }
}
