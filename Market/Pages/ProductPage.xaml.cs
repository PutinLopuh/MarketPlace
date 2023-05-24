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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();

        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(new Product()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGProd.ItemsSource = App.DB.Product.ToList();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = DGProd.SelectedItem as Product;
            if (selectedProduct == null)
            {
                MessageBox.Show(" Select Product");
                return;
            }
            NavigationService.Navigate(new AddPage(selectedProduct));
        }
    }
}
