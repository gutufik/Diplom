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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class ClientMainPage : Page
    {
        public List<Restoraunt> Restoraunts { get; set; }
        public ClientMainPage()
        {
            InitializeComponent();
            Restoraunts = App.DB.Restoraunt.ToList();
            DataContext = this;
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LVRestaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var restaurant = LVRestaurants.SelectedItem as Restoraunt;
            NavigationService.Navigate(new RestaurantPage(restaurant));
        }
    }
}
