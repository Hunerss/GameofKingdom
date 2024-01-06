using GameofKingdom.rescources.classes;
using GameofKingdom.windows.pages.SettingsWindowPages;
using GameofKingdom.windows.tmp.WelcomeWindowPages;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace GameofKingdom.windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {

        private static Welcome window;

        public MainPage(Welcome win)
        {
            window = win;
            InitializeComponent();
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            string btn_name = Basic.ReturnName(sender);
            switch (btn_name.Length)
            {
                case 5:
                    {
                        Window win = new();
                        //Console.WriteLine("_" + btn_name + "_");
                        switch (btn_name)
                        {
                            case "btn_1":
                                Console.WriteLine("Moving to Main window");
                                Basic.NavigateTo(window.frame, new ScorePage(window));
                                break;
                            case "btn_2":
                                Console.WriteLine("Moving to Score window");
                                Basic.NavigateTo(window.frame, new ScorePage(window));
                                break;
                            case "btn_3":
                                Console.WriteLine("Moving to Instruction window");
                                Basic.NavigateTo(window.frame, new InstructionPage(window));
                                break;
                            case "btn_4":
                                Console.WriteLine("Moving to Settings window");
                                Basic.NavigateTo(window.frame, new MainSettingsPage(window));
                                break;
                            case "btn_5":
                                Console.WriteLine("Moving to Licence window");
                                Basic.NavigateTo(window.frame, new LicencePage(window));
                                break;
                            case "btn_6":
                                Console.WriteLine("Closing the application");
                                Window.GetWindow(this).Close();
                                Application.Current.Shutdown();
                                break;
                            default:
                                break;
                        }
                        //if (btn_name == "btn_1" || btn_name == "btn_4" || btn_name == "btn_5" || btn_name == "btn_7")
                        //{
                        //    Window.GetWindow(this).Close();
                        //    if (btn_name == "btn_7")
                        //        Thread.Sleep(1500);
                        //    win.Show();

                        //}
                        break;
                    }
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
