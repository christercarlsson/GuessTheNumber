using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuessTheNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _randomizer;
        int _secretNumber;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RunAgain_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
