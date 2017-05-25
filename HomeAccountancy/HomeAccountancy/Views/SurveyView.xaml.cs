using HomeAccountancy.Model;
using HomeAccountancy.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HomeAccountancy
{
    public partial class SurveyView : UserControl
    {
        TransactionViewModel Context;
        public SurveyView()
        {
            InitializeComponent();

            DateFrom.SelectedDate = DateTime.Today;
            DateTo.SelectedDate = DateTime.Today.AddMonths(1);

            Context = new TransactionViewModel();
            DataContext = Context;

            DataContainer.ItemsSource = Context.Transactions;
        } 

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new SingleTransactionWindow().ShowDialog();
        }

        private void DataContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Context.SelectedTransaction = DataContainer.SelectedItem as Transaction;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Transaction transaction = Context.SelectedTransaction;
            if (transaction != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Ви дійсно бажаєте видалити запис?", "Підтвердження дії", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Context.Transactions.Remove(transaction);
                }
            }
        }
    }
}
