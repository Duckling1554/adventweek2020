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
using TheBESTCarRacing;
using AboutInfo;

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
            var oneD = new DateTime(2019, 12, 01);

            if (IsAble(oneD))
            {
                
            }

            else
            {
                MessageBox.Show
                    ($"Only {Delta(oneD)} more days to go!", "Too Early!",
                    MessageBoxButton.OK);
            }
        }
        private void TwoD_Click(object sender, RoutedEventArgs e)
        {
            var twoD = new DateTime(2019, 12, 01);

            if (IsAble(twoD))
            {
                var racing = new TheBESTCarRacing.Form1();
                racing.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                racing.ShowDialog();
            }
            else
            {
                MessageBox.Show
                    ($"Only {Delta(twoD)} more days to go!", "Too Early!",
                    MessageBoxButton.OK);
            }
        }
        private void ThreeD_Click(object sender, RoutedEventArgs e)
        {
            var threeD = new DateTime(2019, 12, 01);

            if (IsAble(threeD))
            {
                var tictac = new THE_BEST_TIC_TAC.Form1();
                tictac.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                tictac.ShowDialog();
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
            var fourD = new DateTime(2019, 12, 01);

            if (IsAble(fourD))
            {
                var tetris = new TheBESTTetrisEVER.Form1();
                tetris.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                tetris.ShowDialog();
            }
            else
            {
                MessageBox.Show
                    ($"Only {Delta(fourD)} more days to go!", "Too Early!",
                    MessageBoxButton.OK);
            }
        }
        private void FiveD_Click(object sender, RoutedEventArgs e)
        {
            var fiveD = new DateTime(2019, 12, 01);

            if (IsAble(fiveD))
            {
                
            }
            else
            {
                MessageBox.Show
                    ($"Only {Delta(fiveD)} more days to go!", "Too Early!",
                    MessageBoxButton.OK);
            }
        }
        private void SixD_Click(object sender, RoutedEventArgs e)
        {
            var sixD = new DateTime(2019, 12, 01);

            if (IsAble(sixD))
            {
                var snake = new TheBESTSnake.Form1();
                snake.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                snake.ShowDialog();
            }
            else
            {
                MessageBox.Show
                    ($"Only {Delta(sixD)} more days to go!", "Too Early!",
                    MessageBoxButton.OK);
            }
        }
        private void SevenD_Click(object sender, RoutedEventArgs e)
        {
            var sevenD = new DateTime(2019, 12, 01);

            if (IsAble(sevenD))
            {
                var predictor = new MagicPredictor.MainForm();
                predictor.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                predictor.ShowDialog();
            }
            else
            {
                MessageBox.Show
                    ($"Only {Delta(sevenD)} more days to go!", "Too Early!",
                    MessageBoxButton.OK);
            }
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
            double result = (Math.Ceiling(delta.TotalDays));
            return result;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var about = new AboutInfo.Form1();
            about.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            about.ShowDialog();
        }
    }
}
