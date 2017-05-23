using System;

namespace HomeAccountancy.Data
{
    class Currency : DataEntity<Currency>
    {
        public string FullName { get; private set; }
        public string ShortageName { get; private set; }

        public Currency(string fullName, string shortageName)
        {
            FullName = fullName;
            ShortageName = shortageName;
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override Currency GetById()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
