using Okken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken_v2
{
    public class Cubicle_70_M : ICubicle
    {
        public string Name => "70-M";

        public bool IsContainDistribution => false;

        public bool IsContainMotor => true;

        public bool IsIncomingCubicle => true;

        public bool IsDistributionCubicle => true;

        public bool IsDisconnectable => false;

        public bool IsWithdrawable => true;

        public bool IsFixed => false;

        public bool IsContainSingleNW => false;

        public bool IsContainSingleNT_NS => false;

        public bool IsSpecificApplication => false;

        public bool IsPolifast => false;

        public bool IsPowerFactor => false;

        public bool IsFuse => false;

        public List<int> CurrentsOfBusBar { get; }

        public List<string> TypeOfIncomers { get; }

        public List<string> TypeOfFiders { get; }

        /// <summary>
        /// Конструктор для ячейки
        /// </summary>
        public Cubicle_70_M()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = new List<int>();
            CurrentsOfBusBar.Add(1000);
            CurrentsOfBusBar.Add(2100);

            //Список допустимых типов вводных аппаратов
            TypeOfIncomers = null;

            //Список допустимых типов фидеров
            TypeOfFiders = null;
        }
    }
}
