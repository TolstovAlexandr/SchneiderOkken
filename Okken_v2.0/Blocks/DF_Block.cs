using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class DF_Block : ICloneable, IBlock
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int? Current { get; set; }
        public int? NumOfPole { get; set; }
        public string TypeOfBreakingCapacity { get; set; }
        public int? ShortСircuitСurrent { get; set; }
        public int? NumOfUnit { get; set; }
        public string Description { get; set; }
        public double? PriceOfUnit { get; set; }

        public DF_Block(string Type,
            string Name,
            int? Current,
            int? NumOfPole,
            string TypeOfBreakingCapacity,
            int? ShortСircuitСurrent,
            int? NumOfUnit,
            string Description,
            double? PriceOfUnit)
        {
            this.Type = Type;
            this.Name = Name;
            this.Current = Current;
            this.NumOfPole = NumOfPole;
            this.TypeOfBreakingCapacity = TypeOfBreakingCapacity;
            this.ShortСircuitСurrent = ShortСircuitСurrent;
            this.NumOfUnit = NumOfUnit;
            this.Description = Description;
            this.PriceOfUnit = PriceOfUnit;
        }

        public object Clone()
        {
            return new DF_Block(Type, Name, Current, NumOfPole, TypeOfBreakingCapacity, ShortСircuitСurrent, NumOfUnit, Description, PriceOfUnit);
        }

        public override string ToString()
        {
            string fullName = Name + TypeOfBreakingCapacity + "_" + NumOfPole + "P" + "_" + Current + "A" + "_" + ShortСircuitСurrent + "кА";
            return fullName;
        }
    }
}
