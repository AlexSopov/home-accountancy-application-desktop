using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace HomeAccountancy.Model
{
    [DataContract]
    public abstract class DataEntity<T> where T: DataEntity<T>
    {   
        [DataMember]   
        public Guid Id { get; private set; }
        public static ObservableCollection<T> Entities { get; private set; }

        static DataEntity()
        {
            Entities = new ObservableCollection<T>();
        }
        public DataEntity()
        {
            Id = Guid.NewGuid();
        }
        public virtual void Commit()
        {
            Entities.Add((T)this);
        }
        public virtual void Delete()
        {
            Entities.Remove((T)this);
        }

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
        public static void SerializeEntities()
        {
            FileStream stream = new FileStream("Data//" + typeof(T).Name + ".xml", FileMode.Create);
            DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<T>));

            XmlWriter xmlWriter = XmlWriter.Create(stream);
            serializer.WriteObject(xmlWriter, Entities);

            xmlWriter.Close();
            stream.Close();
        }
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
