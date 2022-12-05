using CarRentalSystem.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyDatabase database { get; set; }
        public List<string> Genders { get; set; } = new() { "Male", "Female" };
        public MainWindow()
        {
            //Window2 window2 = new Window2();
            //window2.ShowDialog();
            //this.Close();
            InitializeComponent();
            database = new MyDatabase();
            gender_combobox.ItemsSource = Genders;
        }
        private void ClearSignUp()
        {
            nameSignup_textbox.Text = String.Empty;
            emailSignup_textbox.Text = String.Empty;
            countrySignup_textbox.Text = String.Empty;
            passSignup_textbox.Password = String.Empty;
            gender_combobox.SelectedItem = null;
        }

        private void ClearLogin()
        {
            nameLogin_textbox.Text = String.Empty;
            passLogin_passwordbox.Password = String.Empty;
        }

        private void signup_textblock_MouseEnter(object sender, MouseEventArgs e)
        {
            signup_textblock.Foreground = Brushes.Blue;
        }

        private void signup_textblock_MouseLeave(object sender, MouseEventArgs e)
        {
            signup_textblock.Foreground = Brushes.Black;
        }

        private void signup_textblock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            login_grid.Visibility = Visibility.Hidden;
            signup_grid.Visibility = Visibility.Visible;
            ClearLogin();
            sosLogin_textblock.Visibility = Visibility.Hidden;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(0.5);
            timer.Tick += RefreshSignUp;
            timer.Start();
        }

        
        private void login_textblock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            login_grid.Visibility = Visibility.Visible;
            signup_grid.Visibility = Visibility.Hidden;
            ClearSignUp();
            sos_textblock.Visibility = Visibility.Hidden;
        }

        private void login_textblock_MouseEnter(object sender, MouseEventArgs e)
        {
            login_textblock.Foreground = Brushes.Blue;
        }

        private void login_textblock_MouseLeave(object sender, MouseEventArgs e)
        {
            login_textblock.Foreground = Brushes.Black;
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User() { Username = nameLogin_textbox.Text, Password = passLogin_passwordbox.Password};
            if (database.FindUsersLogin(user) != null)
            {
                sosLogin_textblock.Visibility = Visibility.Hidden;
                Window2 window2 = new Window2();
                window2.Show();
                ClearLogin();
                this.Close();
                
                
            }
            else
                sosLogin_textblock.Visibility = Visibility.Visible;
        }

        private void signup_btn_Click(object sender, RoutedEventArgs e)
        {
            
            User user = new User() { Username = nameSignup_textbox.Text,
                Email = emailSignup_textbox.Text, Country = countrySignup_textbox.Text,
             Password = passSignup_textbox.Password, Gender = gender_combobox.SelectedItem.ToString()};


            if (database.FindUsersSignUp(user) == null)
            {
                database.InsertUsers(user);
                sos_textblock.Visibility = Visibility.Hidden;
                ClearSignUp();
                signup_grid.Visibility = Visibility.Hidden;
                login_grid.Visibility = Visibility.Visible;
            }
            else
                sos_textblock.Visibility = Visibility.Visible;


            
        }

        private void emailSignup_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!regex.IsMatch(emailSignup_textbox.Text) && emailSignup_textbox.Text!= String.Empty)
                emailSignup_textbox.Foreground = Brushes.IndianRed;
            else
                emailSignup_textbox.Foreground = Brushes.Black;
        }

        private void RefreshSignUp(object sender,EventArgs e)
        {
            if (nameSignup_textbox.Text != String.Empty && emailSignup_textbox.Foreground == Brushes.Black
                && countrySignup_textbox.Text != String.Empty && passSignup_textbox.Password != String.Empty
                && gender_combobox.SelectedItem != null)
                signup_btn.IsEnabled = true;
            else
                signup_btn.IsEnabled = false;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
