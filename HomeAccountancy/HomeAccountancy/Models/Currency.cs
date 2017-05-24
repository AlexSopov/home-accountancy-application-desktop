using System;

namespace HomeAccountancy.Model
{
    class Currency : DataEntity<Currency>
    {
        public string FullName { get; private set; }
        public string ShortageName { get; private set; }

        public Currency(long id, string fullName, string shortageName) : base(id)
        {
            FullName = fullName;
            ShortageName = shortageName;
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ShortageName;
        }
    }
}
