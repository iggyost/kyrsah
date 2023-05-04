using kyrsah.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace kyrsah.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        public AddEventWindow()
        {
            InitializeComponent();
            EditEventBtn.Visibility = Visibility.Collapsed;
            AddNewEventBtn.Visibility = Visibility.Visible;   
        }
        public AddEventWindow(Tour selectedTour)
        {
            InitializeComponent();
            selectedTour = App.tour;
            if (App.tour.image != null)
            {
                byte[] image_bytes_context = App.tour.image.ToArray();
                MemoryStream byteStream = new MemoryStream(image_bytes_context);
                BitmapImage imageEdit = new BitmapImage();
                imageEdit.BeginInit();
                imageEdit.StreamSource = byteStream;
                imageEdit.EndInit();
                eventImage.Source = imageEdit;
            }
            else
            {

            }
            NameTb.Text = App.tour.name;
            LocationTb.Text = App.tour.location;
            CostTb.Text = Convert.ToString(App.tour.cost);
            RatingTb.Text = Convert.ToString(App.tour.rating);
            LocationTb.Text = App.tour.location;
            CoordinatesTb.Text = App.tour.location_on_map;
            StartDateDp.SelectedDate = App.tour.start_date;
            ReturnDateDp.SelectedDate = App.tour.return_date;
            AddNewEventBtn.Visibility = Visibility.Collapsed;
            EditEventBtn.Visibility = Visibility.Visible;
        }
        private void EditEventBtn_Click(object sender, RoutedEventArgs e)
        {
            App.tour.name = NameTb.Text;
            App.tour.location = LocationTb.Text;
            App.tour.cost = Convert.ToDecimal(CostTb.Text);
            App.tour.start_date = (DateTime)App.tour.start_date;
            App.tour.return_date = (DateTime)App.tour.return_date;
            App.tour.rating = Convert.ToDouble(RatingTb.Text);
            App.tour.location_on_map = CoordinatesTb.Text;
            App.tour.image = getJPGFromImageControl(eventImage.Source as BitmapImage);

            App.context.Entry(App.tour).State = System.Data.EntityState.Modified;
            App.context.SaveChanges();
            MessageBox.Show("Тур успешно изменён!");
            this.DialogResult = true;
            this.Close();
        }
        public static Image byteArrToImage(byte[] byteArr)
        {
            Image img = new Image();
            MemoryStream stream = new MemoryStream(byteArr);
            img.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            return img;
        }
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        OpenFileDialog ofdPicture = new OpenFileDialog();
        byte[] image_bytes;
        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            ofdPicture.Filter =
                "Image files|*.jpg;*.jpeg*;*.png|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
            {
                eventImage.Source = new BitmapImage(new Uri(ofdPicture.FileName));
                image_bytes = File.ReadAllBytes(ofdPicture.FileName);
            }
        }
        private void RemoveImageBtn_Click(object sender, RoutedEventArgs e)
        {
            eventImage.Source = null;
            RemoveImageBtn.Visibility = Visibility.Collapsed;
        }
        private void AddNewEventBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tour tour = new Tour()
                {
                    name = NameTb.Text,
                    cost = Convert.ToDecimal(CostTb.Text),
                    location = LocationTb.Text,
                    location_on_map = CoordinatesTb.Text,
                    rating = Convert.ToDouble(RatingTb.Text),
                    image = image_bytes,
                    start_date = (DateTime)StartDateDp.SelectedDate,
                    return_date = (DateTime)ReturnDateDp.SelectedDate,
                };
                App.context.Tour.Add(tour);
                App.context.SaveChanges();
                MessageBox.Show("Успешно!");
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }


        }

        private void RatingTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LocationTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CoordinatesTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReturnDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
