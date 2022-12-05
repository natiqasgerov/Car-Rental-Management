using CarRentalSystem.Models;
using Dapper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using Brushes = System.Windows.Media.Brushes;
using System.IO;
using System.Data.SQLite;
using System.Reflection;

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public bool SaveTemp { get; set; } = true;
        public int CIndex { get; set; }
        public static string FileName { get; set; } = String.Empty;
        public static string str { get; set; } = String.Empty;
        public static Customer cus { get; set; }
        public bool DelImageTemp { get; set; } = false;
        public AddCustomerWindow()
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

        private void deleteImageCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            
            imageCustomer_imagebrush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/"
            + Assembly.GetExecutingAssembly().GetName().Name
            + ";component/"
            + "Images/user.jpg", UriKind.Absolute));

            FileName = String.Empty;
            DelImageTemp = true;
            

        }

        private void saveCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveTemp)
            {
                
                

                if (nameCustomer_textbox.Text == String.Empty || phoneCustomer_textbox.Text == String.Empty || emailCustomer_textbox.Foreground == Brushes.Red ||
                    addressCustomer_textbox.Text == String.Empty)
                {
                    ErrorColor();
                    AlertWindow alertWindow = new AlertWindow();
                    alertWindow.ShowDialog();
                    return;
                }
                    
                MyDatabase database = new MyDatabase();

                byte[] image = null;
                if (FileName != String.Empty)
                    image = File.ReadAllBytes(FileName);
                var count = database.db.Query<int>("SELECT Id FROM Customers ORDER BY Id DESC LIMIT 1").FirstOrDefault();

                Customer customer = new Customer()
                {
                    Id = count + 1,
                    Name = nameCustomer_textbox.Text,
                    Phone = phoneCustomer_textbox.Text,
                    Email = emailCustomer_textbox.Text,
                    Address = addressCustomer_textbox.Text,
                    DateBirth = birthDate_datepicker.SelectedDate.ToString(),
                    IssueDate = issueDate_datepicker.SelectedDate.ToString(),
                    ExpiryDate = expiryDate_datapicker.SelectedDate.ToString(),
                    LisenceNo = lisenceNo_textbox.Text,
                    Gender = genderCustomer_combobox.SelectionBoxItem.ToString(),
                    Picture = image,
                };


                Window2.Customers.Add(customer);

                
                database.InsertCustomers(customer);

                

            }
            else
            {
                byte[] image_bytes = null;
                if (FileName != String.Empty)
                    image_bytes = File.ReadAllBytes(FileName);
                else if (DelImageTemp)
                    image_bytes = null;
                else
                    image_bytes = cus.Picture;
                
                MyDatabase database1 = new MyDatabase();
                database1.db.Execute(@$"UPDATE Customers SET Name = @Name, Phone = @Phone, Email = @Email, Address = @Address,Picture = @Picture1,
                                    DateBirth = @Birth,LisenceNo = @LisNo,IssueDate = @Issue,ExpiryDate = @Expiry,Gender = @Gender
                                    WHERE Id = {CIndex}",
                                    new
                                    {
                                        @Name = nameCustomer_textbox.Text,
                                        @Phone = phoneCustomer_textbox.Text,
                                        @Email = emailCustomer_textbox.Text,
                                        @Address = addressCustomer_textbox.Text,
                                        @Birth = birthDate_datepicker.SelectedDate.ToString(),
                                        @LisNo = lisenceNo_textbox.Text,
                                        @Issue = issueDate_datepicker.SelectedDate.ToString(),
                                        @Expiry = expiryDate_datapicker.SelectedDate.ToString(),
                                        @Gender = genderCustomer_combobox.SelectionBoxItem.ToString(),
                                        @Picture1 = image_bytes
                                    });
                SaveTemp = true;
                cus = null;
                Window2.Customers = database1.GetCustomers();
                DelImageTemp = false;          
                
            }
            SuccessWindow successWindow = new SuccessWindow();
            successWindow.ShowDialog();
            FileName = String.Empty;
            this.Close();
        }

        private void browseCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
           
            if (!String.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                imageCustomer_imagebrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                FileName = openFileDialog.FileName;
            }
        }

        private void ErrorColor()
        {
            
            if (nameCustomer_textbox.Text == String.Empty)
                nameCustomer_textbox.Foreground = Brushes.Red;
            if (phoneCustomer_textbox.Text == String.Empty)
                phoneCustomer_textbox.Foreground = Brushes.Red;
            if (addressCustomer_textbox.Text == String.Empty)
                addressCustomer_textbox.Foreground = Brushes.Red;
            if(emailCustomer_textbox.Text == String.Empty)
                emailCustomer_textbox.Foreground= Brushes.Red;
                
            
        }

        private void nameCustomer_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nameCustomer_textbox.Text != String.Empty)
                nameCustomer_textbox.Foreground = Brushes.Black;
        }

        private void phoneCustomer_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(phoneCustomer_textbox.Text != String.Empty)
                phoneCustomer_textbox.Foreground = Brushes.Black;
        }

        private void addressCustomer_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (addressCustomer_textbox.Text != String.Empty)
                addressCustomer_textbox.Foreground = Brushes.Black;
        }

        private void emailCustomer_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string email = emailCustomer_textbox.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                emailCustomer_textbox.Foreground = Brushes.Black;
            else
                emailCustomer_textbox.Foreground = Brushes.Red;
        }

        
    }
}
