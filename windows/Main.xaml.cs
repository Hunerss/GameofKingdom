using GameofKingdom.rescources.classes;
using GameofKingdom.windows.pages.MainWindowPages;
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
    /// Logika interakcji dla klasy Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            Basic.NavigateTo(frame, new LogInPage(this));
            Basic.ApplySettings(this);
        }
    }
}
