using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ARMLibrary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ReadersView.xaml
    /// </summary>
    public partial class ReadersView : UserControl
    {

        public static ARM_B023Context dbContext { get; set; }

        ObservableCollection<Reader> listReaders { get; set; }
        public ReadersView()
        {
            dbContext = new ARM_B023Context();
            InitializeComponent();
            listReaders = new ObservableCollection<Reader>();
        }

        private void UCLoaded(object sender, RoutedEventArgs e)
        {
            var readers = dbContext.Readers;
            var queryReader = from reader in readers orderby reader.LastName select reader;
            foreach (Reader reader in queryReader)
            {
                listReaders.Add(reader);
            }
            DataGridReaders.ItemsSource = listReaders;
        }
    }
}
