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
    /// Логика взаимодействия для ProductTypePage.xaml
    /// </summary>
    public partial class ProductTypePage : Page
    {
        public ProductTypePage()
        {
            InitializeComponent();
            DGType.ItemsSource = App.DB.ProductType.ToList();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditType(new ProductType()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGType.ItemsSource = App.DB.ProductType.ToList();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedType = DGType.SelectedItem as ProductType;
            if (selectedType == null)
            {
                MessageBox.Show(" Select Type");
                return;
            }
            NavigationService.Navigate(new AddEditType(selectedType));
        }
    }
}
