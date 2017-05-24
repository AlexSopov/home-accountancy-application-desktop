using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace HomeAccountancy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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
        }

        private void ShowSurveyView_click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
            ShowReportView.IsChecked = false;
        }

        private void ShowReportView_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
            ShowSurveyView.IsChecked = false;
        }
    }
}
