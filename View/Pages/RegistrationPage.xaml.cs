using kyrsah.AppData;
using kyrsah.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kyrsah.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        bool isEmailValidated = false;
        bool isPasswordValidated = false;
        bool isCompletePasswordValidated = false;
        bool isPhoneValidated = false;
        bool isNameValidated = false;
        bool isStepNameValidated = false;
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            //UserSession.CheckRegistration( FIOTb, EmailTb, PasswordPb);
            if (isEmailValidated == true &&
                isNameValidated == true &&
                isStepNameValidated == true &&
                isPasswordValidated == true &&
                isPhoneValidated == true &&
                isCompletePasswordValidated == true)
            {
                Users user = new Users()
                {
                    email = EmailTb.Text,
                    password = PasswordPb.Password,
                    full_name = NameTb.Text + " " + StepnameTb.Text,
                    phone = PhoneTb.Text,
                    role_id = 2,
                };
                App.context.Users.Add(user);
                App.context.SaveChanges();
                NavigationService.Navigate(new AuthorizationPage());
                MessageBox.Show("Регистрация прошла успешно!");
            }
            else
            {
                MessageBox.Show("Не все поля заполнены верно!");
            }
        }
        private void EmailTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string validationMsg1;
            string validationMsg2;
            var hasCyrillic = new Regex(@"\p{IsCyrillic}+");
            Regex emailFormat = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (emailFormat.IsMatch(EmailTb.Text))
            {
                validationMsg1 = string.Empty;
                isEmailValidated = true;
            }
            else
            {
                validationMsg1 = "Неправильный формат email! ";
                isEmailValidated = false;
            }
            if (!hasCyrillic.IsMatch(EmailTb.Text))
            {
                validationMsg2 = string.Empty;
                isEmailValidated = true;
            }
            else
            {
                validationMsg2 = "Только латинские символы ";
                isEmailValidated = false;
            }
            EmailValidationMessage.Text = validationMsg1 + validationMsg2;
        }

        private void PasswordPb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasCyrillic = new Regex(@"\p{IsCyrillic}+");
            string validationMsg1;
            string validationMsg2;
            string validationMsg3;

            if (hasNumber.IsMatch(PasswordPb.Password))
            {
                validationMsg1 = string.Empty;
                isPasswordValidated = true;
            }
            else
            {
                validationMsg1 = "Минимум 1 цифра! ";
                isPasswordValidated = false;
            }
            if (!hasCyrillic.IsMatch(PasswordPb.Password))
            {
                validationMsg2 = string.Empty;
                isPasswordValidated = true;
            }
            else
            {
                validationMsg2 = "Только латинские символы! ";
                isPasswordValidated = false;
            }
            if (PasswordPb.Password.Length < 5 || PasswordPb.Password.Length > 21)
            {
                validationMsg3 = "Не менее 5 символов и не более 21!";
                isPasswordValidated = false;
            }
            else
            {
                validationMsg3 = String.Empty;
                isPasswordValidated = true;
            }
            PasswordValidationMessage.Text = validationMsg1 + validationMsg2 + validationMsg3;
        }

        private void CompletePasswordPb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string validationMsg1;
            if (PasswordPb.Password == CompletePasswordPb.Password)
            {
                validationMsg1 = string.Empty;
                isCompletePasswordValidated = true;
            }
            else
            {
                validationMsg1 = "Пароли не совпадают! ";
                isCompletePasswordValidated = false;
            }
            CompleteValidationMessage.Text = validationMsg1;
        }


        private void PhoneTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var isEnoughLength = new Regex(@"^\d{11}$");
            var isDigitals = new Regex(@"[0-9]+");
            var isFirstRUS = new Regex(@"^[7]");
            string validationMsg1;
            string validationMsg2;
            string validationMsg3;
            if (isEnoughLength.IsMatch(PhoneTb.Text))
            {
                validationMsg2 = string.Empty;
                isPhoneValidated = true;
            }
            else
            {
                validationMsg2 = "Должно быть 11 цифр! ";
                isPhoneValidated = false;
            }
            if (isFirstRUS.IsMatch(PhoneTb.Text))
            {
                validationMsg1 = string.Empty;
                isPhoneValidated = true;
            }
            else
            {
                validationMsg1 = "Номер должен начинаться с '7'! ";
                isPhoneValidated = false;
            }
            if (isDigitals.IsMatch(PhoneTb.Text))
            {
                validationMsg3 = string.Empty;
                isPhoneValidated = true;
            }
            else
            {
                validationMsg3 = "Поле должно содержать только цифры! ";
                isPhoneValidated = false;
            }
            PhoneValidationMessage.Text = validationMsg1 + validationMsg2 + validationMsg3;
        }
        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var isFirstUpper = new Regex(@"^[А-Я]");
            var isCyrillic = new Regex(@"\p{IsCyrillic}");
            string validationMsg1;
            string validationMsg2;
            if (isCyrillic.IsMatch(NameTb.Text))
            {
                validationMsg1 = string.Empty;
            }
            else
            {
                validationMsg1 = "Только кириллица! ";
                isNameValidated = false;
            }
            if (isFirstUpper.IsMatch(NameTb.Text))
            {
                validationMsg2 = string.Empty;
                isNameValidated = true;
            }
            else
            {
                validationMsg2 = "С заглавной буквы! ";
                isNameValidated = false;
            }
            NameValidationMessage.Text = validationMsg1 + validationMsg2;
        }

        private void StepnameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var isFirstUpper = new Regex(@"^[А-Я]");
            var isCyrillic = new Regex(@"\p{IsCyrillic}");
            string validationMsg1;
            string validationMsg2;
            if (isCyrillic.IsMatch(NameTb.Text))
            {
                validationMsg1 = string.Empty;
                isStepNameValidated = true;
            }
            else
            {
                validationMsg1 = "Только кириллица! ";
                isStepNameValidated = false;
            }
            if (isFirstUpper.IsMatch(NameTb.Text))
            {
                validationMsg2 = string.Empty;
                isStepNameValidated = true;
            }
            else
            {
                validationMsg2 = "С заглавной буквы! ";
                isStepNameValidated = false;
            }
            StepnameValidationMessage.Text = validationMsg1 + validationMsg2;
        }
    }
}
