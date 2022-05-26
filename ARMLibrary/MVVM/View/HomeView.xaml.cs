#nullable enable
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace ARMLibrary.MVVM.View
{
    public partial class HomeView 
    {

        public static ARM_B023Context? DbContext { get; set; }

        private ObservableCollection<History> ListHistory { get; }
        public HomeView()
        {
            DbContext = new ARM_B023Context();
            InitializeComponent();
            ListHistory = new ObservableCollection<History>();
        }

        private void AddBook_MLBDown(object sender, MouseButtonEventArgs e)
        {
            var addBookWindow = new AddBookWindow();
            var result = addBookWindow.ShowDialog();
            if (result != true) return;
            TotalBooks.Text = DbContext.Books.Count().ToString();
            UpdateHistory();
        }

        private void UcLoaded(object sender, RoutedEventArgs e)
        {
            UpdateHistory();
        }

        private void UpdateHistory()
        {
            ListHistory.Clear();
            var histories = DbContext.Histories;
            var queryHistory = from history in histories orderby history.Id descending select history;
            foreach (var history in queryHistory)
            {
                ListHistory.Add(history);
            }
            HistoryGrid.ItemsSource = ListHistory;

        }

        private void AddReader_MLBDown(object sender, MouseButtonEventArgs e)
        {
            var addReaderWindow = new AddReaderWindow();
            var result = addReaderWindow.ShowDialog();
            if (result != true) return;
            TotalReaders.Text = DbContext.Readers.Count().ToString();
            UpdateHistory();
        }

        private void Remove_MLBDown(object sender, MouseButtonEventArgs e)
        {
            var removeWindow = new RemoveBookWindow();
            var result = removeWindow.ShowDialog();
            if (result != true) return;
            TotalBooks.Text = DbContext.Books.Count().ToString();
            UpdateHistory();
        }
    }
}
