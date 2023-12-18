using GameofKingdom.rescources.classes;
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

namespace GameofKingdom.windows.tmp.SettingsWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy GraphicSettingsPage.xaml
    /// </summary>
    public partial class GraphicSettingsPage : UserControl
    {

        private static Settings window;

        public GraphicSettingsPage(Settings settings)
        {
            window = settings;
            InitializeComponent();
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            string clicked_button = Basic.ReturnName(sender);
            Console.WriteLine("Settings Window - Graphics Page - clicked button log - " + clicked_button);
            if (clicked_button == "btn_1")
            {
                Basic.NavigateTo(window.frame, new GraphicSettingsPage(window));
            }
            else if (clicked_button == "btn_2")
            {
                Basic.NavigateTo(window.frame, new GameSettingsPage(window));
            }
            else if (clicked_button == "btn_3")
            {
                Basic.NavigateTo(window.frame, new LanguageSettingsPage(window));
            }
            else if (clicked_button == "btn_4")
            {
                Welcome win = new();
                win.Show();
                window.Close();
            }
            else
            {
                Console.WriteLine("Settings Window - Graphics Page - error log - unknown button");
            }
        }
    }
}
