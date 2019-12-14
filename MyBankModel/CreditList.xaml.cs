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
using System.Data.Entity;

namespace MyBankModel
{
    /// <summary>
    /// Логика взаимодействия для CreditList.xaml
    /// </summary>
    public partial class CreditList : Window
    {
        /// <summary>
        /// оюъект для управления выборками
        /// </summary>
        SelectionHandler selectionHandler;

        public CreditList(SelectionArgs args)
        {
            InitializeComponent();
            selectionHandler += select;
            selectionHandler?.Invoke(args);
                        
        }


        /// <summary>
        /// обработчик параметров вызова
        /// </summary>
        /// <param name="args"></param>
        void select(SelectionArgs args)
        {
            try
            {
                if (args.AllFlag == true && args.type == Type.Client)  // все кредиты для клиентов
                {
                    App.context.Credits.Load();
                    dgCredits.ItemsSource = App.context.Credits.Local.ToBindingList<Credits>();
                    txtInfo.Text = "Все физические лица";
                }

                if (args.AllFlag == true && args.type == Type.Firm)  // все кредиты для клиентов
                {
                    App.context.Lizings.Load();
                    dgCredits.ItemsSource = App.context.Lizings.Local.ToBindingList<Lizings>();
                    txtInfo.Text = "Все юридические лица";
                }

                if (args.AllFlag == false && args.type == Type.Client) // кредиты конкретного клиента
                {
                    App.context.Clients.Load();
                    var rez = App.context.Credits.Where<Credits>((e) => e.ClientId == args.ClientID);

                    dgCredits.ItemsSource = rez.ToList();

                    var client = App.context.Clients.Where(e => e.Id == args.ClientID).FirstOrDefault();
                    txtInfo.Text = $"Клиент: id{client.Id} - {client.Name} {client.LastName} VIP: {client.Vip}";
                }

                if (args.AllFlag == false && args.type == Type.Firm) // кредиты конкретного клиента
                {
                    App.context.Firms.Load();
                    var rez = App.context.Lizings.Where<Lizings>((e) => e.FirmId == args.ClientID);

                    dgCredits.ItemsSource = rez.ToList();

                    var client = App.context.Firms.Where(e => e.Id == args.ClientID).FirstOrDefault();
                    txtInfo.Text = $"Клиент: id{client.Id} - {client.Name}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
