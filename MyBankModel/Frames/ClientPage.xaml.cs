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
    }

}
