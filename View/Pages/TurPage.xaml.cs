using kyrsah.AppData;
using kyrsah.Model;
using kyrsah.View.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

namespace kyrsah.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TurPage.xaml
    /// </summary>
    public partial class TurPage : Page
    {
        public TurPage()
        {
            InitializeComponent();
        }

        private void selectTour(object sender, SelectionChangedEventArgs e)
        {
            if (TurLb.SelectedIndex != -1)
            {
                App.tour = TurLb.SelectedItem as Tour;
                NavigationService.Navigate(new CurrentTourPage(App.tour));
            }
        }

        private void Border_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
        Tour tour = new Tour();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TurLb.ItemsSource = App.context.Tour.ToList();
            if (App.enteredUser != null)
            {
                if (App.enteredUser.role_id == 1)
                {
                    AddEventBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    AddEventBtn.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                AddEventBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void AddEventBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEventWindow addEventWindow = new AddEventWindow();
            addEventWindow.ShowDialog();
            if (addEventWindow.DialogResult == true)
            {
                TurLb.ItemsSource = App.context.Tour.ToList();
            }
        }

        private void RemoveTourBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Вы действительно хотите удалить тур?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            Button btn = (Button)sender;
            int index = int.Parse(btn.Tag.ToString());
            var thisTour = App.context.Tour.Where(t => t.id == index);
            if (result == MessageBoxResult.Yes)
            {
                if (App.context.Orders.Join(App.context.Tour, ordere => ordere.event_id, toure => toure.id, (ordere, toure) => new {ordere,toure}).Where(x => x.ordere.event_id == x.toure.id) != null)
                {
                    var order = App.context.Orders.Join(App.context.Tour, orders => orders.event_id, tour => tour.id, (orders, tour) => new { orders, tour })
                                      .Where(x => x.orders.event_id == x.tour.id)
                                      .Select(x => x.orders);
                    var tourl = App.context.Tour.Join(App.context.Orders, tours => tours.id, orders => orders.event_id, (tours, orders) => new { tours, orders })
                                                 .Where(x => x.orders.event_id == x.tours.id)
                                                 .Select(x => x.tours);
                    App.context.Entry(order.FirstOrDefault()).State = System.Data.EntityState.Deleted;
                    App.context.Entry(tourl.FirstOrDefault()).State = System.Data.EntityState.Deleted;
                }
                else
                {
                    App.context.Entry(thisTour.FirstOrDefault()).State = System.Data.EntityState.Deleted;
                }
                App.context.SaveChanges();
            }
            else
            {

            }
        }

        private void EditTourBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Tag.ToString());
            App.tour = App.context.Tour.Where(t => t.id == index).FirstOrDefault();
            AddEventWindow addEventWindow = new AddEventWindow(App.tour);
            addEventWindow.ShowDialog();
            if (addEventWindow.DialogResult == true)
            {
                TurLb.ItemsSource = App.context.Tour.ToList();
            }
        }

        private void TurLb_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {

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
        Button btnEdit;
        Button btnRemove;
        private void EditTourBtn_Loaded(object sender, RoutedEventArgs e)
        {
            btnEdit = (Button)sender;
            if (App.enteredUser != null)
            {
                if (App.enteredUser.role_id == 1)
                {
                    btnEdit.Visibility = Visibility.Visible;
                }
                else
                {
                    btnEdit.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                btnEdit.Visibility = Visibility.Collapsed;
            }
        }

        private void RemoveTourBtn_Loaded(object sender, RoutedEventArgs e)
        {
            btnRemove = (Button)sender;
            if (App.enteredUser != null)
            {
                if (App.enteredUser.role_id == 1)
                {
                    btnRemove.Visibility = Visibility.Visible;
                }
                else
                {
                    btnRemove.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                btnRemove.Visibility = Visibility.Collapsed;
            }
        }
    }
}


