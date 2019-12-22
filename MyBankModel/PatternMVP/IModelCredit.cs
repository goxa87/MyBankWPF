using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    /// <summary>
    /// Шаблон для модели добавления кредита
    /// </summary>
    interface IModelCredit
    {
        /// <summary>
        /// клиент для которгог создается кредит
        /// </summary>
        IBankClient Client { get; }
        /// <summary>
        /// сумма
        /// </summary>
        int Sum { get; set; }
        /// <summary>
        /// процент
        /// </summary>
        int Loan { get; set; }
        /// <summary>
        /// цель кредита
        /// </summary>
        string Terget { get; set; }
        /// <summary>
        /// вип бонус если есть
        /// </summary>
        int VipBonus { get; set; }

        /// <summary>
        /// хранит метод сохранения
        /// </summary>
        IInjection injection { get; set; }

        /// <summary>
        /// Запускает сохранение
        /// </summary>
        void Run();
    }
}
