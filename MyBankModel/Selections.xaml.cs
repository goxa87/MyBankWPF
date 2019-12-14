using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Selections.xaml
    /// </summary>
    public partial class Selections : Window
    {
        
        /// <summary>
        /// Новое окно выборок
        /// </summary>
        public Selections()
        {
            InitializeComponent();
            try
            {
                List<Credits> cr = new List<Credits>();
                List<Clients> cl = new List<Clients>();
                //Загрузка данных для работы  
                
                    cr = App.context.Credits.ToList();
                    cl = App.context.Clients.ToList();
               
                // задача продолжения                

                //Зпрос объединение Credits and Clients по ID уопрядочены по имени
                var credits = cr.Join
                        (cl,
                        p => p.ClientId,
                        n => n.Id,
                        (p, n) =>
                        new
                        {
                            Name = n.Name,
                            LastName = n.LastName,
                            Sum = p.Sum,
                            Loan = p.Loan,
                            Date = p.Date,
                            VipBonus = p.VipBonus,
                            Target = p.Target
                        }).OrderBy(p => p.LastName).ThenBy(p => p.Name);
                    dgList.ItemsSource = credits;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Получение свойдной информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectCr_Click(object sender, RoutedEventArgs e)
        {
            List<Clients> clients = new List<Clients>();
            List<Credits> credits =new List<Credits>();
            List<Firms> firms = new List<Firms>();
            List<Lizings> lizings = new List<Lizings>();
            try
            {
                App.context.Clients.Load();
                clients = App.context.Clients.ToList();
                App.context.Credits.Load();
                credits = App.context.Credits.ToList();
                App.context.Firms.Load();
                firms = App.context.Firms.ToList();
                App.context.Lizings.Load();
                lizings = App.context.Lizings.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //количественные показатели
            int totClients = clients.Count();
            int totCredits = credits.Count();
            int totFirms = firms.Count();
            int totLizings = lizings.Count();
            // количество вип  клиентов
            int vipCount = clients.Where(p => p.Vip == true).Count();

            // суммы
            int balanceSum = clients.Sum(p => p.Balance) + firms.Sum(p => p.Balance);
            int creditsSum = credits.Sum(p => p.Sum) + lizings.Sum(p => p.Sum);

            //средние значения
            double averCredit = credits.Average(p=>p.Sum);
            double averlizings = lizings.Average(p => p.Sum);

            MessageBox.Show($"клиентов: {totClients}\nкредитов: {totCredits}\nфирм: {totFirms}\nлизингов: {totLizings}\nвип клиентов: {vipCount}\nвклады: {balanceSum}" +
                $"\nкредиты: {creditsSum}\nсредний кредит: {averCredit}\nсредний лизинг: {averlizings}","Сведения.",MessageBoxButton.OK,MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// выборка с количеством и суммами кредитов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectCrSum_Click(object sender, RoutedEventArgs e)
        {
            //для клиентов
            if (radClient.IsChecked.Value)
            {
                try
                {
                    App.context.Clients.Load();
                    App.context.Credits.Load();

                    var cr = App.context.Credits.ToList();
                    var cl = App.context.Clients.ToList();


                    var arr = cr.GroupBy(p => p.ClientId).Select(p => new { Id = p.Key, ColCredits = p.Count() })
                        .Join(cl, p => p.Id, c => c.Id, (p, c) => new { ID = p.Id, Name = c.Name, Last = c.LastName, TotalCountCredit = p.ColCredits });

                    dgList.ItemsSource = arr;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    App.context.Firms.Load();
                    App.context.Lizings.Load();

                    var cr = App.context.Lizings.ToList();
                    var cl = App.context.Firms.ToList();


                    var arr = cr.GroupBy(p => p.FirmId).Select(p => new { Id = p.Key, ColCredits = p.Count() })
                        .Join(cl, p => p.Id, c => c.Id, (p, c) => new { ID = p.Id, Name = c.Name, TotalCountCredit = p.ColCredits });

                    dgList.ItemsSource = arr;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        /// <summary>
        /// Выборка по параметрам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (radClient.IsChecked.Value)
            {
                try
                {
                    //Загрузка данных для работы            
                    var cr = App.context.Credits.ToList();
                    var cl = App.context.Clients.ToList();

                    //Зпрос объединение Credits and Clients по ID уопрядочены по имени
                    var credits = cr.Join
                        (cl,
                        p => p.ClientId,
                        n => n.Id,
                        (p, n) =>
                        new
                        {
                            Id = n.Id,
                            Name = n.Name,
                            LastName = n.LastName,
                            Balance = n.Balance,
                            Sum = p.Sum,
                            Loan = p.Loan,
                            Date = p.Date,
                            VipBonus = p.VipBonus,
                            Target = p.Target
                        });

                    if (radId.IsChecked.Value)// в зависимости от радио разные сортировки
                    {
                        var rez = credits.OrderBy(p => p.Id);
                        dgList.ItemsSource = rez;
                    }
                    else if (radName.IsChecked.Value)
                    {
                        var rez = credits.OrderBy(p => p.LastName).ThenBy(p => p.Name);
                        dgList.ItemsSource = rez;
                    }
                    else
                    {
                        var rez = credits.OrderBy(p => p.Balance);
                        dgList.ItemsSource = rez;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                try
                {
                    //Загрузка данных для работы            
                    var cr = App.context.Lizings.ToList();
                    var cl = App.context.Firms.ToList();

                    //Зпрос объединение Credits and Clients по ID 
                    var credits = cr.Join
                        (cl,
                        p => p.FirmId,
                        n => n.Id,
                        (p, n) =>
                        new
                        {
                            Id = n.Id,
                            Name = n.Name,
                            Balance = n.Balance,
                            Sum = p.Sum,
                            Loan = p.Loan,
                            Date = p.Date,
                            Target = p.Target
                        });

                    if (radId.IsChecked.Value) // в зависимости от радио разные сортировки
                    {
                        var rez = credits.OrderBy(p => p.Id);
                        dgList.ItemsSource = credits;
                    }
                    else if (radName.IsChecked.Value)
                    {
                        var rez = credits.OrderBy(p => p.Name);
                        dgList.ItemsSource = rez;
                    }
                    else
                    {
                        var rez = credits.OrderBy(p => p.Balance);
                        dgList.ItemsSource = rez;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
