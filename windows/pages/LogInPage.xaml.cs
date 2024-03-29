﻿using GameofKingdom.rescources.classes;
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

namespace GameofKingdom.windows.pages.MainWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy LogInPage.xaml
    /// </summary>
    public partial class LogInPage : UserControl
    {

        private static Welcome window;
        private static Boolean init = true;

        public LogInPage(Welcome win)
        {
            window = win;
            init = true;
            InitializeComponent();
            init = false;
            Basic.ApplySettings(window);
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            string name = userName.Text;
            string cbi_rescources = ((ComboBoxItem)rescourcesAmount.SelectedItem).Name;
            string cbi_speed = ((ComboBoxItem)gameSpeed.SelectedItem).Name;
            int rescources = Convert.ToInt32(cbi_rescources[17].ToString());
            int speed = Convert.ToInt32(cbi_speed[6].ToString());

            if (CheckUserName())
            {
                Console.WriteLine("Inputed login values: " +  name + " " + rescources + " " + speed);
                Basic.NavigateTo(window.frame, new GamePage(window, name, rescources, speed));
            }
            else
            {
                Console.WriteLine("LogInPage - error log - wrong name: " + userName.Text);
                MessageBox.Show("Wprowadzono nie poprawną nazwę");
            }
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            init = true;
            Basic.NavigateTo(window.frame, new MainPage(window));
        }

        private void AllowedUserName(object sender, TextChangedEventArgs e)
        {
            // "", "Admin", "admin"
            if (!init)
                CalculateGameDificulty();
            string name = userName.Text;
            if (name == "admin" || name == "Admin")
            {
                MessageBox.Show("Wprowadziłeś nie nie dozwoloną nazwę. Usuwanie");
                userName.Text = "";
            }
        }

        private Boolean CheckUserName()
        {
            string name = userName.Text;
            Console.WriteLine("CheckUserName - middle log - selected user name: " + name);
            return name != "" && name != "admin" && name != "Admin" && name != "Nazwa gracza";
        }

        private void CalculateGameDificulty()
        {
            if(!String.IsNullOrEmpty(((ComboBoxItem)rescourcesAmount.SelectedItem).Name) && !String.IsNullOrEmpty(((ComboBoxItem)gameSpeed.SelectedItem).Name))
            {
                string cbi_rescources = ((ComboBoxItem)rescourcesAmount.SelectedItem).Name;
                string cbi_speed = ((ComboBoxItem)gameSpeed.SelectedItem).Name;
                int rescources = Convert.ToInt32(cbi_rescources[17].ToString());
                int speed = Convert.ToInt32(cbi_speed[6].ToString());

                int difficulty = rescources + speed;
                switch (difficulty)
                {
                    case 0:
                    case 1:
                        gameDifficulty.Text = "Łatwy";
                        gameDifficulty.Foreground = new SolidColorBrush(Colors.Green);
                        break;
                    case 2:
                    case 3:
                        gameDifficulty.Text = "Średni";
                        gameDifficulty.Foreground = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 4:
                    case 5:
                        gameDifficulty.Text = "Trudny";
                        gameDifficulty.Foreground = new SolidColorBrush(Colors.Red);
                        break;
                    case 6:
                        gameDifficulty.Text = "B.Trudny";
                        gameDifficulty.Foreground = new SolidColorBrush(Colors.Crimson);
                        break;
                    default:
                        Console.WriteLine("LogInPage - CalculateGameDificulty - error log - dificulty value unknown");
                        break;
                }
            }
        }

        private void ComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!init)
                CalculateGameDificulty();
        }
    }
}
