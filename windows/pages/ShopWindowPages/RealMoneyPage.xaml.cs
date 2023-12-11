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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameofKingdom.windows.tmp.ShopWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy RealMoneyPage.xaml
    /// </summary>
    public partial class RealMoneyPage : UserControl
    {

        private static Shop window;

        public RealMoneyPage(Shop shop)
        {
            window = shop;
            InitializeComponent();
        }

        public RealMoneyPage()
        {
            InitializeComponent();
        }
    }
}
