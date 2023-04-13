using kyrsah.View.Pages;
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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StartPage1());
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuthorizationPage());
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrationPage());
        }

        private void WindowMenuGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            {
                {
                    if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                }
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
            }
        }

        private void CloseAppBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TurBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TurPage());
        }

        private void ExsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ExsPage());
        }

        private void NewsBtnn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TurVbBth_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ContactsPage());
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Korzina());
        }
    }
}
