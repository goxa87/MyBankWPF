using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace MyBankModel.Methods
{
    /// <summary>
    /// азные обработчики событий
    /// </summary>
    public static class Handlers
    {
        /// <summary>
        /// Начисления для всех счетов в БД по депозитам
        /// </summary>
        /// <param name="db">бд</param>
        /// <returns>общая сумма начислений для всех аккаонтов</returns>
        public static int DoDividend(MyDb db)
        {
            int summ = 0; // общая сумма начислений для всех аккаонтов
            // вычисления
            try
            {
                App.context.Clients.Load();

                foreach (var e in App.context.Clients)  // физ лица
                {
                    int val = 0; // сумма начисления

                    val = e.Balance * Convert.ToInt32(e.Tax) / 100;
                    if (e.Vip)
                        val += e.DepositBonus;
                    e.Balance += val;  // увеличение баланса
                    summ += val;  // для отчета
                }
                //App.context.SaveChanges();

                App.context.Firms.Load();

                foreach (var e in App.context.Firms)
                {
                    int val = 0;

                    val = e.Balance * Convert.ToInt32(e.Tax) / 100;
                    e.Balance += val;
                    summ += val;
                }
                App.context.SaveChanges();
            }            
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return summ;
        }

        /// <summary>
        /// списания по кредитам со счетов 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static int TakeLoan(MyDb db)
        {
            int summ = 0; // общая сумма начислений для всех аккаонтов
            // вычисления
            try
            {
                App.context.Clients.Load();
                App.context.Credits.Load();

                foreach (var e in App.context.Clients) // снятие для клиентов
                {
                    int val = 0;
                    //App.context.Credits

                    //Если нет кредитов вылазит эксепшн. Нужно проверять на наличие записей

                    if (App.context.Credits.Where(i => i.ClientId == e.Id).Count() > 0)
                    {
                        // выбор из кредитов по id потом создание нового анон типа со значением  произведения размера кредита, на таксу потом сумма для всех записей
                        val = App.context.Credits.Where(i => i.ClientId == e.Id).Select(j =>
                                new
                                {
                                    LoanSum = j.Sum * j.Loan / 100
                                }
                            ).Sum(k => k.LoanSum);
                    }

                    e.Balance -= val;  // сняие со счета

                    summ += val;
                }

                App.context.Firms.Load();
                foreach (var e in App.context.Firms) // снятие для фирм
                {
                    int val = 0;
                    int lizBonus = 0;
                    //App.context.Credits
                    if (App.context.Lizings.Where(i => i.FirmId == e.Id).Count() > 0)
                    {
                        // выбор из кредитов по id потом создание нового анон типа со значением  произведения размера кредита, на таксу потом сумма для всех записей
                        val += App.context.Lizings.Where(i => i.FirmId == e.Id).Select(j =>
                                new
                                {
                                    LoanSum = j.Sum * j.Loan / 100
                                }
                            ).Sum(k => k.LoanSum);

                        // вычисление возврата НДС по лизингу на баланс  
                        lizBonus = App.context.Lizings.Where(i => i.FirmId == e.Id).Sum(p => p.ComeBack);
                    }

                    e.Balance += lizBonus;  // просто начисляется на баланс
                    e.Balance -= val;  // сняие со счета процентов по кредитам

                    summ += val;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return summ;
        }


    }
}
