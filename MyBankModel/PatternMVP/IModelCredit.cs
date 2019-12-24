using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    /// <summary>
    /// делегат для работы с экземплярами кредитных объектов
    /// </summary>
    /// <param name="credit"></param>
    public delegate void CreditHandler(IBankCredit credit);

    /// <summary>
    /// Шаблон для модели добавления кредита
    /// </summary>
    public interface IModelCredit
    {
        /// <summary>
        /// клиент для которгог создается кредит
        /// </summary>
        IBankClient Client { get; }
        /// <summary>
        /// сумма операции кредита . Вностияся для обработки
        /// </summary>
        int Sum { get; set; }
        /// <summary>
        /// процент ставки по кредиту. Вностися для обработки
        /// </summary>
        int Loan { get; set; }
        /// <summary>
        /// цель кредита
        /// </summary>
        string Target { get; set; }
        /// <summary>
        /// вип бонус (минус списания по кредиту) если есть
        /// </summary>
        int VipBonus { get; set; }

        /// <summary>
        /// Внедряемый объект, который выполняет операции с данными модели
        /// </summary>
        IInjection Injection { get; set; }

        // здесь второй вриант с использованием делегата

            /// <summary>
            /// делегат на обработку кредита
            /// </summary>
        CreditHandler creditHandler { get; set; }

        /// <summary>
        /// Запускает сохранение
        /// </summary>
        void Run();
    }
}
