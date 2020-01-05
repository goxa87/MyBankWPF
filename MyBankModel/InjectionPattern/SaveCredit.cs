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
        /// <param name="credit">кредит для сохранения</param>
        public void Save(IBankCredit credit,MyDb db)
        {
            //в зависимости от типа добавить в БД
            switch (credit)
            {
                case Credits c:
                    {
                        db.Credits.Add(c);
                        db.SaveChanges();
                        break;
                    }
                case Lizings c:
                    {
                        db.Lizings.Add(c);
                        db.SaveChanges();
                        break;
                    }
                default:
                    throw new ArgumentException("Неверный формат представления объекта кредит");
            }

            //Debug.WriteLine("Дошел нормально");
        }
    }
}
