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

namespace kyrsah.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContactsPage.xaml
    /// </summary>
    public partial class ContactsPage : Page
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            locationWV.Source = new Uri("https://yandex.ru/maps/?whatshere[point]=37.609946,55.728880&whatshere[zoom]=17");
        }
    }
}
