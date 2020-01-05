using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    /// <summary>
    /// шаблон для внедрения в модель сохранения кредита
    /// </summary>
    public interface IInjection
    {
        bool Save(IBankCredit credit, IRepository db);
    }
}
