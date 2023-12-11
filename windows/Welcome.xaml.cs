using GameofKingdom.rescources.classes;
using GameofKingdom.windows.tmp.WelcomeWindowPages;
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
            if(FileHandeler.CheckFile())
                Basic.NavigateTo(frame, new MainPage(this));
            else
                Basic.NavigateTo(frame, new LicencePage(this));
        }   
    }
}
