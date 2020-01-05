using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    public class RepositoryReal : IRepository
    {
        public IEnumerable<Credits> CurrentList { get; set; }

        MyDb Db { get; }

        public RepositoryReal(MyDb db)
        {
            Db = db;
            CurrentList = Db.Credits;
        }
        /// <summary>
        /// Добавление списка к репозиторию
        /// </summary>
        /// <param name="credits"></param>
        /// <returns></returns>
        public int SaveList(IEnumerable<Credits> credits)
        {
            int count = 0;
            foreach (var e in credits)
            {
                (CurrentList as DbSet<Credits>).Add(e);

                count++;
            }
            Db.SaveChanges();
            return count;
        }
        /// <summary>
        /// Добавление одионочной записи кредита к ДБ Сет
        /// </summary>
        /// <param name="credit">Что сохраняем итпа IBankCredit</param>
        /// <returns></returns>
        public bool SaveSingle(IBankCredit credit)
        {
            switch (credit)
            {
                case Credits c:
                    try
                    {
                        Db.Credits.Add(c);
                        Db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    break;

                case Lizings c:
                    try
                    {
                        Db.Lizings.Add(c);
                        Db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    break;


                default:
                    throw new ArgumentException("Неверный параметр для сохранения в БД"); 
            }

            return true;
        }
    }
}
