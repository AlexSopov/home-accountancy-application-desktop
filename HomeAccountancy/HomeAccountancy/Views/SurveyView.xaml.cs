using HomeAccountancy.Model;
using HomeAccountancy.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace HomeAccountancy
{
    public partial class SurveyView : UserControl
    {
        public SurveyView()
        {
            InitializeComponent();

            MainContent.DataContext = new TransactionsViewModel();

            DataContainer.Items.IsLiveSorting = true;
            DataContainer.Items.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

            Accounts.ItemsSource = Account.Entities;
        } 

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new SingleTransactionWindow().ShowDialog();
            (MainContent.DataContext as TransactionsViewModel).UpdateRentInfo();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            (MainContent.DataContext as TransactionsViewModel).UpdateRentInfo();
        }
    }
}
