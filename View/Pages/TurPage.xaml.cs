using kyrsah.AppData;
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
    /// Логика взаимодействия для TurPage.xaml
    /// </summary>
    public partial class TurPage : Page
    {
        public TurPage()
        {
            InitializeComponent();
            List<TurClass> newList = new List<TurClass>()
            {
        new TurClass () {Title="БОЛЬШОЕ ПУТЕШЕСТВИЕ ПО ДАГЕСТАНУ | 5 ДНЕЙ |",Information="40,000P",  Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/путешествие.jpeg")},
        new TurClass () {Title="ГУНИБ | САЛТИНСКОЕ УЩЕЛЬЕ",Information="3,300Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/ущелье.jpg")},
                new TurClass () {Title="ДЕРБЕНТ | НАРЫН — КАЛА",Information="3,500Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/дербент.jpeg")},
                new TurClass () {Title="ДАГЕСТАН | ПОЛЁТ СВОБОДЫ | ИММЕРСИВНОЕ ПУТЕШЕСТВИЕ | 5 ДНЕЙ",Information="57,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/полет1.jpg")},
                new TurClass () {Title="КАСПИЙСКИЙ ВОЯЖ | 8 ДНЕЙ |",Information="19,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/каспийск.jpg")},          
                new TurClass () {Title="ГОРНЫЙ ДАГЕСТАН | 4 ДНЯ |",Information="25,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/горы.jpg")},
                new TurClass () {Title="ДЖИП ТУР | 5 ДНЕЙ",Information="55,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/джип.jpg")},
                new TurClass () {Title="ХУНЗАХ — ВОДОПАДЫ",Information="3,300Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/хунзах.jpg")},
                new TurClass () {Title="КАВКАЗСКИЕ КАНИКУЛЫ | ОТ ЧЕЧНИ ДО ДАГЕСТАНА | 5 ДНЕЙ |",Information="40,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/чечня.jpeg")},
                new TurClass () {Title="ПОЛЕТ СВОБОДЫ",Information="54,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/свобода.jpg")},
                new TurClass () {Title="ПОЛЕТ СВОБОДЫ",Information="54,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/свобода.jpg")},
                new TurClass () {Title="ДАГЕСТАНСКАЯ ШВЕЙЦАРИЯ",Information="13,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/ШВЕЙЦАРИЯ.jpg")},
                new TurClass () {Title="МАХАЧКАЛА РАСУЛА ГАМЗАТОВА",Information="19,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/РАСУЛ.jpg")},
              
                new TurClass () {Title="КАСПИЙСКИЙ ВОЯЖ | 8 ДНЕЙ |",Information="19,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/каспийск.jpg")},
                
            };
            foreach (TurClass news in newList)
            {
                TurLb.Items.Add(news);
            }
        }

        private void selectTour(object sender, SelectionChangedEventArgs e)
        {
            if (TurLb.SelectedItem is TurClass tur)
            {
                NavigationService.Navigate(new currentTour(tur));

            }
        }
    }
}
