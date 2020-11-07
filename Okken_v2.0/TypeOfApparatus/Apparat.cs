using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Apparat
    {
        private string name;
        /// <summary>
        /// Наименование аппарата
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string type;
        /// <summary>
        /// Тип аппарата
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private int numOfPole;
        /// <summary>
        /// Количество полюсов
        /// </summary>
        public int NumOfPole
        {
            get { return numOfPole; }
            set { numOfPole = value; }
        }

        private string maxBusbarCurrent;
        /// <summary>
        /// Максимальный номинальный ток вертикальных шин
        /// </summary>
        public string MaxBusbarCurrent
        {
            get { return maxBusbarCurrent; }
            set { maxBusbarCurrent = value; }
        }

        private string typeOfVertBasbar;
        /// <summary>
        /// Тип вертикальных шин
        /// </summary>
        public string TypeOfVertBasbar
        {
            get { return typeOfVertBasbar; }
            set { typeOfVertBasbar = value; }
        }

        private string maxNumOfDivice_RC;
        /// <summary>
        /// Максимальное кол-во устройств для подсоединения типа RC
        /// </summary>
        public string MaxNumOfDivice_RC
        {
            get { return maxNumOfDivice_RC; }
            set { maxNumOfDivice_RC = value; }
        }

        private string maxNumOfDivice_TDC;
        /// <summary>
        /// Максимальное кол-во устройств для подсоединения типа TDC
        /// </summary>
        public string MaxNumOfDivice_TDC
        {
            get { return maxNumOfDivice_TDC; }
            set { maxNumOfDivice_TDC = value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="current">Номинальный ток аппарата</param>
        /// <param name="typeOfCost">Тип стоимости: Hight/Midle/Low (ценовая политика)</param>
        /// <param name="typeOfConnection">Тип подсоединения: Шинопровод/Кабель</param>
        public Apparat(int current, int shotCurr, string withdraw, string typeOfCost)
        {

        }
    }
}
