using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Cubicle_VSD : ICubicle
    {
        public string Name => "VSD";

        public bool IsContainDistribution => false;

        public bool IsContainMotor => true;

        public bool IsIncomingCubicle => false;

        public bool IsDistributionCubicle => false;

        public bool IsDisconnectable => false;

        public bool IsWithdrawable => true;

        public bool IsFixed => true;

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
        public Cubicle_VSD()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = null;

            //Список допустимых типов вводных аппаратов
            TypeOfIncomers = null;

            //Список допустимых типов фидеров
            TypeOfFiders = null;
        }
    }
}
