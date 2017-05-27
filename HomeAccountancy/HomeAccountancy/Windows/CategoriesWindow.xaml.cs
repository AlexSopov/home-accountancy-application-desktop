using HomeAccountancy.ViewModels;
using MahApps.Metro.Controls;

namespace HomeAccountancy.Windows
{
    public partial class CategoriesWindow : MetroWindow
    {
        public CategoriesWindow()
        {
            InitializeComponent();

            DataContext = new CategoryViewModel();
        }

        private void ListPresenter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            (DataContext as CategoryViewModel).SelectedPage = ListPresenter.SelectedIndex;
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
    }
}
