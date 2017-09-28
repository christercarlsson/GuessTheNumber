using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.BL
{
    public class GuessingGame
    {
        Random _randomizer;
        int _secretNumber;
        public int NumberOfGuesses { get; set; }

        public GuessingGame()
        {
            _randomizer = new Random();
            InitialGame();
        }

        private void InitialGame()
        {
            _secretNumber = _randomizer.Next(1, 101);
        }

        public int Guess(int guessedNumber)
        {
            NumberOfGuesses++;
            return guessedNumber.CompareTo(_secretNumber);
        }
    }
}
