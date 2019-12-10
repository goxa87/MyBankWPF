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
    }
}
