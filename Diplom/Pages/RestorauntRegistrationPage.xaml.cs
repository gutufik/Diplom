using Diplom.ADO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для RestorauntRegistrationPage.xaml
    /// </summary>
    public partial class RestorauntRegistrationPage : Page
    {
        public Restoraunt Restoraunt { get; set; }
        public RestorauntRegistrationPage(Restoraunt restoraunt)
        {
            InitializeComponent();
            CBTerrace.ItemsSource = App.DB.Terrace.ToList();
            CBFood.ItemsSource = App.DB.FoodType.ToList();
            CBCheck.ItemsSource = App.DB.AverageCheck.ToList();
            Restoraunt = restoraunt;
            DataContext = Restoraunt;
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(Restoraunt.Name))
                errorMessage += "Введите имя\n";
            if (string.IsNullOrWhiteSpace(Restoraunt.Description))
                errorMessage += "Заполните описание\n";
            if (string.IsNullOrWhiteSpace(Restoraunt.Adress))
                errorMessage += "Укажите адрес\n";
            if (Restoraunt.Places == null)
                errorMessage += "Укажите количество мест\n";
            if (string.IsNullOrWhiteSpace(Restoraunt.OperatingMode))
                errorMessage += "Укажите график работы\n";
            if (Restoraunt.Terrace == null)
                errorMessage += "Укажите наличие террасы\n";
            if (Restoraunt.FoodType == null)
                errorMessage += "Укажите тип кухни\n";
            if (Restoraunt.AverageCheck == null)
                errorMessage += "Укажите средний чек\n";

            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            Restoraunt.AdministratorId = App.LoggedUser.Id;

            if (Restoraunt.Id == 0)
            {
                App.DB.Restoraunt.Add(Restoraunt);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (fileDialog.ShowDialog().Value)
            {
                var photo = File.ReadAllBytes(fileDialog.FileName);

                Restoraunt.Image = photo;
                RestoImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }
    }
}
