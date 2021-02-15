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
        public List<INC_Block> iNC_Units { get; set; }

        /// <summary>
        /// Список секционных автоматических выключателей
        /// </summary>
        public List<BC_Block> bC_Units { get; set; }

        /// <summary>
        /// Список фмдерных автоматических выключателей
        /// </summary>
        public List<DF_Block> dF_Units { get; set; }

        /// <summary>
        /// Список фмдернов MCC
        /// </summary>
        public List<MCC_Block> mCC_Units { get; set; }

        /// <summary>
        /// Список фмдернов SS
        /// </summary>
        public List<SS_Block> sS_Units { get; set; }

        /// <summary>
        /// Список фмдернов VSD
        /// </summary>
        public List<VSD_Block> vSD_Units { get; set; }

        /// <summary>
        /// Список фмдернов PFC
        /// </summary>
        public List<PFC_Block> pFC_Units { get; set; }

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
        public List<INC_Block> Get_INC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<INC_Block> Units = new List<INC_Block>();

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

                Units.Add(new INC_Block(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, ratedСurrent, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Секционных автоматических выключателей
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<BC_Block> Get_BC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<BC_Block> Units = new List<BC_Block>();

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

                Units.Add(new BC_Block(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, ratedСurrent, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидерных автоматических выключателей
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<DF_Block> Get_DF_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<DF_Block> Units = new List<DF_Block>();

            string name;
            int? numOfPole;
            string typeOfBreakingCapacity;
            int? shortСircuitСurrent;
            int? numOfUnit;
            string description;
            double? priceOfUnit;

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                numOfPole = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                typeOfBreakingCapacity = ExcelWork.ReadString(i, 2, nameOfSheet: nameOfSheet);
                shortСircuitСurrent = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 4, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 5, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 6, nameOfSheet: nameOfSheet);

                Units.Add(new DF_Block(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров MCC
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<MCC_Block> Get_MCC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<MCC_Block> Units = new List<MCC_Block>();

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

                Units.Add(new MCC_Block(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, minPower, maxPower, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров SS
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<SS_Block> Get_SS_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<SS_Block> Units = new List<SS_Block>();

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

                Units.Add(new SS_Block(type, name, numOfPole, shortСircuitСurrent, ratedСurrent, minPower, maxPower, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров VSD
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<VSD_Block> Get_VSD_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<VSD_Block> Units = new List<VSD_Block>();

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

                Units.Add(new VSD_Block(type, name, numOfPole, shortСircuitСurrent, ratedСurrent, minPower, maxPower, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров PFC
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<PFC_Block> Get_PFC_Units(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<PFC_Block> Units = new List<PFC_Block>();

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

                Units.Add(new PFC_Block(type, Power, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }
    }
}
