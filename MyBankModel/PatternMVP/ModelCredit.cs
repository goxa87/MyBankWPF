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
        /// сумма
        /// </summary>
        public int Sum { get ; set ; }
        /// <summary>
        /// процент
        /// </summary>
        public int Loan { get ; set ; }
            /// <summary>
            /// цель
            /// </summary>
        public string Terget { get; set; }
        /// <summary>
        /// вип бонус
        /// </summary>
        public int VipBonus { get ; set ; }

        /// <summary>
        /// класс который выполняет сохранение кредита к клиенту 
        /// (ПАТТЕРН ВНЕДРЕНИЕ ЗАВИСИМОСТЕЙ)
        /// </summary>
        public IInjection injection { get ; set ; }

        /// <summary>
        /// Создание модели
        /// </summary>
        /// <param name="cl1">клиент для которого будет выполнен добавление</param>
        public ModelCredit(IBankClient cl1)
        {
            Client = cl1;
            injection = new SaveCredit();
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
                        credit = ClientsFactory.GetCredit("кр", Sum, Loan, (Client as Clients).Id, VipBonus, Terget);
                        break;
                    }
                case Firms c:
                    {
                        credit = ClientsFactory.GetCredit("л", Sum, Loan, (Client as Firms).Id, VipBonus, Terget);
                        break;
                    }
            }

            injection.Save(credit); // Выполнение логики

        }
    }
}
