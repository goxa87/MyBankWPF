using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    /// <summary>
    /// шаблон для вью добавления кредита
    /// </summary>
    public interface IViewCredit
    {
        string Summa { get; set; }

        string Loan { get; set; }

        string VipBonus { get; set; }

        string Comment { get; set; }
        /// <summary>
        /// клиент для которго создается кредит
        /// </summary>
        IBankClient Client { get; }
    }
}
