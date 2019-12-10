using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyBankModel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static myContext context { get; set; }
        /// <summary>
        /// Доступ к БД
        /// </summary>
        public static MyDb context { get; private set; }
        /// <summary>
        /// Возможные ставки кредитов
        /// </summary>
        public static string[] taxes { get; private set; }

        public App()
        {
            //context = new myContext();
            context = new MyDb();
            taxes = new string[] { "2% легкий", "5% нормальный", "8% чёткий", "10% отличный" };

        }
    }
}
