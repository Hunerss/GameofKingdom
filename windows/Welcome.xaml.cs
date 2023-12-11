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
            Basic.NavigateTo(frame, new MainPage(this));
        }
    }
}
