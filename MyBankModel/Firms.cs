//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBankModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Firms:IBankClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Deposit { get; set; }
        public double Tax { get; set; }
        public string Adress { get; set; }

        public Firms() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">имя</param>
        /// <param name="d">бплпнс</param>
        /// <param name="t">такса вклада</param>
        /// <param name="adr">адрес</param>
        public Firms(string n, int d, double t, string adr)
        {
            Name = n;
            Deposit = d;
            Balance = d;
            Tax = t;
            Adress = adr;
        }
    }
}
