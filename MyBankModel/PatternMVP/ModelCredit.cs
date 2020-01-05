using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    /// <summary>
    /// Модель добавления кредита
    /// </summary>
    public class ModelCredit : IModelCredit
    {
        /// <summary>
        /// клиент для которого создается кредит
        /// </summary>
        public IBankClient Client { get ; }
        /// <summary>
        /// сумма кредита
        /// </summary>
        public int Sum { get ; set ; }
        /// <summary>
        /// процентная ставка на кредит
        /// </summary>
        public int Loan { get ; set ; }
            /// <summary>
            /// цель кредитования
            /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// вип бонус
        /// </summary>
        public int VipBonus { get ; set ; }

        /// <summary>
        /// класс который выполняет сохранение кредита к клиенту 
        /// (ПАТТЕРН ВНЕДРЕНИЕ ЗАВИСИМОСТЕЙ)
        /// </summary>
        public IInjection Injection { get ; set ; }

        /// <summary>
        /// делегат для выполнения операций с экземплярами кредита
        /// </summary>
        public CreditHandler creditHandler { get; set; }

        /// <summary>
        /// Создание модели
        /// </summary>
        /// <param name="cl1">клиент для которого будет выполнен добавление</param>
        public ModelCredit(IBankClient cl1, IInjection injClass)
        {
            Client = cl1;
            Injection = injClass;
        }

        /// <summary>
        /// Выполнение операции сохранения
        /// </summary>
        public void Run()
        {
            // заглушка
            IBankCredit credit = new Credits();

            switch (Client) // создание в зависимости от типа
            {
                case Clients c:
                    {
                        credit = ClientsFactory.GetCredit("кр", Sum, Loan, (Client as Clients).Id, VipBonus, Target);
                        break;
                    }
                case Firms c:
                    {
                        credit = ClientsFactory.GetCredit("л", Sum, Loan, (Client as Firms).Id, VipBonus, Target);
                        break;
                    }
            }

            Injection.Save(credit,App.context); // Выполнение логики для сохранения из объекта класса

            // выполнение логики путем зауска делегата

            creditHandler?.Invoke(credit);

        }
    }
}
