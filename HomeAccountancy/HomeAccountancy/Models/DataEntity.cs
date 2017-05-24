using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;

namespace HomeAccountancy.Model
{
    abstract class DataEntity<T> where T: DataEntity<T>
    {      
        public long Id { get; private set; }
        public static ObservableCollection<T> Entities = new ObservableCollection<T>();

        protected static SQLiteDataAdapter DataAdapter { get; set; }
        protected static DataSet DataSet { get; set; }

        public DataEntity(long id)
        {
            Id = id;
        }

        public static void PreloadData(SQLiteDataAdapter adapter, DataSet dataSet)
        {
            DataAdapter = adapter;
            DataSet = dataSet;
        }
        public static T GetById(long id)
        {
            foreach (T entity in Entities)
            {
                if (entity.Id == id)
                    return entity;
            }

            return null;
        }

        public abstract void Delete();
        public abstract void Save();
    }
}
