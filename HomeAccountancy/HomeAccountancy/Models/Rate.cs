using System;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class Rate : DataEntity<Rate>
    {
        [DataMember]
        public Guid CurrencyFromId { get; private set; }

        [DataMember]
        public Guid CurrencyToId { get; private set; }
        public double RateFromTo { get { throw new NotImplementedException(); } }
        public double RateToFrom { get { throw new NotImplementedException(); } }

        [DataMember]
        private double _RateFromTo { get; set; }

        public Rate(Guid currencyFromId, Guid currencyToId, double rateFromTo) : base()
        {
            CurrencyFromId = currencyFromId;
            CurrencyToId = currencyToId;
            _RateFromTo = rateFromTo;
        }
    }
}
