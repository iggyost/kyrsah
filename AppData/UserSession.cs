using kyrsah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace kyrsah.AppData
{
    class UserSession
    {
        public static void CheckRegistration(TextBox FIOTb, TextBox email, PasswordBox password)
        {
            //обработка исключений 
            try
            {
                //создать 
                User user = new User()
                {
                    FIO= FIOTb.Text,
                    Email = email.Text,
                    Password = password.Password,
                    IdRole = 2
                };
                //добавить
                ModelHelper.GetContext().User.Add(user);

                //сохранить
                ModelHelper.GetContext().SaveChanges();

                //оповестить
                MessageBox.Show("Пользователь зарегистрирован!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }

        }
    }
}
