using System;

namespace MyBankModel.Models
{
    public class Credit
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Сума кредита
        /// </summary>
        public int CreditSum { get; private set; }
        /// <summary>
        /// дыты выдачи
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Ставка процента по кредиту
        /// </summary>
        public double Loan { get; set; }

        /// <summary>
        /// цель кредита
        /// </summary>
        public string Target { get;set;} 
    }
}