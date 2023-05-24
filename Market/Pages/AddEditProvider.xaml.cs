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
    /// Логика взаимодействия для AddEditProvider.xaml
    /// </summary>
    public partial class AddEditProvider : Page
    {
        Provider contextProvider;

        DbPropertyValues oldValues;
        public AddEditProvider(Provider provider)
        {
            InitializeComponent();
            contextProvider = provider;
            DataContext = contextProvider;
            if (contextProvider.Id != 0)
            {
                oldValues = App.DB.Entry(contextProvider).CurrentValues.Clone();
            }
        }
        private void Save_bt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextProvider.Name))
            {
                MessageBox.Show("Write Name");
                return;
            }
            if (contextProvider.Id == 0)
            {
                App.DB.Provider.Add(contextProvider);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (oldValues != null)
            {
                App.DB.Entry(contextProvider).CurrentValues.SetValues(oldValues);
            }
            NavigationService.GoBack();
        }
    }
}
