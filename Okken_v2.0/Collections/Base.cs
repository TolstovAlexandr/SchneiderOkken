using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Okken
{
    public class Base
    {
        /// <summary>
        /// Количество рядов в базе аппаратов
        /// </summary>
        public int numOfRowCB { get; set; }

        ExcelWork ExcelWork { get; set; }
        Worksheet worksheet; //Рабочий лист

        public List<Unit> iNC_Unit { get; set; }//Список вводных автоматических выключателей

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pathToExcell">Путь к файлу Excell с базой</param>
        /// <param name="nmOfCB_Sheet">Имя листа с CB</param>
        /// <param name="nmOfMCC_Sheet">Имя листа с MCC</param>
        /// <param name="nmOfSS_Sheet">Имя листа с SS</param>
        /// <param name="nmOfVSD_Sheet">Имя листа с VSD</param>
        /// <param name="nmOfPFC_Sheet">Имя листа с PFC</param>
        /// <param name="nmOfCollonsSheet">Имя листа с Колоннами</param>
        public Base(string pathToExcell, 
            string INC_Sheet, 
            string BC_Sheet, 
            string DF_Sheet, 
            string MCC_Sheet, 
            string SS_Sheet, 
            string VSD_Sheet,
            string PFC_Sheet)
        {
            try
            {
                ExcelWork = new ExcelWork(pathToExcell);
                iNC_Unit = Get_Unit("INC", INC_Sheet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Считывания с Excell Автоматических выключателей
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<Unit> Get_Unit(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            //Список аппаратов
            List<Unit> Unit = new List<Unit>();

            string name;
            int? numOfPole;
            string typeOfBreakingCapacity;
            int? shortСircuitСurrent;
            int? ratedСurrent;
            int? numOfUnit;
            string description;
            double? priceOfUnit;

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                numOfPole = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                typeOfBreakingCapacity = ExcelWork.ReadString(i, 2, nameOfSheet: nameOfSheet);
                shortСircuitСurrent = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                ratedСurrent = ExcelWork.ReadInt(i, 4, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 5, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 6, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 7, nameOfSheet: nameOfSheet);

                Unit.Add(new Unit(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, ratedСurrent, numOfUnit, description, priceOfUnit));
            }
            return Unit;
        }
    }
}
