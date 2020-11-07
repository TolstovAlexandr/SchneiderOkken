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

        public List<CB_class> CB_List { get; set; }//Список автоматических выключателей

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
        public Base(string pathToExcell, string nmOfCB_Sheet, string nmOfMCC_Sheet, string nmOfSS_Sheet, string nmOfVSD_Sheet, string nmOfPFC_Sheet, string nmOfCollonsSheet)
        {
            try
            {
                ExcelWork = new ExcelWork(pathToExcell);
                CB_List = GetCB_s(nmOfCB_Sheet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Считывания с Excell Автоматических выключателей
        /// </summary>
        /// <param name="nameOfSheet"></param>
        /// <returns></returns>
        public List<CB_class> GetCB_s(string nameOfSheet)
        {
            worksheet = ExcelWork.GetWorksheet(nameOfSheet);
            numOfRowCB = worksheet.Cells.MaxDataRow;

            //Список аппаратов
            List<CB_class> cB_s = new List<CB_class>();

            string name; //имя
            int? numOfPole; //Количество полюсов
            string type; //Тип устройства
            int? shotCurr; //Ток КЗ
            int? curr; //Номинальный ток
            string typeOfInstall; //Тип установки
            string discr; //Описание
            string articul; //Артикул
            double? price; //Цена

            for (int i = 1; i <= numOfRowCB + 1; i++)
            {
                name = ExcelWork.ReadString(i, 0, nameOfSheet: nameOfSheet);
                numOfPole = ExcelWork.ReadInt(i, 1, nameOfSheet: nameOfSheet);
                type = ExcelWork.ReadString(i, 2, nameOfSheet: nameOfSheet);
                shotCurr = ExcelWork.ReadInt(i, 3, nameOfSheet: nameOfSheet);
                curr = ExcelWork.ReadInt(i, 4, nameOfSheet: nameOfSheet);
                typeOfInstall = ExcelWork.ReadString(i, 5, nameOfSheet: nameOfSheet);
                discr = ExcelWork.ReadString(i, 6, nameOfSheet: nameOfSheet);
                articul = ExcelWork.ReadString(i, 7, nameOfSheet: nameOfSheet);
                price = ExcelWork.ReadDouble(i, 8, nameOfSheet: nameOfSheet);

                cB_s.Add(new CB_class(name, numOfPole, type, shotCurr, curr, typeOfInstall, discr, articul, price));
            }
            return cB_s;
        }
    }
}
