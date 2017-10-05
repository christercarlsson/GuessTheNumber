using GuessTheNumber.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGameCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var vm = new MainWindowViewModel();
            Console.WriteLine("Guess a  number between 1 - 100");

            while (vm.GameOn)
            {
                Console.Write("Guess: ");
                vm.Input = Console.ReadLine();
                if (vm.GuessCommand.CanExecute(null))
                {
                    vm.GuessCommand.Execute(null);
                    Console.WriteLine(vm.Message);
                }
                else
                {
                    Console.WriteLine("You need to enter an integer...");
                }
            }

            Console.WriteLine("Congratulate...");

        }
    }
}
