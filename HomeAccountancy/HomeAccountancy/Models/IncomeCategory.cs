using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    /// <summary>
    /// Класс категорії поповнення
    /// </summary>
    [DataContract]
    public class IncomeCategory : Category
    {
        /// <summary>
        /// Конструювання об'єкту. Передача параметрів до базового класу
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public IncomeCategory(string name, string description) : base(name, description)
        {
        }

        /// <summary>
        /// Отримати знак категорій. (Перевизначення методу класу Category)
        /// </summary>
        /// <returns></returns>
        public override int GetTransactionSign()
        {
            return 1;
        }
    }
}
