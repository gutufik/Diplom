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
    /// Interaction logic for ClientReservationsPage.xaml
    /// </summary>
    public partial class ClientReservationsPage : Page
    {
        public User User { get; set; }
        public ClientReservationsPage(User user)
        {
            InitializeComponent();
            User = user;

            ChangeListVisibility();

            DataContext = User;
        }
        private void ChangeListVisibility()
        {
            if (User.Reservation.Count() == 0)
            {
                LabelEmpty.Visibility = Visibility.Visible;
                LVReservations.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelEmpty.Visibility = Visibility.Hidden;
                LVReservations.Visibility = Visibility.Visible;
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
            App.LoggedUser = null;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var reservation = (sender as Button).DataContext as Reservation;
            App.DB.Reservation.Remove(reservation);
            App.DB.SaveChanges();

            User = App.LoggedUser;
            LVReservations.ItemsSource = App.DB.Reservation.ToList();
            ChangeListVisibility();
            LVReservations.Items.Refresh();
        }
        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
