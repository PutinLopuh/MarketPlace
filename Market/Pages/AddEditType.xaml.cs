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
    /// Логика взаимодействия для AddEditType.xaml
    /// </summary>
    public partial class AddEditType : Page
    {
        ProductType contextType;

        DbPropertyValues oldValues;
        public AddEditType(ProductType productType)
        {
            InitializeComponent();
            contextType = productType;
            DataContext = contextType;
            if (contextType.Id != 0)
            {
                oldValues = App.DB.Entry(contextType).CurrentValues.Clone();
            }
        }
        private void Save_bt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextType.Name))
            {
                MessageBox.Show("Write Name");
                return;
            }
            if (contextType.Id == 0)
            {
                App.DB.ProductType.Add(contextType);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (oldValues != null)
            {
                App.DB.Entry(contextType).CurrentValues.SetValues(oldValues);
            }
            NavigationService.GoBack();
        }
    }
}
