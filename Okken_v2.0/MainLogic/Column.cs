using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string LocationOfInputs { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int TotalNumOfModuls { get; set; }
        public int RestNumOfModuls { get; set; }
        public int BusbarCurrent { get; set; }
        public string Discription { get; set; }
        public string Price { get; set; }

        List<IUnit> FuncUnits { get; set; }
    }
}
