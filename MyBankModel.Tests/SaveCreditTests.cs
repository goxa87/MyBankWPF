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
            // ПРОВЕРЯЕТ НА ВХОЖДЕНИЕ ПОСЛЕ ДОБАВЛЕНИЯ
            // инициализация
            var input = ClientsFactory.GetCredit("кр", 1, 1, 1, 0, "цель");

            // выполнение
            SaveCredit SC = new SaveCredit();
            RepositoryFake RF = new RepositoryFake();
             bool rez = SC.Save(input, RF);

            // сравнение

            if (RF.CurrentList.FirstOrDefault() != input)
                Assert.Fail();

            //Assert.AreEqual(true, rez);
        }

        [TestMethod]
        public void SaveCredit_NotBankKredit()
        {
            // ПРОВЕРЯЕТ ВЫБРОС ОШИБКИ ПРИ НЕВЕРНОМ АРГУМЕНТЕ
            // инициализация
            var input = new NotCredit();

            // выполнение
            SaveCredit SC = new SaveCredit();
            RepositoryFake RF = new RepositoryFake();
            try
            {
                bool rez = SC.Save(input, RF);
                Assert.Fail();
            }
            catch {
                
            }
            finally { }
            // сравнение

            

        }
        
        class NotCredit : IBankCredit
                {
                    
                }
        
    }
}
