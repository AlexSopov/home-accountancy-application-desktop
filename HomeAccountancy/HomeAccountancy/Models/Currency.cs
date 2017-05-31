using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    public class Currency : DataEntity<Currency>, INotifyPropertyChanged
    {
        [DataMember]
        private string _FullName;

        [DataMember]
        private string _ShortageName;

        [DataMember]
        private bool _IsMainCurrency;

        public string FullName
        {
            get { return _FullName; }
            set
            {
                _FullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public static Currency MainCurrency
        {
            get
            {
                foreach (Currency currency in Entities)
                {
                    if (currency.IsMainCurrency)
                        return currency;
                }

                return null;
            }
        }
        public string ShortageName
        {
            get { return _ShortageName; }
            set
            {
                _ShortageName = value;
                OnPropertyChanged("ShortageName");
            }
        }
        public bool IsMainCurrency
        {
            get { return _IsMainCurrency; }
            set
            {
                if (value)
                {
                    foreach (Currency currency in Entities)
                    {
                        if (!currency.IsMainCurrency)
                        {
                            currency.IsMainCurrency = false;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Currency currency in Entities)
                    {
                        if (!currency.IsMainCurrency)
                        {
                            currency.IsMainCurrency = true;
                            break;
                        }
                    }
                }

                _IsMainCurrency = value;
                OnPropertyChanged("IsMainCurrency");
            }
        }

        public Currency(string fullName, string shortageName) : base()
        {
            FullName = fullName;
            ShortageName = shortageName;
            Commit();

            Rate rateRel = new Rate(Id, Id, 1);
            rateRel.Commit();

            foreach (Currency currency in Entities)
            {
                if (currency.Id == Id)
                    continue;

                Rate rateFT = new Rate(Id, currency.Id, 1);
                Rate rateTF = new Rate(currency.Id, Id, 1);

                rateFT.Commit();
                rateTF.Commit();
            }
        }

        public override void Delete()
        {
            //if (IsMainCurrency && Entities.Count == 1)
            //    return;

            List<Transaction> delete = new List<Transaction>();
            foreach (Transaction transaction in Transaction.Entities)
            {
                if (transaction.TransactionCurrency.Id == Id)
                    delete.Add(transaction);
            }
            foreach (Transaction transaction in delete)
                transaction.Delete();

            //if (IsMainCurrency)
            //{
            //    foreach (Currency currency in Entities)
            //    {
            //        if (!currency.IsMainCurrency)
            //        {
            //            currency.IsMainCurrency = true;
            //            break;
            //        }
            //    }
            //}

            base.Delete();
        }
        public double ConvertToMainCurrency(double sum)
        {
            Currency mainCurrency = MainCurrency;
            foreach (Rate rate in Rate.Entities)
            {
                if (rate.CurrencyFromId == Id && rate.CurrencyToId == mainCurrency.Id)
                    return sum * rate.RateFromTo;
            }

            return sum;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return ShortageName;
        }
    }
}