using Market.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        Product contextProduct;
        DbPropertyValues oldValues;
        public AddPage(Product product)
        {
            InitializeComponent();
            ProviderCB.ItemsSource = App.DB.Provider.ToList();
            TypeCB.ItemsSource = App.DB.ProductType.ToList();
            contextProduct = product;
            DataContext = contextProduct;
            LV_Photo.ItemsSource = contextProduct.ProductPhoto.ToList();
            if (contextProduct.Id != 0)
            {
                oldValues = App.DB.Entry(contextProduct).CurrentValues.Clone();
            }
        }

        private void Save_bt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextProduct.Name))
            {
                MessageBox.Show("Enter Name");
                return;
            }
            if (contextProduct.Price < 0)
            {
                MessageBox.Show("Enter price ");
                return;
            }
            if (contextProduct.Count < 0)
            {
                MessageBox.Show("Enter count ");
                return;
            }
            if(contextProduct.Provider == null)
            {
                MessageBox.Show("Select Provider");
                return;
            }
            if(contextProduct.ProductType == null)
            {
                MessageBox.Show("Select type");
                return;
            }
            if (contextProduct.Id == 0)
            {
                App.DB.Product.Add(contextProduct);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if(oldValues != null)
            {
                App.DB.Entry(contextProduct).CurrentValues.SetValues(oldValues);
            }
            NavigationService.GoBack();

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Multiselect = true};
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                foreach(var fileName in dialog.FileNames)
                {
                    contextProduct.ProductPhoto.Add(new ProductPhoto()
                    {
                        Photo = File.ReadAllBytes(fileName),
                        Product = contextProduct
                    });
                }
                Refresh();
                DataContext = null;
                DataContext = contextProduct;
            }
        }
        private void Refresh()
        {
            LV_Photo.ItemsSource = contextProduct.ProductPhoto.ToList();
        }
    }
}
