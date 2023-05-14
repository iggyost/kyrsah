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
    /// Логика взаимодействия для AddEditNewsWindows.xaml
    /// </summary>
    public partial class AddEditNewsWindows : Window
    {
        public AddEditNewsWindows()
        {
            InitializeComponent();
            EditNewsBtn.Visibility = Visibility.Collapsed;
            AddNewsBtn.Visibility = Visibility.Visible;
            this.Title = "Добавление новости";
        }
        public AddEditNewsWindows(News selectedNews)
        {
            InitializeComponent();
            this.Title = "Редактирование новости";
            selectedNews = App.selectedNews;
            if (App.selectedNews.news_image != null)
            {
                byte[] image_bytes_context = App.selectedNews.news_image.ToArray();
                MemoryStream byteStream = new MemoryStream(image_bytes_context);
                BitmapImage imageEdit = new BitmapImage();
                imageEdit.BeginInit();
                imageEdit.StreamSource = byteStream;
                imageEdit.EndInit();
                NewsImage.Source = imageEdit;
            }
            HeaderTb.Text = App.selectedNews.header;
            InformationTb.Text = App.selectedNews.information;
            EditNewsBtn.Visibility = Visibility.Visible;
            AddNewsBtn.Visibility = Visibility.Collapsed;
        }
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
        public static Image byteArrToImage(byte[] byteArr)
        {
            Image img = new Image();
            MemoryStream stream = new MemoryStream(byteArr);
            img.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            return img;
        }
        OpenFileDialog ofdPicture = new OpenFileDialog();
        byte[] image_bytes;
        private void AddNewsImageBtn_Click(object sender, RoutedEventArgs e)
        {
            ofdPicture.Filter =
                "Image files|*.jpg;*.jpeg*;*.png|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
            {
                NewsImage.Source = new BitmapImage(new Uri(ofdPicture.FileName));
                image_bytes = File.ReadAllBytes(ofdPicture.FileName);
            }
        }
        private void AddNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                News news = new News()
                {
                    header = HeaderTb.Text,
                    information = InformationTb.Text,
                    news_image = image_bytes,
                    role_id = 1,
                    news_publication_date = DateTime.Now,
                };
                App.context.News.Add(news);
                App.context.SaveChanges();
                MessageBox.Show("Новость успешно добавлена!");
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void EditNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.selectedNews.header = HeaderTb.Text;
                App.selectedNews.information = InformationTb.Text;
                App.selectedNews.news_image = getJPGFromImageControl(NewsImage.Source as BitmapImage);
                App.context.Entry(App.selectedNews).State = System.Data.EntityState.Modified;
                App.context.SaveChanges();
                MessageBox.Show("Новость успешно изменена!");
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
    }
}
