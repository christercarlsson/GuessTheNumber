using GuessTheNumber.BL;
using System.ComponentModel;

namespace GuessTheNumber.VM
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        
        public MainWindowViewModel()
        {
            GuessCommand = new RelayCommand(Guess, CanGuess);
            RestartCommand = new RelayCommand(Restart);
            InitGame();
        }

       

        private GuessingGame game;

        public bool GameOn { get; set; }
        public RelayCommand GuessCommand { get; private set; }
        public RelayCommand RestartCommand { get; private set; }
        public bool GuessVisible { get { return GameOn; } }
        public bool RestartVisible { get { return !GameOn; } }

        private string _message;

        public string Message
        {
            get { return _message; }
            set {
                SetProperty(value, ref _message, nameof(Message));
            }
        }

        private string _input;

        public string Input
        {
            get { return _input; }
            set {
                SetProperty(value, ref _input, nameof(Input));
                GuessCommand.RaiseCanExecuteChanged(); 
            }
        }

        private void Guess(object obj)
        {
            int result = game.Guess(int.Parse(Input));
            if (result == 0)
                SuccessfullGuess();
            else
                Message = result > 0 ? "You need to guess lower" : "You need to guess higher";
        }

        private bool CanGuess(object obj)
        {
            return !string.IsNullOrEmpty(Input) && int.TryParse(Input, out int result);
        }

        private void Restart(object obj)
        {
            InitGame();
        }


        private void SuccessfullGuess()
        {
            Message = $"You guessed correct with {game.NumberOfGuesses} tries";
            GameOn = false;
        }

        private void InitGame()
        {
            game = new GuessingGame();
            Input = "";
            GameOn = true;
            Message = "Guess a number between 1 and 100";

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
