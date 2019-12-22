using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyBankModel
{
    /// <summary>
    /// Логика взаимодействия для CreditWindow.xaml
    /// </summary>
    public partial class CreditWindow : Window,IViewCredit
    {
        /// <summary>
        /// сумма кредита
        /// </summary>
        public string Summa { get => txtSum.Text ; set => txtSum.Text = value; }
        /// <summary>
        /// Процент по кредиту
        /// </summary>
        public string Loan { get => txtLoan.Text; set => txtLoan.Text = value; }
        /// <summary>
        /// вип бонус
        /// </summary>
        public string VipBonus { get => txtVipBonus.Text; set => txtVipBonus.Text = value; }
        /// <summary>
        /// комент
        /// </summary>
        public string Comment { get => txtTarget.Text; set => txtTarget.Text = value; }
        /// <summary>
        /// объект к кторому будет добавлен кредит
        /// </summary>
        public IBankClient Client { get; }
        /// <summary>
        /// представление логики
        /// </summary>
        Presenter presenter { get; set; }


        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="cl">объект типа Credits  или Lizings остальное закроется</param>
        public CreditWindow(IBankClient cl)
        {
            InitializeComponent();
            // PATTERN MATHING
            switch (cl)
            {
                case Clients c:
                    {
                        Client = c as Clients;
                        txtTitle.Text = $"Клиент (физ.лицо) №{(Client as Clients).Id} {(Client as Clients).Name} {(Client as Clients).LastName} Vip - {(Client as Clients).Vip}";
                        //IsTpye = true;
                        break;
                    }

                case Firms c:
                    {
                        Client = c as Firms;
                        txtTitle.Text = $"Клиент (юр.лицо) №{(Client as Firms).Id} {(Client as Firms).Name} ";
                        //IsTpye = false;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Передан неверный тип");
                        this.Close();
                        break;
                    }
            }

            presenter = new Presenter(this);

            txtVipBonus.Text = "0";
            btnCancel.Click += (s, e) => this.Close();
            btnAdd.Click += (s, e) => presenter.DoWork();
        } 



        /// <summary>
        /// Вводит только цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSum_KeyDown(object sender, KeyEventArgs e)
        {
            // допустимые ключи
            Key[] keys = new Key[] { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, Key.Back };
            bool flag = true; // флаг нахождения
            foreach (var i in keys)
            {
                if (e.Key == i)
                {
                    flag = false;  // если нашел то меняем 
                }
            }
            // выполнить в зависимости от результата поиска
            e.Handled = flag;
        }



        //    /// <summary>
        //    /// Закрывает окно без сохранения
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //private void BtnCancel_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        /// <summary>
        /// Добавление на основе выбранного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void BtnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtSum.Text) || string.IsNullOrEmpty(txtLoan.Text) || string.IsNullOrEmpty(txtVipBonus.Text))
        //    {
        //        MessageBox.Show("Заполние поля!", "VOID", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }
        //    else // когда поля не пустые
        //    {
        //        if (IsTpye) // для физ лица
        //        {
        //            int vipB = 0; // вычисление бонуса
        //            if (client.Vip)
        //                vipB = Convert.ToInt32(txtVipBonus.Text);

        //            var credit = new Credits() // создание кредита
        //            {
        //                ClientId = client.Id,
        //                Date = DateTime.Now,
        //                Loan = Convert.ToInt32(txtLoan.Text),
        //                Sum = Convert.ToInt32(txtSum.Text),
        //                VipBonus = vipB,
        //                Target = txtTarget.Text
        //            };

        //            var credit = ClientsFactory.GetCredit("кр", Convert.ToInt32(txtSum.Text), Convert.ToInt32(txtLoan.Text), client.Id, vipB, txtTarget.Text);
        //            try
        //            {
        //                App.context.Credits.Add(credit as Credits); // добавление
        //                App.context.SaveChanges();
        //                MessageBox.Show("Кредит успешно добавлен", "Поздравляем", MessageBoxButton.OK, MessageBoxImage.Warning);  // оповещение
        //                this.Close();   // закрыть окно
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("ошибка обращения к БД " + ex.Message);
        //            }
        //        }
        //        else // юр лицо
        //        {
        //            var lizing = new Lizings()  //объект для добавления
        //            {
        //                FirmId = firm.Id,
        //                Date = DateTime.Now,
        //                Loan = Convert.ToInt32(txtLoan.Text),
        //                Sum = Convert.ToInt32(txtSum.Text),
        //                ComeBack = Convert.ToInt32(txtVipBonus.Text),
        //                Target = txtTarget.Text
        //            };

        //            var lizing = ClientsFactory.GetCredit("л", Convert.ToInt32(txtSum.Text), Convert.ToInt32(txtLoan.Text), firm.Id, Convert.ToInt32(txtVipBonus.Text), txtTarget.Text);
        //            try
        //            {
        //                App.context.Lizings.Add(lizing as Lizings);  // вносим в базу
        //                App.context.SaveChanges();

        //                MessageBox.Show("Кредит успешно добавлен", "Поздравляем", MessageBoxButton.OK, MessageBoxImage.Warning);  // оповещение
        //                this.Close();   // закрыть окно
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("ошибка обращения к БД " + ex.Message);
        //            }
        //        }
        //    }
        //}
    }
}
