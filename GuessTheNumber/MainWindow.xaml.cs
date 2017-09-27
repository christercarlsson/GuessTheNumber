using System;
using System.Windows;

namespace GuessTheNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _randomizer;
        int _secretNumber;
        int _numberOfGuesses;
        int _highScore;

        public MainWindow()
        {
            InitializeComponent();
            _randomizer = new Random();
            _highScore = int.MaxValue;
            InitializeGame();
        }

        private void InitializeGame()
        {
            _secretNumber = _randomizer.Next(1, 101);
            GuessButton.Visibility = Visibility.Visible;
            RunAgainButton.Visibility = Visibility.Hidden;
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out int guessedNumber))
            {
                _numberOfGuesses++;
                CheckIfRight(guessedNumber);
                return;
            }
            OutputTextBlock.Text = $"You need to enter a number"; 
        }

        private void CheckIfRight(int guessedNumber)
        {
            if(guessedNumber < _secretNumber )
            {
                OutputTextBlock.Text = $"You need to guess higher.";
            }
            else if(guessedNumber > _secretNumber)
            {
                OutputTextBlock.Text = $"You need to guess lower";
            }
            else
            {
                HandleSuccess();
            }
        }

        private void HandleSuccess()
        {
            OutputTextBlock.Text = $"Well done, you guessed it with {_numberOfGuesses} tries..";
            CheckIfHighScore();
            GuessButton.Visibility = Visibility.Hidden;
            RunAgainButton.Visibility = Visibility.Visible;
        }

        private void CheckIfHighScore()
        {
            if(_numberOfGuesses < _highScore)
            {
                _highScore = _numberOfGuesses;
                HighScoreTextBlock.Text = $"High Score: {_highScore}";
            }

        }

        private void RunAgain_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }
    }
}
