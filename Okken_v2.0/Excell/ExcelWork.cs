using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Cells;

namespace Okken
{
    public class ExcelWork
    {
        public Workbook tmpWorkbook { get; set; }

        public Workbook workbook { get; set; }

        public string nameOfSheet { get; set; }

        public string message { get; set; }

        //Временный конструктор, потом удалить
        public ExcelWork()
        {
        }

        /// <summary>
        /// Конструктор с указанием пути к файлу
        /// </summary>
        /// <param name="pathToExcel">Путь к файлу</param>
        public ExcelWork(string pathToExcel)
        {
            FileStream fileStream = new FileStream(pathToExcel, FileMode.Open);
            tmpWorkbook = new Workbook(fileStream);
            workbook = new Workbook();
            workbook.Copy(tmpWorkbook);
            fileStream.Close();
        }

        /// <summary>
        /// Функция замены файля excel
        /// </summary>
        /// <param name="path"></param>
        public void ChangeFile(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            tmpWorkbook = new Workbook(fileStream);
            workbook = new Workbook();
            workbook.Copy(tmpWorkbook);
            fileStream.Close();
        }

        /// <summary>
        /// Функция получения листа по имени
        /// </summary>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public Worksheet GetWorksheet(string nameOfSheet)
        {
            return workbook.Worksheets[nameOfSheet];
        }

        /// <summary>
        /// Функция считывания строкового значения ячейки
        /// </summary>
        /// <param name="cell">Имя ячейки (например "A1")</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public string ReadString(string cell, string nameOfSheet)
        {
            Worksheet worksheet = GetWorksheet(nameOfSheet);
            Cell tmcell = worksheet.Cells[cell];

            string value = "";

            if (tmcell != null)
            {
                value = (tmcell.Value)?.ToString();
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">номер ряда</param>
        /// <param name="col">номер столбца</param>
        /// <param name="nameOfShee">Имя листа</param>
        /// <returns></returns>
        public string ReadString(int row, int col, string nameOfSheet)
        {
            Worksheet worksheet = GetWorksheet(nameOfSheet);
            Cell cell = worksheet.Cells.GetCell(row, col);

            string value = "";

            if (cell != null)
            {
                value = (cell.Value)?.ToString();
            }
            return value;
        }

        /// <summary>
        /// Функция считывания значения Double
        /// </summary>
        /// <param name="cell">Имя ячейки (например "A1")</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public double? ReadDouble(string cell, string nameOfSheet)
        {
            double? value;
            object val = GetWorksheet(nameOfSheet).Cells[cell].Value;
            if (val == null || val?.ToString() == "" || val?.ToString() == "#N/A")
            {
                value = null;
            }
            else
            {
                value = Convert.ToDouble(val);
            }
            return value;
        }

        /// <summary>
        /// Функция считывания значения Double
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <param name="col">Номер столбца</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public double? ReadDouble(int row, int col, string nameOfSheet)
        {
            Worksheet worksheet = GetWorksheet(nameOfSheet);
            Cell cell = worksheet.Cells.GetCell(row, col);

            double? value;

            if (cell == null || (cell.Value)?.ToString() == "" || (cell.Value)?.ToString() == "#N/A")
            {
                value = null;
            }
            else
            {
                value = Convert.ToDouble((cell.Value)?.ToString());
            }
            return value;
        }

        /// <summary>
        /// Функция считывания значения Int
        /// </summary>
        /// <param name="cell">Имя ячейки (например "A1")</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public int? ReadInt(string cell, string nameOfSheet)
        {
            int? value;
            int trval;
            object val = GetWorksheet(nameOfSheet).Cells[cell].Value;
            if (val == null || val?.ToString() == "" || val?.ToString() == "#N/A")
            {
                value = null;
            }
            else
            {
                if (int.TryParse(val?.ToString(), out trval))
                    value = trval;
                else value = null;
            }
            return value;
        }

        /// <summary>
        /// Функция считывания значения Int
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <param name="col">Номер столбца</param>
        /// <param name="nameOfSheet">Имя листа</param>
        /// <returns></returns>
        public int? ReadInt(int row, int col, string nameOfSheet)
        {
            Worksheet worksheet = GetWorksheet(nameOfSheet);
            Cell cell = worksheet.Cells.GetCell(row, col);

            int? value;
            int trval;

            if (cell == null || (cell.Value)?.ToString() == "" || (cell.Value)?.ToString() == "#N/A")
            {
                value = null;
            }
            else
            {
                if (int.TryParse((cell.Value)?.ToString(), out trval))
                    value = trval;
                else value = null;
            }
            return value;
        }
    }
}
