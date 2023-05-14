using kyrsah.Model;
using kyrsah.View.Windows;
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
    /// Логика взаимодействия для NewsPage.xaml
    /// </summary>
    public partial class NewsPage : Page
    {
        public NewsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NewsLb.ItemsSource = App.context.News.ToList();
            if (App.enteredUser != null)
            {
                if (App.enteredUser.role_id == 1)
                {
                    AddNewsBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    AddNewsBtn.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                AddNewsBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void AddNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditNewsWindows addEditNewsWindows = new AddEditNewsWindows();
            addEditNewsWindows.ShowDialog();
            if (addEditNewsWindows.DialogResult == true)
            {
                NewsLb.ItemsSource = App.context.News.ToList();
            }
        }

        private void EditRemovePanel_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;
            int index = int.Parse(stackPanel.Tag.ToString());
            if (App.enteredUser != null)
            {
                if (index == App.enteredUser.role_id)
                {
                    stackPanel.Visibility = Visibility.Visible;
                }
                else
                {
                    stackPanel.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                stackPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void EditNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            Button editBtn = (Button)sender;
            int index = int.Parse(editBtn.Tag.ToString());
            App.selectedNews = App.context.News.Where(n => n.id == index).FirstOrDefault();
            AddEditNewsWindows editNewsWindows = new AddEditNewsWindows(App.selectedNews);
            editNewsWindows.ShowDialog();
            if (editNewsWindows.DialogResult == true)
            {
                NewsLb.ItemsSource = App.context.News.ToList();
            }
        }

        private void RemoveNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Вы действительно хотите удалить эту новость?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Button removeBtn = (Button)sender;
                int index = int.Parse(removeBtn.Tag.ToString());
                App.selectedNews = App.context.News.Where(n => n.id == index).FirstOrDefault();
                App.context.News.Remove(App.selectedNews);
                App.context.SaveChanges();
                NewsLb.ItemsSource = App.context.News.ToList();
                MessageBox.Show("Новость удалена!");
            }
        }

        private void NewsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedNews = NewsLb.SelectedItem as News;
            NavigationService.Navigate(new CurrentNewsPage());
        }
    }
}
