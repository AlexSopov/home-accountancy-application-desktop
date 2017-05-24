using System;
using System.Collections.Generic;

namespace HomeAccountancy.Model
{
    class Account : DataEntity<Account>
    {
        public string Name { get; private set; }
        public long CurrencyId { get; private set; }

        public Account(long id, string name, long currencyId) : base(id)
        {
            Name = name;
            CurrencyId = currencyId;
        }

        public List<Transaction> Transactions
        {
            get
            {
                throw new NotImplementedException();
            }
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
            return Name;
        }
    }
}
