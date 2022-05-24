using ARMLibrary.Core;


namespace ARMLibrary.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand BooksViewCommand { get; set; }
        public RelayCommand ReadersViewCommand { get; set; }

        public HomeViewModel? HomeVM { get; set; }
        public BooksViewModel? BooksVM { get; set; }
        public ReadersViewModel? ReadersVM { get; set; }

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
                OnPropertyChanged(CurrentText);
            }
        }

        private object? _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            BooksVM = new BooksViewModel();
            ReadersVM = new ReadersViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            BooksViewCommand = new RelayCommand(o =>
            {
                CurrentView = BooksVM;
            });
            ReadersViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReadersVM;
            });

            CurrentText = "Search";         
            
        }


    }
}
