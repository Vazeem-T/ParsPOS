using CommunityToolkit.Mvvm.ComponentModel;
using ParsPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.ViewModel
{
    public partial class NumberPadViewModel : BaseViewModel
    {
        private string _inputString = "";
        private string _displayText = "";
        private char[] _specialChars = { '*', '#' };

        public ICommand AddCharCommand { get; private set; }
        public ICommand DeleteCharCommand { get; private set; }

        public string InputString
        {
            get => _inputString;
            private set
            {
                if (_inputString != value)
                {
                    _inputString = value;
                    OnPropertyChanged();
                    DisplayText = FormatText(_inputString);

                    ((Command)DeleteCharCommand).ChangeCanExecute();
                }
            }
        }

        public string DisplayText
        {
            get => _displayText;
            private set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    OnPropertyChanged();
                }
            }
        }

        public NumberPadViewModel()
        {
            AddCharCommand = new Command<string>((key) => InputString += key);

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
