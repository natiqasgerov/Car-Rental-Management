using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }

        public User()
        {

        }

        public override string ToString()
        {
            return $"{Username}\n{Email}\n{Country}\n{Password}\n{Gender}";
        }
    }
}
