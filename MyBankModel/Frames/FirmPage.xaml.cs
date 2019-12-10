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
            App.context.Firms.Load();
            lvFirms.ItemsSource = App.context.Firms.Local.ToBindingList<Firms>();
        }

        /// <summary>
        /// Вызов окна средитов для выбранного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowCredits_Click(object sender, RoutedEventArgs e)
        {
            if (lvFirms.SelectedItems != null)
            {
                CreditList creditList = new CreditList(new SelectionArgs((this.lvFirms.SelectedItem as Firms).Id, Type.Firm, false));
                creditList.Show();
            }
            else
                MessageBox.Show("Начала выдилите клиента");
        }
    }
}
