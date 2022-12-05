using CarRentalSystem.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        public static ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();
        public static ObservableCollection<Booking> Bookings { get; set; } = new ObservableCollection<Booking>();
        public static bool DeleteTemp { get; set; } = false;
        public string UserName { get; set; } = String.Empty;
        public Window2()
        {
            InitializeComponent();
            
            ReadData();
            DataContext = this;
            
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void newCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow window = new AddCustomerWindow();
            window.ShowDialog();
        }

        private void ReadData()
        {
            MyDatabase database = new MyDatabase();
            Cars = database.GetCars();
            CarStatusColor();
            Customers = database.GetCustomers();
            
        }

        private void CarStatusColor()
        {
            foreach (var item in Cars)
            {
                if (item.Status == "Available")
                    item.Color = Brushes.GreenYellow;
                else if (item.Status == "Service")
                    item.Color = Brushes.DodgerBlue;
                else
                    item.Color = Brushes.Red;
            }
        }


        private void editCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            var customer = membersDataGrid.SelectedItem as Customer;
            AddCustomerWindow addWindow = new AddCustomerWindow();

            addWindow.SaveTemp = false;
            addWindow.CIndex = customer.Id;
            addWindow.nameCustomer_textbox.Text = customer.Name;
            addWindow.phoneCustomer_textbox.Text = customer.Phone;
            addWindow.emailCustomer_textbox.Text = customer.Email;
            addWindow.addressCustomer_textbox.Text = customer.Address;
            addWindow.birthDate_datepicker.Text = customer.DateBirth;
            addWindow.issueDate_datepicker.Text = customer.IssueDate;
            addWindow.expiryDate_datapicker.Text = customer.ExpiryDate;
            addWindow.lisenceNo_textbox.Text = customer.LisenceNo;
            addWindow.genderCustomer_combobox.Text = customer.Gender;
            if(customer.Picture != null)
                addWindow.imageCustomer_imagebrush.ImageSource = ByteImage.Convert(ByteImage.GetImageFromByteArray(customer.Picture));

            AddCustomerWindow.cus = customer;


            addWindow.ShowDialog();
            membersDataGrid.ItemsSource = Customers;
           
        }

        private void deleteCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            var customer = membersDataGrid.SelectedItem as Customer;
            deleteWindow.ShowDialog();
            
            if(DeleteTemp == true)
            {
                Customers.Remove(customer);
                MyDatabase myDatabase = new MyDatabase();
                myDatabase.db.Execute("DELETE FROM Customers WHERE Id = @Id", new
                {
                    @Id = customer.Id
                });
                myDatabase.db.Execute($"DELETE FROM Bookings WHERE CId = {customer.Id}");
            }
            DeleteTemp = false;
        }
        

        private void customers_Item_Selected(object sender, RoutedEventArgs e)
        {
            customers_grid.Visibility = Visibility.Visible;
            cars_grid.Visibility = Visibility.Hidden;
            dashboard_grid.Visibility = Visibility.Hidden;
        }

        private void cars_Item_Selected(object sender, RoutedEventArgs e)
        {
            cars_grid.Visibility = Visibility.Visible;
            customers_grid.Visibility = Visibility.Hidden;
            dashboard_grid.Visibility = Visibility.Hidden;
        }

        private void newCars_btn_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow window = new AddCarWindow();
            window.ShowDialog();


        }

        private void editCar_btn_Click(object sender, RoutedEventArgs e)
        {
            var car = carsDatagrid.SelectedItem as Car;
            AddCarWindow window = new AddCarWindow();
            window.SaveTemp = false;
            window.CarIndex = car.Id;
            window.makeCar_textbox.Text = car.Make;
            window.modelCar_textbox.Text = car.Model;
            window.carYear_datapicker.Text = car.Year;
            window.carType_comboBox.Text = car.Type;
            window.carNumber_textbox.Text = car.NumberPlate;
            window.carFuel_comboBox.Text = car.FuelType;
            window.carTransmission_comboBox.Text = car.Transmission;
            window.carTank_textbox.Text = car.TankSize;
            window.carEngineSize_textbox.Text = car.EngineSize;
            window.carOdometer_textbox.Text = car.Odometer;
            window.carStatus_comboBox.Text = car.Status;
            if (car.Picture != null)
                window.carImage_imagebrush.ImageSource = ByteImage.Convert(ByteImage.GetImageFromByteArray(car.Picture));

            AddCarWindow.ca = car;
            window.ShowDialog();
            CarStatusColor();
            carsDatagrid.ItemsSource = Cars;
        }

        private void deleteCar_btn_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            var car = carsDatagrid.SelectedItem as Car;
            deleteWindow.ShowDialog();

            if (DeleteTemp == true)
            {
                Cars.Remove(car);
                MyDatabase myDatabase = new MyDatabase();
                myDatabase.db.Execute("DELETE FROM Cars WHERE Id = @Id", new
                {
                    @Id = car.Id
                });
            }
            DeleteTemp = false;
        }

        private void viewCar_btn_Click(object sender, RoutedEventArgs e)
        {
            var car = carsDatagrid.SelectedItem as Car;
            AddCarWindow window = new AddCarWindow();
            window.SaveTemp = false;
            window.CarIndex = car.Id;
            window.makeCar_textbox.Text = car.Make;
            window.modelCar_textbox.Text = car.Model;
            window.carYear_datapicker.Text = car.Year;
            window.carType_comboBox.Text = car.Type;
            window.carNumber_textbox.Text = car.NumberPlate;
            window.carFuel_comboBox.Text = car.FuelType;
            window.carTransmission_comboBox.Text = car.Transmission;
            window.carTank_textbox.Text = car.TankSize;
            window.carEngineSize_textbox.Text = car.EngineSize;
            window.carOdometer_textbox.Text = car.Odometer;
            window.carStatus_comboBox.Text = car.Status;
            if (car.Picture != null)
                window.carImage_imagebrush.ImageSource = ByteImage.Convert(ByteImage.GetImageFromByteArray(car.Picture));

            window.carSave_btn.IsEnabled = false;
            window.carBrowse_btn.IsEnabled = false;
            window.carDelete_btn.IsEnabled = false;
            window.makeCar_textbox.IsEnabled = false;
            window.modelCar_textbox.IsEnabled = false;
            window.carYear_datapicker.IsEnabled = false;
            window.carType_comboBox.IsEnabled = false;
            window.carNumber_textbox.IsEnabled = false;
            window.carTransmission_comboBox.IsEnabled = false;
            window.carFuel_comboBox.IsEnabled = false;
            window.carTank_textbox.IsEnabled = false;
            window.carEngineSize_textbox.IsEnabled = false;
            window.carOdometer_textbox.IsEnabled = false;
            window.carStatus_comboBox.IsEnabled = false;

            window.ShowDialog();
            
        }

        private void viewCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            customers_grid.Visibility = Visibility.Hidden;
            customers2_grid.Visibility = Visibility.Visible;

            var selected = membersDataGrid.SelectedItem as Customer;
            if(selected.Picture != null)
                Customer2_imagebrush.ImageSource = ByteImage.Convert(ByteImage.GetImageFromByteArray(selected.Picture));
            else
                Customer2_imagebrush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/"
                                                    + Assembly.GetExecutingAssembly().GetName().Name
                                                    + ";component/"
                                                    + "Images/user.jpg", UriKind.Absolute));
            customer2Name_textblock.Text = selected.Name;
            summaryAddress.Text = selected.Address;
            summaryEmail.Text = selected.Email;
            summaryPhone.Text = selected.Phone;
            summaryLisence.Text = selected.LisenceNo;
            summaryBirth.Text = selected.DateBirth;
            summaryExpiry.Text = selected.ExpiryDate;
            summaryIssue.Text = selected.IssueDate;
            summaryGender.Text = selected.Gender;

            dashboard_Item.IsEnabled = false;
            customers_Item.IsEnabled = false;
            settings_Item.IsEnabled = false;
            cars_Item.IsEnabled = false;

            MyDatabase database = new MyDatabase();

            var item = membersDataGrid.SelectedItem as Customer;
            
            if (item != null)
            {
                Bookings = database.GetBookings(item.Id);
                bookings_datagrid.ItemsSource = Bookings;
                
            }
            
        }

        private void backCustomer2_btn_Click(object sender, RoutedEventArgs e)
        {
            customers2_grid.Visibility = Visibility.Hidden;
            customers_grid.Visibility = Visibility.Visible;
            dashboard_Item.IsEnabled = true;
            customers_Item.IsEnabled = true;
            settings_Item.IsEnabled = true;
            cars_Item.IsEnabled = true;

            booking_tabcontrl.SelectedIndex = 0;
        }

        private void newBooking_btn_Click(object sender, RoutedEventArgs e)
        {
            AddBookingWindow bookingWindow = new AddBookingWindow();
            AddBookingWindow.SelectedCustomer = membersDataGrid.SelectedItem as Customer;
            bookingWindow.ShowDialog();
        }

        private void editBooking_btn_Click(object sender, RoutedEventArgs e)
        {
            AddBookingWindow bookingWindow = new AddBookingWindow();
            var custom = membersDataGrid.SelectedItem as Customer;
            var booking = bookings_datagrid.SelectedItem as Booking;
            AddBookingWindow.BookingIndex = booking.Id;
            AddBookingWindow.SelectedCustomer = custom;

            AddBookingWindow.BookingIndex = booking.Id;
            bookingWindow.vehicleComboBox.SelectedItem = booking.CarName;
            bookingWindow.CheckIn_datapicker.Text = booking.CheckInDate;
            bookingWindow.CheckOut_datapicker.Text = booking.CheckOutDate;
            bookingWindow.balance_textbox.Text = booking.Balance;
            bookingWindow.type_combobox.Text = booking.Type;
            bookingWindow.Method_combobox.Text = booking.Method;
            bookingWindow.SaveTemp = false;
            bookingWindow.ShowDialog();

            bookings_datagrid.ItemsSource = Bookings;
        }

        private void viewBooking_btn_Click(object sender, RoutedEventArgs e)
        {
            var booking = bookings_datagrid.SelectedItem as Booking;

            AddBookingWindow window = new AddBookingWindow();
            window.SaveTemp = false;
            
            if (booking != null)
            {
                window.vehicleComboBox.SelectedItem = booking.CarName;
                window.CheckIn_datapicker.Text = booking.CheckInDate;
                window.CheckOut_datapicker.Text = booking.CheckOutDate;
                window.balance_textbox.Text = booking.Balance;
                window.type_combobox.Text = booking.Type;
                window.Method_combobox.Text = booking.Method;
            }

            window.vehicleComboBox.IsEnabled = false;
            window.CheckIn_datapicker.IsEnabled = false;
            window.CheckOut_datapicker.IsEnabled = false;
            window.balance_textbox.IsEnabled = false;
            window.type_combobox.IsEnabled = false;
            window.Method_combobox.IsEnabled = false;
            window.bookingSave_btn.IsEnabled = false;

            window.ShowDialog();

        }

        private void deleteBooking_btn_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            var booking  = bookings_datagrid.SelectedItem as Booking;

            deleteWindow.ShowDialog();

            if (DeleteTemp == true)
            {
                Bookings.Remove(booking);
                MyDatabase myDatabase = new MyDatabase();
                myDatabase.db.Execute("DELETE FROM Bookings WHERE Id = @Id", new
                {
                    @Id = booking.Id
                });
            }
            DeleteTemp = false;
        }

        private void dashboard_Item_Selected(object sender, RoutedEventArgs e)
        {
            MyDatabase database = new MyDatabase();
            var totalCustomers = database.db.Query<string>("SELECT count(Id) FROM Customers").FirstOrDefault();
            var totalCars = database.db.Query<string>("SELECT count(Id) FROM Cars").FirstOrDefault();
            var totalBalance = database.db.Query<string>("SELECT sum(Balance) FROM Bookings").FirstOrDefault();
            customer_dashboard.Number = totalCustomers;
            cars_dashboard.Number = totalCars;
            balance_dashboard.Number = "$" + totalBalance;
            dashUserName.Text = $"Good Afternoon, Boss";





            dashboard_grid.Visibility = Visibility.Visible;
            customers_grid.Visibility = Visibility.Hidden;
            cars_grid.Visibility = Visibility.Hidden;
            
        }
    }
}
