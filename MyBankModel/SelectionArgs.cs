using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{
    /// <summary>
    /// делегат для уравления прерациями со счетами
    /// </summary>
    /// <param name="db">контекст базы вкоторой нужно выполнить операции</param>
    /// <returns></returns>
    public delegate int OperationsHandler(MyDb db);

    
    /// <summary>
    /// делегат для управления выборками
    /// </summary>
    /// <param name=""></param>
    public delegate void SelectionHandler(SelectionArgs args);
       
    public enum Type { Client,Firm}
    /// <summary>
    /// параметры вызовов для предачи в окна для выборок 
    /// </summary>
    public class SelectionArgs
    {
        /// <summary>
        /// ID клиента (они повторяются в firms i Clients)
        /// </summary>
        public int ClientID { get; }

        /// <summary>
        /// Каого типа клиент
        /// </summary>
        public Type type { get; }

        /// <summary>
        /// Флаг для выборки всех кредитов 1 lда 0- тольок для 1
        /// </summary>
        public bool AllFlag { get; }

        /// <summary>
        /// Аргументы ля вызова окна выборок кредитов
        /// </summary>
        /// <param name="id">id клиента </param>
        /// <param name="t">тип клиента</param>
        /// <param name="f"> 1 если выбрать все записи для этого типа</param>
        public SelectionArgs(int id, Type t, bool f)
        {
            ClientID = id;
            type = t;
            AllFlag = f;
        }

    }
}
