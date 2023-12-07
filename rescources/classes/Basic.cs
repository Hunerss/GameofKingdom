using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
