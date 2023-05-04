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

namespace kyrsah.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для YandexMapWindow.xaml
    /// </summary>
    public partial class YandexMapWindow : Window
    {
        public YandexMapWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.locationMap != null)
            {
                string[] parts = App.locationMap.Split(',');
                Array.Reverse(parts);
                string reversedString = String.Join(",", parts);
                string coordinates = reversedString;
                WebViewMap.Source = new Uri($"https://yandex.ru/maps/?pt={coordinates}&z=13&l=map");
            }
        }
    }
}
