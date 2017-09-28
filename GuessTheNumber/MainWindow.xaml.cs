using GuessTheNumber.BL;
using System;
using System.Windows;

namespace GuessTheNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        GuessingGame game;
        int _highScore;

        public MainWindow()
        {
            InitializeComponent();
            
            _highScore = int.MaxValue;
            InitializeGame();
        }

        private void InitializeGame()
        {
            game = new GuessingGame();
            OutputTextBlock.Text = "Start guessing a number";
            GuessButton.Visibility = Visibility.Visible;
            RunAgainButton.Visibility = Visibility.Hidden;
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(InputTextBox.Text, out int guessedNumber))
            {
                int result = game.Guess(guessedNumber);
                if(result < 0)
                {
                    OutputTextBlock.Text = "You need to guess higher";
                } 
                else if(result > 0)
                {
                    OutputTextBlock.Text = "You need to guess lower";
                }
                else
                {
                    HandleSuccess();
                }
            }
            else
            {
                OutputTextBlock.Text = "You can only enter a number";
            }
        }

        private void CheckIfRight(int guessedNumber)
        {
        }

        private void HandleSuccess()
        {
            OutputTextBlock.Text = $"Well done, you guessed it with {game.NumberOfGuesses} tries..";
            CheckIfHighScore();
            GuessButton.Visibility = Visibility.Hidden;
            RunAgainButton.Visibility = Visibility.Visible;
        }

        private void CheckIfHighScore()
        {
            if(game.NumberOfGuesses < _highScore)
            {
                _highScore = game.NumberOfGuesses;
                HighScoreTextBlock.Text = $"High Score: {_highScore}";
            }

        }

        private void RunAgain_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }
    }
}
