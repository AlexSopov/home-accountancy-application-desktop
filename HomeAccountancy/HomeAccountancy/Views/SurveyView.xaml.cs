using HomeAccountancy.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HomeAccountancy
{
    public partial class SurveyView : UserControl
    {
        public SurveyView()
        {
            InitializeComponent();

            DateFrom.SelectedDate = DateTime.Today;
            DateTo.SelectedDate = DateTime.Today.AddMonths(1);

            DataContext = new TransactionViewModel();
            DataContainer.ItemsSource = ((TransactionViewModel)DataContext).Transactions;
        }

        private void DataContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
