using System;
using System.Collections.Generic;
using System.Data.Services.Client;
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

namespace ARMLibrary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        public static ARM_B023Context dbContext { get; set; }

        public AddReaderWindow()
        {
            dbContext = new ARM_B023Context();
            InitializeComponent();
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
            try
            {
                Reader reader= Reader.CreateBook(GetLastName(), GetFirstName(), GetBirthday(), GetPhoneNumber(), GetMail());
                History item = History.CreateReaderHistory(GetLastName(),GetFirstName());
                dbContext.Histories.Add(item);
                dbContext.Readers.Add(reader);
                dbContext.SaveChanges();
                DialogResult = true;
            }
            catch (DataServiceRequestException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private string GetLastName()
        {
            return LastNameBox.Text;
        }
        private string GetFirstName()
        {
            return FirstNameBox.Text;
        }

        private string GetBirthday()
        {
            return BirthdateBox.Text;
        }
        private string GetPhoneNumber()
        {
            return PhoneBox.Text;
        }

        private string GetMail()
        {
            return EmailBox.Text;
        }
    }
}
