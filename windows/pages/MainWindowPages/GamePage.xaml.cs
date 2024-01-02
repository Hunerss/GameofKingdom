using System;
using System.Windows;
using System.Windows.Controls;

namespace GameofKingdom.windows.pages.MainWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy GamePage.xaml
    /// </summary>
    public partial class GamePage : UserControl
    {

        private static Main window;

        private static string UserName;
        private static int BaseRescources;
        private static int GameSpeed;

        private static Boolean check;

        public GamePage(Main main, string name, int resc, int speed)
        {
            window = main;
            UserName = name;
            BaseRescources = resc;
            GameSpeed = speed;
            InitializeComponent();
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                MessageBox.Show("Czy jesteś tego pewien?");
                check = true;
            }
            else
            {
                Welcome win = new();
                win.Show();
                window.Close();
            }

        }
    }
}
