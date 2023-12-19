using System;
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

        public static void SetResolution(int resolution, Window win)
        {
            switch (resolution)
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

    }
}
