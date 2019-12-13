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
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace MyBankModel.Frames
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            
            App.context.Clients.Load();
            lvClients.ItemsSource = App.context.Clients.Local.ToBindingList<Clients>();

        }

        /// <summary>
        /// Окно кредитов для выбранного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowCredits_Click(object sender, RoutedEventArgs e)
        {            
            if (lvClients.SelectedValue != null)
            {
                CreditList creditList = new CreditList(new SelectionArgs((this.lvClients.SelectedItem as Clients).Id, Type.Client, false));
                creditList.Show();
            }
            else
                MessageBox.Show("Начала выдилите клиента");

        }

        /// <summary>
        /// Контекстное меню.  добавление кредита
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddLizing_Click(object sender, RoutedEventArgs e)
        {
            CreditWindow CW = new CreditWindow(this.lvClients.SelectedItem);
            CW.Show();
        }

        /// <summary>
        /// Удаелние клиента и всех его кредитов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var flag = MessageBox.Show("Точно безвозвратно удалить его и все его кредиты?", "ВНИМАНИЕ", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (flag == MessageBoxResult.Yes)
            {
                int clientId = (lvClients.SelectedItem as Clients).Id;  // ид клиента

                var arr = App.context.Credits.Where(t => t.ClientId == clientId);   // удаление кредитов
                foreach (var n in arr)
                {
                    App.context.Credits.Remove(n);
                }

                var client = App.context.Clients.Find(clientId);  // удаление самого клиента
                App.context.Clients.Remove(client);

                App.context.SaveChanges();


            }

        }
    }

}
