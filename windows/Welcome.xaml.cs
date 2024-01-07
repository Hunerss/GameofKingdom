using GameofKingdom.rescources.classes;
using GameofKingdom.windows.pages;
using GameofKingdom.windows.tmp.WelcomeWindowPages;
using System;
using System.IO;
using System.Runtime.InteropServices;
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
            //InstallFont();
            InitializeComponent();
            FileHandeler.CheckScores(false);
            if (FileHandeler.CheckFile(true))
                Basic.NavigateTo(frame, new MainPage(this));
            else
                Basic.NavigateTo(frame, new LicencePage(this));
            //FileHandeler.WriteEventsFiles();
            //Basic.NavigateTo(frame, new TestField());
        }


    }
}