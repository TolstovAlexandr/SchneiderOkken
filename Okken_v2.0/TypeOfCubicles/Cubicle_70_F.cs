using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Cubicle_70_F : ICubicle
    {
        public string Name => "70-2-F";

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

        public bool IsFuse => false;

        public List<int> CurrentsOfBusBar { get; }

        public List<string> TypeOfIncomers { get; }

        public List<string> TypeOfFiders { get; }

        /// <summary>
        /// Конструктор для ячейки
        /// </summary>
        public Cubicle_70_F()
        {
            //Список типов вводных шин
            CurrentsOfBusBar = new List<int>();
            CurrentsOfBusBar.Add(2100);

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

            TypeOfFiders.Add("NSX100");
            TypeOfFiders.Add("NSX160");
            TypeOfFiders.Add("NSX250");
            TypeOfFiders.Add("NSX400");
            TypeOfFiders.Add("NSX630");
        }
    }
}
