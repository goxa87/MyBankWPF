using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    class ClientsFactory
    {
        /// <summary>
        /// получение клиента
        /// </summary>
        /// <param name="type">тип "к" - клиент или "ф" - фирма</param>
        /// <param name="balance">баланс</param>
        /// <param name="name">имя</param>
        /// <param name="lastn">фамилия</param>
        /// <param name="tax">ставка</param>
        /// <param name="vip">вип</param>
        /// <param name="depbon">бонус вип</param>
        /// <param name="CommAdr">комент или адрес</param>
        /// <returns></returns>
        public static IBankClient GetClient(string type , int balance, string name = "NoName", string lastn = "NoLastName",
            double taxth = 10,bool vip = false, int depbon = 0, string CommAdr ="NoInfo" )
        {
            switch (type)
            {
                case "к":
                    return new Clients(name, lastn, balance, taxth, vip, depbon, CommAdr);
                case "ф":
                    return new Firms(name, balance, taxth, CommAdr);
                default:
                    return new Clients("NoName","NoLast",0,0,false,0,"");
            }
        }

        /// <summary>
        /// получение кредита
        /// </summary>
        /// <param name="type">тип "кр" - кредит для клиента   "л" - лизинг</param>
        /// <param name="sum">сумма</param>
        /// <param name="loan">процет</param>
        /// <param name="clid">клиент</param>
        /// <param name="bonus">бонус</param>
        /// <param name="target">цель</param>
        /// <returns></returns>
        public static IBankCredit GetCredit(string type, int sum, int loan, int clid,
            int bonus = 0, string target = "цель" )
        {
            switch (type)
            {
                case "кр":
                    return new Credits(sum, loan, target, bonus, clid);
                case "л":
                    return new Lizings(sum, loan, target, bonus, clid);
                default:
                    return new Credits(0, 0, "не определен", 0, clid);
            }
        }
    }
}
