using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;

namespace MyBankModel.Tests
{
    [TestClass]
    public class SaveCreditTests
    {
        MyDb db { get; set; }
        SaveCredit SC { get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            MyDb db = new MyDb("provider=System.Data.SqlClient;data source=GEORGIY-ПК\\sqlexpress;initial catalog=BankDB;integrated security=True;pooling=False;");
            SC = new SaveCredit();
        }
        [TestMethod]
        public void SaveCredit_BankCredit()
        {
            // инициализация
            var input = ClientsFactory.GetCredit("кр", 1, 1, 1, 0, "цель");

            // выполнение
            //MyDb db = new MyDb("provider=System.Data.SqlClient;data source=GEORGIY-ПК\\sqlexpress;initial catalog=BankDB;integrated security=True;pooling=False;");

            //SaveCredit 
            SC.Save(input,db);

            //App.context.Credits.Load();
            //var rezult = App.context.Credits.Where(e => e.Sum == 1 && e.Loan == 1 && e.VipBonus == 0 && e.ClientId == 1).FirstOrDefault();

            db.Credits.Load();
            var rezult = db.Credits.Where(e => e.Sum == 1 && e.Loan == 1 && e.VipBonus == 0 && e.ClientId == 1).FirstOrDefault();
            // сравнение


            Assert.IsTrue((input as Credits).ClientId == rezult.ClientId &&
                (input as Credits).Sum == rezult.Sum &&
                (input as Credits).Target == rezult.Target &&
                (input as Credits).Loan == rezult.Loan);
                

        }
    }
}
