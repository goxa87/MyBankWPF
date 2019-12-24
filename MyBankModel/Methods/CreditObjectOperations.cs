using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankModel
{ 

    /// <summary>
    /// Набор методов для операций над объектом кредита (для делегата CreditHandler)
    /// </summary>
    public static class CreditObjectOperations
    {
        /// <summary>
        /// Запись кредита в txt файл
        /// </summary>
        /// <param name="credit"> кредит для записи</param>
        public static void SaveTxt(IBankCredit credit)
        {
            try
            {
                using (StreamWriter SW = new StreamWriter("credit.txt", true, Encoding.UTF8))
                {
                    string value = "";
                    switch (credit)
                    {
                        case Credits s:
                            {
                                value = $"{s.ClientId} {s.Date.ToString()} {s.Sum} {s.Target} {s.Loan}";
                                break;
                            }
                        case Lizings s:
                            {
                                value = $"{s.FirmId} {s.Date.ToString()} {s.Sum} {s.Target} {s.Loan}";
                                break;
                            }
                        default:
                            value = "WrongFormat";
                            break;

                    }

                    SW.WriteLine(value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Запись в dat файл
        /// </summary>
        /// <param name="credit">кредит для записи</param>
        public static void SaveDat(IBankCredit credit)
        {
            try
            {
                using (StreamWriter SW = new StreamWriter("credit.dat", true, Encoding.UTF8))
                {
                    string value = "";
                    switch (credit)
                    {
                        case Credits s:
                            {
                                value = $"{s.ClientId} {s.Date.ToString()} {s.Sum} {s.Target} {s.Loan}";
                                break;
                            }
                        case Lizings s:
                            {
                                value = $"{s.FirmId} {s.Date.ToString()} {s.Sum} {s.Target} {s.Loan}";
                                break;
                            }
                        default:
                            value = "WrongFormat";
                            break;

                    }

                    SW.WriteLine(value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
