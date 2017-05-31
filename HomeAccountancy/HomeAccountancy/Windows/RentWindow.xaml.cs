using HomeAccountancy.ViewModels;
using MahApps.Metro.Controls;

namespace HomeAccountancy.Windows
{
    public partial class RentWindow : MetroWindow
    {
        public RentWindow()
        {
            InitializeComponent();

            DataPresenter.DataContext = new RateViewModel();
        }
    }
}
