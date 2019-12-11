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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyBankModel
{ 
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Операции по ежемесячным начислениям дивидендов по вкладам
        /// </summary>
        event OperationsHandler DepositTaxesHandler;

        /// <summary>
        /// событие для списания по кредитам
        /// </summary>
        event OperationsHandler CreditTaxesHandler;

        /// <summary>
        ///  Операции по ежемесячным списаниям процентов по кредитам с основного счета
        /// </summary>
        event OperationsHandler CreditLoanHandler;

        public MainWindow()
        {
            InitializeComponent();

            frMain.Content = new Frames.ClientPage();

            // определение  обработчиков для событий списания и начисления по счетам
            DepositTaxesHandler += Methods.Handlers.DoDividend;
            CreditTaxesHandler += Methods.Handlers.TakeLoan;

        }      

        /// <summary>
        /// Отобржение в фрейме списка обычных клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Frames.ClientPage();
        }


        /// <summary>
        /// Отображение фирм клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFirm_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Frames.FirmPage();            
        }

        /// <summary>
        /// Удаление выделенного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelFirm_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddWindow AW = new AddWindow();
            AW.Show();
        }

        /// <summary>
        /// Вызов окна выборок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelection_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Вызов окна  кредитов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAllCredits_Click(object sender, RoutedEventArgs e)
        {
            CreditList creditList = new CreditList(new SelectionArgs(0,Type.Client,true));
            creditList.Show();
        }

        /// <summary>
        /// вызов окна всех записей для кредитов для Юр лиц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAllLizings_Click(object sender, RoutedEventArgs e)
        {
            CreditList creditList = new CreditList(new SelectionArgs(0, Type.Firm, true));
            creditList.Show();
        }
        /// <summary>
        /// кнопка Начисление дивидендов по депозитам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddDepositTax_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Начислено:{DepositTaxesHandler?.Invoke(App.context)} по депозитам");
        }

        /// <summary>
        /// кнопка Списание процентов по кредитам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWCreditLoan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Снято со счетов :{CreditTaxesHandler?.Invoke(App.context)} тугриков за кредиты");
        }
    }

   
}
