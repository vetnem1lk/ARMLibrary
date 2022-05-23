using ARMLibrary.Core;
using ARMLibrary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ARMLibrary.MVVM.ViewModel
{
    internal class AddBookViewModel : ObservableObject
    {
        public RelayCommand BooksViewCommand { get; set; }
        public BooksViewModel? BooksVM { get; set; }
        private object? _currentView;

        
        



        public AddBookViewModel()
        {
            MainViewModel mvm = new MainViewModel();
            BooksVM = new BooksViewModel();
            BooksViewCommand = new RelayCommand(o =>
            {
                mvm.CurrentView = BooksVM;
            });
        }
    }
}
