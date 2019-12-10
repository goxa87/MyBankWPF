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

        public MainWindow()
        {
            InitializeComponent();

            frMain.Content = new Frames.ClientPage();            
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

        private void BtnSelection_Click(object sender, RoutedEventArgs e)
        {

        }
    }

   
}
