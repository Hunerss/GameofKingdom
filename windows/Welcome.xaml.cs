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

        private static int resolution = 0;

        public Welcome()
        {
            InitializeComponent();
            FileHandeler.CheckScores(true);
            if (FileHandeler.CheckFile(true))
                Basic.NavigateTo(frame, new MainPage(this));
            else
                Basic.NavigateTo(frame, new LicencePage(this));
            Basic.SetResolution(resolution, this);
        }

        public Welcome(int res)
        {
            InitializeComponent();
            FileHandeler.CheckScores(true);
            if (FileHandeler.CheckFile(true))
                Basic.NavigateTo(frame, new MainPage(this));
            else
                Basic.NavigateTo(frame, new LicencePage(this));
            resolution = res;
            Basic.SetResolution(resolution, this);

        }
    }
}