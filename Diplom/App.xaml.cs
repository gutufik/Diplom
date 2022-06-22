using Diplom.ADO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RestoEntities DB = new RestoEntities();
        public static User LoggedUser;

        public static object BD { get; internal set; }
    }
}
