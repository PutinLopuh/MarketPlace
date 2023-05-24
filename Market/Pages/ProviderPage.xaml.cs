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
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public ProviderPage()
        {
            InitializeComponent();
            DGProv.ItemsSource = App.DB.Provider.ToList();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProvider(new Provider()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGProv.ItemsSource = App.DB.Provider.ToList();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedProvider = DGProv.SelectedItem as Provider;
            if (selectedProvider == null)
            {
                MessageBox.Show(" Select Provider");
                return;
            }
            NavigationService.Navigate(new AddEditProvider(selectedProvider));
        }
    }
}
