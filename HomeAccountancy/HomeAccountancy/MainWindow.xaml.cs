using HomeAccountancy.Model;
using HomeAccountancy.ViewModels;
using HomeAccountancy.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace HomeAccountancy
{
    public partial class MainWindow : MetroWindow
    {
        public object Accounts { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            ChartPresenter.DataContext = new ChartViewModel();
        }

        private /*async*/ void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*if (e.Cancel)
                return;

            e.Cancel = true;

            MetroDialogSettings exitDialog = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Так",
                NegativeButtonText = "Ні",
                AnimateShow = true,
                AnimateHide = false
            };

            MessageDialogResult result = await this.ShowMessageAsync("Завершення роботи",
                "Ви дійсно бажаєте завершити роботу програми?",
                MessageDialogStyle.AffirmativeAndNegative, exitDialog);

            if (result == MessageDialogResult.Affirmative)
                Application.Current.Shutdown();*/

            //Currency currency = new Currency("Українська гривня", "грн.");
            //Currency currency2 = new Currency("Російський рубль", "руб.");
            //Currency currency3 = new Currency("Долар США", "$");
            //currency.Commit();
            //currency2.Commit();
            //currency3.Commit();
            // Category category = new OutgoCategory("Витрати", "");
            //Account acc = new Account("Готівка", currency.Id, 0);

            DataEntity<Account>.SerializeEntities();
            DataEntity<Category>.SerializeEntities();
            DataEntity<Currency>.SerializeEntities();
            DataEntity<Rate>.SerializeEntities();
            DataEntity<Transaction>.SerializeEntities();
        }

        private void ShowSurveyView_click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
            ShowDiagramView.IsChecked = false;
        }
        private void ShowPlans_Click(object sender, RoutedEventArgs e)
        {
            new RegularTransactionsWindow().ShowDialog();
        }
        private void ShowDiagram_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
            ShowSurveyView.IsChecked = false;

            ChartPresenter.DataContext = new ChartViewModel();
        }
        private void Accounts_click(object sender, RoutedEventArgs e)
        {
            new AccountsWindow().ShowDialog();
        }
        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            new CategoriesWindow().ShowDialog();
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            PieChart chart = (PieChart)chartpoint.ChartView;

            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 5;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            new FilterWindow().ShowDialog();
        }
    }
}
