using GameofKingdom.rescources.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GameofKingdom.windows
{
    /// <summary>
    /// Logika interakcji dla klasy ScorePage.xaml
    /// </summary>
    public partial class ScorePage : UserControl
    {

        private static Welcome window;

        public ScorePage(Welcome win)
        {
            window = win;
            InitializeComponent();
            DisplayScores();
        }

        private void DisplayScores()
        {
            string path = @"C:\ProgramData\GameOfKingdom\Scores.json";
            if (File.Exists(path))
            {
                string json;

                using StreamReader rdr = new(path);
                json = rdr.ReadToEnd();

                if (!string.IsNullOrEmpty(json))
                {
                    Console.WriteLine("Welcome Window - Score Page - log - scores list" + json);
                
                    List<ScoreModel> scores = JsonConvert.DeserializeObject<List<ScoreModel>>(json);
                    scores = scores.OrderByDescending(score => score.Score).ToList();
                    ScoreList.ItemsSource = scores;
                    ScoreList.ItemTemplate = (DataTemplate)Resources["Score"];

                }
                else
                    Console.WriteLine("Welcome Window - Score Page - error log - json string is empty");
            }
            else
                Console.WriteLine("Welcome Window - Score Page - error log - score file doesn't exist");
        }

        private void Btn_return(object sender, RoutedEventArgs e)
        {
            Basic.NavigateTo(window.frame, new MainPage(window));
        }
    }
}
