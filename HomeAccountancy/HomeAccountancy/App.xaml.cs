using HomeAccountancy.Model;
using System.Windows;

namespace HomeAccountancy
{
    public partial class App : Application
    {
        public App()
        {
            DataEntity<Account>.LoadEntities();
            DataEntity<Category>.LoadEntities();
            DataEntity<Currency>.LoadEntities();
            DataEntity<Rate>.LoadEntities();
            DataEntity<Transaction>.LoadEntities();
        }
    }
}