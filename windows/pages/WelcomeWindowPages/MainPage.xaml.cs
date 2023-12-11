using GameofKingdom.rescources.classes;
using GameofKingdom.windows.tmp.WelcomeWindowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {

        private static Welcome window;

        public MainPage(Welcome welcome)
        {
            window = welcome;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string btn_name = Basic.ReturnName(sender);
            switch (btn_name.Length)
            {
                case 5:
                    {
                        Window win = new();
                        switch (btn_name)
                        {
                            case "btn_1":
                                Console.WriteLine("Moving to Main window");
                                win = new Main();
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
                                Console.WriteLine("Moving to Shop window");
                                win = new Shop();
                                break;
                            case "btn_5":
                                Console.WriteLine("Moving to Settings window");
                                win = new Settings();
                                break;
                            case "btn_6":
                                Console.WriteLine("Moving to Licence window");
                                Basic.NavigateTo(window.frame, new LicencePage(window));
                                break;
                            case "btn_7":
                                Console.WriteLine("Restarting the application");
                                win = new Welcome();
                                break;
                            case "btn_8":
                                Console.WriteLine("Closing the application");
                                Window.GetWindow(this).Close();
                                break;
                            default:
                                break;
                        }
                        if (btn_name == "btn_1" || btn_name == "btn_4" || btn_name == "btn_5" || btn_name == "btn_7")
                        {
                            Window.GetWindow(this).Close();
                            if(btn_name == "btn_7")
                                Thread.Sleep(1500);
                            win.Show();
                            
                        }   
                        break;
                    }
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
