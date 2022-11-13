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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cars.View
{
    /// <summary>
    /// Логика взаимодействия для CarViewPage.xaml
    /// </summary>
    public partial class CarViewPage : Page
    {
        public CarViewPage()
        {
            CarsDatabaseEntities carsDatabaseEntities = new CarsDatabaseEntities();
            ComboBoxColor.ItemsSource = carsDatabaseEntities.Color.ToList();
            InitializeComponent();
        }

        private void BackButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
