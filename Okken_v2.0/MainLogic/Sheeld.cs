using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Sheeld
    {
        public Panel panel;
        public Base @base;

        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование щита
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество функциональных блоков
        /// </summary>
        public int NuberOfBlocks { get; set; }

        /// <summary>
        /// Суммарное количество занимаемых юнитов
        /// </summary>
        public int SumNumberOfUnits { get; set; }

        /// <summary>
        /// Все юниты в шкафу
        /// </summary>
        public List<IBlock> AllBlocks;

        /// <summary>
        /// Список DF юнитов секции 1
        /// </summary>
        public List<DF_Block> dF_Blocks_Sect1;

        /// <summary>
        /// Список DF юнитов секции 2
        /// </summary>
        public List<DF_Block> dF_Blocks_Sect2;

        //********************************Приватные поля**************************************************************************************************
        //private int CurrenOfFider1 { get; } = 100;
        //private int CurrenOfFider2 { get; } = 160;
        //private int CurrenOfFider3 { get; } = 250;
        //private int CurrenOfFider4 { get; } = 400;
        //private int CurrenOfFider5 { get; } = 630;
        //private int CurrenOfFider6 { get; } = 800;
        //private int CurrenOfFider7 { get; } = 1000;
        //private int CurrenOfFider8 { get; } = 1200;
        //private int CurrenOfFider9 { get; } = 1600;
        //private int CurrenOfFider10 { get; } = 2000;
        //private int CurrenOfFider11 { get; } = 2500;
        //private int CurrenOfFider12 { get; } = 3200;
        //private int CurrenOfFider13 { get; } = 4000;
        //private int CurrenOfFider14 { get; } = 5000;
        //private int CurrenOfFider15 { get; } = 6300;

        ////Количество фидеров секция 1
        //public int Sect1NumOfFider1 { get; set; }
        //public int Sect1NumOfFider2 { get; set; }
        //public int Sect1NumOfFider3 { get; set; }
        //public int Sect1NumOfFider4 { get; set; }
        //public int Sect1NumOfFider5 { get; set; }
        //public int Sect1NumOfFider6 { get; set; }
        //public int Sect1NumOfFider7 { get; set; }
        //public int Sect1NumOfFider8 { get; set; }
        //public int Sect1NumOfFider9 { get; set; }
        //public int Sect1NumOfFider10 { get; set; }
        //public int Sect1NumOfFider11 { get; set; }
        //public int Sect1NumOfFider12 { get; set; }
        //public int Sect1NumOfFider13 { get; set; }
        //public int Sect1NumOfFider14 { get; set; }
        //public int Sect1NumOfFider15 { get; set; }

        ////Количество фидеров секция 2
        //public int Sect2NumOfFider1 { get; set; }
        //public int Sect2NumOfFider2 { get; set; }
        //public int Sect2NumOfFider3 { get; set; }
        //public int Sect2NumOfFider4 { get; set; }
        //public int Sect2NumOfFider5 { get; set; }
        //public int Sect2NumOfFider6 { get; set; }
        //public int Sect2NumOfFider7 { get; set; }
        //public int Sect2NumOfFider8 { get; set; }
        //public int Sect2NumOfFider9 { get; set; }
        //public int Sect2NumOfFider10 { get; set; }
        //public int Sect2NumOfFider11 { get; set; }
        //public int Sect2NumOfFider12 { get; set; }
        //public int Sect2NumOfFider13 { get; set; }
        //public int Sect2NumOfFider14 { get; set; }
        //public int Sect2NumOfFider15 { get; set; }

        //********************************Секция 1*********************************************************************************************************
        public Stack<Colomn_70_2> Sect1_stackOfColomns_70_2 { get; set; } //Стэк колонн 70-2 для секции 1
        public Stack<Colomn_115> Sect1_stackOfColomns_115 { get; set; } //Стэк колонн 115 для секции 1

        //********************************Секция 1*********************************************************************************************************
        public Stack<Colomn_70_2> Sect2_stackOfColomns_70_2 { get; set; } //Стэк колонн 70-2 для секции 2
        public Stack<Colomn_115> Sect2_stackOfColomns_115 { get; set; } //Стэк колонн 115 для секции 2

        /// <summary>
        /// Конструктор для щита - здесь будет происходить основная магия расчета ***************************************************************************
        /// </summary>
        /// <param name="panel">ссылка на панель</param>
        /// <param name="base">ссылка на базу</param>
        public Sheeld(ref Panel panel, ref Base @base)
        {
            Sect1_stackOfColomns_70_2 = new Stack<Colomn_70_2>();

            this.Id = panel.Id;
            this.Name = panel.Name;

            this.panel = panel;
            this.@base = @base;

            SumNumberOfUnits = 0;

            AllBlocks = new List<IBlock>();
            dF_Blocks_Sect1 = new List<DF_Block>();
            dF_Blocks_Sect2 = new List<DF_Block>();

            //Добавляем в коллекцию фидеры 100А из секции 1
            AddDFBlocks(panel.Sect1NumOfFider1, 100, 1);

            //Добавляем в общую коллекцию фидеры 100А из секции 1
            foreach (DF_Block item in dF_Blocks_Sect1)
            {
                AllBlocks.Add(item);

                //Считаем суммарное количество занимаемых модулей
                SumNumberOfUnits += (int)item.NumOfUnit;
            }

            
            NuberOfBlocks = AllBlocks.Count();
        }

        /// <summary>
        /// Поиск фидера по току
        /// </summary>
        /// <param name="RatedСurrent"></param>
        /// <returns></returns>
        public DF_Block FindDF_Blocks(int? RatedСurrent)
        {
            List<DF_Block> units = @base.dF_Units;

            var unit = from dfunits in units
                       where dfunits.NumOfPole.ToString() + "P" == panel.NumOfPole
                       where dfunits.ShortСircuitСurrent >= panel.ShotCurr
                       where dfunits.RatedСurrent == RatedСurrent
                       orderby dfunits.ShortСircuitСurrent
                       select dfunits;

            DF_Block baseUnit = (DF_Block)unit.First();

            return (DF_Block)baseUnit.Clone();
        }

        /// <summary>
        /// Функция добавления DF фидеров список фидеров секции 1
        /// </summary>
        /// <param name="num">Количество</param>
        /// <param name="current">Номинальный ток</param>
        /// <param name="numOfSect">Номер секции</param>
        public void AddDFBlocks(int num, int current, int numOfSect)
        {
            if(numOfSect == 1)
            {
                for (int i = 0; i < num; i++)
                {
                    dF_Blocks_Sect1.Add(FindDF_Blocks(current));
                }
            }else if(numOfSect == 2)
            {
                for (int i = 0; i < num; i++)
                {
                    dF_Blocks_Sect2.Add(FindDF_Blocks(current));
                }
            }
            
        }
    }
}
