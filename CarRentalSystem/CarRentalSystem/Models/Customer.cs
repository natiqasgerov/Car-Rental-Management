using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte[]? Picture { get; set; }
        public string? DateBirth { get; set; }
        public string? LisenceNo { get; set; }
        public string? IssueDate { get; set; }
        public string? ExpiryDate { get; set; }
        public string? Gender { get; set; }

       
    }
}
