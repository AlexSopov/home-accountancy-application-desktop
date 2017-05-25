using System;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class Currency : DataEntity<Currency>
    {
        [DataMember]
        public string FullName { get; private set; }
        [DataMember]
        public string ShortageName { get; private set; }

        public Currency(string fullName, string shortageName) : base()
        {
            FullName = fullName;
            ShortageName = shortageName;
        }

        public override string ToString()
        {
            return ShortageName;
        }
    }
}
