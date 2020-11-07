using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Cubicle_PFC : ICubicle
    {
        public string Name => "PFC";

        public bool IsContainDistribution => true;

        public bool IsContainMotor => false;

        public bool IsIncomingCubicle => false;

        public bool IsDistributionCubicle => false;

        public bool IsDisconnectable => false;

        public bool IsWithdrawable => false;

        public bool IsFixed => true;

        public bool IsContainSingleNW => false;

        public bool IsContainSingleNT_NS => false;

        public bool IsSpecificApplication => false;

        public bool IsPolifast => false;

        public bool IsPowerFactor => true;

        public bool IsFuse => false;

        public List<int> CurrentsOfBusBar { get; }

        public List<string> TypeOfIncomers { get; }

        public List<string> TypeOfFiders { get; }

        /// <summary>
        /// Конструктор для ячейки
        /// </summary>
        public Cubicle_PFC()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = new List<int>();
            CurrentsOfBusBar.Add(2100);

            //Список допустимых типов вводных аппаратов
            TypeOfIncomers = null;

            //Список допустимых типов фидеров
            TypeOfFiders = null;
        }
    }
}
