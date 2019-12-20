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
using MagicPredictor;


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
            var tetris = new MagicPredictor.MainForm();
            tetris.Show();
        }
        private void ThreeD_Click(object sender, RoutedEventArgs e)
        {
            var threeD = new DateTime(2019, 12, 29);

            if (IsAble(threeD))
            {
                var tetris = new THE_BEST_TIC_TAC.Form1();
                tetris.Show();
            }
            else
            {
                MessageBox.Show
                    ($"Only {Delta(threeD)} more days to go!", "Too Early!",
                    MessageBoxButton.OK);
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

        bool IsAble(DateTime day)
        {
            var today = DateTime.Now;
            if ((today.Year - day.Year) >= 0 & 
                (today.Month - day.Month) >= 0 & 
                (today.Day - day.Day >= 0))
            {
                return true;
            }
            return false;
        }

        double Delta(DateTime day)
        {
            var today = DateTime.Now;
            TimeSpan delta = day - today;
            double result = (Math.Truncate(delta.TotalDays));
            return result;
        }
}
}
