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
    /// Interaction logic for ReservationPAge.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        public Reservation Reservation { get; set; }
        public ReservationPage(Restoraunt restoraunt)
        {
            InitializeComponent();
            Reservation = new Reservation()
            {
                User = App.LoggedUser,
                Restoraunt = restoraunt
            };
            DataContext = Reservation;
        }

        private void BtnReserve_Click(object sender, RoutedEventArgs e)
        {
            Reservation.Time = DateTime.Today + Reservation.Time.TimeOfDay;
            App.DB.Reservation.Add(Reservation);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }
        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
