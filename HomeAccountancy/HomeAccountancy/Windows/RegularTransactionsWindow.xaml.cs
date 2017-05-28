using MahApps.Metro.Controls;
using System.Windows;

namespace HomeAccountancy.Windows
{
    public partial class RegularTransactionsWindow : MetroWindow
    {
        public RegularTransactionsWindow()
        {
            InitializeComponent();

            int[] days = new int[31];
            for (int i = 0; i < days.Length; i++)
                days[i] = i;

            DayOfMonth.ItemsSource = days;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
