using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class SS_Unit : IUnit
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int? NumOfPole { get; set; }
        public int? ShortСircuitСurrent { get; set; }
        public int? RatedСurrent { get; set; } //Номинальный ток устройства плавного пуска
        public double? MinPower { get; set; }
        public double? MaxPower { get; set; }
        public int? NumOfUnit { get; set; }
        public string Description { get; set; }
        public double? PriceOfUnit { get; set; }

        public SS_Unit(string Type,
            string Name,
            int? NumOfPole,
            int? ShortСircuitСurrent,
            int? RatedСurrent,
            double? MinPower,
            double? MaxPower,
            int? NumOfUnit,
            string Description,
            double? PriceOfUnit)
        {
            this.Type = Type;
            this.Name = Name;
            this.NumOfPole = NumOfPole;
            this.ShortСircuitСurrent = ShortСircuitСurrent;
            this.RatedСurrent = RatedСurrent;
            this.MinPower = MinPower;
            this.MaxPower = MaxPower;
            this.NumOfUnit = NumOfUnit;
            this.Description = Description;
            this.PriceOfUnit = PriceOfUnit;
        }
    }
}
