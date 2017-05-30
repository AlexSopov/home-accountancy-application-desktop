using System;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    /// <summary>
    /// Класс транакції з переказу коштів з одного рахунку на інший
    /// </summary>
    [DataContract]
    public class TransferTransaction : Transaction
    {
        /// <summary>
        /// Отримувач переводу
        /// </summary>
        [DataMember]
        public Guid ToAccontId { get; private set; }

        /// <summary>
        /// Конструювання транзакції, передача параметрів до базового класу
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="fromAccountId"></param>
        /// <param name="toAccountId"></param>
        /// <param name="sum"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        public TransferTransaction(Guid categoryId, Guid fromAccountId, Guid toAccountId, double sum, DateTime date, string description) :
            base(categoryId, fromAccountId, date, sum, description)
        {
            ToAccontId = toAccountId;
        }

        /// <summary>
        /// Підтвердження статусу переказу. Створення транзакції по зняттю грошей 
        /// з одного разунку та начисленні їх на інший
        /// </summary>
        public override void Commit()
        {
            base.Commit();
        }

        /// <summary>
        /// перевірка відповідності суми платежу його категорії
        /// </summary>
        /// <returns></returns>
        public override bool ValidateSum()
        {
            return Sum > 0;
        }
    }
}
