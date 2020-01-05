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
        /// Сохранение кредита в репозиторий
        /// </summary>
        /// <param name="credit">кредит для сохранения</param>
        /// <param name="repository">репозиторий куда сохраняется</param>
        public bool Save(IBankCredit credit,IRepository repository)
        {
            return repository.SaveSingle(credit);

            ////в зависимости от типа добавить в БД
            //switch (credit)
            //{
            //    case Credits c:
            //        {
            //            repository.SaveSingle(c);
            //            break;
            //        }
            //    case Lizings c:
            //        {
            //            repository.SaveSingle(c);
            //            break;
            //        }
            //    default:
            //        throw new ArgumentException("Неверный формат представления объекта кредит");
            //}

            //Debug.WriteLine("Дошел нормально");
        }
    }
}
