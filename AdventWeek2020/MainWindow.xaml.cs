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
using TheBESTTetrisEVER;
using THE_BEST_TIC_TAC;

namespace AdventWeek2020
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OneD_Click(object sender, RoutedEventArgs e)
        {
                                    
        }
        private void TwoD_Click(object sender, RoutedEventArgs e)
        {
            var tetris = new TheBESTTetrisEVER.Form1();
            tetris.Show();
        }
        private void ThreeD_Click(object sender, RoutedEventArgs e)
        {
            var date = DateTime.UtcNow;
            if (date.Year >= 2020)
            {
                var tetris = new THE_BEST_TIC_TAC.Form1();
                tetris.Show();
            }
            
        }
        private void FourD_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FiveD_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SixD_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SevenD_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
