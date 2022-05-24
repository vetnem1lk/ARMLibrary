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
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        public static ARM_B023Context dbContext { get; set; }

        ObservableCollection<History> listHistory { get; set; }
        public HomeView()
        {
            dbContext = new ARM_B023Context();
            InitializeComponent();
            listHistory = new ObservableCollection<History>();
        }

        private void AddBook_MLBDown(object sender, MouseButtonEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Show();
        }

        private void UCLoaded(object sender, RoutedEventArgs e)
        {
            var histories = dbContext.Histories;
            var queryhistory = from history in histories orderby history.Id descending select history;
            foreach (History history in queryhistory)
            {
                listHistory.Add(history);
            }
            HistoryGrid.ItemsSource = listHistory;
        }
    }
}
