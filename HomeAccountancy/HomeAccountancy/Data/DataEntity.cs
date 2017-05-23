using System.Collections.Generic;

namespace HomeAccountancy.Data
{
    abstract class DataEntity<T>
    {
        public long Id { get; private set; }
        public static List<T> Entities;

        static DataEntity()
        {
            Entities = new List<T>();
            LoadData();
        }
        private static void LoadData()
        {

        }

        public abstract T GetById();
        public abstract void Delete();
        public abstract void Save();
    }
}
