using Diplom.ADO;
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

namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectRolePage());
        }

        private void BAuth_Click(object sender, RoutedEventArgs e)
        {
            var phone = TBPhone.Text;
            var password = PBPassword.Password;
            User user = App.DB.User.Where(u => u.Phone == phone && u.Password == password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            if (user.RoleId == 1)
            {
                App.LoggedUser = user;
                NavigationService.Navigate(new AdminMainPage());
            }
            if (user.RoleId == 2)
            {
                App.LoggedUser = user;
                NavigationService.Navigate(new ClientMainPage());
            }

        }
    }
}
