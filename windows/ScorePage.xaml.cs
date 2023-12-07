using GameofKingdom.rescources.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GameofKingdom.windows
{
    /// <summary>
    /// Logika interakcji dla klasy ScorePage.xaml
    /// </summary>
    public partial class ScorePage : UserControl
    {
        public ScorePage()
        {
            InitializeComponent();
            DisplayScores();
        }

        private void DisplayScores()
        {
            // zmień na bardziej cool w appdata albo chociaż dokumentach
            // C:\Users\localhost\source\repos\GameofKingdom\rescources\events.json
            string path = @"C:\Users\localhost\source\repos\GameofKingdom\rescources\scores.json";
            string json = File.ReadAllText(path);
            Console.WriteLine(json);
            List<ScoreModel> scores = JsonConvert.DeserializeObject<List<ScoreModel>>(json);
            scores = scores.OrderByDescending(score => score.Score).ToList();
            ScoreList.ItemsSource = scores;
            ScoreList.ItemTemplate = (DataTemplate)Resources["Score"];
        }

        private void Btn_return(object sender, RoutedEventArgs e)
        {
            Welcome win = new();
            win.Show();
            Window.GetWindow(this).Close();
        }
    }
}
