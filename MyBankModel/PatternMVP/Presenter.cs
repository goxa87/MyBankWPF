using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBankModel
{
    /// <summary>
    /// Перезентер для связи в Креддит Виндоу
    /// </summary>
    public class Presenter
    {
        /// <summary>
        /// модель обработки записи
        /// </summary>
        IModelCredit model { get; set; }
        /// <summary>
        /// окно
        /// </summary>
        IViewCredit view { get; set; }
        /// <summary>
        /// презентеря для связи с кодом
        /// </summary>
        /// <param name="v">ссылка на окно для привязки</param>
        public Presenter(IViewCredit v)
        {
            view = v;
            model = new ModelCredit(v.Client, new SaveCredit());
        }

        /// <summary>
        /// Выполнение обработки 
        /// </summary>
        public void DoWork()
        {
            try
            {
                // проверка на наличеи е значения
                if (string.IsNullOrWhiteSpace(view.Summa) || string.IsNullOrWhiteSpace(view.Loan))
                    throw new ArgumentNullException("Поля не заполнены");

                // передача параметров из полей в модель
                model.Sum = int.Parse(view.Summa)!=0? int.Parse(view.Summa):throw new ArgumentNullException("Значения поля сумма не должно быть 0");
                model.Loan = int.Parse(view.Loan)!=0? int.Parse(view.Loan): throw new ArgumentNullException("Значения поля процент не должно быть 0");
                int temp = 0;
                int.TryParse(view.VipBonus, out temp);
                model.VipBonus = temp;
                model.Target = view.Comment;


                // метод из модели который запускает внедренную зависимость
                // подставляем новые методы  для делегата 
                model.creditHandler += CreditObjectOperations.SaveTxt;
                model.creditHandler += CreditObjectOperations.SaveDat;
                // добавление экземпляра для обработки с помощью класса
                model.Injection = new SaveCredit();
                // запуск процесса обработки нажатия клавиши
                model.Run();
                MessageBox.Show("Успешно добавлено");
                (view as Window).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Чтото пошло не так. " + ex.Message);
            }                              
        }
    }
}
