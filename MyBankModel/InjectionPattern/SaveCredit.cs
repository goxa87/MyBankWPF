using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    /// <summary>
    /// Хранит операцию обработки объекта кредита
    /// </summary>
    public class SaveCredit : IInjection
    {
        public SaveCredit()
        {
            //Save(cr1);
        }

        /// <summary>
        /// сохранение кредита
        /// </summary>
        /// <param name="credit"></param>
        public void Save(IBankCredit credit)
        {
            //в зависимости от типа добавить в БД
            switch (credit)
            {
                case Credits c:
                    {
                        App.context.Credits.Add(c);
                        App.context.SaveChanges();
                        break;
                    }
                case Lizings c:
                    {
                        App.context.Lizings.Add(c);
                        App.context.SaveChanges();
                        break;
                    }
                default:
                    throw new FormatException("Неверный формат представления объекта кредит");
            }
            Debug.WriteLine("Дошел нормально");
        }
    }
}
