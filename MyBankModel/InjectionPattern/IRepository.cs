using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    public interface IRepository
    {
        /// <summary>
        /// Текущий список к которому нужно сохранить
        /// </summary>
        IEnumerable<Credits> CurrentList { get; set; }

        bool SaveSingle(IBankCredit credit);
        int SaveList(IEnumerable<Credits> credits);
    }
}
