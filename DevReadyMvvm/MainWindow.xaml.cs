﻿using System;
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
using DevReadyMvvm.ViewModel;

namespace DevReadyMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SampleViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SampleViewModel source = (SampleViewModel)DataContext;
            source.Name = "Duncan";
            
        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            SampleViewModel source = (SampleViewModel)DataContext;
            MessageBox.Show("The textbox says: " + source.Name);

        }
    }
}
