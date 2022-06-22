﻿using System;
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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class SelectRolePage : Page
    {
        public SelectRolePage()
        {
            InitializeComponent();
        }

        private void RadioButtonClick(object sender, RoutedEventArgs e)
        {
            var user = new User();
            
            user.RoleId = int.Parse((sender as RadioButton).Uid);

            NavigationService.Navigate(new RegistrationPage(user));
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
