using GameofKingdom.rescources.classes;
using GameofKingdom.windows.pages.SettingsWindowPages;
using GameofKingdom.windows.tmp.SettingsWindowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameofKingdom.windows
{
    /// <summary>
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            Basic.NavigateTo(frame, new MainSettingsPage(this));
            Basic.ApplySettings(this);
        }
    }
}
