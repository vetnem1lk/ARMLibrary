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

        private int GetPublisherId()
        {
            int id;
            if (PublisherIdBox.SelectedValue == null)
            {
                var publisher = Publisher.CreatePublisher(PublisherIdBox.Text);
                dbContext.Publishers.Add(publisher);
                dbContext.SaveChanges();
                id = publisher.Id;
            }
            else
            {
                id = (int)PublisherIdBox.SelectedValue;
            }
            return id;
        }
        private string GetTitle()
        {
            var title = TitleBox.Text == "" ? "Unknown title" : TitleBox.Text;
            return title;
        }
        private string GetAuthor()
        {
            var author = AuthorBox.Text == "" ? "Unknown author" : AuthorBox.Text;
            return author;
        }
        private DateTime GetRelease()
        {
            var release = ReleaseDatePicker.SelectedDate.Value;
            return release;
        }

        private void MLBDown_Done(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Book book = Book.CreateBook(GetTitle(), GetAuthor(), GetRelease(), GetPublisherId());
                History item = History.CreateHistory(GetTitle(), GetAuthor());
                dbContext.Histories.Add(item);
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                DialogResult = true;
            }
            catch (DataServiceRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
