﻿using GameofKingdom.rescources.classes;
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

        private static int resolution = 0;

        public Settings()
        {
            InitializeComponent();
            Basic.NavigateTo(frame, new GraphicSettingsPage(this));
            Basic.SetResolution(resolution, this);
        }

        public Settings(int res)
        {
            InitializeComponent();
            Basic.NavigateTo(frame, new GraphicSettingsPage(this));
            resolution = res;
            Basic.SetResolution(resolution, this);
        }
    }
}
