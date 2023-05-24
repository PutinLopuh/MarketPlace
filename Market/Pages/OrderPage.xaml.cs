using Market.Models;
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

namespace Market.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            LVOrders.ItemsSource = App.DB.Order.ToList();
        }
        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEdit(new Order()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LVOrders.ItemsSource = App.DB.Order.ToList();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = LVOrders.SelectedItem as Order;
            if (selectedOrder == null)
            {
                MessageBox.Show(" Select Product");
                return;
            }
            NavigationService.Navigate(new AddEdit(selectedOrder));
        }
    }
}
