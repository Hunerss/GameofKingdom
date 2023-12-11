﻿using GameofKingdom.rescources.classes;
using GameofKingdom.windows.tmp.ShopWindowPages;
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
    /// Logika interakcji dla klasy Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        public Shop()
        {
            InitializeComponent();
            //Basic.NavigateTo(frame, new RealMoneyPage(this));
            Basic.NavigateTo(frame, new RealMoneyPage());
        }
    }
}
