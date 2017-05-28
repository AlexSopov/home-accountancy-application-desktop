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

            MainContent.DataContext = new TransactionsViewModel();
        } 

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new SingleTransactionWindow().ShowDialog();

            (MainContent.DataContext as TransactionsViewModel).UpdateRentInfo();
        }
    }
}
