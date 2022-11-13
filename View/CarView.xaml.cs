using Cars.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для CarView.xaml
    /// </summary>
    public partial class CarView : Window
    {
        private Auto _auto = new Auto();
        MainWindow _mainWindow;
        bool addingForm = false;

        CarsDatabaseEntities carsDatabaseEntities;
        public CarView(int id, MainWindow mainWindow)
        {
            InitializeComponent();
            carsDatabaseEntities = new CarsDatabaseEntities();
            _auto = carsDatabaseEntities.Auto.Where(x => x.Id == id).First();
            DataContext = _auto;
            ComboBoxColor.ItemsSource = carsDatabaseEntities.Color.ToList();
            _mainWindow = mainWindow;
            addingForm = false;
        }
        public CarView(MainWindow mainWindow)
        {
            InitializeComponent();
            carsDatabaseEntities = new CarsDatabaseEntities();
            ComboBoxColor.ItemsSource = carsDatabaseEntities.Color.ToList();
            _mainWindow = mainWindow;
            addingForm = true;
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if (addingForm)
            {
                try
                {
                    Cars.Data.Auto auto = new Auto();
                    auto.ModelName = TextBoxModelName.Text;
                    auto.ColorId = ComboBoxColor.SelectedIndex;
                    auto.ProductDateYear = TextBoxDate.Text;
                    Random r = new Random();
                    auto.Insurance = r.Next(358234);
                    auto.DailyRentalCost = r.Next(10000);
                    auto.GovNumber = TextBoxGovNumber.Text;
                    auto.Available = CheckBoxAvalible.IsChecked;
                    auto.Cost = Double.Parse(TextBoxCost.Text);

                    carsDatabaseEntities.Auto.Add(auto);
                    carsDatabaseEntities.SaveChanges();
                    this.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                carsDatabaseEntities.SaveChanges();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            carsDatabaseEntities.Auto.Remove(_auto);
            carsDatabaseEntities.SaveChanges();
        }
    }
}
