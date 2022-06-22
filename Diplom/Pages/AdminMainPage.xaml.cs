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
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        private static NavigationService NavigationService { get; } 
            = (Application.Current.MainWindow as MainWindow).MainFrame.NavigationService;
        public List<Restoraunt> Restoraunts { get; set; }
        public AdminMainPage()
        {
            InitializeComponent();
            Restoraunts = App.LoggedUser.Restoraunt.ToList();

            if (Restoraunts.Count == 0)
            {
                LVRestaurants.Visibility = Visibility.Hidden;
                TextEmpty.Visibility = Visibility.Visible;
            }
            else 
            {
                LVRestaurants.Visibility = Visibility.Visible;
                TextEmpty.Visibility = Visibility.Hidden;
            }
            HelloLabel.Text = $"Здравствуйте, {App.LoggedUser.Name}!";
            NavigationService.Navigated += RefreshRestaurants;
            DataContext = this;
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var restaurant = (sender as Button).DataContext as Restoraunt;
            NavigationService.Navigate(new RestorauntPage(restaurant));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var restaurant = (sender as Button).DataContext as Restoraunt;
            if (MessageBox.Show("Удалить ресторан?",
                    "",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.DB.Restoraunt.Remove(restaurant);
                App.DB.SaveChanges();

                Restoraunts = App.DB.Restoraunt.ToList();
                LVRestaurants.ItemsSource = Restoraunts;
                LVRestaurants.Items.Refresh();
            }
        }
        private void RefreshRestaurants(object sender, NavigationEventArgs e)
        {
            Restoraunts = App.DB.Restoraunt.ToList();
            LVRestaurants.ItemsSource = Restoraunts;
            LVRestaurants.Items.Refresh();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
            App.LoggedUser = null;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RestorauntPage(new Restoraunt()));
        }
    }
}
