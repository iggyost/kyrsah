﻿using kyrsah.AppData;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

//        private void LoginBtn_Click(object sender, RoutedEventArgs e)
//        {
//            var user = Context._con.User.Where(p => p.Email == LoginTb.Text && p.Password == PasswordPb.Password).FirstOrDefault();
//            if (user != null)
//            {
//                User = user;
//                StartWindow startWindow = new StartWindow();
//                startWindow.Show();
//                this.Close();
//            }
//            else
//            {
//                MessageBox.Show("Пользователь не найден!");
//            }
//       }

//        private void LoginTb_GotFocus(object sender, RoutedEventArgs e)
//        {
//            if (LoginTb.Text == "Login")
//            {
//                LoginTb.Text = string.Empty;
//            }
//        }

//        private void PasswordPb_GotFocus(object sender, RoutedEventArgs e)
//        {
//            if (PasswordPb.Password == "Password")
//            {
//                PasswordPb.Password = string.Empty;
//            }
//        }

//        private void PasswordPb_LostFocus(object sender, RoutedEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
//            {
//                PasswordPb.Password = "Password";
//            }
//        }

//        private void LoginTb_LostFocus(object sender, RoutedEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(LoginTb.Text))
//            {
//                LoginTb.Text = "Login";
//            }
//        }

//        private void LoginBtn_Click(object sender, RoutedEventArgs e)
//        {

//        }
//    }
       
//}
