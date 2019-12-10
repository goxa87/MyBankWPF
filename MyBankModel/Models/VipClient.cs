using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel.Models
{
    /// <summary>
    /// Vip клиент
    /// </summary>
    public class VipClient:Client
    {
        /// <summary>
        /// Статический бонус на депозит
        /// </summary>
        public int DepositBonus { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        public VipClient() { }

        /// <summary>
        /// Новый вип клиент
        /// </summary>
        /// <param name="n">имя</param>
        /// <param name="l">фамилия</param>
        /// <param name="b">баланс</param>
        /// <param name="d">депозит</param>
        /// <param name="t"> ставка по депозиту</param>
        /// <param name="bonus">бонус на депозит</param>
        /// <param name="comment">комментарий</param>
        public VipClient(string n, string l, int b, int d, double t, int bonus, string comment):base(n,l,b,d,t)
        {
            DepositBonus = bonus;
            Comment = comment;
        }
    }
}
