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
        /// <summary>
        /// Сумма кредита
        /// </summary>
        string Summa { get; set; }
        /// <summary>
        /// процентная ставка по кредиту
        /// </summary>
        string Loan { get; set; }
        /// <summary>
        /// бонус для уменьшения платежа
        /// </summary>
        string VipBonus { get; set; }
        /// <summary>
        /// комментарий
        /// </summary>
        string Comment { get; set; }
        /// <summary>
        /// клиент для которго создается кредит
        /// </summary>
        IBankClient Client { get; }
    }
}
