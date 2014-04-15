using System;
using System.Text.RegularExpressions;
using RegexTester.ViewModels.Base;

namespace RegexTester.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string regexPattern;

        private string inputText;

        private string message;

        private Regex regex;

        public MainViewModel()
        {
        }

        private void ValidateInputText()
        {
            if (regexPattern == String.Empty)
            {
                Message = "Regex is Empty";
                return;
            }

            try
            {
                regex = new Regex(regexPattern);
                Message = String.Empty;
            }
            catch (ArgumentException error)
            {
                Message = error.Message;
                return;
            }

            if (InputText != null)
            {
                bool isMatch = regex.IsMatch(InputText);
                if (isMatch)
                {
                    Message = "It's works!";
                }
                else
                {
                    Message = "No working :(";
                }
            }
        }

        public string RegexPattern
        {
            get { return regexPattern; }
            set
            {
                if (regexPattern != value)
                {
                    regexPattern = value;
                    ValidateInputText();
                    OnPropertyChanged();
                }
            }
        }

        public string InputText
        {
            get { return inputText; }
            set
            {
                if (inputText != value)
                {
                    inputText = value;
                    ValidateInputText();
                    OnPropertyChanged();
                }
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
