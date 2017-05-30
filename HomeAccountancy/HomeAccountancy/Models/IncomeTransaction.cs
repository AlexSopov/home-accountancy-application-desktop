using System;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    /// <summary>
    /// Класс транакціївитрати
    /// </summary>
    [DataContract]
    public class IncomeTransaction : Transaction
    {
        /// <summary>
        /// Кнструювання об'єкту, передача параметрів до базового класу
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="fromAccountId"></param>
        /// <param name="sum"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        public IncomeTransaction(Guid
            categoryId, Guid fromAccountId, double sum, DateTime date, string description) : 
            base(categoryId, fromAccountId, date, sum, description)
        {
        }


        /// <summary>
        /// Перевірка чи правильна сума для обраної категорії платежу
        /// </summary>
        /// <returns></returns>
        public override bool ValidateSum()
        {
            throw new NotImplementedException();
        }
    }
}
