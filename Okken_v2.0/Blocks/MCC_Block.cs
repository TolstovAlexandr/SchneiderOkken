using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Okken
{
    public class MCC_Block : ICloneable, IBlock
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int? NumOfPole { get; set; }
        public string TypeOfBreakingCapacity { get; set; }
        public int? ShortСircuitСurrent { get; set; }
        public double? Power { get; set; }
        public string DegreeOfProtection { get; set; }
        public int? Temperature { get; set; }
        public int? NumOfUnit { get; set; }
        public string Description { get; set; }
        public double? PriceOfUnit { get; set; }

        public MCC_Block(string Type,
            string Name,
            int? NumOfPole,
            string TypeOfBreakingCapacity,
            int? ShortСircuitСurrent,
            double? Power,
            string DegreeOfProtection,
            int? Temperature,
            int? NumOfUnit,
            string Description,
            double? PriceOfUnit)
        {
            this.Type = Type;
            this.Name = Name;
            this.NumOfPole = NumOfPole;
            this.TypeOfBreakingCapacity = TypeOfBreakingCapacity;
            this.ShortСircuitСurrent = ShortСircuitСurrent;
            this.Power = Power;
            this.DegreeOfProtection = DegreeOfProtection;
            this.Temperature = Temperature;
            this.NumOfUnit = NumOfUnit;
            this.Description = Description;
            this.PriceOfUnit = PriceOfUnit;
        }

        public object Clone()
        {
            return new MCC_Block(Type, Name, NumOfPole, TypeOfBreakingCapacity, ShortСircuitСurrent, Power, DegreeOfProtection, Temperature, NumOfUnit, Description, PriceOfUnit);
        }

        public override string ToString()
        {
            string fullName = Name + TypeOfBreakingCapacity + "_" + NumOfPole + "P" + "_" + Power + "кВт" + "_" + ShortСircuitСurrent + "кА";
            return fullName;
        }
    }
}
