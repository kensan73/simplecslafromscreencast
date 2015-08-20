﻿using System.Windows;
using BizLogicLibrary;

namespace HelloCslaWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = await PersonEdit.GetPersonEditAsync(123);
        }
    }
}
