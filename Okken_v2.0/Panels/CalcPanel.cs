using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class CalcPanel
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование щита
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество функциональных блоков
        /// </summary>
        public int NuberOfFuncUnits { get; set; }

        /// <summary>
        /// Суммарное количество занимаемых юнитов
        /// </summary>
        public int SumNumberOfUnits { get; set; }
    }
}
