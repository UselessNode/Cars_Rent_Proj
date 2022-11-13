using Cars.Data;
using Cars.View;
using RentCar.Pages;
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

namespace Cars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Users _user;
        Auto _auto;
        CarView carView;
        public MainWindow(Users user)
        {
            InitializeComponent();
            _user = user;
            CarsPage.Navigate(new CarsPage(_user,this));
            UserLabel.Content = user.Login;
            
        }

        public MainWindow()
        {
            InitializeComponent();
            _user = new Users();
            _user.Id = 0;
            CarsPage.Navigate(new CarsPage(_user,this));
            UserLabel.Content = "Гость";
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_user.RoleId == 3 || _user.RoleId == 2)
            {
                //Открывает окно просмотра
                carView = new CarView(this);
                carView.ShowDialog();
            }
            else
                MessageBox.Show("Недостаточно прав");
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            //CarsPage.Navigate(new CarsPage(_user, this));
            CarsPage.Content = new CarsPage(_user, this);
        }
    }
}
