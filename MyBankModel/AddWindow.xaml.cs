using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        /// <summary>
        /// добавляемый тип 1 = клиента 0 - фирма
        /// </summary>
        bool Type { get; set; }

        public AddWindow()
        {
            InitializeComponent();
            Type = true;  // что добавляем
            cbTaxes.ItemsSource = App.taxes;  // содержимое комбо
            cbTaxes.SelectedIndex = 0;
        }

        /// <summary>
        /// Нажате клавиши чтоб были только цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtDeposit_KeyDown(object sender, KeyEventArgs e)
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
        /// Режим клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadClient_Click(object sender, RoutedEventArgs e)
        {
            // затенить некоторые недоступные поля
            Type = true;
            txtLastName.IsEnabled = true;
            txtLastName.Background = Brushes.Black;
            chVip.IsEnabled = true;
            lblBonus.Foreground = Brushes.Black;
            txtBonus.IsEnabled = true;
            txtBonus.Background = Brushes.Black;
        }
        /// <summary>
        /// Режим Фирмы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadFirm_Click(object sender, RoutedEventArgs e)
        {

            // разблокировать некоторые недоступнные поля
            Type = false;
            txtLastName.IsEnabled = false;
            txtLastName.Background = Brushes.Gray;
            chVip.IsEnabled = false;
            lblBonus.Foreground = Brushes.Gray;
            txtBonus.IsEnabled = false;
            txtBonus.Background = Brushes.Gray;
        }

        /// <summary>
        /// Добавление через entity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddEntity_Click(object sender, RoutedEventArgs e)
        {
            //некоторые поля не должны быть пустыми
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDeposit.Text))
            {
                MessageBox.Show("Поля имя и депозит не должны быть пустыми");
                return;
            }

            // тип клиент или фирма
            if (Type)
            {
                int tax = Convert.ToInt32(cbTaxes.SelectedItem.ToString().Split('%')[0]); // получить % по вкладу из строк в APP.ефчуыы
                bool vip;  // вип или нет
                int depBonus = 0;  // бонус зависит от вип
                if (chVip.IsChecked == true)
                {
                    vip = true;
                    depBonus = Convert.ToInt32(txtBonus.Text);
                }
                else
                {
                    vip = false;
                }


                var cl1 = new Clients()  // создаем экземпляр
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    Balance = Convert.ToInt32(txtDeposit.Text),
                    Deposit = Convert.ToInt32(txtDeposit.Text),
                    Tax = tax,
                    Vip = vip,
                    DepositBonus = depBonus,
                    Comment = txtComment.Text                    
                };
                try
                {
                    App.context.Clients.Add(cl1);  // добавить в БД
                    App.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ошибка обращения к БД " + ex.Message);
                }
            }
            else
            {
                int tax = Convert.ToInt32(cbTaxes.SelectedItem.ToString().Split('%')[0]);        //    // получить % по вкладу из строк в APP.ефчуыы

                var f1 = new Firms()  // экземпляр на основе введенных данных
                {
                    Name = txtName.Text,                    
                    Balance = Convert.ToInt32(txtDeposit.Text),
                    Deposit = Convert.ToInt32(txtDeposit.Text),
                    Tax = tax,                    
                    Adress = txtComment.Text
                };
                try { 
                    App.context.Firms.Add(f1);  // добавить в БД
                    App.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ошибка обращения к БД " + ex.Message);
                }
            }
                       
            MessageBox.Show("Добавлено");
            this.Close();
        }

        /// <summary>
        /// добавление через sql клиент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddSql_Click(object sender, RoutedEventArgs e)
        {
            //некоторые поля не должны быть пустыми
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDeposit.Text))
            {
                MessageBox.Show("Поля имя и депозит не должны быть пустыми");
                return;
            }

            string conStr = @"Data Source = GEORGIY-ПК\sqlexpress; Initial Catalog = BankDB; Integrated Security = True; Pooling = False";
            SqlConnection connection = new SqlConnection(conStr);


            if (!Type) // это фирма
            {
                var arr = cbTaxes.SelectedItem.ToString().Split('%');  // получение ставки
                string sql = $"INSERT INTO [Firms] ([Name],[Balance],[Deposit],[Tax],[Adress]) VALUES (N'{txtName.Text}',{txtDeposit.Text}," +
                    $"{txtDeposit.Text},{arr[0]},N'{txtComment.Text}')";

                using (connection)  // соедиенение
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sql, connection);
                        int number = command.ExecuteNonQuery();  // выполнение
                        MessageBox.Show($"Добавлено объектов: {number}");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ошибка обращения к БД " + ex.Message);
                    }

                }
            }
            else
            {
                string vip;
                string depBon;
                if (chVip.IsChecked == true)  // сбор данных для строки
                {
                    vip = "1";
                    depBon = txtBonus.Text;
                }
                else
                {
                    vip = "0";
                    depBon = "0";
                }
                var arr = cbTaxes.SelectedItem.ToString().Split('%');  // получение проценты по вкладу
                string sql = $"INSERT INTO [Clients] ([Name],[LastName],[Balance],[Deposit],[Tax],[Vip],[DepositBonus],[Comment]) " +
                    $"VALUES (N'{txtName.Text}',N'{txtLastName.Text}',{txtDeposit.Text},{txtDeposit.Text},{arr[0]},{vip},{depBon},N'{txtComment.Text}')";

                using (connection)
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sql, connection);
                        int number = command.ExecuteNonQuery();
                        MessageBox.Show($"Добавлено объектов: {number}");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ошибка обращения к БД " + ex.Message);
                    }
                }
            }                
        }


        /// <summary>
        /// Возвращение из этого окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
