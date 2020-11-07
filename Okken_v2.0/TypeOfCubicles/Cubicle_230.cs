using Okken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Cubicle_230 : ICubicle
    {
        public string Name => "230";

        public bool IsContainDistribution => true;

        public bool IsContainMotor => false;

        public bool IsIncomingCubicle => true;

        public bool IsDistributionCubicle => true;

        public bool IsDisconnectable => true;

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
        public Cubicle_230()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = new List<int>();
            CurrentsOfBusBar.Add(4500);
            CurrentsOfBusBar.Add(7300);

            //Список допустимых типов вводных аппаратов
            TypeOfIncomers = new List<string>();
            TypeOfIncomers.Add("NW40b");
            TypeOfIncomers.Add("NW63b");

            //Список допустимых типов фидеров
            TypeOfFiders = new List<string>();
            TypeOfFiders.Add("NW40b");
            TypeOfFiders.Add("NW63b");
        }
    }
}
