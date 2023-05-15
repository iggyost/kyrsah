using kyrsah.Model;
using kyrsah.View.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        decimal totalCost;
        private void ToursCartLb_Loaded(object sender, RoutedEventArgs e)
        {
            var tours = App.context.Tour
                                   .Join(App.context.Orders, tour => tour.id, orders => orders.event_id, (tour, orders) => new { tour, orders })
                                   .Where(x => x.orders.user_id == App.enteredUser.id)
                                   .Select(x => x.tour)
                                   .ToList();
            ToursCartLb.ItemsSource = tours;
            if (ToursCartLb.HasItems)
            {
                foreach (var item in tours.Join(App.context.Orders, t => t.id, o => o.event_id, (t, o) => new { t, o }).Where(x => x.o.is_paid == false && App.enteredUser.id == x.o.user_id))
                {
                    totalCost += item.t.cost;
                }
                totalCostTbl.Text = totalCost.ToString() + "₽";
            }
            else
            {

            }
        }
        private void removeFromCartBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag != null)
            {
                int index = int.Parse(btn.Tag.ToString());
                var currentTour = App.context.Tour.Where(t => t.id == index).FirstOrDefault();
                var tourInCart = App.context.Orders.Where(o => o.event_id == currentTour.id).FirstOrDefault();
                App.context.Orders.Remove(tourInCart);
                App.context.SaveChanges();
                var tours = App.context.Tour
                                   .Join(App.context.Orders, tour => tour.id, orders => orders.event_id, (tour, orders) => new { tour, orders })
                                   .Where(x => x.orders.user_id == App.enteredUser.id)
                                   .Select(x => x.tour)
                                   .ToList();
                ToursCartLb.ItemsSource = tours;
                if (tourInCart.is_paid == false)
                {
                    totalCost = totalCost - currentTour.cost;
                    totalCostTbl.Text = totalCost.ToString() + "₽";
                }
            }
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ToursCartLb.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста!");
            }
            else
            {
                PaymentWindow paymentWindow = new PaymentWindow();
                paymentWindow.ShowDialog();
                if (paymentWindow.DialogResult == true)
                {
                    var rows = from o in App.context.Orders
                               where o.user_id == App.enteredUser.id
                               select o;
                    foreach (var row in rows)
                    {
                        row.is_paid = true;
                    }
                    App.context.SaveChanges();
                    totalCostTbl.Text = 0.ToString() + "₽";
                }
                else
                {

                }
                var tours = App.context.Tour
                                       .Join(App.context.Orders, tour => tour.id, orders => orders.event_id, (tour, orders) => new { tour, orders })
                                       .Where(x => x.orders.user_id == App.enteredUser.id)
                                       .Select(x => x.tour)
                                       .ToList();
                ToursCartLb.ItemsSource = tours;
                if (ToursCartLb.HasItems)
                {
                    foreach (var item in tours)
                    {
                        totalCost += item.cost;
                    }
                    totalCostTbl.Text = 0.ToString() + "₽";
                }
                else
                {

                }
            }
        }
        TextBlock tblStatus;
        private void OrderStatusTbl_Loaded(object sender, RoutedEventArgs e)
        {
            tblStatus = (TextBlock)sender;
            int index = int.Parse(tblStatus.Tag.ToString());
            var currentOrder = App.context.Orders.Where(o => o.event_id == index && o.event_id == indexEllipse && App.enteredUser.id == o.user_id).FirstOrDefault();
            if (currentOrder.is_paid == true)
            {
                tblStatus.Text = "Оплачено";
                ellipseStatus.Fill = System.Windows.Media.Brushes.Green;
            }
            else
            {
                tblStatus.Text = "Ждет оплаты";
                ellipseStatus.Fill = System.Windows.Media.Brushes.Orange;
            }
        }
        Ellipse ellipseStatus;
        int indexEllipse;
        private void EllipseStatus_Loaded(object sender, RoutedEventArgs e)
        {
            ellipseStatus = (Ellipse)sender;
            indexEllipse = int.Parse(ellipseStatus.Tag.ToString());
        }
    }
}
