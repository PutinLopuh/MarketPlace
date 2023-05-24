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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginTb.Text.ToString(); var password = Password.Password.ToString();
                var User = App.DB.User.ToList().Find(x => x.Login == login && x.Password == password);
                if (User != null)
                {
                    MessageBox.Show("Вы успешно вошли в систему"); NavigationService.Navigate(new MainPage());
                }
                else
                {
                    MessageBox.Show("Пользовтель не авторезирован ");
                }
            
            
        }
    }
}
