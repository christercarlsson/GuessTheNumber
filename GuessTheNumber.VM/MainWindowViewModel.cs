using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.VM
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set {
                SetProperty(value, ref _message, nameof(Message));
            }
        }

        private string _output;

        public string Output
        {
            get { return _output; }
            set {
                SetProperty(value, ref _output, nameof(Output));
            }
        }


        protected void SetProperty(string value, ref string property, string name)
        {
            if (value != _message)
            {
                property = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
