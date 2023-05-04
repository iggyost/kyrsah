using kyrsah.AppData;
using kyrsah.Model;
using kyrsah.View.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            if (TurLb.SelectedItem is TurClass tur)
            {
                NavigationService.Navigate(new currentTour(tur));

            }
        }

        private void Border_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
        //private static BitmapImage LoadImage(byte[] imageData)
        //{
        //    if (imageData == null || imageData.Length == 0) return null;
        //    var image = new BitmapImage();
        //    using (var mem = new MemoryStream(imageData))
        //    {
        //        mem.Position = 0;
        //        image.BeginInit();
        //        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        //        image.CacheOption = BitmapCacheOption.OnLoad;
        //        image.UriSource = null;
        //        image.StreamSource = mem;
        //        image.EndInit();
        //    }
        //    image.Freeze();
        //    return image;
        //}
        Tour tour = new Tour();
        //public System.Drawing.Image BinaryToImage(byte[] binaryData)
        //{
        //    MemoryStream ms = new MemoryStream(binaryData);
        //    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
        //    return img;
        //}
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TurLb.ItemsSource = App.context.Tour.ToList();
            if (tour.image != null)
            {
                System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(tour.image));
            }
            else
            {

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

        private void LocationTbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void LocationPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TurLb.SelectedIndex != -1)
            {
                App.tour = TurLb.SelectedItem as Tour;
                App.locationMap = App.tour.location_on_map.ToString();
                YandexMapWindow mapWindow = new YandexMapWindow();
                mapWindow.ShowDialog();
            }
            else
            {

            }
        }

        private void RemoveTourBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Вы действительно хотите удалить тур?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                int index = int.Parse(btn.Tag.ToString());
                var currentTour = App.context.Tour.Where(t => t.id == index).FirstOrDefault();
                App.context.Tour.Remove(currentTour);
                App.context.SaveChanges();
                TurLb.ItemsSource = App.context.Tour.ToList();
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
    }
}
