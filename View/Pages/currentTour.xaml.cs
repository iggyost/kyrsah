﻿using kyrsah.AppData;
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

namespace kyrsah.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для currentTour.xaml
    /// </summary>
    public partial class currentTour : Page
    {
        public currentTour(AppData.TurClass tour)
        {
            InitializeComponent();          
            this.title.Text = tour.Title;
            this.description.Text = tour.Information;
           
        }

        private void test_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}