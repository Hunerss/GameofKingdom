using GameofKingdom.rescources.classes;
using System;
using System.Windows;

namespace GameofKingdom.windows
{
    /// <summary>
    /// Logika interakcji dla klasy Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
            Basic.NavigateTo(mainFrame, new MainPage());
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
                                Console.WriteLine("Moving to Main window");
                                win = new Score();
                                break;
                            case "btn_3":
                                Console.WriteLine("Moving to Main window");
                                win = new Instruction();
                                break;
                            case "btn_4":
                                Console.WriteLine("Moving to Main window");
                                win = new Shop();
                                break;
                            case "btn_5":
                                Console.WriteLine("Moving to Main window");
                                win = new Settings();
                                break;
                            case "btn_6":
                                Console.WriteLine("Moving to Main window");
                                win = new Licence();
                                break;
                            case "btn_7":
                                Console.WriteLine("Restarting the application");
                                win = new Welcome();
                                break;
                            case "btn_8":
                                Console.WriteLine("Closing the application");
                                Close();
                                break;
                            default:
                                break;
                        }
                        win.Show();
                        Close();
                        break;
                    }

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        //private 
    }
}
