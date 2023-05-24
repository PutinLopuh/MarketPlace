using Market.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

namespace Market.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Page
    {
        Order contextOrder;
        DbPropertyValues oldValues;
        public AddEdit(Order order)
        {
            InitializeComponent();
            PointCB.ItemsSource = App.DB.DeliveryPoint.ToList();
            StatusCB.ItemsSource = App.DB.OrderStatus.ToList();
            UserCB.ItemsSource = App.DB.User.ToList();
            TypeCB.ItemsSource = App.DB.DeliveryType.ToList();
            contextOrder = order;
            DataContext = contextOrder;
            if (contextOrder.Id != 0)
            {
                oldValues = App.DB.Entry(contextOrder).CurrentValues.Clone();
            }
        }

        private void Save_bt_Click(object sender, RoutedEventArgs e)
        {
            if (contextOrder.Date == null)
            {
                MessageBox.Show("Enter Name");
                return;
            }
            if (contextOrder.DeliveryPoint == null)
            {
                MessageBox.Show("Select Provider");
                return;
            }
            if (contextOrder.DeliveryType == null)
            {
                MessageBox.Show("Select type");
                return;
            }
            if (contextOrder.Id == 0)
            {
                App.DB.Order.Add(contextOrder);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (oldValues != null)
            {
                App.DB.Entry(contextOrder).CurrentValues.SetValues(oldValues);
            }
            NavigationService.GoBack();

        }
    }
}
