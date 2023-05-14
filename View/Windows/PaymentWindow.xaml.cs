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
using System.Windows.Shapes;

namespace kyrsah.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public PaymentWindow()
        {
            InitializeComponent();
        }
        Regex isDigit = new Regex("^[0-9]+$");
        string validationMsgCardNumber;
        bool firstBlock = false;
        bool secondBlock = false;
        bool thirdBlock = false;
        bool fourthBlock = false;

        bool isAllBlockFourDigits = false;
        bool isCartHolderValidated = false;
        bool isDayValidated = false;
        bool isYearValidated = false;
        bool isCVVValidated = false;

        private void firstBlockCardNumberTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isDigit.IsMatch(firstBlockCardNumberTb.Text))
            {
                if (firstBlockCardNumberTb.Text.Length == 4)
                {
                    secondBlockCardNumberTb.IsEnabled = true;
                    secondBlockCardNumberTb.Focus();
                }
                else
                {
                    secondBlockCardNumberTb.Text = string.Empty;
                    thirdBlockCardNumberTb.Text = string.Empty;
                    fourthBlockCardNumberTb.Text = string.Empty;
                    secondBlockCardNumberTb.IsEnabled = false;
                    thirdBlockCardNumberTb.IsEnabled = false;
                    fourthBlockCardNumberTb.IsEnabled = false;
                }
                firstBlock = true;
                validationMsgCardNumber = string.Empty;
            }
            else
            {
                firstBlock = false;
                validationMsgCardNumber = "Только цифры! ";
            }
            validationCardNumberTbl.Text = validationMsgCardNumber;
        }

        private void secondBlockCardNumberTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isDigit.IsMatch(secondBlockCardNumberTb.Text))
            {
                if (secondBlockCardNumberTb.Text.Length == 4)
                {
                    thirdBlockCardNumberTb.IsEnabled = true;
                    thirdBlockCardNumberTb.Focus();
                }
                else
                {
                    thirdBlockCardNumberTb.Text = string.Empty;
                    fourthBlockCardNumberTb.Text = string.Empty;
                    thirdBlockCardNumberTb.IsEnabled = false;
                    fourthBlockCardNumberTb.IsEnabled = false;
                }
                secondBlock = true;
                validationMsgCardNumber = string.Empty;
            }
            else
            {
                secondBlock = false;
                validationMsgCardNumber = "Только цифры! ";
            }
            if (secondBlockCardNumberTb.Text.Length == 0)
            {
                if (Keyboard.IsKeyDown(Key.Back))
                {
                    firstBlockCardNumberTb.Focus();
                }
            }
            validationCardNumberTbl.Text = validationMsgCardNumber;
        }

        private void thirdBlockCardNumberTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isDigit.IsMatch(thirdBlockCardNumberTb.Text))
            {
                if (thirdBlockCardNumberTb.Text.Length == 4)
                {
                    fourthBlockCardNumberTb.IsEnabled = true;
                    fourthBlockCardNumberTb.Focus();
                }
                else
                {
                    fourthBlockCardNumberTb.Text = string.Empty;
                    fourthBlockCardNumberTb.IsEnabled = false;
                }
                thirdBlock = true;
                validationMsgCardNumber = string.Empty;
            }
            else
            {
                thirdBlock = false;
                validationMsgCardNumber = "Только цифры! ";
            }
            if (thirdBlockCardNumberTb.Text.Length == 0)
            {
                if (Keyboard.IsKeyDown(Key.Back))
                {
                    secondBlockCardNumberTb.Focus();
                }
            }
            validationCardNumberTbl.Text = validationMsgCardNumber;
        }

        string validationLength;
        private void fourthBlockCardNumberTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isDigit.IsMatch(fourthBlockCardNumberTb.Text))
            {
                if (fourthBlockCardNumberTb.Text.Length == 4)
                {
                    validationLength = string.Empty;
                    isAllBlockFourDigits = true;
                }
                else
                {
                    validationLength = "В каждом блоке должно быть 4 цифры! ";
                    isAllBlockFourDigits = false;
                }
                fourthBlock = true;
                validationMsgCardNumber = string.Empty;
            }
            else
            {
                fourthBlock = false;
                validationMsgCardNumber = "Только цифры! ";
            }
            if (fourthBlockCardNumberTb.Text.Length == 0)
            {
                if (Keyboard.IsKeyDown(Key.Back))
                {
                    thirdBlockCardNumberTb.Focus();
                }
            }
            validationCardNumberTbl.Text = validationMsgCardNumber + validationLength;
        }
        Regex isCartHolderName = new Regex("^[A-Z]*(\\s[A-Z]*)+$");
        private void CartHolderTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isCartHolderName.IsMatch(CartHolderTb.Text))
            {
                validationCartHolderTbl.Text = string.Empty;
                isCartHolderValidated = true;
            }
            else
            {
                validationCartHolderTbl.Text = "Имя держателя не соответствует формату!";
                isCartHolderValidated = false;
            }
        }
        string validationDay1;
        string validationDay2;
        private void DayTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isDigit.IsMatch(DayTb.Text))
            {
                validationDay1 = string.Empty;
                isDayValidated = true;
                if (int.Parse(DayTb.Text) > 31 || int.Parse(DayTb.Text) <= 0)
                {
                    validationDay2 = "Неправильный формат";
                    isDayValidated = false;
                }
                else
                {
                    isDayValidated = true;
                    validationDay2 = string.Empty;
                }
            }
            else
            {
                isDayValidated = false;
                validationDay1 = "Только цифры! ";
            }
            validationDayTbl.Text = validationDay1 + validationDay2;
        }
        string validationYear1;
        string validationYear2;
        private void YearTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isDigit.IsMatch(YearTb.Text))
            {
                validationYear1 = string.Empty;
                if (int.Parse(YearTb.Text) < DateTime.Now.Year)
                {
                    validationYear2 = "Карта просрочена!";
                    isYearValidated = false;
                }
                else
                {
                    validationYear2 = string.Empty;
                    isYearValidated = true;
                }
            }
            else
            {
                validationYear1 = "Только цифры! ";
            }
            validationYearTbl.Text = validationYear1 + validationYear2;
        }
        string validationCv1;
        string validationCv2;
        private void CVCodeTb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (isDigit.IsMatch(CVCodeTb.Password))
            {
                validationCv1 = string.Empty;
                if (CVCodeTb.Password.Length != 3)
                {
                    validationCv2 = "Длина некорректна!";
                    isCVVValidated = false;
                }
                else
                {
                    validationCv2 = string.Empty;
                    isCVVValidated = true;
                }
            }
            else
            {
                validationCv1 = "Только цифры! ";
            }
            validationCVVCodeTbl.Text = validationCv1 + validationCv2;
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isAllBlockFourDigits == true &&
                isCartHolderValidated == true &&
                isDayValidated == true &&
                isYearValidated == true &&
                isCVVValidated == true)
            {
                MessageBox.Show("Оплата произведена успешно!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены верно!");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
