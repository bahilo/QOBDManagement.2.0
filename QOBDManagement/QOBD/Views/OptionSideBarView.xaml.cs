﻿using QOBD.Classes;
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

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for OptionSideBarView.xaml
    /// </summary>
    public partial class OptionSideBarView : UserControl
    {
        public OptionSideBarView()
        {
            InitializeComponent();
        }

        private void OptionSideBarView_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
