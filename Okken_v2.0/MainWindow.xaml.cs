using Cells = Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows.Markup;

namespace Okken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Полное имя для сохранения
        string fileNameToSave;
        CollectionOfPanels CollectionOfPanels;
        CollectionOfCalcPanels CollectionOfCalcPanels;
        Base @base;
        ProjectClass projectClass { get; set; } //Переменная содержащая проект для расчета

        DataGridColumn CurrentColumn = null;

        Style IncomerColumnStyle1 = null;
        Style IncomerColumnStyle2 = null;

        static int numOfCol_Inc; //Номер столбца Вводных аппаратов
        static int numOfCol_Sect; //Номер столбца Секционника

        static int numOfCol_Sect1Fider_First; //Номер столбца 1-го фидера секции 1
        static int numOfCol_Sect1Fider_Last; //Номер столбца последнего фидера секции 1

        static int numOfCol_Sect2Fider_First; //Номер столбца 1-го фидера секции 2
        static int numOfCol_Sect2Fider_Last; //Номер столбца последнего фидера секции 2

        static int numOfCol_Sect1MCC_First; //Номер столбца 1-го MCC секции 1
        static int numOfCol_Sect1MCC_Last; //Номер столбца последнего MCC секции 1

        static int numOfCol_Sect2MCC_First; //Номер столбца 1-го MCC секции 2
        static int numOfCol_Sect2MCC_Last; //Номер столбца последнего MCC секции 2

        static int numOfCol_Sect1SS_First; //Номер столбца 1-го SS секции 1
        static int numOfCol_Sect1SS_Last; //Номер столбца последнего SS секции 1

        static int numOfCol_Sect2SS_First; //Номер столбца 1-го SS секции 2
        static int numOfCol_Sect2SS_Last; //Номер столбца последнего SS секции 2

        static int numOfCol_Sect1VSD_First; //Номер столбца 1-го VSD секции 1
        static int numOfCol_Sect1VSD_Last; //Номер столбца последнего VSD секции 1

        static int numOfCol_Sect2VSD_First; //Номер столбца 1-го VSD секции 2
        static int numOfCol_Sect2VSD_Last; //Номер столбца последнего VSD секции 2

        static int numOfCol_PFC; //Номер столбца компенсации

        public MainWindow()
        {

            //------------------------------------------Считывание базы из файла-------------------------------------//

            @base = new Base("Base.xlsx", "INC-Base", "BC-Base", "DF-Base", "MCC-Base", "SS-Base", "VSD-Base", "PFC-Base", "Derating");

            //------------------------------------------Инициализация и основная логика------------------------------------//
            InitializeComponent();

            numOfCol_Inc = MainDataGrid.Columns.IndexOf(INCLocationComboBox);
            numOfCol_Sect = MainDataGrid.Columns.IndexOf(BusTieComboBox);

            numOfCol_Sect1Fider_First = MainDataGrid.Columns.IndexOf(Sect1Fider1Text);
            numOfCol_Sect1Fider_Last = MainDataGrid.Columns.IndexOf(Sect1FiderLastText);

            numOfCol_Sect2Fider_First = MainDataGrid.Columns.IndexOf(Sect2Fider1Text);
            numOfCol_Sect2Fider_Last = MainDataGrid.Columns.IndexOf(Sect2FiderLastText);

            numOfCol_Sect1MCC_First = MainDataGrid.Columns.IndexOf(Sect1MCC1);
            numOfCol_Sect1MCC_Last = MainDataGrid.Columns.IndexOf(Sect1MCC_Last);

            numOfCol_Sect2MCC_First = MainDataGrid.Columns.IndexOf(Sect2MCC1);
            numOfCol_Sect2MCC_Last = MainDataGrid.Columns.IndexOf(Sect2MCC_Last);

            numOfCol_Sect1SS_First = MainDataGrid.Columns.IndexOf(Sect1SS1);
            numOfCol_Sect1SS_Last = MainDataGrid.Columns.IndexOf(Sect1SS_Last);

            numOfCol_Sect2SS_First = MainDataGrid.Columns.IndexOf(Sect2SS1);
            numOfCol_Sect2SS_Last = MainDataGrid.Columns.IndexOf(Sect2SS_Last);

            numOfCol_Sect1VSD_First = MainDataGrid.Columns.IndexOf(Sect1VSD1);
            numOfCol_Sect1VSD_Last = MainDataGrid.Columns.IndexOf(Sect1VSD_Last);

            numOfCol_Sect2VSD_First = MainDataGrid.Columns.IndexOf(Sect2VSD1);
            numOfCol_Sect2VSD_Last = MainDataGrid.Columns.IndexOf(Sect2VSD_Last);

            numOfCol_PFC = MainDataGrid.Columns.IndexOf(Sect1CompPowerComboBox);

            //Устанавливаем столбцы для заголовка
            Grid.SetColumn(IncomersBorder, numOfCol_Inc-3); //Для Вводного на 3 меньше за счет того что первыми тремя столбцами выступают бордеры
            Grid.SetColumnSpan(IncomersBorder, numOfCol_Sect - numOfCol_Inc);

            Grid.SetColumn(BTBorder, numOfCol_Sect - 3); //Для секционника
            Grid.SetColumnSpan(BTBorder, 2); //Объеденяем

            Grid.SetColumn(Sec1FidersBorder, numOfCol_Sect1Fider_First - 3); //Для вводных аппаратов секция 1
            Grid.SetColumnSpan(Sec1FidersBorder, numOfCol_Sect1Fider_Last - numOfCol_Sect1Fider_First + 1); //Объединяем

            Grid.SetColumn(Sec2FidersBorder, numOfCol_Sect2Fider_First - 3); //Для вводных аппаратов секция 2
            Grid.SetColumnSpan(Sec2FidersBorder, numOfCol_Sect2Fider_Last - numOfCol_Sect2Fider_First + 1); //Объединяем

            Grid.SetColumn(FiderBorder, numOfCol_Sect1Fider_First - 3); //Для зоголовка "Отходящие фидеры"
            Grid.SetColumnSpan(FiderBorder, numOfCol_Sect2Fider_Last - numOfCol_Sect1Fider_First + 1); //Объединяем

            Grid.SetColumn(Sec1MCCBorder, numOfCol_Sect1MCC_First - 3); //Для MCC секция 1
            Grid.SetColumnSpan(Sec1MCCBorder, numOfCol_Sect1MCC_Last - numOfCol_Sect1MCC_First + 1); //Объединяем

            Grid.SetColumn(Sec2MCCBorder, numOfCol_Sect2MCC_First - 3); //Для MCC секция 2
            Grid.SetColumnSpan(Sec2MCCBorder, numOfCol_Sect2MCC_Last - numOfCol_Sect2MCC_First + 1); //Объединяем

            Grid.SetColumn(MCCBorder, numOfCol_Sect1MCC_First - 3); //Для зоголовка "Управления двигателями"
            Grid.SetColumnSpan(MCCBorder, numOfCol_Sect2MCC_Last - numOfCol_Sect1MCC_First + 1); //Объединяем

            Grid.SetColumn(Sect1SSBorder, numOfCol_Sect1SS_First - 3); //Для SS секция 1
            Grid.SetColumnSpan(Sect1SSBorder, numOfCol_Sect1SS_Last - numOfCol_Sect1SS_First + 1); //Объединяем

            Grid.SetColumn(Sect2SSBorder, numOfCol_Sect2SS_First - 3); //Для SS секция 2
            Grid.SetColumnSpan(Sect2SSBorder, numOfCol_Sect2SS_Last - numOfCol_Sect2SS_First + 1); //Объединяем

            Grid.SetColumn(SSBorder, numOfCol_Sect1SS_First - 3); //Для зоголовка "Устройства плавного пуска"
            Grid.SetColumnSpan(SSBorder, numOfCol_Sect2SS_Last - numOfCol_Sect1SS_First + 1); //Объединяем

            Grid.SetColumn(Sect1VSDBorder, numOfCol_Sect1VSD_First - 3); //Для VSD секция 1
            Grid.SetColumnSpan(Sect1VSDBorder, numOfCol_Sect1VSD_Last - numOfCol_Sect1VSD_First + 1); //Объединяем

            Grid.SetColumn(Sect2VSDBorder, numOfCol_Sect2VSD_First - 3); //Для VSD секция 2
            Grid.SetColumnSpan(Sect2VSDBorder, numOfCol_Sect2VSD_Last - numOfCol_Sect2VSD_First + 1); //Объединяем

            Grid.SetColumn(VSDBorder, numOfCol_Sect1VSD_First - 3); //Для зоголовка "Частотный преобразователь"
            Grid.SetColumnSpan(VSDBorder, numOfCol_Sect2VSD_Last - numOfCol_Sect1VSD_First + 1); //Объединяем

            Grid.SetColumn(PFCBorder, numOfCol_PFC - 3); //Для PFC секция 1
            Grid.SetColumnSpan(PFCBorder, 2); 


            CollectionOfPanels = new CollectionOfPanels(ref @base);

            Panel newPanel = new Panel
            {
                Id = 1,
                NumOfPole = "3P",
                TypeOfAutomation = "Стандартный",
                TypeOfService = "Одностороннее",
                ShotCurr = 25,
                GrSystem = "TN-S",
                DegreeIP = "IP31",
                AmbTemperature = 35,
                PowerSupply = "Кабель",
                MetalBusCoating = "НЕТ",
                EpoxyBusCoating = "НЕТ",
                Painting = "RAL 9003",
                SpaceReserve = "10",
                ATSPresent = "НЕТ",
                IncomerLocation = "По краям",
                TypeOfConnection = "Сверху",
                StringIncomerCurrent_Sect1 = "НЕТ",
                StringIncomerCurrent_Sect2 = "НЕТ",
                StringIncomerCurrent_Sect3 = "НЕТ",
                StringBustieCurrent = "НЕТ",
                TypeOfSectApp = "АВ",
                StrCompPowerSect1 = "НЕТ",
                StrCompPowerSect2 = "НЕТ"
            };

            CollectionOfPanels.AddPanel(newPanel);

            //------------------------------------------Инициализация таблицы с исходными данными------------------------------------//
            #region Инициализация таблицы с исходными данными

            MainDataGrid.ItemsSource = CollectionOfPanels.PanelList;
            NumsOfPoleComboBox.ItemsSource = CollectionOfPanels.NumsOfPole;
            TypeOfServiceComboBox.ItemsSource = CollectionOfPanels.TypeOfServices;
            TypesOfAutomationlComboBox.ItemsSource = CollectionOfPanels.TypesOfAutomation;
            ShotCurrentsComboBox.ItemsSource = CollectionOfPanels.ShotCurrents;
            GrSystemsComboBox.ItemsSource = CollectionOfPanels.GrSystems;
            DegreeIPComboBox.ItemsSource = CollectionOfPanels.DegreeIPs;
            AmbTemperaturComboBox.ItemsSource = CollectionOfPanels.AmbTemperatures;
            PowerSupplyComboBox.ItemsSource = CollectionOfPanels.PowerSupplys;
            MetalBusCoatingComboBox.ItemsSource = CollectionOfPanels.MetalBusCoatings;
            EpoxyBusCoatingComboBox.ItemsSource = CollectionOfPanels.EpoxyBusCoatings;
            PaintingComboBox.ItemsSource = CollectionOfPanels.Paintings;
            ATSPresentComboBox.ItemsSource = CollectionOfPanels.ATSPresents;
            SpaceReserveComboBox.ItemsSource = CollectionOfPanels.SpaceReserves;
            INCLocationComboBox.ItemsSource = CollectionOfPanels.IncomerLocations;
            INCConnectionComboBox.ItemsSource = CollectionOfPanels.TypeOfConnections;
            INC1ComboBox.ItemsSource = CollectionOfPanels.StringIncomersCurrents;
            INC2ComboBox.ItemsSource = CollectionOfPanels.StringIncomersCurrents;
            INC3ComboBox.ItemsSource = CollectionOfPanels.StringIncomersCurrents;
            BusTieComboBox.ItemsSource = CollectionOfPanels.StringIncomersCurrents;
            TypeOfBusTieComboBox.ItemsSource = CollectionOfPanels.TypeOfSectApps;
            Sect1CompPowerComboBox.ItemsSource = CollectionOfPanels.CompPowers;
            Sect2CompPowerComboBox.ItemsSource = CollectionOfPanels.CompPowers;

            #endregion

            IncomerColumnStyle1 = (Style)MainDataGrid.Resources["IncomerColumnStyle1"];
            IncomerColumnStyle2 = (Style)MainDataGrid.Resources["IncomerColumnStyle2"];

            MainDataGrid.Columns[numOfCol_Sect1Fider_First].CellStyle = IncomerColumnStyle1;
            MainDataGrid.Columns[numOfCol_Sect1Fider_Last].CellStyle = IncomerColumnStyle1;

            MainDataGrid.Columns[numOfCol_Sect2Fider_First].CellStyle = IncomerColumnStyle2;
            MainDataGrid.Columns[numOfCol_Sect2Fider_Last].CellStyle = IncomerColumnStyle2;

            MainDataGrid.Columns[numOfCol_Sect1MCC_First].CellStyle = IncomerColumnStyle1;
            MainDataGrid.Columns[numOfCol_Sect1MCC_Last].CellStyle = IncomerColumnStyle1;

            MainDataGrid.Columns[numOfCol_Sect2MCC_First].CellStyle = IncomerColumnStyle2;
            MainDataGrid.Columns[numOfCol_Sect2MCC_Last].CellStyle = IncomerColumnStyle2;

            MainDataGrid.Columns[numOfCol_Sect1SS_First].CellStyle = IncomerColumnStyle1;
            MainDataGrid.Columns[numOfCol_Sect1SS_Last].CellStyle = IncomerColumnStyle1;

            MainDataGrid.Columns[numOfCol_Sect2SS_First].CellStyle = IncomerColumnStyle2;
            MainDataGrid.Columns[numOfCol_Sect2SS_Last].CellStyle = IncomerColumnStyle2;

            MainDataGrid.Columns[numOfCol_Sect1VSD_First].CellStyle = IncomerColumnStyle1;
            MainDataGrid.Columns[numOfCol_Sect1VSD_Last].CellStyle = IncomerColumnStyle1;

            MainDataGrid.Columns[numOfCol_Sect2VSD_First].CellStyle = IncomerColumnStyle2;
            MainDataGrid.Columns[numOfCol_Sect2VSD_Last].CellStyle = IncomerColumnStyle2;


            //Событие изменения коллекции****************************************************************************************
            CollectionOfPanels.PanelList.CollectionChanged += PanelList_CollectionChanged;


            //ICubicle cubicle_230 = new Cubicle_230();

            //MessageBox.Show(cubicle_230.Name);

            //------------------------------------------Инициализация таблицы с расчетными данными------------------------------------//
            #region Инициализация таблицы с расчетными данными

            CollectionOfCalcPanels = new CollectionOfCalcPanels(ref @base);
            CalcDataGrid.ItemsSource = CollectionOfCalcPanels.PanelList;

            #endregion
        }

        public void RefreshTable()
        {
            int id = 1;
            foreach (var item in CollectionOfPanels.PanelList)
            {
                item.Id = id;
                id++;
            }
            //MainDataGrid.Items.Refresh();
            MainDataGrid.ItemsSource = null;
            MainDataGrid.ItemsSource = CollectionOfPanels.PanelList;
        }

        //Событие изменения таблицы****************************************************************************************
        private void PanelList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CollectionOfPanels.SetLinkToSelf(CollectionOfPanels);
            RefreshTable();
        }

        //Кнопка добавить ряд
        private void AddRowBtn_Click(object sender, RoutedEventArgs e)
        {
            int Lastindex = CollectionOfPanels.NumOfPanel - 1;
            if (Lastindex >= 0)
            {
                Panel newPanel = new Panel
                {
                    NumOfPole = CollectionOfPanels.PanelList[Lastindex].NumOfPole,
                    TypeOfService = CollectionOfPanels.PanelList[Lastindex].TypeOfService,
                    TypeOfAutomation = CollectionOfPanels.PanelList[Lastindex].TypeOfAutomation,
                    ShotCurr = CollectionOfPanels.PanelList[Lastindex].ShotCurr,
                    GrSystem = CollectionOfPanels.PanelList[Lastindex].GrSystem,
                    DegreeIP = CollectionOfPanels.PanelList[Lastindex].DegreeIP,
                    AmbTemperature = CollectionOfPanels.PanelList[Lastindex].AmbTemperature,
                    PowerSupply = CollectionOfPanels.PanelList[Lastindex].PowerSupply,
                    MetalBusCoating = CollectionOfPanels.PanelList[Lastindex].MetalBusCoating,
                    EpoxyBusCoating = CollectionOfPanels.PanelList[Lastindex].EpoxyBusCoating,
                    Painting = CollectionOfPanels.PanelList[Lastindex].Painting,
                    StringIncomerCurrent_Sect1 = CollectionOfPanels.PanelList[Lastindex].StringIncomerCurrent_Sect1,
                    StringIncomerCurrent_Sect2 = CollectionOfPanels.PanelList[Lastindex].StringIncomerCurrent_Sect2,
                    StringIncomerCurrent_Sect3 = CollectionOfPanels.PanelList[Lastindex].StringIncomerCurrent_Sect3,
                    StringBustieCurrent = CollectionOfPanels.PanelList[Lastindex].StringBustieCurrent,
                    SpaceReserve = CollectionOfPanels.PanelList[Lastindex].SpaceReserve,
                    ATSPresent = CollectionOfPanels.PanelList[Lastindex].ATSPresent,
                    IncomerLocation = CollectionOfPanels.PanelList[Lastindex].IncomerLocation,
                    TypeOfConnection = CollectionOfPanels.PanelList[Lastindex].TypeOfConnection,
                    TypeOfSectApp = CollectionOfPanels.PanelList[Lastindex].TypeOfSectApp,
                    StrCompPowerSect1 = CollectionOfPanels.PanelList[Lastindex].StrCompPowerSect1,
                    StrCompPowerSect2 = CollectionOfPanels.PanelList[Lastindex].StrCompPowerSect2
                };

                CollectionOfPanels.AddPanel(newPanel);
            }
            else { CollectionOfPanels.AddPanel(new Panel {
                Id = 1,
                NumOfPole = "3P",
                TypeOfAutomation = "Стандартный",
                TypeOfService = "Одностороннее",
                ShotCurr = 25,
                GrSystem = "TN-S",
                DegreeIP = "IP31",
                AmbTemperature = 35,
                PowerSupply = "Кабель",
                MetalBusCoating = "НЕТ",
                EpoxyBusCoating = "НЕТ",
                Painting = "RAL 9003",
                SpaceReserve = "10",
                ATSPresent = "НЕТ",
                IncomerLocation = "По краям",
                TypeOfConnection = "Сверху",
                StringIncomerCurrent_Sect1 = "НЕТ",
                StringIncomerCurrent_Sect2 = "НЕТ",
                StringIncomerCurrent_Sect3 = "НЕТ",
                StringBustieCurrent = "НЕТ",
                TypeOfSectApp = "АВ",
                StrCompPowerSect1 = "НЕТ",
                StrCompPowerSect2 = "НЕТ"
            }); ; }
        }

        ///Изменение цвета выбранного столбца
        private void MainDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            var dataGrid = (DataGrid)sender;

            int? index;

            index = dataGrid.CurrentCell.Column?.DisplayIndex;

            if (index != null)
            {
                if (index != numOfCol_Sect1Fider_First 
                    && index != numOfCol_Sect1Fider_Last 
                    && index != numOfCol_Sect2Fider_First 
                    && index != numOfCol_Sect2Fider_Last 
                    && index != numOfCol_Sect1MCC_First 
                    && index != numOfCol_Sect1MCC_Last
                    && index != numOfCol_Sect2MCC_First 
                    && index != numOfCol_Sect2MCC_Last 
                    && index != numOfCol_Sect1SS_First 
                    && index != numOfCol_Sect1SS_Last 
                    && index != numOfCol_Sect2SS_First 
                    && index != numOfCol_Sect2SS_First 
                    && index != numOfCol_Sect1VSD_First 
                    && index != numOfCol_Sect1VSD_Last 
                    && index != numOfCol_Sect2VSD_First 
                    && index != numOfCol_Sect2VSD_Last)
                {
                    if (CurrentColumn != null)
                        CurrentColumn.CellStyle = null;

                    CurrentColumn = dataGrid.CurrentColumn;
                    if (CurrentColumn != null)
                        CurrentColumn.CellStyle = (Style)dataGrid.Resources["SelectedColumnStyle"];
                }
                else
                {
                    if (CurrentColumn != null)
                        CurrentColumn.CellStyle = null;
                }
            }
        }

        //Событие перемещения таблицы заголовка вслет за полосой прокрутки
        private void MainDataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.HorizontalChange != 0)
            {
                HeaderGrid.Margin = new Thickness(HeaderGrid.Margin.Left - e.HorizontalChange, 0, 0, 0);
            }
        }
        
        //*************************************************************************************************************************************************
        //Событие сохранения проекта
        private void Save_Click(object sender, RoutedEventArgs e)
        {          
            if(fileNameToSave != null)
            {
                // Save document
                SerializeXML(out fileNameToSave, fileNameToSave);
            }
            else
            {
                try
                {
                    // Configure open file dialog box
                    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                    dlg.FileName = "Document"; // Default file name
                    dlg.DefaultExt = ".ken"; // Default file extension
                    dlg.Filter = "ken файл (.ken)|*.ken"; // Filter files by extension

                    // Show open file dialog box
                    Nullable<bool> result = dlg.ShowDialog();

                    // Process open file dialog box results
                    if (result == true)
                    {
                        // Save document
                        SerializeXML(out fileNameToSave, dlg.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Событие сохранения как проекта 
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Нажали SaveAs");     
            try
            {
                // Configure save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".ken"; // Default file extension
                dlg.Filter = "ken файл (.ken)|*.ken"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    SerializeXML(out fileNameToSave, dlg.FileName);
                }
                else { MessageBox.Show("Файл не сохранен"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Событие открытие проекта ------------------------------------------------------------------------------
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenDialogWindow openDialogWindow = new OpenDialogWindow();
            openDialogWindow.Show();
            openDialogWindow.YesSaveButton.Click += SaveAs_Click;
            openDialogWindow.YesSaveButton.Click += Open_Click1;
            openDialogWindow.NoCancelButton.Click += Open_Click1;
        }

        private void Open_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Configure open file dialog box
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".ken"; // Default file extension
                dlg.Filter = "ken файл (.ken)|*.ken"; // Filter files by extension

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    DeserializeXML(out fileNameToSave, dlg.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не соответствует формату!");
            }
        }
        //Событие открытие проекта ------------------------------------------------------------------------------

        //Событи создать новый файл
        private void New_Click(object sender, RoutedEventArgs e)
        {
            fileNameToSave = null;

            SaveDialogWindow saveDialogWindow = new SaveDialogWindow();
            saveDialogWindow.Show();
            saveDialogWindow.YesSaveButton.Click += SaveAs_Click;

            CollectionOfPanels.PanelList.Clear();

            Panel newPanel = new Panel
            {
                Id = 1,
                NumOfPole = "3P",
                TypeOfAutomation = "Стандартный",
                TypeOfService = "Одностороннее",
                ShotCurr = 25,
                GrSystem = "TN-S",
                DegreeIP = "IP31",
                AmbTemperature = 35,
                PowerSupply = "Кабель",
                MetalBusCoating = "НЕТ",
                EpoxyBusCoating = "НЕТ",
                Painting = "RAL 9003",
                SpaceReserve = "10",
                ATSPresent = "НЕТ",
                IncomerLocation = "По краям",
                TypeOfConnection = "Сверху",
                StringIncomerCurrent_Sect1 = "НЕТ",
                StringIncomerCurrent_Sect2 = "НЕТ",
                StringIncomerCurrent_Sect3 = "НЕТ",
                StringBustieCurrent = "НЕТ",
                TypeOfSectApp = "АВ",
                StrCompPowerSect1 = "НЕТ",
                StrCompPowerSect2 = "НЕТ"
            };
            CollectionOfPanels.AddPanel(newPanel);
        }

        /// <summary>
        /// Серриализация и перезапись файла
        /// </summary>
        /// <param name="fileNameToSave">Глобальная переменная для сохранения имяни файла</param>
        /// <param name="fileName">Новое имя файла</param>
        public void SerializeXML(out string fileNameToSave, string fileName)
        {
            fileNameToSave = fileName;

            XmlSerializer formater = new XmlSerializer(typeof(CollectionOfPanels));
            File.Delete(fileNameToSave);
            using (FileStream fs = new FileStream(fileNameToSave, FileMode.Create))
            {
                formater.Serialize(fs, CollectionOfPanels);
                MessageBox.Show("Файл сохранен");
            }
        }

        /// <summary>
        /// Открытие и Дессериализация файла
        /// </summary>
        /// <param name="fileNameToSave">Глобальная переменная для сохранения имяни файла</param>
        /// <param name="fileName">Новое имя файла</param>
        public void DeserializeXML(out string fileNameToSave, string fileName)
        {
            fileNameToSave = fileName;

            XmlSerializer formater = new XmlSerializer(typeof(CollectionOfPanels));
            using (FileStream fs = new FileStream(fileNameToSave, FileMode.OpenOrCreate))
            {
                CollectionOfPanels = (CollectionOfPanels)formater.Deserialize(fs);
                RefreshTable();
                CollectionOfPanels.PanelList.CollectionChanged += PanelList_CollectionChanged;
            }
        }

        private void CalcDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void CalcDataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }

        /// <summary>
        /// Кнопка рассчитать панели
        /// </summary>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            projectClass = new ProjectClass(ref CollectionOfPanels, ref @base); //Создаем проект и передаем по ссылке коллекцию панелей и базу

            #region Логика с заполнением класса для вывода расчетной информации
            CollectionOfCalcPanels.PanelList.Clear();
            foreach (Sheeld sheeld in projectClass.sheelds)
            {
                CalcPanel calcPanel = new CalcPanel();
                calcPanel.Id = sheeld.Id;
                calcPanel.Name = sheeld.Name;
                calcPanel.NuberOfFuncUnits = sheeld.NuberOfBlocks;
                calcPanel.SumNumberOfUnits = sheeld.SumNumberOfUnits;
                calcPanel.SumPrice = sheeld.SumPrice;
                calcPanel.Discription = sheeld.ToString();

                calcPanel.Message = sheeld.Message;

                CollectionOfCalcPanels.PanelList.Add(calcPanel);
            }
            #endregion

        }

        /// <summary>
        /// Событие изменения основной таблицы
        /// </summary>
        private void MainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Sect1FiderLastText.Header = "Билиберда";
        }       
    }

    /// <summary>
    /// Класс для развертывания детального описания шкафа
    /// </summary>
    [ValueConversion(typeof(Visibility), typeof(bool))]
    public sealed class VisibilityToBooleanConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as Visibility? == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as bool? == true ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
