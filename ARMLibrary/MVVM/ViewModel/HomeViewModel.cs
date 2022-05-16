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
        public HomeViewModel()
        {
            CurrentText = "Name";
        }
    }
}
