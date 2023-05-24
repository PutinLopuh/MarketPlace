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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Bt_Prod_Click(object sender, RoutedEventArgs e)
        {
            My_Frame.Navigate(new ProductPage());
        }

        private void Bt_Order_Click(object sender, RoutedEventArgs e)
        {
            My_Frame.Navigate(new OrderPage());
        }

        private void Bt_Provider_Click(object sender, RoutedEventArgs e)
        {
            My_Frame.Navigate(new ProviderPage());
        }

        private void Bt_ProductType_Click(object sender, RoutedEventArgs e)
        {
            My_Frame.Navigate(new ProductTypePage());
        }
    }
}
