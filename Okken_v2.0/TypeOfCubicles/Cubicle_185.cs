using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Cubicle_185 : ICubicle
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

        public bool IsPowerFactor => false;

        public bool IsFuse => true;

        public List<int> CurrentsOfBusBar { get; }

        public List<string> TypeOfIncomers { get; }

        public List<string> TypeOfFiders { get; }

        /// <summary>
        /// Конструктор для ячейки
        /// </summary>
        public Cubicle_185()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = new List<int>();
            CurrentsOfBusBar.Add(630);
            CurrentsOfBusBar.Add(1500);

            //Список допустимых типов вводных аппаратов
            TypeOfIncomers = null;

            //Список допустимых типов фидеров
            TypeOfFiders = null;
        }
    }
}
