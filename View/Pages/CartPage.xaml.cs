using kyrsah.Model;
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
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            ToursCartLb.ItemsSource = App.context.Tour.Where(t => t.id == App.context.Orders.Select(o => o.event_id).FirstOrDefault() && App.context.Orders.Select(o => o.user_id).FirstOrDefault() == App.enteredUser.id).ToList();
        }

        private void borderBackground_Loaded(object sender, RoutedEventArgs e)
        {
            Border brd = (Border)sender;
            int index = int.Parse(brd.Tag.ToString());
            var currentTour = App.context.Tour.Where(t => t.id == index).FirstOrDefault();
            if (brd.Tag != null)
            {
                if (currentTour.rating == 5)
                {
                    brd.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#802cba00");
                }
                else if (currentTour.rating < 5 && currentTour.rating > 4)
                {
                    brd.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#80a3ff00");
                }
                else if (currentTour.rating <= 4 && currentTour.rating > 3)
                {
                    brd.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#80fff400");
                }
                else if (currentTour.rating <= 3 && currentTour.rating > 2)
                {
                    brd.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#80ffa700");
                }
                else if (currentTour.rating <= 2 && currentTour.rating > 0)
                {
                    brd.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#80ff0000");
                }
                else if (currentTour.rating == 0)
                {
                    brd.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#80000000");
                }
            }
        }
    }
}
