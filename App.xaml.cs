using kyrsah.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace kyrsah
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DagestanToursDbEntities context = new DagestanToursDbEntities();
        public static Tour tour = new Tour();
        public static Users enteredUser = new Users();
        public static string locationMap;
    }
}
