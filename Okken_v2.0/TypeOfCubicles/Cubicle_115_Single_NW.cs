using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Cubicle_115_Single_NW : ICubicle
    {
        public string Name => "115";

        public bool IsContainDistribution => true;

        public bool IsContainMotor => false;

        public bool IsIncomingCubicle => false;

        public bool IsDistributionCubicle => false;

        public bool IsDisconnectable => true;

        public bool IsWithdrawable => true;

        public bool IsFixed => false;

        public bool IsContainSingleNW => true;

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
        public Cubicle_115_Single_NW()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = new List<int>();
            CurrentsOfBusBar.Add(1600);
            CurrentsOfBusBar.Add(3200);

            //Список допустимых типов вводных аппаратов
            TypeOfIncomers = new List<string>();

            TypeOfIncomers.Add("NW08");
            TypeOfIncomers.Add("NW10");
            TypeOfIncomers.Add("NW12");
            TypeOfIncomers.Add("NW16");
            TypeOfIncomers.Add("NW20");
            TypeOfIncomers.Add("NW25");
            TypeOfIncomers.Add("NW32");

            //Список допустимых типов фидеров
            TypeOfFiders = new List<string>();
            TypeOfFiders.Add("NW08");
            TypeOfFiders.Add("NW10");
            TypeOfFiders.Add("NW12");
            TypeOfFiders.Add("NW16");
            TypeOfFiders.Add("NW20");
            TypeOfFiders.Add("NW25");
            TypeOfFiders.Add("NW32");
        }
    }
}
