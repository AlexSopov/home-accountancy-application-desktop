﻿using HomeAccountancy.Model;
using HomeAccountancy.ViewModels;
using MahApps.Metro.Controls;

namespace HomeAccountancy
{
    /// <summary>
    /// Логика взаимодействия для AccountsView.xaml
    /// </summary>
    public partial class AccountsWindow : MetroWindow
    {
        public AccountsWindow()
        {
            InitializeComponent();

            DataContext = new AccountViewModel();

            CurrencyComboBox.ItemsSource = Currency.Entities;
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
    }
}
