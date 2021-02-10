using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class CollectionOfPanels
    {
        CollectionOfPanels() { }

        Base @base;

        /// <summary>
        /// Коллекция панелей
        /// </summary>
        public ObservableCollection<Panel> PanelList { get; set; }

        private int numOfPanel;
        /// <summary>
        /// Количество панелей
        /// </summary>
        public int NumOfPanel
        {
            get 
            {
                numOfPanel = PanelList.Count;
                return numOfPanel; 
            }
        }

        /// <summary>
        /// Коллекция полюстности
        /// </summary>
        public ObservableCollection<string> NumsOfPole { get; set; }

        /// <summary>
        /// Коллекция типов обслуживания щита
        /// </summary>
        public ObservableCollection<string> TypeOfServices { get; set; }

        /// <summary>
        /// Коллекция типов установки
        /// </summary>
        public ObservableCollection<string> TypesOfInstall { get; set; }

        /// <summary>
        /// Коллекция типов подключения
        /// </summary>
        public ObservableCollection<string> TypeOfConnections { get; set; }
        /// <summary>
        /// Типы автоматизации
        /// </summary>
        public ObservableCollection<string> TypesOfAutomation { get; set; }

        /// <summary>
        /// Коллекция токов КЗ
        /// </summary>
        //public ObservableCollection<int> ShotCurrents { get; set; }

        /// <summary>
        /// Коллекция систем заземления
        /// </summary>
        public ObservableCollection<string> GrSystems { get; set; }

        /// <summary>
        /// Коллекция типов подвода питания
        /// </summary>
        public ObservableCollection<string> PowerSupplys { get; set; }

        /// <summary>
        /// Коллекция типов металлизированного покрытий шин
        /// </summary>
        public ObservableCollection<string> MetalBusCoatings { get; set; }

        /// <summary>
        /// Коллекция типов эпоксидного покрытий шин
        /// </summary>
        public ObservableCollection<string> EpoxyBusCoatings { get; set; }

        /// <summary>
        /// Коллекция типов покраски
        /// </summary>
        public ObservableCollection<string> Paintings { get; set; }

        /// <summary>
        /// Коллекция выбора резерва в %
        /// </summary>
        public ObservableCollection<string> SpaceReserves { get; set; }

        /// <summary>
        /// Коллекция выбора присутствия АВР
        /// </summary>
        public ObservableCollection<string> ATSPresents { get; set; }

        /// <summary>
        /// Коллекция расположения вводов
        /// </summary>
        public ObservableCollection<string> IncomerLocations { get; set; }

        /// <summary>
        /// Коллекция Степеней защиты
        /// </summary>
        public ObservableCollection<string> DegreeIPs { get; set; }

        /// <summary>
        /// Коллекция токов в формате string
        /// </summary>
        public ObservableCollection<string> StringIncomersCurrents { get; set; }

        /// <summary>
        /// Коллекция типов секционного аппарата
        /// </summary>
        public ObservableCollection<string> TypeOfSectApps { get; set; }

        /// <summary>
        /// Коллекция реактивных мощностей
        /// </summary>
        public ObservableCollection<string> CompPowers { get; set; }

        public CollectionOfPanels(ref Base @base)
        {
            this.@base = @base;

            PanelList = new ObservableCollection<Panel>();

            NumsOfPole = new ObservableCollection<string>();
            NumsOfPole.Add("3P");
            NumsOfPole.Add("4P");

            TypeOfServices = new ObservableCollection<string>();
            TypeOfServices.Add("Одностороннее");
            TypeOfServices.Add("Двухстороннее");

            TypesOfInstall = new ObservableCollection<string>();
            TypesOfInstall.Add("Втычной");
            TypesOfInstall.Add("Выкатной");

            TypesOfAutomation = new ObservableCollection<string>();
            TypesOfAutomation.Add("Стандартный");
            TypesOfAutomation.Add("Modbus");
            TypesOfAutomation.Add("Modbus + МЭК-61850");

            //ShotCurrents = new ObservableCollection<int>();
            //ShotCurrents.Add(35);
            //ShotCurrents.Add(42);
            //ShotCurrents.Add(65);
            //ShotCurrents.Add(100);
            //ShotCurrents.Add(150);

            GrSystems = new ObservableCollection<string>();
            GrSystems.Add("TN-C");
            GrSystems.Add("TN-S");
            GrSystems.Add("TN-C-S");

            DegreeIPs = new ObservableCollection<string>();
            DegreeIPs.Add("IP31");
            DegreeIPs.Add("IP41");
            DegreeIPs.Add("IP54");

            PowerSupplys = new ObservableCollection<string>();
            PowerSupplys.Add("Шинопровод");
            PowerSupplys.Add("Кабель");

            MetalBusCoatings = new ObservableCollection<string>();
            MetalBusCoatings.Add("НЕТ");
            MetalBusCoatings.Add("Серебро");
            MetalBusCoatings.Add("Олово");
            MetalBusCoatings.Add("Никель");

            EpoxyBusCoatings = new ObservableCollection<string>();
            EpoxyBusCoatings.Add("ДА");
            EpoxyBusCoatings.Add("НЕТ");

            Paintings = new ObservableCollection<string>();
            Paintings.Add("RAL 9003");
            Paintings.Add("Другой");

            SpaceReserves = new ObservableCollection<string>();
            for (int i = 10; i <= 40; i+=10)
            {
                SpaceReserves.Add(i.ToString());
            }

            ATSPresents = new ObservableCollection<string>();
            ATSPresents.Add("ДА");
            ATSPresents.Add("НЕТ");

            IncomerLocations = new ObservableCollection<string>();
            IncomerLocations.Add("По краям");
            IncomerLocations.Add("В центре");

            TypeOfConnections = new ObservableCollection<string>();
            TypeOfConnections.Add("Сверху");
            TypeOfConnections.Add("Снизу");

            StringIncomersCurrents = new ObservableCollection<string>();
            StringIncomersCurrents.Add("НЕТ");
            //Заполняем из база номинальные токи аппаратов
            foreach (var item in @base.iNC_Units)
            {
                bool flag = false;
                //Исключаем повторение
                foreach (var incomerCurr in StringIncomersCurrents)
                {
                    if (item.RatedСurrent.ToString() == incomerCurr)
                    {
                        flag = true;
                    }
                }
                
                if (flag != true && item.RatedСurrent >= 800)
                    StringIncomersCurrents.Add(item.RatedСurrent.ToString());
                flag = false;
            }

            TypeOfSectApps = new ObservableCollection<string>();
            TypeOfSectApps.Add("АВ");
            TypeOfSectApps.Add("Разъедениетель");

            CompPowers = new ObservableCollection<string>();
            CompPowers.Add("НЕТ");
            CompPowers.Add("12.5");
            CompPowers.Add("25");
            CompPowers.Add("50");
            CompPowers.Add("75");
            CompPowers.Add("100");
            CompPowers.Add("125");
            CompPowers.Add("150");
            CompPowers.Add("200");
            CompPowers.Add("250");
            CompPowers.Add("350");
            CompPowers.Add("500");
            CompPowers.Add("700");
            CompPowers.Add("1000");
        }


        /// <summary>
        /// Добавление панели
        /// </summary>
        /// <param name="panel"></param>
        public void AddPanel(Panel panel)
        {
            PanelList.Add(panel);
            PanelList[NumOfPanel - 1].SetLinkToSelf(this);
        }

        /// <summary>
        /// Установка всем панелям ссылку на себя
        /// </summary>
        /// <param name="collectionOfPanels"></param>
        public void SetLinkToSelf(CollectionOfPanels collectionOfPanels)
        {
            foreach (var item in PanelList)
            {
                item.SetLinkToSelf(collectionOfPanels);
            }
        }
    }
}
