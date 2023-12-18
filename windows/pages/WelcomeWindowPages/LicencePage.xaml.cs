using GameofKingdom.rescources.classes;
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

namespace GameofKingdom.windows.tmp.WelcomeWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy LicencePage.xaml
    /// </summary>
    public partial class LicencePage : UserControl
    {

        private static Welcome window;

        public LicencePage(Welcome welcome)
        {
            window = welcome;
            InitializeComponent();
        }

        private void Btn_return(object sender, RoutedEventArgs e)
        {
            if (LicenceAgreament.IsChecked == true && FileHandeler.CheckFile(false))
            {
                Console.WriteLine("Licence Accpeted Another Time");
                Basic.NavigateTo(window.frame, new MainPage(window));
            }
            else if (LicenceAgreament.IsChecked == true)
            {
                Console.WriteLine("Licence Accpeted - Creating Licence File");
                //FileHandeler.WriteLicence();
                Basic.NavigateTo(window.frame, new MainPage(window));
            }
            else
            {
                Console.WriteLine("Licence Error - Licence not accepted");
                MessageBox.Show("Umowa Licenycja nie zakceptowana, zamykanie aplikacji");
                Window.GetWindow(this).Close();
            }
        }
    }
}
