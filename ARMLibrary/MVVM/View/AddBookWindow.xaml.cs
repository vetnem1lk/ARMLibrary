using ARMLibrary.MVVM.ViewModel;
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
using ARMLibrary.Core;
using System.Data.Services.Client;

namespace ARMLibrary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public static ARM_B023Context dbContext { get; set; }

        public AddBookWindow()
        {
            dbContext = new ARM_B023Context();
            InitializeComponent();
            DataContext = new AddBookViewModel();
        }

        private void ExBtn_MLBDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ToolBart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
            
        }

        private void MLBDown_Done(object sender, MouseButtonEventArgs e)
        {
            int id;
            if (PublisherIdBox.SelectedValue == null)
            {
                Publisher publisher = Publisher.CreatePublisher(PublisherIdBox.Text);
                dbContext.Publishers.Add(publisher);
                dbContext.SaveChanges();
                id = publisher.Id;
            }
            else
            {
                id = (int)PublisherIdBox.SelectedValue;
            }

            try
            {
                string title = TitleBox.Text;
                string author = AuthorBox.Text;
                DateTime releaseDateTime = ReleaseDatePicker.SelectedDate.Value;
                int publisherID = id;

                Book book = Book.CreateBook(title, author, releaseDateTime, publisherID);
                History item = History.CreateHistory(title, author);
                dbContext.Histories.Add(item);
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            
            Close();
        }
    }
}
