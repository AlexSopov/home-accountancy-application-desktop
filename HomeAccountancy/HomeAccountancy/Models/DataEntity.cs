using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace HomeAccountancy.Model
{
    /// <summary>
    /// Описує дочрній об'єкст, як об’єкт даних
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public abstract class DataEntity<T> where T: DataEntity<T>
    {   
        /// <summary>
        /// Унікальний ідентифікатор об'єкта даних
        /// </summary>
        [DataMember]   
        public Guid Id { get; private set; }

        /// <summary>
        /// Колекція об'єктів даних
        /// </summary>
        public static ObservableCollection<T> Entities { get; private set; }

        static DataEntity()
        {
            Entities = new ObservableCollection<T>();
        }
        public DataEntity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Метод підтвердження статуст елемента даних
        /// </summary>
        public virtual void Commit()
        {
            // Додати елемент до бази
            Entities.Add((T)this);
        }

        /// <summary>
        /// Метод видалення елементу даних
        /// </summary>
        public virtual void Delete()
        {
            // Видалити елемент з бази
            Entities.Remove((T)this);
        }

        /// <summary>
        /// Десеріалізація об'єктів даних
        /// </summary>
        public static void DeserializeEntities()
        {
            if (!File.Exists("Data//" + typeof(T).Name + ".xml"))
                return;

            FileStream stream = null;
            DataContractSerializer serializer = null;
            XmlReader xmlReader = null;

            try
            {
                stream = new FileStream("Data//" + typeof(T).Name + ".xml", FileMode.Open);

                serializer = new DataContractSerializer(typeof(ObservableCollection<T>));
                xmlReader = XmlReader.Create(stream);

                Entities = (ObservableCollection<T>)serializer.ReadObject(xmlReader);
            }
            catch { }
            finally
            {
                xmlReader?.Close();
                stream?.Close();
            }


        }

        /// <summary>
        /// Серіалізація об'єктів даних
        /// </summary>
        public static void SerializeEntities()
        {
            FileStream stream = new FileStream("Data//" + typeof(T).Name + ".xml", FileMode.Create);
            DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<T>));

            XmlWriter xmlWriter = XmlWriter.Create(stream);
            serializer.WriteObject(xmlWriter, Entities);

            xmlWriter.Close();
            stream.Close();
        }

        /// <summary>
        ///  Знайти елемент за його Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetById(Guid id)
        {
            foreach (T entity in Entities)
            {
                if (entity.Id == id)
                    return entity;
            }

            return null;
        }
    }
}
