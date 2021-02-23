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
        /// Суммарная стоимость
        /// </summary>
        public double SumPrice { get; set; }

        /// <summary>
        /// Сообщение предупреждение о дерэйтинге
        /// </summary>
        public string Message { get; set; } = "";

        //********************************Номинальные токи с учетом дерэйтинга**************************************************************************************************
        /// <summary>
        /// Для фидера 5000А
        /// </summary>
        public int CurrenOf5000 { get; set; } = 5000;

        /// <summary>
        /// Для фидера 6300А
        /// </summary>
        public int CurrenOf6300 { get; set; } = 6300;

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


        //********************************Секция 1*********************************************************************************************************
        /// <summary>
        /// Стэк колонн 70-2 для секции 1
        /// </summary>
        public Stack<Colomn_70_2> Sect1_stackOfColomns_70_2 { get; set; }
        /// <summary>
        /// Стэк колонн 115 для секции 1
        /// </summary>
        public Stack<Colomn_115> Sect1_stackOfColomns_115 { get; set; }

        //********************************Секция 1*********************************************************************************************************
        /// <summary>
        /// Стэк колонн 70-2 для секции 2
        /// </summary>
        public Stack<Colomn_70_2> Sect2_stackOfColomns_70_2 { get; set; }
        /// <summary>
        /// Стэк колонн 115 для секции 2
        /// </summary>
        public Stack<Colomn_115> Sect2_stackOfColomns_115 { get; set; }

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

            SumNumberOfUnits = 0; //Суммарное количество юнитов
            SumPrice = 0.0; //Суммарная стоимость
            AllBlocks = new List<IBlock>(); //Создаем экземпляр класса списка всех функциональных блоков
            dF_Blocks_Sect1 = new List<DF_Block>(); //Создаем экземпляр класса списка фидерных функциональных блоков для секции 1
            dF_Blocks_Sect2 = new List<DF_Block>(); //Создаем экземпляр класса списка фидерных функциональных блоков для секции 2

            #region Нахождение номинальных (CurrenOf5000, CurrenOf6300) токов самых больших аппаратов (5000А и 6300А) с учетом дирэйтинга и запись сообщения
            List<Derating> deratingCBs = @base.deratngCBs;

            var deratingCB_5000 = (from dCBs in deratingCBs
                                   where dCBs.Name == "NW50"
                                   select dCBs).First();

            var deratingCB_6300 = (from dCBs in deratingCBs
                                   where dCBs.Name == "NW63"
                                   select dCBs).First();

            if (panel.DegreeIP == "IP31")
            {
                if (panel.AmbTemperature == 35)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP31_35C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP31_35C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 40)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP31_40C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP31_40C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 45)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP31_45C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP31_45C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 50)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP31_50C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP31_50C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 55)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP31_55C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP31_55C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
            }
            else if (panel.DegreeIP == "IP41" || panel.DegreeIP == "IP54")
            {
                if (panel.AmbTemperature == 35)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP41_35C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP41_35C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 40)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP41_40C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP41_40C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 45)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP41_45C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP41_45C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 50)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP41_50C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP41_50C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
                else if (panel.AmbTemperature == 55)
                {
                    CurrenOf5000 = (int)deratingCB_5000.RatedСurrent_IP41_55C;
                    CurrenOf6300 = (int)deratingCB_6300.RatedСurrent_IP41_55C;
                    if (CurrenOf5000 < 5000)
                    {
                        CurrenOf5000 = CurrenOf6300;
                    }
                }
            }

            Message += "При: " + panel.DegreeIP + " и " + panel.AmbTemperature + "°C дирэйтинг:\n";
            if (CurrenOf5000 < 5000)
            {
                Message += "Для аппаратов 5000А - " + CurrenOf5000 + "А;\n";
            }
            Message += "Для аппаратов 6300А - " + CurrenOf6300 + "А";
            #endregion

            #region Поиск о добавление фидерных блоков Секция 1 в список dF_Blocks_Sect1 и в AllBlocks            
            AddDFBlocks(panel.Sect1NumOfFider1, 100, 1); //Добавляем фидеры 100А
            AddDFBlocks(panel.Sect1NumOfFider2, 160, 1); //Добавляем фидеры 160А
            AddDFBlocks(panel.Sect1NumOfFider3, 250, 1); //Добавляем фидеры 250А
            AddDFBlocks(panel.Sect1NumOfFider4, 400, 1); //Добавляем фидеры 400А
            AddDFBlocks(panel.Sect1NumOfFider5, 630, 1); //Добавляем фидеры 630А
            AddDFBlocks(panel.Sect1NumOfFider6, 800, 1); //Добавляем фидеры 800А
            AddDFBlocks(panel.Sect1NumOfFider7, 1000, 1); //Добавляем фидеры 1000А
            AddDFBlocks(panel.Sect1NumOfFider8, 1200, 1); //Добавляем фидеры 1200А
            AddDFBlocks(panel.Sect1NumOfFider9, 1600, 1); //Добавляем фидеры 1600А
            AddDFBlocks(panel.Sect1NumOfFider10, 2000, 1); //Добавляем фидеры 2000А
            AddDFBlocks(panel.Sect1NumOfFider11, 2500, 1); //Добавляем фидеры 2500А
            AddDFBlocks(panel.Sect1NumOfFider12, 3200, 1); //Добавляем фидеры 3200А
            AddDFBlocks(panel.Sect1NumOfFider13, 4000, 1); //Добавляем фидеры 4000А
            AddDFBlocks(panel.Sect1NumOfFider14, CurrenOf5000, 1); //Добавляем фидеры 5000А с учетом дирэйтинга
            AddDFBlocks(panel.Sect1NumOfFider15, CurrenOf6300, 1); //Добавляем фидеры 6300А с учетом дирэйтинга

            //Добавляем в общую коллекцию фидеры 100А из секции 1
            foreach (DF_Block item in dF_Blocks_Sect1)
            {
                AllBlocks.Add(item);

                SumNumberOfUnits += (int)item.NumOfUnit; //Считаем суммарное количество занимаемых модулей
                SumPrice += (double)item.PriceOfUnit; //Суммарная стоимость
            }
            #endregion

            #region Поиск о добавление фидерных блоков Секция 2 в список dF_Blocks_Sect2 и в AllBlocks            
            AddDFBlocks(panel.Sect2NumOfFider1, 100, 2); //Добавляем фидеры 100А
            AddDFBlocks(panel.Sect2NumOfFider2, 160, 2); //Добавляем фидеры 160А
            AddDFBlocks(panel.Sect2NumOfFider3, 250, 2); //Добавляем фидеры 250А
            AddDFBlocks(panel.Sect2NumOfFider4, 400, 2); //Добавляем фидеры 400А
            AddDFBlocks(panel.Sect2NumOfFider5, 630, 2); //Добавляем фидеры 630А
            AddDFBlocks(panel.Sect2NumOfFider6, 800, 2); //Добавляем фидеры 800А
            AddDFBlocks(panel.Sect2NumOfFider7, 1000, 2); //Добавляем фидеры 1000А
            AddDFBlocks(panel.Sect2NumOfFider8, 1200, 2); //Добавляем фидеры 1200А
            AddDFBlocks(panel.Sect2NumOfFider9, 1600, 2); //Добавляем фидеры 1600А
            AddDFBlocks(panel.Sect2NumOfFider10, 2000, 2); //Добавляем фидеры 2000А
            AddDFBlocks(panel.Sect2NumOfFider11, 2500, 2); //Добавляем фидеры 2500А
            AddDFBlocks(panel.Sect2NumOfFider12, 3200, 2); //Добавляем фидеры 3200А
            AddDFBlocks(panel.Sect2NumOfFider13, 4000, 2); //Добавляем фидеры 4000А
            AddDFBlocks(panel.Sect2NumOfFider14, CurrenOf5000, 2); //Добавляем фидеры 5000А с учетом дирэйтинга
            AddDFBlocks(panel.Sect2NumOfFider15, CurrenOf6300, 2); //Добавляем фидеры 6300А с учетом дирэйтинга

            //Добавляем в общую коллекцию фидеры 100А из секции 1
            foreach (DF_Block item in dF_Blocks_Sect2)
            {
                AllBlocks.Add(item);

                //Считаем суммарное количество занимаемых модулей
                SumNumberOfUnits += (int)item.NumOfUnit;
            }
            #endregion

            NuberOfBlocks = AllBlocks.Count(); //Считаем общее количество функциональных
        }

        /// <summary>
        /// Поиск фидера по току
        /// </summary>
        /// <param name="RatedСurrent"></param>
        /// <returns></returns>
        public DF_Block FindDF_Blocks(int? RatedСurrent)
        {
            List<DF_Block> units = @base.dF_Units;
            List<Derating> deratingCBs = @base.deratngCBs;

            Derating deratingCB = new Derating();

            if(panel.DegreeIP == "IP31")
            {
                if(panel.AmbTemperature == 35)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP31_35C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP31_35C
                                            select dCBs).First();
                }
                else if(panel.AmbTemperature == 40)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP31_40C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP31_40C
                                            select dCBs).First();
                }
                else if (panel.AmbTemperature == 45)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP31_45C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP31_45C
                                            select dCBs).First();
                }
                else if (panel.AmbTemperature == 50)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP31_50C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP31_50C
                                            select dCBs).First();
                }
                else if (panel.AmbTemperature == 55)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP31_55C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP31_55C
                                            select dCBs).First();
                }
            }
            else if(panel.DegreeIP == "IP41" || panel.DegreeIP == "IP54")
            {
                if (panel.AmbTemperature == 35)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP41_35C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP41_35C
                                            select dCBs).First();
                }
                else if (panel.AmbTemperature == 40)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP41_40C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP41_40C
                                            select dCBs).First();
                }
                else if (panel.AmbTemperature == 45)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP41_45C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP41_45C
                                            select dCBs).First();
                }
                else if (panel.AmbTemperature == 50)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP41_50C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP41_50C
                                            select dCBs).First();
                }
                else if (panel.AmbTemperature == 55)
                {
                    deratingCB = (Derating)(from dCBs in deratingCBs
                                            where dCBs.RatedСurrent_IP41_55C >= RatedСurrent
                                            orderby dCBs.RatedСurrent_IP41_55C
                                            select dCBs).First();
                }
            }

            var unit = from dfunits in units
                       where dfunits.NumOfPole.ToString() + "P" == panel.NumOfPole
                       where dfunits.ShortСircuitСurrent >= panel.ShotCurr
                       where dfunits.Name == deratingCB.Name
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
            if (num > 0)
            {
                if (numOfSect == 1)
                {
                    for (int i = 0; i < num; i++)
                    {
                        dF_Blocks_Sect1.Add(FindDF_Blocks(current));
                    }
                }
                else if (numOfSect == 2)
                {
                    for (int i = 0; i < num; i++)
                    {
                        dF_Blocks_Sect2.Add(FindDF_Blocks(current));
                    }
                }
            }                   
        }
    }
}
