using GameofKingdom.rescources.classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameofKingdom.windows.pages.MainWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy GamePage.xaml
    /// </summary>
    public partial class GamePage : UserControl
    {

        private static Welcome window;

        private static string UserName;
        private static int BaseRescources;
        private static int GameSpeed;
        private static int Difficulty;

        private static Boolean check;

        public GamePage(Welcome win, string name, int resc, int speed)
        {
            window = win;
            UserName = name;
            BaseRescources = resc;
            GameSpeed = speed;
            check = false;
            InitializeComponent();
            ApplytGameSettings();
        }






        private void OperateProgressBars(int progrssBarId, int changeValue)
        {
            switch (progrssBarId)
            {
                case 0:
                    // food
                    food.Value += changeValue;
                    break;
                case 1:
                    // money
                    money.Value += changeValue;
                    break;
                case 2:
                    // army
                    army.Value += changeValue;
                    break;
                case 3:
                    // control
                    control.Value += changeValue;
                    break;
                case 4:
                    // population
                    pop.Value += changeValue;
                    break;
                case 5:
                    // time
                    time.Value += changeValue;
                    break;
                default:
                    Console.WriteLine("GamePage - OperateProgressBars - error log - non existing progressBarId value");
                    return;
            }

        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                MessageBox.Show("Czy jesteś tego pewien?");
                check = true;
            }
            else
                Basic.NavigateTo(window.frame, new MainPage(window));
        }

        private void ApplytGameSettings()
        {
            SetDefficulty();
            SetBasicProgressBars();
        }

        private void SetDefficulty()
        {
            if (BaseRescources >= 0 && BaseRescources <= 4)
                Difficulty = BaseRescources + 1;
            else
                Console.WriteLine("GamePage - SetDefficulty - error log - BaseRescources value unknown");
        }

        private void SetBasicProgressBars()
        {
            time.Value = 1;
            int changeValue = 0;
            switch (BaseRescources)
            {
                case 0:
                    changeValue = 60;
                    break;
                case 1:
                    changeValue = 50;
                    break;
                case 2:
                    changeValue = 40;
                    break;
                case 3:
                    changeValue = 30;
                    break;
                case 4:
                    changeValue = 20;
                    break;
                default:
                    Console.WriteLine("GamePage - SetBasicProgressBars - error log - BaseRescources value unknown");
                    break;
            }
            SetProgresBarValue(food, changeValue);
            SetProgresBarValue(money, changeValue);
            SetProgresBarValue(army, changeValue);
            SetProgresBarValue(control, changeValue);
            SetProgresBarValue(pop, changeValue);
        }

        private void SetProgresBarValue(ProgressBar psb, double value)
        {
            psb.Value = value;
            psb.ToolTip = psb.Value.ToString();
        }

        private void ProgressBarValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ProgressBar pgb = (ProgressBar)sender;
            int value = (int)pgb.Value;
            SolidColorBrush brush = pgb.Name != "time"
                ? value switch
                {
                    <= 20 => new SolidColorBrush(Colors.Red),
                    >= 90 => new SolidColorBrush(Colors.Green),
                    _ => new SolidColorBrush(Colors.Gray),
                }
                : value switch
                {
                    >= 90 => new SolidColorBrush(Colors.Red),
                    _ => new SolidColorBrush(Colors.Green),
                };

            /*
             if (pgb.Name != "time")
            {
                switch (value)
                {
                    case <= 20:
                        brush = new SolidColorBrush(Colors.Red);
                        break;
                    case >= 90:
                        brush = new SolidColorBrush(Colors.Green);
                        break;
                    default:
                        brush = new SolidColorBrush(Colors.Gray);
                        break;
                }
            }
            else
            {
                switch (value)
                {
                    case >= 90:
                        brush = new SolidColorBrush(Colors.Red);
                        break;
                    default:
                        brush = new SolidColorBrush(Colors.Green);
                        break;
                }
            }
             */
            pgb.Foreground = brush;
        }
    }
}
