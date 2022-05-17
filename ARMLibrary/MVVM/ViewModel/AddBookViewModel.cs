using ARMLibrary.Core;
using ARMLibrary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMLibrary.MVVM.ViewModel
{
    class AddBookViewModel : ObservableObject
    {
        private string _text;
        public string CurrentText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        
        AddBookWindow win = new AddBookWindow();
        
        public AddBookViewModel()
        {
            string curText = win.InputgNameBook.Text;
            CurrentText = curText;
        }
    }
}
