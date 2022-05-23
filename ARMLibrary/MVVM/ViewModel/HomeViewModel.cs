using ARMLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMLibrary.MVVM.ViewModel
{
    internal class HomeViewModel : ObservableObject
    {
        public static ARM_B023Context dbContext { get; set; }

        private string _totalBooks;
        public string TotalBooks
        {
            get
            {
                return _totalBooks;
            }
            set
            {
                _totalBooks = value;
                OnPropertyChanged(TotalBooks);
            }
        }


        public HomeViewModel()
        {
            dbContext = new ARM_B023Context();
            TotalBooks = dbContext.Books.Count().ToString();
        }
    }
}
