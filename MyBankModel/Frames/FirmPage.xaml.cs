using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace MyBankModel.Frames
{
    /// <summary>
    /// Логика взаимодействия для FirmPage.xaml
    /// </summary>
    public partial class FirmPage : Page
    {
        public FirmPage()
        {
            
            InitializeComponent();
            try
            {                
                App.context.Firms.Load();
                lvFirms.ItemsSource = App.context.Firms.Local.ToBindingList<Firms>();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Вызов окна средитов для выбранного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowCredits_Click(object sender, RoutedEventArgs e)
        {
            if (lvFirms.SelectedValue != null)
            {
                CreditList creditList = new CreditList(new SelectionArgs((this.lvFirms.SelectedItem as Firms).Id, Type.Firm, false));
                creditList.Show();
            }
            else
                MessageBox.Show("Сначала выдилите клиента");
        }

        /// <summary>
        /// Вызов окна добавления кредита для этого клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddLizing_Click(object sender, RoutedEventArgs e)
        {
            CreditWindow CW = new CreditWindow(this.lvFirms.SelectedItem);
            CW.Show();
        }


        /// <summary>
        /// Удаление этого клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var flag = MessageBox.Show("Точно безвозвратно удалить фирму и все ее кредиты?", "ВНИМАНИЕ", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (flag == MessageBoxResult.Yes) // ответ из месседж бокса
            {
                try
                {
                    int clientId = (lvFirms.SelectedItem as Firms).Id;  // ид клиента

                    var arr = App.context.Lizings.Where(t => t.FirmId == clientId);  // удаление кредитов
                    foreach (var n in arr)
                    {
                        App.context.Lizings.Remove(n);
                    }

                    var client = App.context.Firms.Find(clientId); // удаление самого клиента
                    App.context.Firms.Remove(client);

                    App.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
    }
}
