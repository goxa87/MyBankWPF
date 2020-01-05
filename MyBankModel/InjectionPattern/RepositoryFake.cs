using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    public class RepositoryFake : IRepository
    {
        public IEnumerable<Credits> CurrentList { get; set; }
        public IEnumerable<Lizings> CurrentLizings { get; set; }

        /// <summary>
        /// ненастоящий репозиторий
        /// </summary>
        /// <param name="credits">список с чему добавлять</param>
        public RepositoryFake()
        {
            CurrentList = new List<Credits>();
            CurrentLizings = new List<Lizings>();
        }
        /// <summary>
        /// Сохранение списка
        /// </summary>
        /// <param name="credits"></param>
        /// <returns></returns>
        public int SaveList(IEnumerable<Credits> credits)
        {
            int count = 0;
            foreach (var e in credits)
            {
                (CurrentList as List<Credits>).Add(e);
            }
            return count;
        }
        /// <summary>
        /// Сохранение 1 й записи
        /// </summary>
        /// <param name="credit"></param>
        /// <returns></returns>
        public bool SaveSingle(IBankCredit credit)
        {
            switch (credit)
            {
                case Credits c:
                    try
                    {
                        (CurrentList as List<Credits>).Add(c);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    break;

                case Lizings c:
                    try
                    {
                        (CurrentLizings as List<Lizings>).Add(c);
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
