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

        
        public AddBookViewModel()
        {
        }
    }
}
