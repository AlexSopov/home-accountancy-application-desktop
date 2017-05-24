using System;
using System.Data.SQLite;

namespace HomeAccountancy.Model
{
    class Rate : DataEntity<Rate>
    {
        public long CurrencyFromId { get; private set; }
        public long CurrencyToId { get; private set; }
        public double RateFromTo { get { throw new NotImplementedException(); } }
        public double RateToFrom { get { throw new NotImplementedException(); } }

        private double _RateFromTo { get; set; }

        public Rate(long id, long currencyFromId, long currencyToId, double rateFromTo) : base(id)
        {
            CurrencyFromId = currencyFromId;
            CurrencyToId = currencyToId;
            _RateFromTo = rateFromTo;
        }


        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
