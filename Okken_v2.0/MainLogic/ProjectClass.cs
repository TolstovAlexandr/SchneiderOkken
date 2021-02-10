using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class ProjectClass
    {
        public List<Sheeld> sheelds { get; set; }

        private Base @base;

        /// <summary>
        /// Коллекция панелей для расчета
        /// </summary>
        private CollectionOfPanels сollectionOfPanels;

        /// <summary>
        /// Передаем в конструкор проекта коллекцию панелей
        /// </summary>
        /// <param name="collectionOfPanels"></param>
        public ProjectClass(ref CollectionOfPanels collectionOfPanels, ref Base @base)
        {
            this.сollectionOfPanels = collectionOfPanels;
            this.@base = @base;

            sheelds = new List<Sheeld>(); //Создаем экзкмпляр списка щитов

            int numOfPanelse = сollectionOfPanels.PanelList.Count;

            for (int i = 0; i < numOfPanelse; i++)
            {
                Panel panel = сollectionOfPanels.PanelList[i];
                Sheeld sheeld = new Sheeld(ref panel, ref @base); //Создаем щит и передаем по ссылке панель и базу
                sheelds.Add(sheeld);
            }

        }
    }
}
