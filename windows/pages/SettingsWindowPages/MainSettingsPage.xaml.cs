using GameofKingdom.rescources.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace GameofKingdom.windows.pages.SettingsWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy MainSettingsPage.xaml
    /// </summary>
    public partial class MainSettingsPage : UserControl
    {
        private static Settings window;

        public MainSettingsPage(Settings settings)
        {
            window = settings;
            InitializeComponent();
            SetMySettings();
        }

        private void SetMySettings()
        {
            if (FileHandeler.CheckSettingsFile())
            {
                string loadedJson = File.ReadAllText(FileHandeler.ReturnPath(2));
                if (!string.IsNullOrEmpty(loadedJson))
                {
                    List<SettingsModel> settingsList = JsonSerializer.Deserialize<List<SettingsModel>>(loadedJson);
                    SettingsModel settings = settingsList[0];
                    language.SelectedIndex = settings.Language;
                    resolution.SelectedIndex = settings.Resolution;
                    if (settings.EventAnimation)
                        eventAnimation.SelectedIndex = 0;
                    else
                        eventAnimation.SelectedIndex = 1;
                }
                else
                    Console.WriteLine("ApplySettings - error log - failed to read settings json");
            }
            else
            {
                Console.WriteLine("ApplayingSettings - error log - cirtical error, closing the game");
                MessageBox.Show("Coś poszło nie tak, zamykanie aplikacji. Przepraszamy za utrudnienia");
                Application.Current.Shutdown();
            }
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            int selected_resolution;
            bool selected_animation;
            string cbx_language = ((ComboBoxItem)language.SelectedItem).Name;
            string cbx_resolution = ((ComboBoxItem)resolution.SelectedItem).Name;
            string cbx_animation = ((ComboBoxItem)eventAnimation.SelectedItem).Name;
            int selected_language = Convert.ToInt32(cbx_language[9].ToString());

            if (cbx_resolution[11].ToString() == "X")
                selected_resolution = 10;
            else
                selected_resolution = Convert.ToInt32(cbx_resolution[11].ToString());

            if (cbx_animation[15]=='1')
                selected_animation = true;
            else
                selected_animation = false;

            Console.WriteLine("New settings values: " + selected_language + " " + selected_resolution + " " + selected_animation);

            FileHandeler.OverrideSettings(selected_language, selected_resolution, selected_animation);
            Welcome win = new();
            win.Show();
            window.Close();
        }
    }
}
