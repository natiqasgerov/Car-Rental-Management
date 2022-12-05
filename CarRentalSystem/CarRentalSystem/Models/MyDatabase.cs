using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class MyDatabase
    {
        public IDbConnection db;

        public MyDatabase()
        {
            db = new SQLiteConnection("Data Source = MyData.sqlite3;");
        }

        public void InsertUsers(User user)
        {
            db.Execute("INSERT INTO Users VALUES(@Username,@Email,@Country,@Password,@Gender)",
                new
                {
                    @Username = user.Username,
                    @Email = user.Email,
                    @Country = user.Country,
                    @Password = user.Password,
                    @Gender = user.Gender,
                });
        }

        public void InsertCustomers(Customer customer)
        {
            byte[] image_bytes = null;
            if (AddCustomerWindow.FileName != String.Empty)
                image_bytes = File.ReadAllBytes(AddCustomerWindow.FileName);
            

            db.Execute("INSERT INTO Customers VALUES(@Id,@Name,@Phone,@Email,@Address,@Profil,@Birth,@LisenceNo,@Issue,@Expiry,@Gender)",
                new
                {
                    @Id = customer.Id,
                    @Name = customer.Name,
                    @Phone = customer.Phone,
                    @Email = customer.Email,
                    @Address = customer.Address,
                    @Picture = customer.Picture,
                    @Birth = customer.DateBirth,
                    @LisenceNo = customer.LisenceNo,
                    @Issue = customer.IssueDate,
                    @Expiry = customer.ExpiryDate,
                    @Gender = customer.Gender,
                    @Profil = image_bytes
                });

            
        }
        public void InsertBookings(Booking booking)
        {
            db.Execute("INSERT INTO Bookings VALUES(@Id,@CId,@CarName,@CheckIn,@CheckOut,@Balance,@Type,@Method)",
                new
                {
                    @Id = booking.Id,
                    @CId = booking.CustomerId,
                    @CarName = booking.CarName,
                    @CheckIn = booking.CheckInDate,
                    @CheckOut = booking.CheckOutDate,
                    @Balance = booking.Balance,
                    @Type = booking.Type,
                    @Method = booking.Method,
                });
        }
        public User? FindUsersSignUp(User user)
        {
            var item = db.Query<User>("SELECT * FROM Users WHERE Users.Username = @Username",
                new { @Username = user.Username }).FirstOrDefault();
            return item;
        }

        public User? FindUsersLogin(User user)
        {
            var item = db.Query<User>("SELECT * FROM Users WHERE Users.Username = @Username AND Users.Password = @Password",
                new
                {
                    @Username = user.Username,
                    @Password = user.Password
                }).FirstOrDefault();
            return item;
        }

        public ObservableCollection<Customer> GetCustomers()
        {
            var list = db.Query<Customer>("SELECT * FROM Customers").ToList();
            ObservableCollection<Customer> collec = new ObservableCollection<Customer>(list);
            return collec;
        }

        public ObservableCollection<Car> GetCars()
        {
            var list = db.Query<Car>("SELECT * FROM Cars").ToList();
            ObservableCollection<Car> collec = new ObservableCollection<Car>(list);
            return collec;
        }


        public ObservableCollection<Booking> GetBookings(int id)
        {
            var list = db.Query<Booking>($"SELECT * FROM Bookings WHERE CId = {id}").ToList();
            ObservableCollection<Booking> collec = new ObservableCollection<Booking>(list);
            return collec;
        }

        public void InsertCars(Car car)
        {
            byte[] image_bytes = null;
            if (AddCarWindow.FileName != String.Empty)
                image_bytes = File.ReadAllBytes(AddCarWindow.FileName);


            db.Execute("INSERT INTO Cars VALUES(@Id,@Make,@Model,@Year,@Type,@Number,@Fuel,@Transmission,@Tank,@Engine,@Odometer,@Status,@Picture1)",
                new
                {
                    @Id = car.Id,
                    @Make = car.Make,
                    @Model = car.Model,
                    @Year = car.Year,
                    @Type = car.Type,
                    @Number = car.NumberPlate,
                    @Fuel = car.FuelType,
                    @Transmission = car.Transmission,
                    @Tank = car.TankSize,
                    @Engine = car.EngineSize,
                    @Odometer = car.Odometer,
                    @Status = car.Status,
                    @Picture1 = image_bytes,
                });
        }
    }
}
