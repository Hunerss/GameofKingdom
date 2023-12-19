﻿using GameofKingdom.rescources.classes;
using GameofKingdom.windows.pages.FreePageComponents;
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

namespace GameofKingdom.windows.tmp.SettingsWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy LanguageSettingsPage.xaml
    /// </summary>
    public partial class LanguageSettingsPage : UserControl
    {

        private static Settings window;

        public LanguageSettingsPage(Settings settings)
        {
            window = settings;
            InitializeComponent();
            Basic.NavigateTo(frame, new SettingsNavigation(window));
        }
    }
}
