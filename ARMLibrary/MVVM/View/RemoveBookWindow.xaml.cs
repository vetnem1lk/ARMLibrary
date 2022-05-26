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
using ARMLibrary.MVVM.Model;

namespace ARMLibrary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для RemoveBookWindow.xaml
    /// </summary>
    public partial class RemoveBookWindow : Window
    {
        public static ARM_B023Context dbContext { get; set; }
        public RemoveBookWindow()
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
                dbContext.Books.Remove(GetBook());
                History item = History.CreateRemoveHistory(GetId(), GetReason());
                dbContext.Histories.Add(item);
                dbContext.SaveChanges();
                DialogResult = true;
            }
            catch (DataServiceRequestException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private string GetReason()
        {
            return ReasonBox.Text;
        }

        private int GetId()
        {
            return (int)BookList.SelectedValue;
        }

        private Book GetBook()
        {
            var listBook = new ListBook();
            return listBook[GetId()];
        }
    }
}
