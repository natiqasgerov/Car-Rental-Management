using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CarName { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string Balance { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        
    }
}
