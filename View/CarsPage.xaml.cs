using Cars;
using Cars.Data;
using Cars.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace RentCar.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        Users _user;
        MainWindow _mainWindow;
        public CarsPage(Users user,MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _user = user;
            InitializeComponent();
            RefreshTable();
        }

        public CarsPage(Users user, MainWindow mainWindow, bool adding)
        {
            _mainWindow = mainWindow;
            _user = user;
            CarsDatabaseEntities database = new CarsDatabaseEntities();
            InitializeComponent();
            DataGridCars.ItemsSource = database.Auto.ToList();

        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            if(_user.RoleId == 3 || _user.RoleId == 2)
            {
                var b = sender as Button;
                var row = b.DataContext;
                int index = DataGridCars.SelectedIndex + 1;
                CarsDatabaseEntities database = new CarsDatabaseEntities();
                Auto auto = database.Auto.Where(x => x.Id == index).First();

                //Открывает окно просмотра
                CarView carView = new CarView(index,_mainWindow);
                carView.ShowDialog();
            }
            else
                MessageBox.Show("Недостаточно прав");
        }

        public void RefreshTable()
        {
            CarsDatabaseEntities database = new CarsDatabaseEntities();
            DataGridCars.ItemsSource = database.Auto.ToList();
            DataGridCars.Items.Refresh();
        }
    }
}
