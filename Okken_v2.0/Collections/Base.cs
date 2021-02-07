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

        /// <summary>
        /// Список вводных автоматических выключателей
        /// </summary>
        public List<INC_Unit> iNC_Units { get; set; }

        /// <summary>
        /// Список секционных автоматических выключателей
        /// </summary>
        public List<BC_Unit> bC_Units { get; set; }

        /// <summary>
        /// Список фмдерных автоматических выключателей
        /// </summary>
        public List<DF_Unit> dF_Units { get; set; }

        /// <summary>
        /// Список фмдернов MCC
        /// </summary>
        public List<MCC_Unit> mCC_Units { get; set; }

        /// <summary>
        /// Список фмдернов SS
        /// </summary>
        public List<SS_Unit> sS_Units { get; set; }

        /// <summary>
        /// Список фмдернов VSD
        /// </summary>
        public List<VSD_Unit> vSD_Units { get; set; }

        /// <summary>
        /// Список фмдернов PFC
        /// </summary>
        public List<PFC_Unit> pFC_Units { get; set; }

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
                iNC_Units = Get_INC_Units("INC", INC_Sheet);
                bC_Units = Get_BC_Units("BC", BC_Sheet);
                dF_Units = Get_DF_Units("DF", DF_Sheet);
                mCC_Units = Get_MCC_Units("MCC", MCC_Sheet);
                sS_Units = Get_SS_Units("SS", SS_Sheet);
                vSD_Units = Get_VSD_Units("VSD", VSD_Sheet);
                pFC_Units = Get_PFC_Units("PFC", PFC_Sheet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Считывания с Excell Вводных автоматических выключателей
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<INC_Unit> Get_INC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<INC_Unit> Units = new List<INC_Unit>();

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

                Units.Add(new INC_Unit(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, ratedСurrent, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Секционных автоматических выключателей
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<BC_Unit> Get_BC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<BC_Unit> Units = new List<BC_Unit>();

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

                Units.Add(new BC_Unit(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, ratedСurrent, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидерных автоматических выключателей
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<DF_Unit> Get_DF_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<DF_Unit> Units = new List<DF_Unit>();

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

                Units.Add(new DF_Unit(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, ratedСurrent, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров MCC
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<MCC_Unit> Get_MCC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<MCC_Unit> Units = new List<MCC_Unit>();

            string name;
            int? numOfPole;
            string typeOfBreakingCapacity;
            int? shortСircuitСurrent;
            double? minPower;
            double? maxPower;
            int? numOfUnit;
            string description;
            double? priceOfUnit;

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                numOfPole = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                typeOfBreakingCapacity = ExcelWork.ReadString(i, 2, nameOfSheet: nameOfSheet);
                shortСircuitСurrent = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                minPower = ExcelWork.ReadDouble(i, 4, nameOfSheet: nameOfSheet);
                maxPower = ExcelWork.ReadDouble(i, 5, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 6, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 7, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 8, nameOfSheet: nameOfSheet);

                Units.Add(new MCC_Unit(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, minPower, maxPower, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров SS
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<SS_Unit> Get_SS_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<SS_Unit> Units = new List<SS_Unit>();

        string name;
            int? numOfPole;
            int? shortСircuitСurrent;
            int? ratedСurrent;
            double? minPower;
            double? maxPower;
            int? numOfUnit;
            string description;
            double? priceOfUnit;

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                numOfPole = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                shortСircuitСurrent = ExcelWork.ReadInt(i, 2, nameOfSheet: nameOfSheet);
                ratedСurrent = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                minPower = ExcelWork.ReadDouble(i, 4, nameOfSheet: nameOfSheet);
                maxPower = ExcelWork.ReadDouble(i, 5, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 6, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 7, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 8, nameOfSheet: nameOfSheet);

                Units.Add(new SS_Unit(type, name, numOfPole, shortСircuitСurrent, ratedСurrent, minPower, maxPower, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров VSD
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<VSD_Unit> Get_VSD_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<VSD_Unit> Units = new List<VSD_Unit>();

            string name;
            int? numOfPole;
            int? shortСircuitСurrent;
            int? ratedСurrent;
            double? minPower;
            double? maxPower;
            int? numOfUnit;
            string description;
            double? priceOfUnit;

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                numOfPole = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                shortСircuitСurrent = ExcelWork.ReadInt(i, 2, nameOfSheet: nameOfSheet);
                ratedСurrent = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                minPower = ExcelWork.ReadDouble(i, 4, nameOfSheet: nameOfSheet);
                maxPower = ExcelWork.ReadDouble(i, 5, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 6, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 7, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 8, nameOfSheet: nameOfSheet);

                Units.Add(new VSD_Unit(type, name, numOfPole, shortСircuitСurrent, ratedСurrent, minPower, maxPower, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров PFC
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<PFC_Unit> Get_PFC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<PFC_Unit> Units = new List<PFC_Unit>();

            double? Power;
            int? numOfUnit;
            string description;
            double? priceOfUnit;

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                Power = ExcelWork.ReadDouble(i, 0, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 2, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 3, nameOfSheet: nameOfSheet);

                Units.Add(new PFC_Unit(type, Power, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }
    }
}
