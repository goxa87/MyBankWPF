using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;

namespace MyBankModel.Tests
{
    [TestClass]
    public class SaveCreditTests
    {        
        [TestMethod]
        public void SaveCredit_BankCredit()
        {
            // инициализация
            var input = ClientsFactory.GetCredit("кр", 1, 1, 1, 0, "цель");

            // выполнение
            SaveCredit SC = new SaveCredit();
             bool rez = SC.Save(input, new RepositoryFake());

            // сравнение

            Assert.AreEqual(true, rez);
        }
    }
}
