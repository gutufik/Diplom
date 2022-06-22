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
using Diplom.ADO;

namespace Diplom.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public User User { get; set; }
        public RegistrationPage(User user)
        {
            InitializeComponent();
            User = user;

            if (user.RoleId == 1)
                Description.Text = "Это необходимо для управления ресторанами";
            else
                Description.Text = "Это необходимо для бронирования столиков";

            DataContext = User;
        }
        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User.Password = TBPass.Password;
                App.DB.User.Add(User);
                App.DB.SaveChanges();
                MessageBox.Show("Успех!");
                NavigationService.Navigate(new AuthorizationPage());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
