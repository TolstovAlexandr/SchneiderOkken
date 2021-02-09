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
        /// <summary>
        /// Коллекция панелей
        /// </summary>
        public ObservableCollection<CalcPanel> PanelList { get; set; }
    }
}
