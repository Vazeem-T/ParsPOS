using CommunityToolkit.Mvvm.ComponentModel;
using ParsPOS.InterfaceServices;
using System.Windows.Input;

namespace ParsPOS.ViewModel
{
    public partial class NumberPadViewModel : BaseViewModel
    {
        private string _inputString = "";
        private string _displayText = "";
        private char[] _specialChars = { '*', '#' };

        private SaleViewModel _SaleView;
        private PayPopupViewModel _payPopupViewModel { get; set; }
        public ICommand AddCharCommand { get; private set; }
        public ICommand DeleteCharCommand { get; private set; }

        public string InputString
        {
            get => _inputString;
            set
            {
                if (_inputString != value)
                {
                    _inputString = value;
                    OnPropertyChanged(nameof(InputString));
                    DisplayText = FormatText(_inputString);
                    
                    ((Command)DeleteCharCommand).ChangeCanExecute();
                }
            }
        }

        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    OnPropertyChanged();
                    _payPopupViewModel.NumberText = value;
                    _payPopupViewModel.UpdateDisplayTextCommand.Execute(value);
                    //MessagingCenter.Send(this, "DisplayTextChanged", value);
                }
            }
        }

        public NumberPadViewModel()
        {
            
            _SaleView = new SaleViewModel();
            _payPopupViewModel = new PayPopupViewModel(_SaleView,this);
            AddCharCommand = new Command<string>((key) =>
            {
                InputString += key;
            });
            
            DeleteCharCommand =
            new Command(
                () => InputString = InputString.Substring(0, InputString.Length - 1),
                () => InputString.Length > 0
            );
        }
        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(_specialChars) != -1;
            string formatted = str;
            return formatted;
        }
    }
}
