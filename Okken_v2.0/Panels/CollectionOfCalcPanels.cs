using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Okken
{
    public class CollectionOfCalcPanels
    {
        Base @base;
        public CollectionOfCalcPanels()
        {
            PanelList = new ObservableCollection<CalcPanel>();
        }

        public CollectionOfCalcPanels(ref Base @base):this()
        {
            this.@base = @base;
        }

        /// <summary>
        /// Коллекция панелей
        /// </summary>
        public ObservableCollection<CalcPanel> PanelList { get; set; }
    }
}
