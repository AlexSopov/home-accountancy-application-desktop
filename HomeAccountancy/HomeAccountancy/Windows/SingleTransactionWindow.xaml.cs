using HomeAccountancy.Model;
using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace HomeAccountancy
{
    /// <summary>
    /// Логика взаимодействия для SingleTransactionWindow.xaml
    /// </summary>
    public partial class SingleTransactionWindow : MetroWindow
    {
        public SingleTransactionWindow()
        {
            InitializeComponent();

            CurrentDate.SelectedDate = DateTime.Now;
            Categories.ItemsSource = Category.Entities;

            if (Category.Entities.Count > 0)
                Categories.SelectedIndex = 0;

            Accounts.ItemsSource = Account.Entities;

            if (Account.Entities.Count > 0)
                Accounts.SelectedIndex = 0;

            Sum.Value = 0;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // TOOD Validating
            if (Categories.SelectedItem == null || Accounts.SelectedItem == null)
                return;

            Transaction transaction = null;

            if (Categories.SelectedItem is IncomeCategory)
            {
                transaction = new IncomeTransaction(((Category)(Categories.SelectedItem)).Id,
                    ((Account)(Accounts.SelectedItem)).Id, Sum.Value.Value, CurrentDate.SelectedDate.Value, Comment.Text);
            }
            else
            {
                transaction = new OutgoTransaction(((Category)(Categories.SelectedItem)).Id,
                    ((Account)(Accounts.SelectedItem)).Id, Sum.Value.Value, CurrentDate.SelectedDate.Value, Comment.Text);
            }

            Close();
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
    }
}
