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
using System.Windows.Shapes;
using Diplom.WindowS;

namespace Diplom.WindowS
{
    /// <summary>
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        public AuthWin()
        {
            InitializeComponent();
        }

        private void ButReg_Click(object sender, RoutedEventArgs e)
        {
            WindowS.RoleWin roleWin = new RoleWin();
            roleWin.Show();
            this.Close();
        }
    }
}
