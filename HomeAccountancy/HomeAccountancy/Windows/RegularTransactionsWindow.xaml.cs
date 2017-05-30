using HomeAccountancy.Model;
using HomeAccountancy.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;

namespace HomeAccountancy.Windows
{
    public partial class RegularTransactionsWindow : MetroWindow
    {
        public RegularTransactionsWindow()
        {
            InitializeComponent();

            DataPresenter.DataContext = new RegularTransactionViewModel();


            int[] days = new int[31];
            for (int i = 0; i < days.Length; i++)
                days[i] = i + 1;

            DayOfMonth.ItemsSource = days;
            AccountsList.ItemsSource = Account.Entities;
            CategoriesList.ItemsSource = Category.Entities;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int i = 0; i < Transaction.Entities.Count; i++)
            {
                if (Transaction.Entities[i] is RegularTransaction)
                    Transaction.Entities[i].Commit();
            }
        }
    }
}
