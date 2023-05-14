using kyrsah.Model;
using kyrsah.View.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            this.Title = "Добавление тура";
        }
        public AddEventWindow(Tour selectedTour)
        {
            InitializeComponent();
            this.Title = "Редактирование тура";
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
            ratingSlider.Value = App.tour.rating;
            LocationTb.Text = App.tour.location;
            CostTb.Text = Convert.ToString(App.tour.cost);
            LocationTb.Text = App.tour.location;
            CoordinatesTb.Text = App.tour.location_on_map;
            StartDateDp.SelectedDate = App.tour.start_date;
            ReturnDateDp.SelectedDate = App.tour.return_date;
            DescriptionTb.Text = App.tour.description;
            AddNewEventBtn.Visibility = Visibility.Collapsed;
            EditEventBtn.Visibility = Visibility.Visible;
            isNameValidated = true;
            isLocationValidated = true;
            isCoordinatesValidated = true;
            isStartDateValidated = true;
            isReturnDateValidated = true;
            isHaveImageValidated = true;
            isCostValidated = true;
        }
        double middleRatingValue;
        int ratingCounter;
        double sumOfAllRatings;
        private void EditEventBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isNameValidated == true &&
                isLocationValidated == true &&
                isCoordinatesValidated == true &&
                isStartDateValidated == true &&
                isReturnDateValidated == true &&
                isHaveImageValidated == true &&
                isCostValidated == true)
            {
                App.tour.name = NameTb.Text;
                App.tour.location = LocationTb.Text;
                App.tour.cost = Convert.ToDecimal(CostTb.Text);
                App.tour.rating = ratingSlider.Value;
                App.tour.start_date = (DateTime)App.tour.start_date;
                App.tour.return_date = (DateTime)App.tour.return_date;
                App.tour.location_on_map = CoordinatesTb.Text;
                App.tour.image = getJPGFromImageControl(eventImage.Source as BitmapImage);
                App.tour.description = DescriptionTb.Text;

                App.context.Entry(App.tour).State = System.Data.EntityState.Modified;
                App.context.SaveChanges();
                MessageBox.Show("Тур успешно изменён!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены верно!");
            }
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
            if (eventImage.Source != null)
            {
                isHaveImageValidated = true;
            }
            else
            {
                isHaveImageValidated = false;
            }
            if (isNameValidated == true &&
                isLocationValidated == true &&
                isCoordinatesValidated == true &&
                isStartDateValidated == true &&
                isReturnDateValidated == true &&
                isHaveImageValidated == true &&
                isCostValidated == true)
            {
                try
                {
                    Tour tour = new Tour()
                    {
                        name = NameTb.Text,
                        cost = Convert.ToDecimal(CostTb.Text),
                        location = LocationTb.Text,
                        location_on_map = CoordinatesTb.Text,
                        rating = ratingSlider.Value,
                        image = image_bytes,
                        start_date = (DateTime)StartDateDp.SelectedDate,
                        return_date = (DateTime)ReturnDateDp.SelectedDate,
                        description = DescriptionTb.Text,
                    };
                    TurPage turPage = new TurPage();
                    App.context.Tour.Add(tour);
                    App.context.SaveChanges();
                    MessageBox.Show("Успешно!");
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception)
                {
                    Exception exc = new Exception();
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены верно!");
            }


        }
        bool isNameValidated = false;
        bool isLocationValidated = false;
        bool isCoordinatesValidated = false;
        bool isStartDateValidated = false;
        bool isReturnDateValidated = false;
        bool isHaveImageValidated = false;
        bool isCostValidated = false;

        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTb.Text != string.Empty && NameTb.Text.Length > 2)
            {
                NameValidationTbl.Text = string.Empty;
                isNameValidated = true;
            }
            else
            {
                NameValidationTbl.Text = "Название тура должно содержать не менее 3 символов!";
                isNameValidated = false;
            }
        }

        private void LocationTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string validationMsg1;
            string validationMsg2;
            Regex isCyrillic = new Regex(@"\p{IsCyrillic}");
            if (isCyrillic.IsMatch(LocationTb.Text))
            {
                validationMsg1 = string.Empty;
                isLocationValidated = true;
            }
            else
            {
                validationMsg1 = "Название места тура должно содержать только кириллицу! ";
                isLocationValidated = false;
            }
            if (LocationTb.Text.Length > 3)
            {
                validationMsg2 = string.Empty;
                isLocationValidated = true;
            }
            else
            {
                validationMsg2 = "Название места тура должно содержать не менее 4 символов! ";
                isLocationValidated = false;
            }
            LocationValidationTbl.Text = validationMsg1 + validationMsg2;
        }

        private void CoordinatesTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex isCoordinates = new Regex("^(\\d+\\.\\d+),\\s(\\d+\\.\\d+)$");
            if (isCoordinates.IsMatch(CoordinatesTb.Text))
            {
                CoordinatesValidationTbl.Text = string.Empty;
                isCoordinatesValidated = true;
            }
            else if (CoordinatesTb.Text == string.Empty)
            {
                CoordinatesValidationTbl.Text = string.Empty;
                isCoordinatesValidated = true;
            }
            else
            {
                CoordinatesValidationTbl.Text = "Неправильный формат координат Яндекс Карты!";
                isCoordinatesValidated = false;
            }
        }

        private void StartDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReturnDateDp.SelectedDate < StartDateDp.SelectedDate)
            {
                DateValidationTbl.Text = "Дата возвращения не может быть раньше чем дата отбытия!";
                isReturnDateValidated = false;
                isStartDateValidated = false;
            }
            else
            {
                DateValidationTbl.Text = string.Empty;
                isReturnDateValidated = true;
                isStartDateValidated = true;
            }
        }

        private void ReturnDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReturnDateDp.SelectedDate < StartDateDp.SelectedDate)
            {
                DateValidationTbl.Text = "Дата возвращения не может быть раньше чем дата отбытия!";
                isReturnDateValidated = false;
                isStartDateValidated = false;
            }
            else
            {
                DateValidationTbl.Text = string.Empty;
                isReturnDateValidated = true;
                isStartDateValidated = true;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ratingValue.Text = ratingSlider.Value.ToString();
        }

        private void CostTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex isDigit = new Regex("^[0-9]+$");
            if (isDigit.IsMatch(CostTb.Text))
            {
                CostValidationTbl.Text = string.Empty;
                isCostValidated = true;
            }
            else
            {
                CostValidationTbl.Text = "Цена должна состоять только из цифр!";
                isCostValidated = false;
            }
        }
    }
}
