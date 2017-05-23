using System;
using System.Collections.Generic;

namespace HomeAccountancy.Data
{
    class Account : DataEntity<Account>
    {
        public string Name { get; private set; }
        public long CurrencyId { get; private set; }

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

        public override Account GetById()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
