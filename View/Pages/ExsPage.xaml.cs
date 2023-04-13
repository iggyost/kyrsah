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
    /// Логика взаимодействия для ExsPage.xaml
    /// </summary>
    public partial class ExsPage : Page
    {
        public ExsPage()
        {
            InitializeComponent();
            List<ExsClass> newList = new List<ExsClass>()
             {
        new ExsClass () {Title="ДЕРБЕНТ — ПЕРВАЯ ВСТРЕЧА Вы познакомитесь с одним из древнейших мест России, наполненным таинственным восточным колоритом, — средневековые мечети, величественные крепостные стены, суровая красота горных пейзажей, пение муэдзинов. Я покажу вам главные достопримечательности Дербента: цитадель Нарын-Кала, Джума-мечеть, Девичью баню и музей декабриста Бестужева-Марлинского.",Information="4,000P",  Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/дер1.jpg")},
        new ExsClass () {Title="ДРУЖЕСКИЙ ТУР К СУЛАКСКОМУ КАНЬОНУ Из Махачкалы мы отправимся к одному из самых длинных и глубоких каньонов мира — даже знаменитый американский Гранд-Каньон уступает ему. Вас ждут головокружительные виды Сулакского каньона, «Качели любви» и прогулка по лесу. А при желании вы навестите Бархан Сарыкум, проплывете на катере по ущелью, пролетите на зиплайне или покатаетесь на лошадях.",Information="7,800Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/другтур.jpeg")},
                new ExsClass () {Title="ЗДРАВСТВУЙ, МАХАЧКАЛА! На обзорной экскурсии я познакомлю вас с ключевыми достопримечательностями Махачкалы, при этом моя главная цель — рассказать о знаковых местах без отрыва от реальной жизни и помочь разглядеть за открыточными видами, древними фасадами и городскими легендами менталитет и философию дагестанцев. Ведь именно люди рисуют облик города и наделяют его своей душой.",Information="5,200Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/здрав.jpeg")},
                new ExsClass () {Title="ЧУДЕСНЫЙ ДАГЕСТАН: БАРХАН, КАНЬОН И ФОРЕЛЕВОЕ ХОЗЯЙСТВО В этой поездке мы увидим бархан «Сарыкум», прогуляемся по Сулакскому каньону, посетим форелевое хозяйство, прокатимся на катере, полюбуемся видами каньона сверху, отведаем форель либо любое национальное блюдо, привезём кучу фоток, впечатлений и эмоций.",Information="10,000Р", Uri=new Uri(@"O:/Pankrateva_Ekaterina/kyrsah/kyrsah/Resourses/бархан.jpg")},
                

            };
            foreach (ExsClass news in newList)
            {
                ExsLb.Items.Add(news);
            }
        }

        private void ExsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
