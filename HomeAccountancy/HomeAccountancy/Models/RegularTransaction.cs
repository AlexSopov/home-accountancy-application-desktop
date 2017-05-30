using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    public class RegularTransaction : Transaction, INotifyPropertyChanged
    {
        public enum ExecutingStrategy { Once, MultyDay, MultyMonth}

        [DataMember]
        private DateTime _StartDate;

        [DataMember]
        private DateTime _EndDate;

        [DataMember]
        private DateTime _LastExecuteDayDate;

        [DataMember]
        private ExecutingStrategy _Strategy;

        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                OnPropertyChanged("StartDate");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                OnPropertyChanged("EndDate");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public DateTime LastExecuteDayDate
        {
            get { return _LastExecuteDayDate; }
            set
            {
                _LastExecuteDayDate = value;
                OnPropertyChanged("LastExecuteDayDate");
            }
        }
        public ExecutingStrategy Strategy
        {
            get { return _Strategy; }
            set
            {
                _Strategy = value;
                OnPropertyChanged("Strategy");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public DateTime? NextExecutinDate
        {
            get
            {
                switch (Strategy)
                {
                    case (ExecutingStrategy.Once):
                        return ExecutingDate;
                    case (ExecutingStrategy.MultyDay):
                        return GetNextMultyDay();
                    case (ExecutingStrategy.MultyMonth):
                        return GetNextMultyMonth();
                    default:
                        return null;
                }
            }
        }

        #region OnceStrategy
        [DataMember]
        private DateTime _ExecutingDate;
        public DateTime ExecutingDate
        {
            get { return _ExecutingDate; }
            set
            {
                _ExecutingDate = value;
                OnPropertyChanged("ExecutingDate");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        #endregion
        #region MultyDayStrategy
        [DataMember]
        private bool _IsMonday, _IsTuesday, _IsWednesday, _IsThursday, _IsFriday, _IsSaturday, _IsSunday;

        public bool IsMonday
        {
            get { return _IsMonday; }
            set
            {
                _IsMonday = value;
                OnPropertyChanged("IsMonday");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public bool IsTuesday
        {
            get { return _IsTuesday; }
            set
            {
                _IsTuesday = value;
                OnPropertyChanged("IsTuesday");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public bool IsWednesday
        {
            get { return _IsWednesday; }
            set
            {
                _IsWednesday = value;
                OnPropertyChanged("IsWednesday");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public bool IsThursday
        {
            get { return _IsThursday; }
            set
            {
                _IsThursday = value;
                OnPropertyChanged("IsThursday");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public bool IsFriday
        {
            get { return _IsFriday; }
            set
            {
                _IsFriday = value;
                OnPropertyChanged("IsFriday");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public bool IsSaturday
        {
            get { return _IsSaturday; }
            set
            {
                _IsSaturday = value;
                OnPropertyChanged("IsSaturday");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        public bool IsSunday
        {
            get { return _IsSunday; }
            set
            {
                _IsSunday = value;
                OnPropertyChanged("IsSunday");
                OnPropertyChanged("NextExecutinDate");
            }
        }

        #endregion
        #region MultiMonth
        [DataMember]
        private int _DayOfMonth;
        public int DayOfMonth
        {
            get { return _DayOfMonth; }
            set
            {
                _DayOfMonth = value;
                OnPropertyChanged("DayOfMonth");
                OnPropertyChanged("NextExecutinDate");
            }
        }
        #endregion

        public RegularTransaction(Guid categoryId, Guid fromAccountId, double sum, DateTime date, string description) :
            base(categoryId, fromAccountId, date, sum, description)
        {
        }

        public override void Commit()
        {
            ExecuteToToday();
            ValidateActivity();
        }
        public static void  GetRegularSumToAccount(Account account, DateTime toDateTime, out double incomes, out double outgoes)
        {
            // TODO Refactor!!!
            double incomesSum = 0, outgoesSum = 0;
            if (account == null)
            {
                incomes = 0;
                outgoes = 0;
                return;
            }

            foreach (var transaction in Entities)
            {
                if (!(transaction is RegularTransaction))
                    continue;

                RegularTransaction regularTransaction = (RegularTransaction)transaction;
                if (regularTransaction.FromAccountId != account.Id)
                    continue;

                DateTime last = regularTransaction.LastExecuteDayDate.AddDays(1);
                while (last <= toDateTime)
                {
                    switch (regularTransaction.Strategy)
                    {
                        case (ExecutingStrategy.Once):
                            if (last == regularTransaction.ExecutingDate)
                            {
                                if (Category.GetById(regularTransaction.CategoryId) is IncomeCategory)
                                    incomesSum += regularTransaction.Sum;
                                else
                                    outgoesSum += regularTransaction.Sum;

                                break;
                            }
                            break;
                        case (ExecutingStrategy.MultyDay):
                            DayOfWeek dayofWeek = DateTime.Today.DayOfWeek;
                            if (regularTransaction.IsMonday == false && regularTransaction.IsTuesday == false && regularTransaction.IsWednesday == false && regularTransaction.IsThursday == false && regularTransaction.IsFriday == false && regularTransaction.IsSaturday == false && regularTransaction.IsSunday == false)
                                break;


                            if ((regularTransaction.IsMonday && dayofWeek == DayOfWeek.Monday) ||
                                (regularTransaction.IsTuesday && dayofWeek == DayOfWeek.Tuesday) ||
                                (regularTransaction.IsWednesday && dayofWeek == DayOfWeek.Wednesday) ||
                                (regularTransaction.IsThursday && dayofWeek == DayOfWeek.Thursday) ||
                                (regularTransaction.IsFriday && dayofWeek == DayOfWeek.Friday) ||
                                (regularTransaction.IsSaturday && dayofWeek == DayOfWeek.Saturday) ||
                                (regularTransaction.IsSunday && dayofWeek == DayOfWeek.Sunday))
                            {
                                if (Category.GetById(regularTransaction.CategoryId) is IncomeCategory)
                                    incomesSum += regularTransaction.Sum;
                                else
                                    outgoesSum += regularTransaction.Sum;
                            }
                            break;
                        case (ExecutingStrategy.MultyMonth):
                            if (last.Day == regularTransaction.DayOfMonth)
                            {
                                if (Category.GetById(regularTransaction.CategoryId) is IncomeCategory)
                                    incomesSum += regularTransaction.Sum;
                                else
                                    outgoesSum += regularTransaction.Sum;
                            }

                            if (DateTime.DaysInMonth(last.Year, last.Month) < regularTransaction.DayOfMonth &&
                                last.Day == DateTime.DaysInMonth(last.Year, last.Month))
                                if (Category.GetById(regularTransaction.CategoryId) is IncomeCategory)
                                    incomesSum += regularTransaction.Sum;
                                else
                                    outgoesSum += regularTransaction.Sum;
                            break;
                    }
                    last = last.AddDays(1);
                }              
            }

            incomes = incomesSum;
            outgoes = outgoesSum;
        }

        private void ExecuteToToday()
        {
            if (DateTime.Today <= LastExecuteDayDate)
                return;

            while (LastExecuteDayDate < DateTime.Today)
            {
                LastExecuteDayDate = LastExecuteDayDate.AddDays(1);

                switch (Strategy)
                {
                    case (ExecutingStrategy.Once):
                        if (ExecuteOnce(LastExecuteDayDate))
                        {
                            Delete();
                            return;
                        }
                        break;
                    case (ExecutingStrategy.MultyDay):
                        ExecuteMultyDay(LastExecuteDayDate);
                        break;
                    case (ExecutingStrategy.MultyMonth):
                        ExecuteMultyMonth(LastExecuteDayDate);
                        break;
                }

                if (!ValidateActivity())
                {
                    Delete();
                    return;
                }
            }
        }
        private void Execute(DateTime executingDate)
        {
            Transaction transaction = null;
            if (Category.GetById(CategoryId) is IncomeCategory)
                transaction = new IncomeTransaction(CategoryId, FromAccountId, Sum, executingDate, Description);
            else
                transaction = new OutgoTransaction(CategoryId, FromAccountId, Sum, executingDate, Description);

            transaction.Commit();
        }
        private bool ExecuteOnce(DateTime executingDate)
        {
            if (executingDate != ExecutingDate)
                return false;

            Execute(executingDate);
            return true;
        }
        private void ExecuteMultyDay(DateTime executingDate)
        {
            if (executingDate < StartDate || executingDate > EndDate)
                return;

            DayOfWeek dayofWeek = DateTime.Today.DayOfWeek;
            if (IsMonday == false && IsTuesday == false && IsWednesday == false && IsThursday == false && IsFriday == false && IsSaturday == false && IsSunday == false)
                return;


            if ((IsMonday && dayofWeek == DayOfWeek.Monday) || 
                (IsTuesday && dayofWeek == DayOfWeek.Tuesday) || 
                (IsWednesday && dayofWeek == DayOfWeek.Wednesday) || 
                (IsThursday && dayofWeek == DayOfWeek.Thursday) || 
                (IsFriday && dayofWeek == DayOfWeek.Friday) || 
                (IsSaturday && dayofWeek == DayOfWeek.Saturday) || 
                (IsSunday && dayofWeek == DayOfWeek.Sunday))
            {
                Execute(executingDate);
            }
        }
        private void ExecuteMultyMonth(DateTime executingDate)
        {
            if (executingDate < StartDate || executingDate > EndDate)
                return;

            if (executingDate.Day == DayOfMonth)
            {
                Execute(executingDate);
                return;
            }

            if (DateTime.DaysInMonth(executingDate.Year, executingDate.Month) < DayOfMonth &&
                executingDate.Day == DateTime.DaysInMonth(executingDate.Year, executingDate.Month))
                Execute(executingDate);

        }
        private bool ValidateActivity()
        {
            return NextExecutinDate != null;
        }

        private DateTime? GetNextMultyDay()
        {
            DateTime last = LastExecuteDayDate;
            while (last <= EndDate)
            {
                if (IsMonday == false && IsTuesday == false && IsWednesday == false && IsThursday == false && IsFriday == false && IsSaturday == false && IsSunday == false)
                    return null;

                if ((IsMonday && last.DayOfWeek == DayOfWeek.Monday) ||
                (IsTuesday && last.DayOfWeek == DayOfWeek.Tuesday) ||
                (IsWednesday && last.DayOfWeek == DayOfWeek.Wednesday) ||
                (IsThursday && last.DayOfWeek == DayOfWeek.Thursday) ||
                (IsFriday && last.DayOfWeek == DayOfWeek.Friday) ||
                (IsSaturday && last.DayOfWeek == DayOfWeek.Saturday) ||
                (IsSunday && last.DayOfWeek == DayOfWeek.Sunday))
                {
                    return last;
                }

                last = last.AddDays(1);
            }

            return null;
        }
        private DateTime? GetNextMultyMonth()
        {
            DateTime last = LastExecuteDayDate;
            while (LastExecuteDayDate <= EndDate)
            {
                if (last.Day == DayOfMonth)
                    return last;

                if (DateTime.DaysInMonth(last.Year, last.Month) < DayOfMonth &&
                    last.Day == DateTime.DaysInMonth(last.Year, last.Month))
                    Execute(last);

                last = last.AddDays(1);
            }

            return null;
        }

        public override bool ValidateSum()
        {
            return true;
        }
    }
}