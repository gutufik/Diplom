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
    /// Interaction logic for RestaurantPage.xaml
    /// </summary>
    public partial class RestaurantPage : Page
    {
        public Restoraunt Restoraunt { get; set; }
        public RestaurantPage(Restoraunt restoraunt)
        {
            InitializeComponent();
            Restoraunt = restoraunt;
            DataContext = Restoraunt;

        }

        private void BtnReserve_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReservationPage(Restoraunt));
        }
    }
}
