using HomeAccountancy.Model;
using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

            Categories.ItemsSource = Category.Entities;
            Accounts.ItemsSource = Account.Entities;
            Sum.Value = 0;

            if (Category.Entities.Count > 0)
                Categories.SelectedIndex = 0;

            if (Account.Entities.Count > 0)
                Accounts.SelectedIndex = 0;

            CurrentDate.SelectedDate = DateTime.Now;
            MainData.DataContextChanged += (sender, e) => InitIfDataContext();
        } 

        private void InitIfDataContext()
        {
            if (MainData.DataContext == null)
                return;

            Transaction transaction = MainData.DataContext as Transaction;
            Accounts.SelectedItem = transaction.TransactionAccount;
            CurrentDate.SelectedDate = transaction.Date;
            Categories.SelectedItem = transaction.TransactionCategory;
            Sum.Value = transaction.Sum;
            Comment.Text = transaction.Description;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Categories.SelectedItem == null || Accounts.SelectedItem == null)
                return;

            if (MainData.DataContext != null)
            {
                Transaction currentTransaction = MainData.DataContext as Transaction;
                currentTransaction.TransactionAccount = Accounts.SelectedItem as Account;
                currentTransaction.Date = CurrentDate.SelectedDate.Value;
                currentTransaction.TransactionCategory = Categories.SelectedItem as Category;
                currentTransaction.Sum = Sum.Value.Value;
                currentTransaction.Description = Comment.Text;

                Close();
                return;
            }

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

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
