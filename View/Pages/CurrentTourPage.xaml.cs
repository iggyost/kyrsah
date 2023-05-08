using kyrsah.Model;
using kyrsah.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для CurrentTourPage.xaml
    /// </summary>
    public partial class CurrentTourPage : Page
    {
        public CurrentTourPage(Tour selectedTour)
        {
            InitializeComponent();
            selectedTour = App.tour;
            DataContext = selectedTour;
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

        private void LocationPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (App.tour != null)
            {
                App.locationMap = App.tour.location_on_map.ToString();
                YandexMapWindow mapWindow = new YandexMapWindow();
                mapWindow.ShowDialog();
            }
            else
            {

            }
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TurPage());
        }

        private void AddToCartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.enteredUser != null)
            {
                Orders orders = new Orders()
                {
                    event_id = App.tour.id,
                    user_id = App.enteredUser.id,
                    total_cost = App.tour.cost,
                };
                App.context.Orders.Add(orders);
                App.context.SaveChanges();
                MessageBox.Show("Тур добавлен в корзину!");
            }
            else 
            {
                MessageBox.Show("Чтобы добавить тур в корзину, авторизуйтесь!");
            }
        }
    }
}
