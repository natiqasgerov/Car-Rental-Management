using CarRentalSystem.Models;
using Dapper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public bool SaveTemp { get; set; } = true;
        public int CarIndex { get; set; }
        public static string FileName { get; set; } = String.Empty;
        public static Car ca { get; set; }
        public bool DelImage { get; set; } = false;
        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void carSave_btn_Click(object sender, RoutedEventArgs e)
        {
            MyDatabase database = new MyDatabase();
            if (SaveTemp)
            {
                
                if (makeCar_textbox.Text == String.Empty || modelCar_textbox.Text == String.Empty || carYear_datapicker.SelectedDate.ToString() == String.Empty
                    || carType_comboBox.SelectionBoxItem.ToString() == String.Empty || carNumber_textbox.Text == String.Empty || carFuel_comboBox.SelectionBoxItem.ToString() == String.Empty
                    || carTransmission_comboBox.SelectionBoxItem.ToString() == String.Empty || carTank_textbox.Text == String.Empty || carEngineSize_textbox.Text == String.Empty
                    || carOdometer_textbox.Text == String.Empty || carStatus_comboBox.SelectionBoxItem.ToString() == String.Empty)
                {
                    ErrorColor();
                    AlertWindow alertWindow = new AlertWindow();
                    alertWindow.ShowDialog();
                    return;
                }

                byte[] image = null;
                if(FileName != String.Empty)
                    image = File.ReadAllBytes(FileName);
                var count = database.db.Query<int>("SELECT Id FROM Cars ORDER BY Id DESC LIMIT 1").FirstOrDefault();

                Car car = new Car()
                {
                    Id = count + 1,
                    Make = makeCar_textbox.Text,
                    Model = modelCar_textbox.Text,
                    Year = carYear_datapicker.SelectedDate.ToString(),
                    Type = carType_comboBox.SelectionBoxItem.ToString(),
                    NumberPlate = carNumber_textbox.Text,
                    FuelType = carFuel_comboBox.SelectionBoxItem.ToString(),
                    Transmission = carTransmission_comboBox.SelectionBoxItem.ToString(),
                    TankSize = carTank_textbox.Text,
                    EngineSize = carEngineSize_textbox.Text,
                    Odometer = carOdometer_textbox.Text,
                    Status = carStatus_comboBox.SelectionBoxItem.ToString(),
                    Picture = image,
                    
                };

                if (car.Status == "Available")
                    car.Color = Brushes.GreenYellow;
                else if (car.Status == "Service")
                    car.Color = Brushes.DodgerBlue;
                else
                    car.Color = Brushes.Red;

                

                Window2.Cars.Add(car);

                database.InsertCars(car);
                
                
            }
            else
            {
                byte[] image_bytes = null;
                if (FileName != String.Empty)
                    image_bytes = File.ReadAllBytes(FileName);
                else if (DelImage)
                    image_bytes = null;
                else
                    image_bytes = ca.Picture;

                database.db.Execute(@$"UPDATE Cars SET Make = @Make,Model = @Model,Year = @Year,Type = @Type,NumberPlate = @Number,FuelType = @Fuel,Transmission = @Trans,
                    TankSize = @Tank,EngineSize = @Engine,Odometer = @Odometer,Status = @Status,Picture = @Picture1
                    WHERE Id = {CarIndex}",
                    new
                    {
                        @Make = makeCar_textbox.Text,
                        @Model = modelCar_textbox.Text,
                        @Year = carYear_datapicker.SelectedDate.ToString(),
                        @Type = carType_comboBox.SelectionBoxItem.ToString(),
                        @Number = carNumber_textbox.Text,
                        @Fuel = carFuel_comboBox.SelectionBoxItem.ToString(),
                        @Trans = carTransmission_comboBox.SelectionBoxItem.ToString(),
                        @Tank = carTank_textbox.Text,
                        @Engine = carEngineSize_textbox.Text,
                        @Odometer = carOdometer_textbox.Text,
                        @Status = carStatus_comboBox.SelectionBoxItem.ToString(),
                        @Picture1 = image_bytes,
                    });

                Window2.Cars = database.GetCars();

                SaveTemp = true;
                DelImage = false;
            }
            SuccessWindow successWindow = new SuccessWindow();
            successWindow.ShowDialog();
            FileName = String.Empty;
            this.Close();
        }


        private void ErrorColor()
        {
            if (makeCar_textbox.Text == String.Empty)
                makeCar_textbox.Foreground = Brushes.Red;
            if (modelCar_textbox.Text == String.Empty)
                modelCar_textbox.Foreground = Brushes.Red;
            if (carYear_datapicker.SelectedDate.ToString() == String.Empty)
                carYear_datapicker.Foreground = Brushes.Red;
            if (carType_comboBox.SelectionBoxItem.ToString() == String.Empty)
                carType_comboBox.Foreground = Brushes.Red;

            if (carNumber_textbox.Text == String.Empty)
                carNumber_textbox.Foreground = Brushes.Red;

            if (carFuel_comboBox.SelectionBoxItem.ToString() == String.Empty)
                carFuel_comboBox.Foreground = Brushes.Red;

            if (carTransmission_comboBox.SelectionBoxItem.ToString() == String.Empty)
                carTransmission_comboBox.Foreground = Brushes.Red;

            if (carTank_textbox.Text == String.Empty)
                carTank_textbox.Foreground = Brushes.Red;

            if (carEngineSize_textbox.Text == String.Empty)
                carEngineSize_textbox.Foreground = Brushes.Red;

            if (carOdometer_textbox.Text == String.Empty)
                carOdometer_textbox.Foreground = Brushes.Red;

            if (carStatus_comboBox.SelectionBoxItem.ToString() == String.Empty)
                carStatus_comboBox.Foreground = Brushes.Red;
        }

        private void makeCar_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (makeCar_textbox.Text != String.Empty)
                makeCar_textbox.Foreground = Brushes.Black;
        }

        private void modelCar_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(modelCar_textbox.Text != String.Empty)
                modelCar_textbox.Foreground = Brushes.Black;
        }

        private void carYear_datapicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(carYear_datapicker.SelectedDate != DateTime.MinValue)
                carYear_datapicker.Foreground = Brushes.Black;
        }

        private void carType_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(carType_comboBox.SelectionBoxItem != null)
                carType_comboBox.Foreground = Brushes.Black;
        }

        private void carFuel_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (carFuel_comboBox.SelectionBoxItem != null)
                carFuel_comboBox.Foreground = Brushes.Black;
        }

        private void carTransmission_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (carTransmission_comboBox.SelectionBoxItem != null)
                carTransmission_comboBox.Foreground = Brushes.Black;
        }

        private void carTank_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (carTank_textbox.Text != String.Empty)
                carTank_textbox.Foreground = Brushes.Black;
        }

        private void carEngineSize_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (carEngineSize_textbox.Text != String.Empty)
                carEngineSize_textbox.Foreground = Brushes.Black;
        }

        private void carNumber_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (carNumber_textbox.Text != String.Empty)
                carNumber_textbox.Foreground = Brushes.Black;
        }

        private void carOdometer_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (carOdometer_textbox.Text != String.Empty)
                carOdometer_textbox.Foreground = Brushes.Black;
        }

        private void carStatus_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (carStatus_comboBox.SelectionBoxItem != null)
                carStatus_comboBox.Foreground = Brushes.Black;
        }

        private void carBrowse_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if (!String.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                carImage_imagebrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                FileName = openFileDialog.FileName;
            }
        }

        private void carDelete_btn_Click(object sender, RoutedEventArgs e)
        {
            carImage_imagebrush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/"
            + Assembly.GetExecutingAssembly().GetName().Name
            + ";component/"
            + "Images/car.png", UriKind.Absolute));

            FileName = String.Empty;
            DelImage = true;
        }
    }
}
