using Okken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken_v2
{
    public class Cubicle_115 : ICubicle
    {
        public string Name => "115";

        public bool IsContainDistribution => true;

        public bool IsContainMotor => false;

        public bool IsIncomingCubicle => true;

        public bool IsDistributionCubicle => true;

        public bool IsDisconnectable => true;

        public bool IsWithdrawable => true;

        public bool IsFixed => false;

        public bool IsContainOneMasterpact => false;

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
        public Cubicle_115()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = new List<int>();
            CurrentsOfBusBar.Add(1750);
            CurrentsOfBusBar.Add(4000);

            //Список допустимых типов вводных аппаратов
            TypeOfIncomers = new List<string>();
            TypeOfIncomers.Add("NT08");
            TypeOfIncomers.Add("NT10");
            TypeOfIncomers.Add("NT12");
            TypeOfIncomers.Add("NT16");

            TypeOfIncomers.Add("NS800");
            TypeOfIncomers.Add("NS1000");
            TypeOfIncomers.Add("NS1250");
            TypeOfIncomers.Add("NS1600");

            TypeOfIncomers.Add("NW08");
            TypeOfIncomers.Add("NW10");
            TypeOfIncomers.Add("NW12");
            TypeOfIncomers.Add("NW16");
            TypeOfIncomers.Add("NW20");
            TypeOfIncomers.Add("NW25");
            TypeOfIncomers.Add("NW32");
            TypeOfIncomers.Add("NW40");

            //Список допустимых типов фидеров
            TypeOfFiders = new List<string>();
            TypeOfFiders.Add("NT08");
            TypeOfFiders.Add("NT10");
            TypeOfFiders.Add("NT12");
            TypeOfFiders.Add("NT16");

            TypeOfFiders.Add("NS800");
            TypeOfFiders.Add("NS1000");
            TypeOfFiders.Add("NS1250");
            TypeOfFiders.Add("NS1600");

            TypeOfFiders.Add("NW08");
            TypeOfFiders.Add("NW10");
            TypeOfFiders.Add("NW12");
            TypeOfFiders.Add("NW16");
            TypeOfFiders.Add("NW20");
            TypeOfFiders.Add("NW25");
            TypeOfFiders.Add("NW32");
            TypeOfFiders.Add("NW40");
        }
    }
}
