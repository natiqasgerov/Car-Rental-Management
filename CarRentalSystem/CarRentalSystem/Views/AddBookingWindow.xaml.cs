using CarRentalSystem.Models;
using Dapper;
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

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for AddBookingWindow.xaml
    /// </summary>
    public partial class AddBookingWindow : Window
    {
        public bool SaveTemp { get; set; } = true;
        public static Customer SelectedCustomer { get; set; }
        public static int BookingIndex { get; set; }
        public List<string> Cars { get; set; } = new();
        public AddBookingWindow()
        {
            InitializeComponent();
            var item = Window2.Cars.Where(x => x.Status == "Available").ToList();
            item.ForEach(x => Cars.Add(x.Make + " " + x.Model));
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void bookingSave_btn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveTemp)
            {

                if (vehicleComboBox.SelectionBoxItem.ToString() == String.Empty || CheckIn_datapicker.SelectedDate.ToString() == String.Empty || CheckOut_datapicker.SelectedDate.ToString() == String.Empty ||
                    balance_textbox.Text == String.Empty || type_combobox.SelectionBoxItem.ToString() == String.Empty || Method_combobox.SelectionBoxItem.ToString() == String.Empty)
                {
                    ErrorColor();
                    AlertWindow alertWindow = new AlertWindow();
                    alertWindow.ShowDialog();
                    return;
                }

                MyDatabase database = new MyDatabase();

                
                var count = database.db.Query<int>("SELECT Id FROM Bookings ORDER BY Id DESC LIMIT 1").FirstOrDefault();

                Booking booking = new Booking()
                {
                    Id = count + 1,
                    CustomerId = SelectedCustomer.Id,
                    CarName = vehicleComboBox.SelectedItem.ToString(),
                    CheckInDate = CheckIn_datapicker.SelectedDate.ToString(),
                    CheckOutDate = CheckOut_datapicker.SelectedDate.ToString(),
                    Balance = balance_textbox.Text,
                    Method = Method_combobox.SelectionBoxItem.ToString(),
                    Type = type_combobox.SelectionBoxItem.ToString(),

                };


                Window2.Bookings.Add(booking);

                database.InsertBookings(booking);


            }
            else
            {
                MyDatabase database1 = new MyDatabase();
                database1.db.Execute(@$"UPDATE Bookings SET CarName = @Name, CheckInDate = @In, CheckOutDate = @Out, Balance = @Balance,Type = @Type,
                                    Method = @Method
                                    WHERE Id = {BookingIndex}",
                                    new
                                    {
                                        @Name = vehicleComboBox.SelectionBoxItem.ToString(),
                                        @In = CheckIn_datapicker.SelectedDate.ToString(),
                                        @Out = CheckOut_datapicker.SelectedDate.ToString(),
                                        @Balance = balance_textbox.Text,
                                        @Type = type_combobox.SelectionBoxItem.ToString(),
                                        @Method = Method_combobox.SelectionBoxItem.ToString(),
                                        
                                    });
                SaveTemp = true;
                
                Window2.Bookings = database1.GetBookings(SelectedCustomer.Id);
            }
            SuccessWindow successWindow = new SuccessWindow();
            successWindow.ShowDialog();
            this.Close();
        }

        private void ErrorColor()
        {

            if (vehicleComboBox.SelectionBoxItem.ToString() == String.Empty)
                vehicleComboBox.Foreground = Brushes.Red;
            if (CheckIn_datapicker.SelectedDate.ToString() == String.Empty)
                CheckIn_datapicker.Foreground = Brushes.Red;
            if (CheckOut_datapicker.SelectedDate.ToString() == String.Empty)
                CheckOut_datapicker.Foreground = Brushes.Red;
            if (balance_textbox.Text == String.Empty)
                balance_textbox.Foreground = Brushes.Red;
            if (type_combobox.SelectionBoxItem.ToString() == String.Empty)
                type_combobox.Foreground = Brushes.Red;
            if (Method_combobox.SelectionBoxItem.ToString() == String.Empty)
                Method_combobox.Foreground = Brushes.Red;


        }
        private void CheckOut_datapicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckOut_datapicker.SelectedDate.ToString() != String.Empty)
                CheckOut_datapicker.Foreground = Brushes.Black;


            var item = (CheckOut_datapicker.SelectedDate - CheckIn_datapicker.SelectedDate).ToString();
            if (item != "00:00:00")
                days_textbox.Text = item.Substring(0, item.Length - 9);
            else
                days_textbox.Text = "0";
            
        }

        private void vehicleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vehicleComboBox.SelectionBoxItem != null)
                vehicleComboBox.Foreground = Brushes.Black;
        }

        private void CheckIn_datapicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckIn_datapicker.SelectedDate.ToString() != String.Empty)
                CheckIn_datapicker.Foreground = Brushes.Black;
        }

        private void balance_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (balance_textbox.Text != String.Empty)
                balance_textbox.Foreground = Brushes.Black;
        }

        private void type_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type_combobox.SelectionBoxItem != null)
                type_combobox.Foreground = Brushes.Black;
        }

        private void Method_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Method_combobox.SelectionBoxItem != null)
                Method_combobox.Foreground = Brushes.Black;
        }

        private void ChangeStatus(string str)
        {
            
        }
    }
}
