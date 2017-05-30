using HomeAccountancy.Model;
using HomeAccountancy.Models;
using HomeAccountancy.ViewModels;
using MahApps.Metro.Controls;

namespace HomeAccountancy.Windows
{
    /// <summary>
    /// Логика взаимодействия для FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : MetroWindow
    {
        bool ProgramaticlyAdd;
        public FilterWindow()
        {
            InitializeComponent();

            AccountsList.ItemsSource = Account.Entities;
            CategoriesList.ItemsSource = Category.Entities;

            DataPresenter.DataContext = new FilterViewModel();
            FilterViewModel viewModel = DataPresenter.DataContext as FilterViewModel;

            ProgramaticlyAdd = true;
            foreach (var item in viewModel.CurrentFilter.EnabledCategories)
                CategoriesList.SelectedItems.Add(item);

            foreach (var item in viewModel.CurrentFilter.EnabledAccounts)
                AccountsList.SelectedItems.Add(item);
            ProgramaticlyAdd = false;
        }

        private void CategoriesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProgramaticlyAdd)
                return;

            FilterViewModel viewModel = DataPresenter.DataContext as FilterViewModel;

            foreach (var item in e.AddedItems)
                viewModel.CurrentFilter.EnabledCategories.Add((Category)item);

            foreach (var item in e.RemovedItems)
                viewModel.CurrentFilter.EnabledCategories.Remove((Category)item);
        }
        private void AccountsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProgramaticlyAdd)
                return;

            FilterViewModel viewModel = DataPresenter.DataContext as FilterViewModel;

            foreach (var item in e.AddedItems)
                viewModel.CurrentFilter.EnabledAccounts.Add((Account)item);

            foreach (var item in e.RemovedItems)
                viewModel.CurrentFilter.EnabledAccounts.Remove((Account)item);
        }

        private void UnExecuteFilter(object sender, System.Windows.RoutedEventArgs e)
        {
            Filter filter = Filter.GetInstance();
            filter.IsCategoryFilter = false;
            filter.IsDatesFilter = false;
            filter.IsSumFilter = false;

            filter.UpdateFilteredTransactions();

        }

        private void ExecuteFilter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Filter.GetInstance().UpdateFilteredTransactions();
            Close();
        }
    }
}
