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
        public List<INC_Block> iNC_Blocks { get; set; }

        /// <summary>
        /// Список секционных автоматических выключателей
        /// </summary>
        public List<BC_Block> bC_Blocks { get; set; }

        /// <summary>
        /// Список фмдерных автоматических выключателей
        /// </summary>
        public List<DF_Block> dF_Blocks { get; set; }

        /// <summary>
        /// Список фмдернов MCC
        /// </summary>
        public List<MCC_Block> mCC_Blocks { get; set; }

        /// <summary>
        /// Список фмдернов SS
        /// </summary>
        public List<SS_Block> sS_Blocks { get; set; }

        /// <summary>
        /// Список фмдернов VSD
        /// </summary>
        public List<VSD_Block> vSD_Blocks { get; set; }

        /// <summary>
        /// Список фмдернов PFC
        /// </summary>
        public List<PFC_Block> pFC_Blocks { get; set; }

        /// <summary>
        /// Список автоматических выключателей с дерайтингом
        /// </summary>
        public List<Derating> deratngCBs { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pathToExcell">Путь к файлу Excell с базой</param>
        /// <param name="INC_Sheet">Имя листа с INC</param>
        /// <param name="BC_Sheet">Имя листа с BC</param>
        /// <param name="DF_Sheet">Имя листа с DF</param>
        /// <param name="MCC_Sheet">Имя листа с MCC</param>
        /// <param name="SS_Sheet">Имя листа с SS</param>
        /// <param name="VSD_Sheet">Имя листа с VSD</param>
        /// <param name="PFC_Sheet">Имя листа с PFC</param>
        /// <param name="derating_Sheet">Имя листа с таблицей дерайтинга</param>
        public Base(string pathToExcell, 
            string INC_Sheet, 
            string BC_Sheet, 
            string DF_Sheet, 
            string MCC_Sheet, 
            string SS_Sheet, 
            string VSD_Sheet,
            string PFC_Sheet,
            string derating_Sheet)
        {
            try
            {
                ExcelWork = new ExcelWork(pathToExcell);
                iNC_Blocks = Get_INC_Blocks("INC", INC_Sheet);
                bC_Blocks = Get_BC_Blocks("BC", BC_Sheet);
                dF_Blocks = Get_DF_Blocks("DF", DF_Sheet);
                mCC_Blocks = Get_MCC_Blocks("MCC", MCC_Sheet);
                sS_Blocks = Get_SS_Blocks("SS", SS_Sheet);
                vSD_Blocks = Get_VSD_Blocks("VSD", VSD_Sheet);
                pFC_Blocks = Get_PFC_Blocks("PFC", PFC_Sheet);
                deratngCBs = Get_DeratngCBs(derating_Sheet);
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
        public List<INC_Block> Get_INC_Blocks(string type, string nameOfSheet)
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
        public List<BC_Block> Get_BC_Blocks(string type, string nameOfSheet)
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
        public List<DF_Block> Get_DF_Blocks(string type, string nameOfSheet)
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

                Units.Add(new DF_Block(type, name, 0, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров MCC
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<MCC_Block> Get_MCC_Blocks(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<MCC_Block> Units = new List<MCC_Block>();

            string name;
            int? numOfPole;
            string typeOfBreakingCapacity;
            int? shortСircuitСurrent;
            double? power;
            string degreeOfProtection;
            int? temperature;
            int? numOfUnit;
            string description;
            double? priceOfUnit;

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                numOfPole = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                typeOfBreakingCapacity = ExcelWork.ReadString(i, 2, nameOfSheet: nameOfSheet);
                shortСircuitСurrent = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                power = ExcelWork.ReadDouble(i, 4, nameOfSheet: nameOfSheet);
                degreeOfProtection = ExcelWork.ReadString(i, 5, nameOfSheet: nameOfSheet);
                temperature = ExcelWork.ReadInt(i, 6, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 7, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 8, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 9, nameOfSheet: nameOfSheet);

                Units.Add(new MCC_Block(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, power, degreeOfProtection, temperature, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров SS
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<SS_Block> Get_SS_Blocks(string type, string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<SS_Block> Units = new List<SS_Block>();

            string name;
            int? numOfPole;
            string typeOfBreakingCapacity;
            int? shortСircuitСurrent;
            int? ratedСurrent;
            double? power;
            string degreeOfProtection;
            int? temperature;
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
                power = ExcelWork.ReadDouble(i, 5, nameOfSheet: nameOfSheet);
                degreeOfProtection = ExcelWork.ReadString(i, 6, nameOfSheet: nameOfSheet);
                temperature = ExcelWork.ReadInt(i, 7, nameOfSheet: nameOfSheet);
                numOfUnit = ExcelWork.ReadInt(i, 8, nameOfSheet: nameOfSheet);
                description = ExcelWork.ReadString(i, 9, nameOfSheet: nameOfSheet);
                priceOfUnit = ExcelWork.ReadDouble(i, 10, nameOfSheet: nameOfSheet);

                Units.Add(new SS_Block(type, name, numOfPole, typeOfBreakingCapacity, shortСircuitСurrent, ratedСurrent, power, degreeOfProtection, temperature, numOfUnit, description, priceOfUnit));
            }
            return Units;
        }

        /// <summary>
        /// Считывания с Excell Фидеров VSD
        /// </summary>
        /// <param name="type">Тип юнита</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<VSD_Block> Get_VSD_Blocks(string type, string nameOfSheet)
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
        public List<PFC_Block> Get_PFC_Blocks(string type, string nameOfSheet)
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

        /// <summary>
        /// Считывание с Excell таблицы дерэйтинга
        /// </summary>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public List<Derating> Get_DeratngCBs(string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            List<Derating> deratngCBs = new List<Derating>();

            string name; //Имя блока(автомата)
            //IP31
            int? ratedСurrent_IP31_35C; //Номинальный ток при IP31_35C
            int? ratedСurrent_IP31_40C; //Номинальный ток при IP31_40C
            int? ratedСurrent_IP31_45C; //Номинальный ток при IP31_45C
            int? ratedСurrent_IP31_50C; //Номинальный ток при IP31_50C
            int? ratedСurrent_IP31_55C; //Номинальный ток при IP31_55C

            //IP41
            int? ratedСurrent_IP41_35C; //Номинальный ток при IP41_35C
            int? ratedСurrent_IP41_40C; //Номинальный ток при IP41_40C
            int? ratedСurrent_IP41_45C; //Номинальный ток при IP41_45C
            int? ratedСurrent_IP41_50C; //Номинальный ток при IP41_50C
            int? ratedСurrent_IP41_55C; //Номинальный ток при IP41_55C

            for (int i = 3; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                ratedСurrent_IP31_35C = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                ratedСurrent_IP31_40C = ExcelWork.ReadInt(i, 2, nameOfSheet: nameOfSheet);
                ratedСurrent_IP31_45C = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                ratedСurrent_IP31_50C = ExcelWork.ReadInt(i, 4, nameOfSheet: nameOfSheet);
                ratedСurrent_IP31_55C = ExcelWork.ReadInt(i, 5, nameOfSheet: nameOfSheet);

                ratedСurrent_IP41_35C = ExcelWork.ReadInt(i, 6, nameOfSheet: nameOfSheet);
                ratedСurrent_IP41_40C = ExcelWork.ReadInt(i, 7, nameOfSheet: nameOfSheet);
                ratedСurrent_IP41_45C = ExcelWork.ReadInt(i, 8, nameOfSheet: nameOfSheet);
                ratedСurrent_IP41_50C = ExcelWork.ReadInt(i, 9, nameOfSheet: nameOfSheet);
                ratedСurrent_IP41_55C = ExcelWork.ReadInt(i, 10, nameOfSheet: nameOfSheet);


                deratngCBs.Add(new Derating(name, 
                    ratedСurrent_IP31_35C, ratedСurrent_IP31_40C, ratedСurrent_IP31_45C, ratedСurrent_IP31_50C, ratedСurrent_IP31_55C,
                    ratedСurrent_IP41_35C, ratedСurrent_IP41_40C, ratedСurrent_IP41_45C, ratedСurrent_IP41_50C, ratedСurrent_IP41_55C));
            }
            return deratngCBs;
        }
    }
}
