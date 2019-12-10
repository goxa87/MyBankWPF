using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

namespace MyBankModel.Models
{
    public class Client
    {
        #region fields
        /// <summary>
        /// идентификатор
        /// </summary>
        
        public int ID { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// текущий баланс
        /// </summary>
        public int Balance { get; set; }
        /// <summary>
        /// Начальная сумма депозита
        /// </summary>
        public int Deposit { get; set; }
        /// <summary>
        /// проценты для начисления на депозит
        /// </summary>
        public double Tax { get; private set; }
        
        /// <summary>
        /// список кредитов 
        /// </summary>
        public ObservableCollection<Credit> Credits { get; set; }
        #endregion

        /// <summary>
        /// поумолчанию
        /// </summary>
        public Client() { }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="n">имя</param>
        /// <param name="l">фамилия</param>
        /// <param name="b">баланс</param>
        /// <param name="d">начальный депозит</param>
        /// <param name="t">проценты по вкладу</param>

        public Client( string n, string l, int b, int d, double t)
        {
            Name = n;
            LastName = l;
            Balance = b;
            Deposit = d;
            Tax = t;  
        }


    }
}
