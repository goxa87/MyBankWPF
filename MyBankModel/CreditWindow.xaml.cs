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
    public partial class CreditWindow : Window
    {
        /// <summary>
        /// Клиент для которого создается кредит
        /// </summary>
        Clients client { get; }

        /// <summary>
        /// Фирма для которой будет создаваться
        /// </summary>
        Firms firm { get; }

        /// <summary>
        /// тип клиента 1- физ 0- юр
        /// </summary>
        bool IsTpye { get; }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="cl">объект типа Credits  или Lizings остальное закроется</param>
        public CreditWindow(object cl)
        {
            InitializeComponent();
            // PATTERN MATHING
            switch (cl)
            {
                case Clients c:
                    {
                        client = c;
                        txtTitle.Text = $"Клиент (физ.лицо) №{client.Id} {client.Name} {client.LastName} Vip - {client.Vip}";
                        IsTpye = true;
                        break;
                    }

                case Firms f:
                    {
                        firm = f;
                        txtTitle.Text = $"Клиент (юр.лицо) №{firm.Id} {firm.Name} ";
                        IsTpye = false;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Передан неверный тип");
                        this.Close();
                        break;
                    }
            }

            txtVipBonus.Text = "0";
                
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



            /// <summary>
            /// Закрывает окно без сохранения
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Добавление на основе выбранного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSum.Text) || string.IsNullOrEmpty(txtLoan.Text) || string.IsNullOrEmpty(txtVipBonus.Text))
            {
                MessageBox.Show("Заполние поля!","VOID",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            else // когда поля не пустые
            {
                if (IsTpye) // для физ лица
                {
                    int vipB = 0; // вычисление бонуса
                    if (client.Vip)
                        vipB = Convert.ToInt32(txtVipBonus.Text);

                    var credit = new Credits() // создание кредита
                    {
                        ClientId = client.Id,
                        Date = DateTime.Now,
                        Loan = Convert.ToInt32(txtLoan.Text),
                        Sum = Convert.ToInt32(txtSum.Text),
                        VipBonus = vipB,
                        Target = txtTarget.Text
                    };

                    App.context.Credits.Add(credit); // добавление
                    App.context.SaveChanges();
                    MessageBox.Show("Кредит успешно добавлен", "Поздравляем", MessageBoxButton.OK, MessageBoxImage.Warning);  // оповещение
                    this.Close();   // закрыть окно
                }
                else // юр лицо
                {
                    var lizing = new Lizings()  //объект для добавления
                    {
                        FirmId = firm.Id,
                        Date = DateTime.Now,
                        Loan = Convert.ToInt32(txtLoan.Text),
                        Sum = Convert.ToInt32(txtSum.Text),
                        ComeBack = Convert.ToInt32(txtVipBonus.Text),
                        Target = txtTarget.Text
                    };

                    App.context.Lizings.Add(lizing);  // вносим в базу
                    App.context.SaveChanges();

                    MessageBox.Show("Кредит успешно добавлен", "Поздравляем", MessageBoxButton.OK, MessageBoxImage.Warning);  // оповещение
                    this.Close();   // закрыть окно
                }
            }
        }
    }
}
