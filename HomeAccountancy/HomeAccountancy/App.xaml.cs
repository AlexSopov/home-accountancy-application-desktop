using HomeAccountancy.Model;
using System.Windows;

namespace HomeAccountancy
{
    public partial class App : Application
    {
        public App()
        {
            DataEntity<Account>.DeserializeEntities();
            DataEntity<Category>.DeserializeEntities();
            DataEntity<Currency>.DeserializeEntities();
            DataEntity<Rate>.DeserializeEntities();
            DataEntity<Transaction>.DeserializeEntities();

            for (int i = 0; i < Transaction.Entities.Count; i++)
            {
                if (Transaction.Entities[i] is RegularTransaction)
                    Transaction.Entities[i].Commit();
            }
        }
    }
}