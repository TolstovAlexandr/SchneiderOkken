using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Okken
{
    /// <summary>
    /// Interaction logic for SaveDialogWindow.xaml
    /// </summary>
    public partial class SaveDialogWindow : Window
    {
        public SaveDialogWindow()
        {
            InitializeComponent();
        }

        public bool saveFlag = false;

        private void YesSaveButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NoCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
