using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace GameofKingdom.rescources.classes
{
    class Basic
    {
        public static string ReturnName(object sender)
        {
            Button btn = (Button)sender;
            return btn.Name ?? "error";
        }

        public static void NavigateTo(System.Windows.Controls.Frame frame, object page)
        {
            frame.NavigationService.Navigate(page);
        }

        private static int ReturnResolutionNumber(object sender)
        {
            Button btn = (Button)sender;
            return Convert.ToInt32(btn.Name[11]);
        }

        private static string ReturnLanguage(int language)
        {
            if (language == 0)
                return @"\rescources\languages\Polish.xaml";
            else if (language == 1)
                return @"\rescources\languages\English.xaml";
            else if (language == 2)
                return @"\rescources\languages\Russian.xaml";
            Console.WriteLine("ReturnLanguage - error log - language id doesn't exist");
            return "error";
        }

        public static void SetResolution(object sender, Window win)
        {
            switch (ReturnResolutionNumber(sender))
            {
                case 1:
                    win.Height = 600;
                    win.Width = 800;
                    break;
                case 2:
                    win.Height = 768;
                    win.Width = 1024;
                    break;
                case 3:
                    win.Height = 720;
                    win.Width = 1280;
                    break;
                case 4:
                    win.Height = 768;
                    win.Width = 1366;
                    break;
                case 5:
                    win.Height = 900;
                    win.Width = 1440;
                    break;
                case 6:
                    win.Height = 900;
                    win.Width = 1600;
                    break;
                case 7:
                    win.Height = 1080;
                    win.Width = 1920;
                    break;
                case 8:
                    win.Height = 480;
                    win.Width = 640;
                    break;
                case 9:
                    win.Height = 1050;
                    win.Width = 1680;
                    break;
                case 10:
                    win.Height = 2160;
                    win.Width = 3840;
                    break;
                default:
                    win.Height = 450;
                    win.Width = 800;
                    break;
            }
        }

        private static void SetResolution(int resolution, Window win)
        {
            switch (resolution)
            {
                case 0:
                    win.Height = 450;
                    win.Width = 800;
                    break;
                case 1:
                    win.Height = 600;
                    win.Width = 800;
                    break;
                case 2:
                    win.Height = 768;
                    win.Width = 1024;
                    break;
                case 3:
                    win.Height = 720;
                    win.Width = 1280;
                    break;
                case 4:
                    win.Height = 768;
                    win.Width = 1366;
                    break;
                case 5:
                    win.Height = 900;
                    win.Width = 1440;
                    break;
                case 6:
                    win.Height = 900;
                    win.Width = 1600;
                    break;
                case 7:
                    win.Height = 1080;
                    win.Width = 1920;
                    break;
                case 8:
                    win.Height = 480;
                    win.Width = 640;
                    break;
                case 9:
                    win.Height = 1050;
                    win.Width = 1680;
                    break;
                case 10:
                    win.WindowState = WindowState.Maximized;
                    win.WindowStyle = WindowStyle.None;
                    win.Height = SystemParameters.PrimaryScreenHeight;
                    win.Width = SystemParameters.PrimaryScreenWidth;
                    break;
                default:
                    win.Height = 450;
                    win.Width = 800;
                    break;
            }
        }

        private static void SetLanguage(int language)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            ResourceDictionary dictionary = new()
            {
                Source = new Uri(Basic.ReturnLanguage(language), UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        public static void ApplySettings(Window win)
        {
            // stage is infromation about which stage of applaying setting do we want to achive - 0 = basic one, 1 = event animations, 2 = all of it - insta game run
            if (FileHandeler.CheckSettingsFile())
            {
                string loadedJson = File.ReadAllText(FileHandeler.ReturnPath(2));
                if (!string.IsNullOrEmpty(loadedJson))
                {
                    Console.WriteLine("ApplySettings - middle log - settings json exist and isn't null or empty");
                    List<SettingsModel> settingsList = JsonSerializer.Deserialize<List<SettingsModel>>(loadedJson);
                    SettingsModel settings = settingsList[0];

                    SetLanguage(settings.Language);
                    SetResolution(settings.Resolution, win);
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
    }
}
