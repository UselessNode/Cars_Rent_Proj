using Cars.Data;
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

namespace Cars.View
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }
        MainWindow mainWindow;


        private void loginButtonClick(object sender, RoutedEventArgs e)
        {
            string login = LoginInput.Text;
            CarsDatabaseEntities database = new CarsDatabaseEntities();
            string password = PasswordInput.Password;
            if (database.Users.Any(x => login.Equals(x.Login) && password.Equals(x.Password)))
            {
                var user = database.Users.Where(x => login.Equals(x.Login) && password.Equals(x.Password)).First();
                LoadMain(user);
            }
            else
                MessageBox.Show("Пользователь не найден");
        }

        private void guestButtonClick(object sender, MouseButtonEventArgs e)
        {
            LoadMain();
        }

        public void LoadMain(Users user = null)
        {
            mainWindow = new MainWindow(user);
            mainWindow.Show();
            this.Close();
        }
        public void LoadMain()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
