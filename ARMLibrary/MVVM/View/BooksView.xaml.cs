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
    /// Логика взаимодействия для DiscoveryView.xaml
    /// </summary>
    public partial class DiscoveryView : UserControl
    {
        public static ARM_B023Context dbContext { get; set; }

        ObservableCollection<Book> listBooks { get; set; }

        public DiscoveryView()
        {
            dbContext = new ARM_B023Context();
            InitializeComponent();
            listBooks = new ObservableCollection<Book>();
        }

        private void UCLoaded(object sender, RoutedEventArgs e)
        {
            var books = dbContext.Books;
            var queryBook = from book in books orderby book.Name select book;
            foreach (Book book in queryBook)
            {
                listBooks.Add(book);
            }
            DataGridBooks.ItemsSource = listBooks;
        }
    }
}
